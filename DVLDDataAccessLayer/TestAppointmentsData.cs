using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class TestAppointmentsData
    {
        public static DataTable GetTestAppointments(int LocalDrivingLicesenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString))
            {

                string query = @"SELECT TestAppointmentID , AppointmentDate , PaidFees ,isLocked FROM TestAppointments
                                WHERE LocalDrivingLicesenseApplicationID = @LocalDrivingLicesenseApplicationID 
                                AND TestTypeID = @TestTypeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                    catch (Exception ex)
                    {

                    }
                }
            }
            return dt;
        }

        public static int CreateTestAppointment(
            int TestTypeID,
            int LocalDrivingLicesenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool isLocked
            )
        {
            int TestAppointmentID;
            using (SqlConnection conn = new SqlConnection())
            {
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
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    cmd.Parameters.AddWithValue("@LocalDrivingLicesenseApplicationID", LocalDrivingLicesenseApplicationID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@isLocked", isLocked);
                    try
                    {
                        conn.Open();
                        object value = cmd.ExecuteScalar();
                        if (value != null)
                            TestAppointmentID = (int)value;
                        else
                            TestAppointmentID = -1;
                    }
                    catch (Exception ex)
                    {
                        TestAppointmentID = -1;
                    }
                }
            }
            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(
            int TestAppointmentID,
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
                        isUpdated = false;
                    }
                }
            }
            return isUpdated;
        }

        public static bool GetTestAppointmentByID(
            int TestAppointmentID,
            ref int TestTypeID,
            ref int LocalDrivingLicesenseApplicationID,
            ref DateTime AppointmentDate,
            ref decimal PaidFees,
            ref int CreatedByUserID,
            ref bool isLocked
            )
        {
            bool isFaund;
            using (SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments
                                WHERE TestAppointmentID = @TestAppointmentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestTypeID = (int)reader["TestTypeID"];
                                LocalDrivingLicesenseApplicationID = (int)reader["LocalDrivingLicesenseApplicationID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                isLocked = (bool)reader["isLocked"];
                                isFaund = true;
                            }
                            else
                            {
                                isFaund = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFaund = false;
                    }
                }
            }
            return isFaund;
        }

    }
}
