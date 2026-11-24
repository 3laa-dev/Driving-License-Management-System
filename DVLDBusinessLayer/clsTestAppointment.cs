using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsTestAppointment
    {
        enMode Mode;
        public int TestAppointmentID { set; get; }
        public int TestTypeID { set; get; }
        public int LocalDrivingLicesenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLocked { set; get; }
        
        public clsTestType TestType { set; get; }

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { set; get; }

        public clsTestAppointment() { 
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicesenseApplicationID = -1;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.isLocked = false;
            this.TestType = null;
            this.LocalDrivingLicenseApplication = null;
            this.Mode = enMode.AddNew;
        }

        clsTestAppointment( int testAppointmentID, int testTypeID, int localDrivingLicesenseApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            Mode = enMode.Update;
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicesenseApplicationID = localDrivingLicesenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            this.LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(localDrivingLicesenseApplicationID);

            this.isLocked = isLocked;
        }

        public static clsTestAppointment Find(int TestAppointmentID) {
            
            int TestTypeID = -1;
            int LocalDrivingLicesenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool isLocked = false;
            
            return (TestAppointmentsData.GetTestAppointmentByID
                (TestAppointmentID,
                    ref TestTypeID,
                    ref LocalDrivingLicesenseApplicationID,
                    ref AppointmentDate,
                    ref PaidFees,
                    ref CreatedByUserID,
                    ref isLocked))?
                    new clsTestAppointment(
                        TestAppointmentID,
                         TestTypeID,
                         LocalDrivingLicesenseApplicationID,
                         AppointmentDate,
                         PaidFees,
                         CreatedByUserID,
                         isLocked
                        ) : null;
        }

        bool _UpdateTestAppointment() {
            return (TestAppointmentsData.UpdateTestAppointment(
                         this.TestAppointmentID,
                         this.TestTypeID,
                         this.LocalDrivingLicesenseApplicationID,
                         this.AppointmentDate,
                         this.PaidFees,
                         this.CreatedByUserID,
                         this.isLocked
                         ));
        }

        bool _CreateTestAppointmet() {
            this.TestAppointmentID =  TestAppointmentsData.CreateTestAppointment(
                this.TestTypeID,
                this.LocalDrivingLicesenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.isLocked
                );
            return this.TestAppointmentID != -1;
        }

        public bool Save()
        {
            if(this.isLocked) 
                return false;
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._CreateTestAppointmet())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else {
                        return _UpdateTestAppointment();
                    }

                case enMode.Update:
                    return  this._UpdateTestAppointment();
                default:
                    return false;
            }

        }


        public static DataTable GetTestAppointments(int LocalDrivingLicesenseApplicationID , int TestTypeID) {
            return TestAppointmentsData.GetTestAppointments(LocalDrivingLicesenseApplicationID , TestTypeID );
        }

        public static bool hasActiveAppointment(int LocalDrivingLicesenseApplicationID) { 
            return TestAppointmentsData.hasActiveAppointment(LocalDrivingLicesenseApplicationID); ;
        }

    }
}
