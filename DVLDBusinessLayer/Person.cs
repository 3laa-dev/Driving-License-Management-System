using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class Person
    {
        enMode Mode;
        public int PersonID { get; set; }
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }   
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath{ get; set; }

        public string FullName {
            get
            {
                return this.FirstName +" "+ this.SecondName + " " + this.ThirdName + " " + this.LastName;

            }
        }
        public clsCountry CountryInfo { set; get; }

        private Person(
                int personID,
                string nationalNO,
                string firstName,
                string secondName,
                string thirdName,
                string lastName,
                string gender,
                DateTime dateOfBirth,
                string address,
                string phone,
                string email,
                int nationalityCountryID,
                string imagePath)
        {
            this.PersonID = personID;
            this.NationalNO = nationalNO;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;

            this.Mode = enMode.Update;
        }

        public Person() {
            this.PersonID = -1;
            this.NationalNO = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.Gender = "";
            this.ImagePath = "";

            this.Mode = enMode.AddNew;
        }

        
        public static DataTable GetPeople()
        {
            return PeopleData.GetPeople();
        }
        public static DataTable GetPeople(string FilterBy , string value) { 
            return PeopleData.GetPeople(FilterBy,value);
        }

        private bool _AddNewPerson() {
            this.PersonID = PeopleData.AddPerson(
                 this.NationalNO ,
                 this.FirstName ,
                 this.SecondName ,
                 this.ThirdName ,
                 this.LastName,
                 this.Gender ,
                 this.DateOfBirth ,
                 this.Address,
                 this.Phone ,
                 this.Email ,
                 this.NationalityCountryID ,
                 this.ImagePath 
                );
            return this.PersonID != -1;
        }
        private bool _UpdatetPerson() {
            return PeopleData.UpdatePerson(
                this.PersonID,
                this.NationalNO,
                 this.FirstName,
                 this.SecondName,
                 this.ThirdName,
                 this.LastName,
                 this.Gender ,
                 this.DateOfBirth,
                 this.Address,
                 this.Phone,
                 this.Email,
                 this.NationalityCountryID,
                 this.ImagePath
                );
        }

        public static Person Find(int id) {

            string NationalNO = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Gender = "";
            DateTime DateOfBirth = DateTime.Now;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (PeopleData.GetPersonByID(id, ref NationalNO, ref FirstName, ref SecondName, ref ThirdName, ref LastName ,ref Gender, ref DateOfBirth, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath)) {
                return new Person(id , NationalNO , FirstName ,SecondName ,ThirdName , LastName , Gender  , DateOfBirth , Address , Phone , Email , NationalityCountryID ,ImagePath);
            }else
                return null;

            
        }
        public static Person Find(string NationalNO) {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Gender = "";
            DateTime DateOfBirth = DateTime.Now;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (PeopleData.GetPersonByNationalNO( NationalNO ,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Gender, ref DateOfBirth, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new Person(PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }
        public static bool isFoundNationalNO(string NationalNO) {
            return PeopleData.isFoundNationalNO(NationalNO);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    { 
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return (_UpdatetPerson());
                default:
                    return false;

            }

        }

        public static bool DeletePerson(int PersonID) { 
            return PeopleData.DeletePerson(PersonID);
        }

    }
}
