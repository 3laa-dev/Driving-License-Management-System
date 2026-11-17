using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    internal class TestAppointmentData
    {
        public DataTable GetTestAppointments(int LocalDrivingLicesenseApplicationID, byte TestTypeID) { 
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection()) { 
                
                string query = @"SELECT * FROM TestAppointments
                                WHERE LocalDrivingLicesenseApplicationID = @LocalDrivingLicesenseApplicationID 
                                AND TestTypeID = @TestTypeID";
                using (SqlCommand cmd = new SqlCommand(query , conn)) {
                    try
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@LocalDrivingLicesenseApplicationID", LocalDrivingLicesenseApplicationID);
                        cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex) { 
                    
                    }
                }
            }
            return dt;
        }

        public int CreateTestAppointment(
            int TestTypeID , 
            int LocalDrivingLicesenseApplicationID , 
            DateTime AppointmentDate ,  
            decimal PaidFees , 
            int CreatedByUserID , 
            bool isLocked
            ) {
            int TestAppointmentID;
            using (SqlConnection conn = new SqlConnection()) {
                string query = @"INSERT INTO TestAppointments
                                      (TestTypeID ,
                                       LocalDrivingLicesenseApplicationID ,
                                       AppointmentDate ,
                                       PaidFees ,
                                       CreatedByUserID ,
                                       isLocked)
                                 VALUES
                                       (
	                            	   @TestTypeID ,
                                       @LocalDrivingLicesenseApplicationID ,
                                       @AppointmentDate ,
                                       @PaidFees ,
                                       @CreatedByUserID ,
                                       @isLocked
	                            	   );
                                       SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@TestTypeID" , TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicesenseApplicationID" , LocalDrivingLicesenseApplicationID);
                    cmd.Parameters.AddWithValue("@AppointmentDate" , AppointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees" , PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID" , CreatedByUserID);
                    cmd.Parameters.AddWithValue("@isLocked" , isLocked);
                    try
                    {
                        conn.Open();
                        object value = cmd.ExecuteScalar();
                        if (value != null)
                            TestAppointmentID = (int)value;
                        else
                            TestAppointmentID = -1;
                    }
                    catch (Exception ex) { 
                        TestAppointmentID = -1;
                    }
                }
            }
            return TestAppointmentID;
        }

        public bool UpdateTestAppointment(
            int TestAppointmentID  , 
            int TestTypeID,
            int LocalDrivingLicesenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool isLocked)
        {
            bool isUpdated;
            
            using (SqlConnection conn = new SqlConnection())
            {
                string query = @"UPDATE TestAppointments 
                                	SET TestTypeID = @TestTypeID , 
                                		LocalDrivingLicesenseApplicationID = @LocalDrivingLicesenseApplicationID , 
                                		AppointmentDate = @AppointmentDate , 
                                		PaidFees =  @PaidFees ,
                                		CreatedByUserID = @CreatedByUserID, 
                                		isLocked =  @isLoc1ked
                                WHERE TestAppointmentID = @TestAppointmentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicesenseApplicationID", LocalDrivingLicesenseApplicationID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@isLocked", isLocked);
                    cmd.Parameters.AddWithValue("@TestAppointmentID ", TestAppointmentID);
                    try
                    {
                        conn.Open();
                        int effected = cmd.ExecuteNonQuery();
                        isUpdated = effected == 1;

                    }
                    catch (Exception ex)
                    {
                        isUpdated =false;
                    }
                }
            }
            return isUpdated;
        }

        

    }
}
