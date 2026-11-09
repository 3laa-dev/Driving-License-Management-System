using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { set; get; }

        private clsCountry( int CountryID , string CountryName) { 
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            
        }
        public static DataTable GetAllCountries() { 
            return CountryData.GetAllCountries();
        }

        public static clsCountry GetCountryID(int ID )
        {
            string CountryName = "Not Found";
            if (CountryData.GetCountryID(ID, ref CountryName))
                return new clsCountry(ID , CountryName);
            return null;
        }

        public static clsCountry GetCountryName(string CountryName)
        {
            int ID = -1;
            if (CountryData.GetCountryName(CountryName, ref ID))
                return new clsCountry(ID, CountryName);
            return null;
        }
    }
}
