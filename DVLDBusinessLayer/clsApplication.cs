using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        internal enMode Mode;
        public int ApplicationID ;
        public int ApplicationPersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public int ApplicationTypeID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public byte ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        public Person Person { set; get; }
        public clsUser User { set; get; }
        public clsApplicationType Type { set; get; }
        
        public clsApplication() {
            this.ApplicationPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationStatus = 0;
            this.PaidFees = 0;
            this.LastStatusDate = DateTime.Now;
            this.Mode = enMode.AddNew;
            this.CreatedByUserID = -1;
            this.ApplicationID = -1;
            this.Person = null;
            this.User = null;
        }
        
        protected clsApplication( int applicationID, int applicationPersonID, int createdByUserID, int applicationTypeID, DateTime applicationDate, byte applicationStatus, DateTime lastStatusDate, decimal paidFees)
        {
            ApplicationPersonID = applicationPersonID;
            CreatedByUserID = createdByUserID;
            ApplicationTypeID = applicationTypeID;
            ApplicationDate = applicationDate;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            Mode = enMode.Update;
            PaidFees = paidFees;
            this.ApplicationID = applicationID;

            this.Person = Person.Find(ApplicationPersonID);
            this.User = clsUser.Find(this.CreatedByUserID);
            this.Type = clsApplicationType.Find(this.ApplicationTypeID);
        }


        public  static  bool CancelApplication(int applicationID) { 
            return ApplicationsData.CancelApplication(applicationID);
        }

        private bool _UpdateApplication() {
            return ApplicationsData.UpdateApplication(
            this.ApplicationID,
            this.ApplicationPersonID,
            this.CreatedByUserID,
            this.ApplicationTypeID,
            this.ApplicationDate,
            this.ApplicationStatus,
            this.LastStatusDate,
            this.PaidFees);
        }

        private bool _CreateApplication() {
            this.ApplicationID =
                 ApplicationsData.CreateApplication(
                       this.ApplicationPersonID,
                       this.CreatedByUserID,
                       this.ApplicationTypeID,
                       this.ApplicationDate,
                       this.ApplicationStatus,
                       this.LastStatusDate,
                       this.PaidFees);
            return this.ApplicationID != -1;
        }

        public virtual bool Save()
        {
            if (this.ApplicationStatus == 2)
                return false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_CreateApplication()) { 
                        this.Mode = enMode.Update; 
                        return true ;
                    }
                    return false;
                case enMode.Update:
                    return false;
                default:
                    return false;
            }

        }
    }
}
