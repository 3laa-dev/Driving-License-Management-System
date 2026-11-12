using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplication:clsApplication
    {
        
        public int LocalDrivingLicenseApplicationID;
        public int LicenseClassID;

        public clsLicenseClass LicenseClass;
        

        public clsLocalDrivingLicenseApplication(int CreatedByUserID):base(CreatedByUserID) {
            this.LocalDrivingLicenseApplicationID =  - 1;
            this.LicenseClassID = -1;
            this.LicenseClass = null;
            
        }

        private clsLocalDrivingLicenseApplication
            (
                int LocalDrivingLicenseApplicationID,
                int ApplicationPersonID,
                int CreatedByUserID,
                int ApplicationTypeID,
                DateTime ApplicationDate,
                byte ApplicationStatus,
                DateTime LastStatusDate,
                decimal PaidFees,
                int LicenseClassID
            ) : base(
                    ApplicationPersonID,
                    CreatedByUserID,
                    ApplicationTypeID,
                    ApplicationDate,
                    ApplicationStatus,
                    LastStatusDate,
                    PaidFees  
                )
        { 
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
        }



        bool _CreateNewLocalDrivingLicenseApplication() {
            this.LocalDrivingLicenseApplicationID =
               LocalDrivingLicenseApplicationsData.
               CreateLocalDrivingLicenseApplication(
                   this.ApplicationPersonID ,
                   this.CreatedByUserID,
                   this.ApplicationTypeID ,
                   this.ApplicationDate ,
                   this.ApplicationStatus ,
                   this.LastStatusDate ,
                   this.PaidFees ,
                   this.LicenseClassID
                   );

            return (this.LocalDrivingLicenseApplicationID != -1);
            
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _CreateNewLocalDrivingLicenseApplication();
                case enMode.Update:
                    return false;
                default:
                    return false;
            }

        }

        public static bool IsPersonRegisteredForLocalDrivingLicenseApplication(int PersonID , int LicenseClassID) {
            return LocalDrivingLicenseApplicationsData.IsPersonRegisteredForLocalDrivingLicenseApplication(PersonID, LicenseClassID);
        }
        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return LocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplication();
        }


    }
}
