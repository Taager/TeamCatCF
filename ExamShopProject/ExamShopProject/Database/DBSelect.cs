using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;
using System.Data;

namespace ExamShopProject
{
    class DBSelect
    {
        public static List<User> SelectAllUsers()
        {
            try
            {
                List<User> userList = new List<User>();
                DBOpenClose.OpenConnection();
                SqlCommand getUsers = new SqlCommand(
                    "SELECT * FROM [User]", DBOpenClose.myConnection);
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
                DBOpenClose.CloseConnection();
                return userList;
            }
            catch (Exception ex)
            {
                List<User> userList = new List<User>();
                Log.WriteFail(ex);
                return userList;
            }
        }
        public static User SelectUser(int ID)
        {
            try
            {
                User user = new User();
                DBOpenClose.OpenConnection();
                SqlCommand getUser = new SqlCommand(
                    "SELECT * FROM [User] WHERE UserID=@UserID", DBOpenClose.myConnection);
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
                DBOpenClose.CloseConnection();
                return user;
            }
            catch (Exception ex)
            {
                User user = new User();
                Log.WriteFail(ex);
                return user;
            }
        }
    }
}
