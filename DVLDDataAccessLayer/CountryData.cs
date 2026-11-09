using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class CountryData
    {
        
        private CountryData(int CountryID  , string CountryName) { }
        public static DataTable GetAllCountries() {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = "SELECT * FROM Countries";

            SqlCommand sqlCommand = new SqlCommand(query, conn);

            DataTable Countries = new DataTable();
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                    Countries.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            { }
            finally { 
                conn.Close();
            }
            return Countries;
        }

        public static bool GetCountryID(int ID ,ref string CountryName ) {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT CountryName FROM Countries
                             WHERE CountryID = @CountryID";
            SqlCommand sqlCommand = new SqlCommand( query, conn);
            sqlCommand.Parameters.AddWithValue("@CountryID", ID);
            bool isFound;
            try {
                conn.Open();
                object result = sqlCommand.ExecuteScalar();
                if (result != null) {
                    CountryName = result.ToString();
                    isFound = true;
                }else isFound = false;

            }catch (Exception ex) { isFound = false; }
            finally { conn.Close(); }
            return isFound;
        }

        public static bool GetCountryName(string CountryName, ref int ID)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT CountryID FROM Countries
                             WHERE CountryName = @CountryName";
            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@CountryName", CountryName);
            bool isFound;
            try
            {
                conn.Open();
                object result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    ID = Convert.ToInt32(result.ToString());
                    isFound = true;
                }
                else isFound = false;

            }
            catch (Exception ex) { isFound = false; }
            finally { conn.Close(); }
            return isFound;
        }

    }
}
