using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class PeopleData
    {
        public static DataTable GetPeople()
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT People.PersonID ,
		            People.NationalNo ,
		            People.FirstName , 
		            People.SecondName , 
		            People.ThirdName,
		            People.LastName , 
		            CASE
		              WHEN People.Gender = 'm' THEN 'Male'
		              WHEN People.Gender = 'f' THEN 'Female'
		              ELSE '?'
		            END AS Gender ,
		            People.DateOfBirth , 
		            People.Address , 
		            People.Phone , 
		            People.Email ,
		            Countries.CountryName AS Nationality
		            FROM People
		            INNER JOIN Countries
		            ON People.NationalityCountryID = Countries.CountryID";

            SqlCommand sqlCommand = new SqlCommand(query, conn);

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

        public static DataTable GetPeople(string FilterBy , string value) {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            FilterBy = (FilterBy == "Nationality")? "Countries.CountryName":FilterBy;
            value = (FilterBy == "Gender") ? (value == "")?"": value[0].ToString() : value;
            string query = 
                $@"SELECT People.PersonID ,
		            People.NationalNo ,
		            People.FirstName , 
		            People.SecondName , 
		            People.ThirdName,
		            People.LastName , 
		            CASE
		              WHEN People.Gender = 'm' THEN 'Male'
		              WHEN People.Gender = 'f' THEN 'Female'
		              ELSE '?'
		            END AS Gender ,
		            People.DateOfBirth , 
		            People.Address , 
		            People.Phone , 
		            People.Email ,
		            Countries.CountryName AS Nationality
		            FROM People
		            INNER JOIN Countries
		            ON People.NationalityCountryID = Countries.CountryID
                    WHERE {FilterBy} like '{value}%'";

            SqlCommand sqlCommand = new SqlCommand(query, conn);
            
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

       
        public static int AddPerson(

                string NationalNO,
                string FirstName,
                string SecondName,
                string ThirdName,
                string LastName,
                string Gender , 
                DateTime DateOfBirth,
                string Address,
                string Phone,
                string Email,
                int NationalityCountryID,
                string ImagePath)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"INSERT INTO People
                            (NationalNO,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Address,Phone,Email,NationalityCountryID ,ImagePath , Gender)
                             VALUES
                            (@NationalNO,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath , @Gender);
                            SELECT SCOPE_IDENTITY();";


            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@NationalNO", NationalNO);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (String.IsNullOrEmpty(ImagePath))
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            sqlCommand.Parameters.AddWithValue("@Gender", (Gender == "Male") ? "m" : (Gender == "Female") ? "f" : "?");

            int PersonID = -1;
            try
            {
                conn.Open();
                object value = sqlCommand.ExecuteScalar();
                if (value != null)
                {
                    PersonID = Convert.ToInt32(value.ToString());
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
            finally { conn.Close(); }

            return PersonID;
        }
        public static bool GetPersonByID(
            int PersonID,
            ref string NationalNO,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref string Gender , 
            ref DateTime DateOfBirth,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT * FROM People
                             WHERE PersonID = @PersonID";


            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@personID", PersonID);

            bool isFound;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    NationalNO = reader["NationalNO"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gender = (reader["Gender"].ToString() == "m")?"Male" : "Female";
                    DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"].ToString();
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

        public static bool GetPersonByNationalNO(
            
            string NationalNO,
            ref int PersonID,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref string Gender,
            ref DateTime DateOfBirth,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath
            )
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"SELECT * FROM People
                             WHERE NationalNo = @NationalNo";


            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNO);

            bool isFound;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    //NationalNO = reader["NationalNO"].ToString();
                    PersonID = (int)reader["PersonID"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gender = (reader["Gender"].ToString() == "m") ? "Male" : "Female";
                    DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"].ToString();
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
        public static bool isFoundNationalNO(string NationalNO)
        {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM People
                            WHERE NationalNo = @NationalNo";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNO);
            bool isFound = false;
            try
            {
                conn.Open();

                object value = cmd.ExecuteScalar();
                if (value != null)
                {
                    if (1 == Convert.ToInt32(value.ToString()))
                    {
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                    }
                }
                else isFound = false;

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { conn.Close(); }

            return isFound;
        }

        public static bool UpdatePerson(
            int PersonID,
            string NationalNO,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            string Gender , 
            DateTime DateOfBirth,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath
            ) {
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"UPDATE People
                               SET NationalNo = @NationalNo
                                  ,FirstName = @FirstName
                                  ,SecondName = @SecondName
                                  ,ThirdName = @ThirdName
                                  ,LastName = @LastName
                                  ,Gender = @Gender
                                  ,DateOfBirth = @DateOfBirth
                                  ,Address = @Address
                                  ,Phone = @Phone
                                  ,Email = @Email
                                  ,NationalityCountryID = @NationalityCountryID
                                  ,ImagePath = @ImagePath
                             WHERE PersonID = @PersonID ";
            SqlCommand sqlCommand = new SqlCommand(query , conn);

            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNO);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (String.IsNullOrEmpty(ImagePath))
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            sqlCommand.Parameters.AddWithValue("@Gender", (Gender == "Male") ? "m" : (Gender == "Female") ? "f" : "?");

            bool isUpdated;
            try
            {
                conn.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
            }
            finally { 
                conn.Close();
            }
            return isUpdated;
        }


        public static bool DeletePerson(int PersonID){
            bool isDeleted ;
            SqlConnection conn = new SqlConnection(DatabaseSettings.ConnectionString);
            string query = @"DELETE FROM People
                             WHERE PersonID = @PersonID;";

            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("@PersonID" , PersonID);

            try
            {
                conn.Open();
                int rowEffected = sqlCommand.ExecuteNonQuery();
                if (rowEffected > 0)
                {
                    isDeleted = true;
                }
                else { 
                    isDeleted= false;
                }

            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
            finally { 
                conn.Close() ;
            }



            return isDeleted;
        }

    }
      
}
