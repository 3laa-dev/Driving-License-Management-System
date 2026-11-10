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
                object Value = sqlCommand.ExecuteNonQuery();
                id = (int)Value;
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

        public static bool IsPersonRegisteredForLocalDrivingLicenseApplication(int PersonID) { 
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Applications
                            INNER JOIN LocalDrivingLicenseApplications
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE Applications.ApplicationStatus != 2 AND  Applications.ApplicationPersonID = @PersonID";

            SqlCommand command = new SqlCommand( query, conn );

            command.Parameters.AddWithValue("@PersonID", PersonID);

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
    }
}
