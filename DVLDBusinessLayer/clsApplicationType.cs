using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public  class clsApplicationType
    {
       
        public  int ApplicationTypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        
        private clsApplicationType( int applicationTypeID, string title, decimal fees)
        {
            ApplicationTypeID = applicationTypeID;
            Title = title;
            Fees = fees;
        }

        public static DataTable GetAllApplicationTypes() { 
            return ApplicationTypesData.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ID) {
            string Title = "";
            decimal Fees = 0;
            return (ApplicationTypesData.GetApplicationTypeByID(ID, ref Title, ref Fees)) ?
               new clsApplicationType(ID , Title , Fees):
               null ;
        }
        bool _UpdateApplicationType() { 
            return ApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID , this.Title , this.Fees   );
        }
        public bool Save() {
           return _UpdateApplicationType();
        }
    }
}
