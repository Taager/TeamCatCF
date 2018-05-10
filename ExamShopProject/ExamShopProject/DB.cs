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
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [User] (UserName, Password, Name, IsAdmin) VALUES (@username, @password, @name, @isAdmin)", myConnection);
                command.Parameters.Add("@username", SqlDbType.VarChar);
                command.Parameters["@username"].Value = user.Username;
                command.Parameters.Add("@password", SqlDbType.VarChar);
                command.Parameters["@password"].Value = user.Password;
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = user.Name;
                command.Parameters.Add("@isAdmin", SqlDbType.Bit);
                command.Parameters["@isAdmin"].Value = user.IsAdmin;
                command.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region viewList*
        // Made by Mikkel E.R. Glerup
        public static List<User> SelectAllUsers()
        {
            try
            {
                List<User> userList = new List<User>();
                openConnection();
                SqlCommand getUsers = new SqlCommand(
                    "SELECT * FROM [User]", myConnection);
                SqlDataReader reader = getUsers.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.IsAdmin = reader.GetBoolean(4);
                    userList.Add(user);
                }
                closeConnection();
                return userList;
            }
            catch (Exception ex)
            {
                List<User> userList = new List<User>();
                Log.WriteFail(ex);
                return userList;
            }
        }
        //Made by Mikkel E.R. Glerup
        public static User SelectUser(int ID)
        {
            try
            {
                User user = new User();
                openConnection();
                SqlCommand getUser = new SqlCommand(
                    "SELECT * FROM [User] WHERE UserID=@UserID", myConnection);
                getUser.Parameters.Add("@UserID", SqlDbType.Int);
                getUser.Parameters["@UserID"].Value = ID;
                    SqlDataReader reader = getUser.ExecuteReader();
                while (reader.Read())
                {
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.IsAdmin = reader.GetBoolean(4);
                }
                closeConnection();
                return user;
            }
            catch (Exception ex)
            {
                User user = new User();
                Log.WriteFail(ex);
                return user;
            }
        }
        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User user)
        {
            try
            {
                openConnection();
                SqlCommand UpdateUser = new SqlCommand("UPDATE [User] SET Username=@Username, Password=@Password, [Name]=@Name, IsAdmin=@IsAdmin WHERE UserID=@UserID", myConnection);
                UpdateUser.Parameters.Add("@Username", SqlDbType.VarChar);
                UpdateUser.Parameters["@Username"].Value = user.Username;
                UpdateUser.Parameters.Add("@Password", SqlDbType.VarChar);
                UpdateUser.Parameters["@Password"].Value = user.Password;
                UpdateUser.Parameters.Add("@Name", SqlDbType.VarChar);
                UpdateUser.Parameters["@Name"].Value = user.Name;
                UpdateUser.Parameters.Add("@IsAdmin", SqlDbType.Bit);
                UpdateUser.Parameters["@IsAdmin"].Value = user.IsAdmin;
                UpdateUser.Parameters.Add("@UserID", SqlDbType.Int);
                UpdateUser.Parameters["@UserID"].Value = user.ID;
                UpdateUser.ExecuteNonQuery();
                closeConnection();
                return true;

            }
            catch (Exception ex)
            {
                closeConnection();
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region open and close connection
        //made by Mikkel. E.R. Glerup
        public static SqlConnection myConnection;
        public static bool openConnection()
        {
            try
            {
                myConnection = new SqlConnection(
                    "Data Source=.;Initial Catalog=Charlie-APE;Integrated Security=True"
                    );
                myConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
        //Made by Mikkel E.R. Glerup
        public static bool closeConnection()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
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
