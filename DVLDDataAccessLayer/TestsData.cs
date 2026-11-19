using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
