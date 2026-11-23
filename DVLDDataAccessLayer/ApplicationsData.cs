using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLDDataAccessLayer
{
    public class ApplicationsData
    {
        public static DataTable GetAllApplications()
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT	* From Users; ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            DataTable Users = new DataTable();
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    Users.Load(reader);
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
            return Users;

        }
        
       
        public static int CreateApplication(
             int ApplicationPersonID,
             int CreatedByUserID ,
             int ApplicationTypeID  ,
             DateTime ApplicationDate ,
             byte ApplicationStatus ,
             DateTime LastStatusDate ,
             decimal PaidFees
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"   INSERT INTO Applications 
                                (ApplicationPersonID ,CreatedByUserID ,ApplicationTypeID  ,ApplicationDate ,ApplicationStatus ,LastStatusDate ,PaidFees)
                                VALUES
                                (@ApplicationPersonID ,@CreatedByUserID ,@ApplicationTypeID  ,@ApplicationDate ,@ApplicationStatus ,@LastStatusDate ,@PaidFees);
                                SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            sqlCommand.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            sqlCommand.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            int ApplicationID = -1;
            try
            {
                conn.Open();
                object value = sqlCommand.ExecuteScalar();
                if (value != null)
                {
                    ApplicationID = Convert.ToInt32(value);
                }
                else
                {

                    ApplicationID = -1;
                }

            }
            catch (Exception ex)
            {
                ApplicationID = -1;
            }
            finally
            {
                conn.Close();
            }
            return ApplicationID;
        }


        public static bool UpdateApplication(
            int ApplicationID , 
            int ApplicationPersonID,
            int CreatedByUserID,
            int ApplicationTypeID,
            DateTime ApplicationDate,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"UPDATE Applications
                            SET ApplicationPersonID = @ApplicationPersonID , 
                                CreatedByUserID  = @CreatedByUserID , 
                                ApplicationTypeID  =@ApplicationTypeID, 
                                ApplicationDate = @ApplicationDate,
                                ApplicationStatus = @ApplicationStatus,
                                LastStatusDate = @LastStatusDate, 
                                PaidFees = @PaidFees
                             WHERE ApplicationID = @ApplicationID ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            sqlCommand.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID ",CreatedByUserID );
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID ",ApplicationTypeID );
            sqlCommand.Parameters.AddWithValue("@ApplicationDate",ApplicationDate);
            sqlCommand.Parameters.AddWithValue("@ApplicationStatus",ApplicationStatus);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate",LastStatusDate);
            sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);

            bool updated;
            try
            {
                conn.Open();
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    updated = true;
                }
                else
                {

                    updated = false;
                }

            }
            catch (Exception)
            {
                updated = false;
            }
            finally
            {
                conn.Close();
            }
            return updated;
        }
        
        public static bool GetApplicationByID(
            int ApplicationID , 
            ref int ApplicationPersonID,
            ref int CreatedByUserID,
            ref int ApplicationTypeID,
            ref DateTime ApplicationDate,
            ref byte ApplicationStatus,
            ref DateTime LastStatusDate,
            ref decimal PaidFees)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            
            string query = @"SELECT * FROM Applications 
                             WHERE ApplicationID = @ApplicationID";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool isFound;
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationPersonID = (int)reader["ApplicationPersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ApplicationTypeID = (int)reader["ApplicationID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"]; 
                    PaidFees = (decimal)reader["PaidFees"];
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { conn.Close(); }
            return isFound;
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"DELETE FROM Applications 
                            WHERE ApplicationID  = @ApplicationID";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool isDeleted;
            try
            {
                conn.Open();
                int result = sqlCommand.ExecuteNonQuery();
                isDeleted = result != 0;

            }
            catch (Exception)
            {
                isDeleted = false;
            }
            finally { conn.Close(); }
            return isDeleted;
        }

        public static bool CancelApplication( int ApplicationID )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"UPDATE Applications
                            SET ApplicationStatus = 2
                             WHERE ApplicationID = @ApplicationID ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            

            bool canceled;
            try
            {
                conn.Open();
                int result = sqlCommand.ExecuteNonQuery();
                canceled = result > 0;

            }
            catch (Exception)
            {
                canceled = false;
            }
            finally
            {
                conn.Close();
            }
            return canceled;
        }


    }
}
