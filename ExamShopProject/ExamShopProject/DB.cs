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
