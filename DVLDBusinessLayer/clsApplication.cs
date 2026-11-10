using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        internal enMode Mode;
        public int ApplicationPersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public int ApplicationTypeID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public byte ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees { set; get; }

        public clsApplication(int CreatedByUserID) {
            this.ApplicationPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationStatus = 0;
            this.PaidFees = 0;
            this.LastStatusDate = DateTime.Now;
            this.Mode = enMode.AddNew;
            this.CreatedByUserID = CreatedByUserID;
        }
        protected clsApplication( int applicationPersonID, int createdByUserID, int applicationTypeID, DateTime applicationDate, byte applicationStatus, DateTime lastStatusDate, decimal paidFees)
        {
            ApplicationPersonID = applicationPersonID;
            CreatedByUserID = createdByUserID;
            ApplicationTypeID = applicationTypeID;
            ApplicationDate = applicationDate;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            Mode = enMode.Update;
            PaidFees = paidFees;
        }
    }
}
