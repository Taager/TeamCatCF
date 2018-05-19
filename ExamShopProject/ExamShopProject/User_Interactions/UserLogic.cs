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
        GetUsername usernameCreation = new GetUsername();
        GetRandomPassword passwordCreation = new GetRandomPassword();
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
                ErrorHandler.Log.WriteEvent(ex);
            }
        }
        //made by Mikkel E.R. Glerup
        public bool CreateUser(string name, bool isAdmin)
        {
            try
            {
                user.Name = name;
                user.Username = usernameCreation.GetRandomUsername(name);
                user.Password = passwordCreation.CreateRandomPassword();
                user.IsAdmin = isAdmin;
                bool wasSuccess = DB.InsertUser(user);
                if (wasSuccess)
                    throw new UserWasAdded(user);
                return false;
            }
            //Only thrown if creating user was a succes
            catch (UserWasAdded ex)
            {
                
                Log.WriteEvent(ex);
                return true;
            }
        }
        //Made by Mikkel E.R. Glerup
        public bool EditUser(User user)
        {
            try
            {
                bool wasSucces = DB.EditUser(user);
                if (wasSucces)
                    throw new UserWasEdited(user);
                return wasSucces;
            }
            catch (UserWasEdited ex)
            {
               Log.WriteEvent(ex);
                return true;
            }
        }
        public bool DeleteUser(string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.Delete(callerClass, callerID);
                if (wasSucces)
                    throw new UserWasDeleted(user);
                return wasSucces;
            }
            catch (UserWasDeleted ex)
            {
                Log.WriteEvent(ex);
                return true;
            }
     
        }
    }
}
