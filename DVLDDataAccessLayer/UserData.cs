using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class UserData
    {
        public static DataTable GetAllUsers() {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT	Users.UserID ,
		                        Users.PersonID ,
		                        FullName = People.FirstName +' '+ People.SecondName +' '+ People.ThirdName +' '+ People.LastName ,
                                Users.UserName , 
		                        Users.isActive
                                From Users
                                JOIN People ON Users.PersonID = People.PersonID";
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
            finally { 
                conn.Close();
            }
            return Users;

        }
        public static DataTable GetAllUsers(string FilterBy, string value)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            FilterBy = (FilterBy == "FullName")?"People.FirstName": FilterBy;
            FilterBy = (FilterBy == "PersonID") ? "People.PersonID" : FilterBy;
            string query =
                $@"SELECT	Users.UserID ,
		                        Users.PersonID ,
		                        FullName = People.FirstName +' '+ People.SecondName +' '+ People.ThirdName +' '+ People.LastName ,
                                Users.UserName , 
		                        Users.isActive
                                From Users
                                JOIN People ON Users.PersonID = People.PersonID
                    WHERE {FilterBy} like @value";



            SqlCommand sqlCommand = new SqlCommand(query, conn);

            //sqlCommand.Parameters.AddWithValue("@FilterBy", FilterBy );
            sqlCommand.Parameters.AddWithValue("@value" , value + "%" );
            DataTable People = new DataTable();
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                    People.Load(reader);

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return People;
        }

        public static bool isUser(int PersonID) {
            SqlConnection sqlConnection = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT Found = 1  FROM Users
	                            WHERE PersonID = @PersonID;";
            SqlCommand sqlCommand = new SqlCommand(query , sqlConnection); ;

            sqlCommand.Parameters.AddWithValue  ("@PersonID", PersonID);
            bool isFound;
            try
            {
                sqlConnection.Open();
                object value = sqlCommand.ExecuteScalar();
                if (value != null)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { 
                sqlConnection.Close();
            }

            return isFound;
        }

        public static int CreateUser(
            int PersonID , string UserName , string Password , bool isActive
            ) { 
            SqlConnection conn  = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"   INSERT INTO Users 
                                (PersonID , UserName , Password , isActive)
                                VALUES
                                (@PersonID , @UserName , @Password , @isActive);
                                SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand( query , conn);

            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@UserName" , UserName);
            sqlCommand.Parameters.AddWithValue("@Password" , Password);
            sqlCommand.Parameters.AddWithValue("@isActive" , isActive);
            int UserID = -1;
            try
            {
                conn.Open();
                object value = sqlCommand.ExecuteScalar();
                if (value != null)
                {
                    UserID = Convert.ToInt32(value);
                }
                else
                {

                    UserID = -1;
                }

            }
            catch (Exception)
            {
                UserID = -1;
            }
            finally { 
                conn.Close();
            }
            return UserID;
        }

        
        public static bool UpdateUser(
            int UserID, string UserName , bool isActive
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"UPDATE Users
            SET UserName = @UserName , 
                isActive = @isActive
          WHERE UserID = @UserID ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@isActive", isActive);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            bool updated;
            try
            {
                conn.Open();
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0 )
                {
                    updated = true;
                }
                else
                {

                    updated= false;
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
        public static bool GerUserByUserNameAndPassword(
             string UserName , string Password , ref int UserID,ref int PersonID, ref bool isActive) { 
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM Users 
                             WHERE UserName = @UserName AND Password = @Password";
            SqlCommand sqlCommand = new SqlCommand(query , conn);
            sqlCommand.Parameters.AddWithValue ("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            bool isFound;
            
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["isActive"];
                    isFound = true;
                }
                else { 
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) {
                isFound=false;
            }
            finally { conn.Close(); } 
            return isFound;
        }

        public static bool GerUserByID(
            int UserID, ref int PersonID,ref  string UserName, ref bool isActive)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT * FROM Users 
                             WHERE UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            bool isFound;
            try
            {
                conn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    
                    PersonID = (int)reader["PersonID"];
                    UserName = reader["UserName"].ToString();
                    isActive = (bool)reader["isActive"];

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
        public static bool DeleteUser(int UserID) { 
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"DELETE FROM Users 
                            WHERE Users.UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(query , conn);
            sqlCommand.Parameters.AddWithValue("@UserID" , UserID);
            bool isDeleted;
            try {
                conn.Open();
                int result = sqlCommand.ExecuteNonQuery();
                isDeleted = result != 0;

            } catch (Exception) { 
                isDeleted = false;
            }finally { conn.Close(); }
            return isDeleted;
        }

        public static bool ChangePassword(int UserID , string Password , string NewPassword) { 
            SqlConnection sqlConnection = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"UPDATE Users
                             SET Password = @NewPassword 
                            WHERE UserID = @UserID AND Password = @Password";
            SqlCommand sqlCommand = new SqlCommand( query , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID" , UserID );
            sqlCommand.Parameters.AddWithValue("@Password" , Password);
            sqlCommand.Parameters.AddWithValue("@NewPassword", NewPassword);
            bool PasswordHasChanged;
            try {
                sqlConnection.Open();
                int EffectedRows = sqlCommand.ExecuteNonQuery();
                PasswordHasChanged = EffectedRows == 1;
            }catch (Exception)
            { PasswordHasChanged = false; } 
            finally { sqlConnection.Close(); }
            return PasswordHasChanged;
        }
    }
}
