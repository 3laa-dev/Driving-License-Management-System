using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;
namespace DVLDBusinessLayer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }

        public decimal TestFees {  get; set; }

        private clsTestType(int TestTypeID , string TestTypeTitle , string TestTypeDescription  , decimal TestFees) { 
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestFees = TestFees;
        }

        public static DataTable GetAllTestTypes() { 
            return TestTypesData.GetAllTestTypes();
        }

        public static clsTestType Find(int ID)
        {
            string TestTypeTitle = "";
            string TestDescription = "";
            decimal TestFees = 0;
            return TestTypesData.GetApplicationTypeByID(ID ,ref TestTypeTitle ,ref TestDescription ,ref TestFees) ?
               new clsTestType(ID, TestTypeTitle , TestDescription , TestFees) :
               null;
        }
        bool _UpdateTestType()
        {
            return TestTypesData.UpdateTests(this.TestTypeID, TestTypeTitle, TestTypeDescription, TestFees);
        }
        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}
