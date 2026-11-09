using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class ApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes";
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

        public static bool UpdateApplicationType( int ApplicationTypeID , string Title , decimal Fees) {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes
                             SET Title = @Title , 
                                 Fees = @Fees
                           WHERE ApplicationTypeID = @ApplicationTypeID ";
            SqlCommand sqlCommand = new SqlCommand( query, conn);
            sqlCommand.Parameters.AddWithValue("@Title", Title);
            sqlCommand.Parameters.AddWithValue("@Fees" , Fees);
            sqlCommand.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

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
            (int ID ,ref  string Title ,ref decimal Fees) {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM ApplicationTypes
                                WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", ID);   
            bool isFound;
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Title = reader["Title"].ToString();
                    Fees = (decimal)reader["Fees"];
                    isFound = true;
                }else
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
