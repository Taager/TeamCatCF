using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject
{
    class DBEdit
    {
        public static bool EditUser(User user)
        {
            try
            {
                DBOpenClose.openConnection();
                SqlCommand UpdateUser = new SqlCommand("UPDATE [User] SET Username=@Username, Password=@Password, [Name]=@Name, IsAdmin=@IsAdmin WHERE UserID=@UserID", DBOpenClose.myConnection);
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
                DBOpenClose.closeConnection();
                return true;

            }
            catch (Exception ex)
            {
                DBOpenClose.closeConnection();
                Log.WriteFail(ex);
                return false;
            }
        }
    }
}