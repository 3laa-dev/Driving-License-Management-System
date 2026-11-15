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
        
        public clsApplication(int CreatedByUserID) {
            this.ApplicationPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationStatus = 0;
            this.PaidFees = 0;
            this.LastStatusDate = DateTime.Now;
            this.Mode = enMode.AddNew;
            this.CreatedByUserID = CreatedByUserID;
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
        }


        public  static  bool CancelApplication(int applicationID) { 
            return ApplicationsData.CancelApplication(applicationID);
        }
        

    }
}
