using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public  class LicenseClassesData
    {
        public static DataTable GetAllLicenseClasses() {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        public static bool GetLicenseClasseByID
            (int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses
                                WHERE LicenseClassID = @LicenseClassID";

            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            bool isFound;
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString() ;
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                    isFound = true;
                }
                else
                    isFound = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                conn.Close();
            }
            return isFound;
        }
        }
}
