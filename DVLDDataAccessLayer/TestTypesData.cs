using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public  class TestTypesData
    {
        public static DataTable GetAllTestTypes()
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes";
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

        public static bool UpdateTests(int TestTypeID, string TestTypeTitle, string TestDescription ,decimal Fees)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @TestTypeTitle , 
                                 TestDescription = @TestDescription , 
                                 TestFees = @TestFees
                           WHERE TestTypeID = @TestTypeID ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            sqlCommand.Parameters.AddWithValue("@TestFees", Fees);
            sqlCommand.Parameters.AddWithValue("@TestDescription", TestDescription);
            sqlCommand.Parameters.AddWithValue("TestTypeID", TestTypeID);

            bool updated;

            try
            {
                conn.Open();

                int EffectedRows = sqlCommand.ExecuteNonQuery();
                updated = EffectedRows == 1;


            }
            catch (Exception ex)
            {
                updated = false;
            }
            finally
            {
                conn.Close();
            }
            return updated;

        }

        public static bool GetApplicationTypeByID
            (int ID, ref string TestTypeTitle,ref string TestDescription,  ref decimal TestFees)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM TestTypes
                                WHERE TestTypeID = @ID";

            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@TestTypeID", ID);
            bool isFound;
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestDescription = reader["Description"].ToString();
                    TestFees = (decimal)reader["TestFees"];
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
