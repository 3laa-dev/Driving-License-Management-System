using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLDBusinessLayer;

namespace DVLDConsoleForTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataTable dataTable = Person.GetPeoples();
            //foreach (DataRow row in dataTable.Rows) {
            //    Console.WriteLine($"{row["PersonID"]}-{row["FirstName"]}");
            //}



            //Person person = new Person();

            //person.NationalNO = "4321414";
            //person.FirstName = "anas";
            //person.SecondName = "keles";
            //person.ThirdName = "said";
            //person.LastName = "nur";
            //person.DateOfBirth = DateTime.Parse("01-12-2003");
            //person.Address = "Marash";
            //person.Phone = "3434342342";
            //person.Email = "eneskeles@gmail.com";
            //person.NationalityCountryID = 150;
            //person.ImagePath = "";


            //if (person.Save())
            //{

            //    Console.WriteLine($"{person.PersonID} : Saved");
            //}
            //else {
            //    Console.WriteLine("Error");
            //}



            //Person person = Person.Find(13);
            //if (person != null)
            //{
            //    Console.WriteLine(person.FirstName);
            //    Console.WriteLine(person.LastName);
            //}
            //else {
            //    Console.WriteLine("This Person is not found");
            //}

            //string NationalNO = "724643543c";
            //if (Person.isFoundNationalNO(NationalNO))
            //{
            //    Console.WriteLine("is found");
            //}
            //else {
            //    Console.WriteLine("IS not found");
            //}


            //while (true)
            //{
            //    Console.WriteLine("Write Value");
            //    string value = Console.ReadLine();
            //    DataTable dt = Person.GetPeople("CountryName", value);
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        Console.WriteLine($"{row["PersonID"]}-{row["FirstName"]}-{row["LastName"]}-{row["NationalityCountryID"]}");
            //    }
            //}


            //Person person = Person.Find(13);
            //Console.WriteLine(person.FirstName);
            //Console.WriteLine(person.LastName);
            //Console.WriteLine(person.NationalityCountryID);
            //Console.WriteLine(person.NationalNO);

            //
            //Console.WriteLine("Write Value");
            //string value = Console.ReadLine();


            //person.NationalNO = value;
            //if (person.Save())
            //{
            //    Console.WriteLine(person.FirstName);
            //    Console.WriteLine(person.LastName);
            //    Console.WriteLine(person.NationalityCountryID);
            //    Console.WriteLine(person.NationalNO);
            //}
            //else {
            //    Console.WriteLine("Error");
            //}

            //DataTable dt = clsCountry.GetAllCountries();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine($"{dr["CountryID"]}-{dr["CountryName"]}");
            //}
            //Console.WriteLine(1);

            //DataTable dataTable = clsLicenseClass.GetAllLicenseClasses();
            //foreach (DataRow dr in dataTable.Rows)
            //{

            //    Console.WriteLine($"{dr["LicenseClassID"]} <> {dr["ClassName"]} <> {dr["ClassDescription"]}");
            //    Console.WriteLine("---------");
            //}
            //clsLicenseClass test = clsLicenseClass.Find(5);

            //Console.WriteLine(test.ClassDescription);

            //clsLocalDrivingLicenseApplication ob = new clsLocalDrivingLicenseApplication(2);

            //ob.ApplicationPersonID = 26;
            //ob.ApplicationTypeID = 1;
            //ob.ApplicationDate = DateTime.Parse("2-2-2027");
            //ob.ApplicationStatus = 0;
            //ob.LicenseClassID = 1;

            //if (ob.Save())
            //{
            //    Console.WriteLine("Saved");
            //}
            //else {
            //    Console.WriteLine("Save Failed");
            //}

            DataTable dt = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(
                    $"{dr["LocalDrivigLicenseApplicationID"]} | " +
                    $"{dr["ClassName"]} | " +
                    $"{dr["NationalNo"]} | " +
                    $"{dr["FirstName"]} | " +
                    $"{dr["ApplicationDate"]} | " +
                    $"{dr["PassedTest"]} | " +
                    $"{dr["ApplicationStatus"]}"
                );
            }
            Console.ReadKey();
        }
    }
}
