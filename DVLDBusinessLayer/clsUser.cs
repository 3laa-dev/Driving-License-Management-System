using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public  class clsUser
    {
        enMode Mode;
        public Person Person { get; set; }

        public int PersonID { get; set; }
        public int UserID{get;set;}
        public string UserName{get;set;}

        public string Password{get;set;}
        public bool isActive { get; set; }

        public clsUser() { 
            this.isActive = false;
            this.PersonID = -1;
            this.Person = null;
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Mode = enMode.AddNew;
        }

        clsUser( int userID , int PersonID, string userName, string password, bool isActive)
        {
            this.PersonID = PersonID;
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.isActive = isActive;
            this.Person = Person.Find(PersonID);
            this.Mode = enMode.Update;
        }

        public static DataTable GetAllUsers() { 
            return UserData.GetAllUsers();
        }

        public static DataTable GetAllUsers(string FilterBy, string value) {
            return UserData.GetAllUsers( FilterBy,  value);
        }
        
        public static bool isUser(int PersonID)
        {
            return UserData.isUser(PersonID);
        }

        public static bool DeleteUser(int UserID) { 
            return UserData.DeleteUser(UserID);
        }

        bool _CreateUser() {
            this.UserID = UserData.CreateUser(this.PersonID, this.UserName, this.Password, this.isActive);
            return this.UserID != -1;
        }

        bool _UpdateUser() { 
            return UserData.UpdateUser(this.UserID , this.UserName, this.isActive);
        }
        public bool Save() {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_CreateUser()) {
                        this.Mode = enMode.Update;
                        return true;
                    }else
                        return false; 
                case enMode.Update:
                    return _UpdateUser();
                default:
                    return false;
            }
        }

        public static clsUser Find(string UserName , string Password) {
            int UserID =-1, PersonID = -1;
            bool isActive = false;

            return (UserData.GerUserByUserNameAndPassword(UserName, Password , ref UserID, ref PersonID, ref isActive) ?
                new clsUser(UserID, PersonID, UserName, Password, isActive) :
                null
                );
        }

        public static clsUser Find(int UserID)
        {
            int  PersonID = -1;
            bool isActive = false;
            string UserName = "";
            return (UserData.GerUserByID( UserID ,ref PersonID ,ref UserName , ref isActive) ?
                new clsUser(UserID, PersonID, UserName, "", isActive) :
                null
                );
        }

        public bool ChangePassword(string CurrentPassword , string NewPassword) { 
            bool hasChanged = UserData.ChangePassword(this.UserID, CurrentPassword , NewPassword);
            if(hasChanged)Password = NewPassword;
            return hasChanged;
        }

    }
}
