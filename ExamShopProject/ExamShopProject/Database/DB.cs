using System;
using ExamShopProject.ErrorHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using ExamShopProject.Object;
using System.Data;

namespace ExamShopProject
{
    // made by Mikkel. E.R. Glerup
    static class DB
    {
        public static bool UserLogin()
        {
            try
            {
                return true;
            }
            catch
            {

                return false;
            }
        }
        #region Insert*
        //made by Mikkel. E.R. Glerup
        public static bool InsertUser(User user)
        {
            return DBInsert.InsertUser(user);
        }
        public static bool InsertCustomer(Customer customer)
        {

            return true;
        }
        #endregion
        #region viewList*
        // Made by Mikkel E.R. Glerup
        public static List<User> SelectAllUsers()
        {
            return DBSelect.SelectAllUsers();
        }
        //Made by Mikkel E.R. Glerup
        public static User SelectUser(int ID)
        {
            return DBSelect.SelectUser(ID);
        }
        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User user)
        {
            return DBEdit.EditUser(user);
        }
        #endregion
        #region Delete*
        public static bool DeleteUser(string callerClass, int CallerID)
        {
            return DBDelete.DeleteUser(callerClass, CallerID);
        }
        #endregion
    }
}
//        ** OBS**
//          Helena indsæt dette i "Insert*" regionen
//         ** OBS*
//        public static bool InsertCustomer(Customer customer)
//{
//    try
//    {
//        openConnection();
//        SqlCommand command = new SqlCommand(
//            "INSERT INTO [User] (UserName, Password, Name, IsAdmin) VALUES (@username, @password, @name, @isAdmin)", myConnection);
//        command.Parameters.Add("@username", SqlDbType.VarChar);
//        command.Parameters["@username"].Value = user.Username;
//        command.Parameters.Add("@password", SqlDbType.VarChar);
//        command.Parameters["@password"].Value = user.Password;
//        command.Parameters.Add("@name", SqlDbType.VarChar);
//        command.Parameters["@name"].Value = user.Name;
//        command.Parameters.Add("@isAdmin", SqlDbType.Bit);
//        command.Parameters["@isAdmin"].Value = user.IsAdmin;
//        command.ExecuteNonQuery();
//        closeConnection();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        Log.WriteFail(ex);
//        return false;
//    }
//}
