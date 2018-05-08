using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject.User_Interactions
{
    class UserLogic
    {
        Random rnd = new Random();
        //made by Mikkel E.R. Glerup
        User user = new User();
        public void UserLogin()
        {
            try
            {
                bool isSucces = DB.UserLogin();
                if (isSucces)
                    throw new UserLogInMessage();
                if (!isSucces)
                    throw new UserLogInFail();
            }
            catch (Exception ex)
            {
                ErrorHandler.Log.WritEvent(ex);
            }
        }
        //made by Mikkel E.R. Glerup
        public void CreateUser(string name, string username, string password, bool isAdmin)
        {
            try
            {
                user.Name = name;
                user.Username = GetRandomUsername(name);
                user.Password = GetRandomPassword();
                user.IsAdmin = isAdmin;
                bool wasSucces = DB.InsertUser(user);
                if (wasSucces)
                {
                    throw new UserWasAdded(user);
                }
            }
            //Only thrown if creating user was a succes
            catch (UserWasAdded ex)
            {
                ErrorHandler.Log.WritEvent(ex);
            }
        }
        #region Get rnd username and string logic
        //made by Mikkel E.R. Glerup
        public string GetRandomUsername(string name)
        {
            rnd.Next();
            if (name.Length < 3)
            {
                name = name + GetRandomChar();
            }
            return name = name.Substring(0, 3) + GetRandomNumber(); ;
        }
        public char GetRandomChar()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            int num = rnd.Next(0, chars.Length - 1);
            char rndChar = chars[num];
            return rndChar;
        }
        public string GetRandomNumber()
        {  

            int rndNumb = rnd.Next(100,999);
            string rndNumbString = rndNumb.ToString();
            return rndNumbString;
        }
        public string GetRandomPassword()
        {
            string password = System.IO.Path.GetRandomFileName();
            return password = password.Substring(0, 8) + password.Replace(".", "");
        }
        #endregion
        private void EditUser(int IDToEdit)
        {
           
        }
        private void DeleteUser(int IDToDelete)
        {
            // DB command(IDToDelete)
        }
        private void ViewUser()
        {
            // DB command
        }
        private void ViewUserStat()
        {
            // Stat command
        }
        public void Log()
        {
            // Log command
        }
    }
}
