using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class LocalDrivingLicenseApplicationsData
    {
        public static int CreateLocalDrivingLicenseApplication
            (
             int ApplicationPersonID,
             int CreatedByUserID,
             int ApplicationTypeID,
             DateTime ApplicationDate,
             byte ApplicationStatus,
             DateTime LastStatusDate,
             decimal PaidFees , 
             int LicenseClassID
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query  = @"INSERT INTO Applications 
                            (ApplicationPersonID ,CreatedByUserID ,ApplicationTypeID  ,ApplicationDate ,ApplicationStatus ,LastStatusDate ,PaidFees)
                            VALUES
                            (@ApplicationPersonID ,@CreatedByUserID ,1  , @ApplicationDate , 0 ,@LastStatusDate ,@PaidFees);
                            INSERT INTO LocalDrivingLicenseApplications
                            ( ApplicationID , LicenseClassID)
                            VALUES
                            (SCOPE_IDENTITY() , @LicenseClassID );
                            SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand( query, conn );

            sqlCommand.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            sqlCommand.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            sqlCommand.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
            sqlCommand.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int id;
            try
            {
                conn.Open();
                object Value = sqlCommand.ExecuteScalar();
                id = Convert.ToInt32(Value);
            }
            catch (Exception ex)
            {
                id = -1;
            }
            finally { 
                conn.Close();
            }
            return id;
        }

        public static bool IsPersonRegisteredForLocalDrivingLicenseApplication(int PersonID , int LicenseClassID) { 
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Applications
                            INNER JOIN LocalDrivingLicenseApplications
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE Applications.ApplicationStatus != 2 
                            AND  Applications.ApplicationPersonID = @PersonID
                            AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand( query, conn );

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool isFound;
            try
            {
                conn.Open();

                object Value = command.ExecuteScalar();

                isFound = Value != null;

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { 
                conn.Close ();
            }
            return isFound;
        }


        public static DataTable GetAllLocalDrivingLicenseApplication() { 
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM viewLocalDrivingLicenseApplications";

            SqlCommand command =  new SqlCommand(query , conn);

            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dataTable;
        }


        public static DataTable GetAllLocalDrivingLicenseApplication(string FilterBy, string value)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = $@"SELECT * FROM viewLocalDrivingLicenseApplications
                              WHERE {FilterBy}  like @value";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@value", value+"%");

            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
            return dataTable;
        }

    }
}
