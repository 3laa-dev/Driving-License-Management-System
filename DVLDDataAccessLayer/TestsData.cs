using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class TestsData
    {
        public static int CreateTest(int TestAppointmentID , int CreatedByUserID , bool TestResult  , string Notes) {

            int ID;
            using (SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString))
            {
                string query = @"INSERT INTO Tests
                                       (TestAppointmentID,TestResult,Notes,CreatedByUserID)
                                 VALUES
                                       (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);
                                 UPDATE TestAppointments
                                   SET isLocked = 1
                                 WHERE TestAppointmentID = @TestAppointmentID
                                    SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query , conn)) {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    cmd.Parameters.AddWithValue("@TestResult", TestResult);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    if (String.IsNullOrEmpty(Notes))
                    {
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@Notes", Notes);
                    }
                    try
                    {
                        conn.Open();
                        object value = cmd.ExecuteScalar();
                        ID = (value != null) ? Convert.ToInt32(value) : -1;
                    }
                    catch (Exception ex) { 
                        ID = -1;
                    }  
                }
            }
            return ID;
        }

        public static int CountTest(int PersonID , bool? isPassed)
        {
            int result;

            using (SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString))
            {
                string query = $@"SELECT COUNT(*) AS CountOfPassedTests FROM Tests
                                    INNER JOIN TestAppointments 
                                    ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                    INNER JOIN LocalDrivingLicenseApplications
                                    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicesenseApplicationID
                                    INNER JOIN Applications
                                    ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                                    WHERE Applications.ApplicationPersonID = @PersonID AND Tests.TestResult = @isPassed";

                using (SqlCommand cmd = new SqlCommand(query, conn)) { 
                    cmd.Parameters.AddWithValue("@PersonID" , PersonID);
                    cmd.Parameters.AddWithValue("@isPassed", isPassed);
                    try
                    {
                        conn.Open();

                        result = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    catch (Exception ex) { result = 0; };

                }


            }
            return result;
        }

        

    }
}
