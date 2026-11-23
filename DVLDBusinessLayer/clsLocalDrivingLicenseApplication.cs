using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
        

        public clsLocalDrivingLicenseApplication():base() {
            this.LocalDrivingLicenseApplicationID =  - 1;
            this.LicenseClassID = -1;
            this.LicenseClass = null;
            
        }

        private clsLocalDrivingLicenseApplication
            (
                int LocalDrivingLicenseApplicationID,
                int ApplicationID,
                int ApplicationPersonID,
                int CreatedByUserID,
                int ApplicationTypeID,
                DateTime ApplicationDate,
                byte ApplicationStatus,
                DateTime LastStatusDate,
                decimal PaidFees,
                int LicenseClassID
            ) : base(
                    ApplicationID,
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
                    if (_CreateNewLocalDrivingLicenseApplication())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else { 
                        return false;
                    }
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

        public static DataTable GetAllLocalDrivingLicenseApplication(string FilterBy , string value)
        {
            return LocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplication(FilterBy ,  value);
        }

        public static bool CancelLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID) {
            return LocalDrivingLicenseApplicationsData.CancelLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static clsLocalDrivingLicenseApplication Find(int ID ) {
            
            int ApplicationID = -1;
            int ApplicationPersonID = -1;
            int CreatedByUserID = -1;
            int ApplicationTypeID = -1;
            DateTime ApplicationDate = DateTime.Now;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int LicenseClassID = -1;


            return (LocalDrivingLicenseApplicationsData
                    .GetLocalDrivingLicenseApplicationByID(
                     ID,
                        ref ApplicationID,
                        ref ApplicationPersonID,
                        ref CreatedByUserID,
                        ref ApplicationTypeID,
                        ref  ApplicationDate,
                        ref  ApplicationStatus,
                        ref  LastStatusDate,
                        ref  PaidFees,
                        ref  LicenseClassID
                )) ?
                new clsLocalDrivingLicenseApplication
                (ID,
                 ApplicationID,
                 ApplicationPersonID,
                 CreatedByUserID,
                 ApplicationTypeID,
                 ApplicationDate,
                 ApplicationStatus,
                 LastStatusDate,
                 PaidFees,
                 LicenseClassID)
                :null;
        }
    }
}
