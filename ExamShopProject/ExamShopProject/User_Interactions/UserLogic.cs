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
        #region UserLogIn
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
                ErrorHandler.Log.WriteUserLogInAttempt(ex);   
            }
        }
        #endregion
        public void CreateCustomer(string name, string username, string password, bool isAdmin)
        {
            // DB command (name, adress, contactInfo, spokesPerson)
        }
        private void EditCustomer(int IDToEdit)
        {
            // DB command(IDToEdit)
        }
        private void DeleteCustomer(int IDToDelete)
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
