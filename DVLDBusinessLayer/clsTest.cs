using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsTest
    {
        enMode Mode;
        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get;  }

        public clsTest() {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.Mode = enMode.AddNew;
        }

        bool _CreateTest() {
            this.TestID = TestsData.CreateTest(TestAppointmentID, CreatedByUserID, TestResult, Notes);
            return this.TestID != -1;
        }

        public static int CountOfPassedTests(Person person) {
            return TestsData.CountTest(person.PersonID , true);
        }
        public static int CountOfPassedTests(int  personID )
        {
            return TestsData.CountTest(personID , true);
        }

        public static int CountFailedTests(int personID)
        {
            return TestsData.CountTest(personID, false);
        }

        public static int CountFailedTests(Person person)
        {
            return TestsData.CountTest(person.PersonID, false);
        }
        
        public bool Save() {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_CreateTest())
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
    }
}
