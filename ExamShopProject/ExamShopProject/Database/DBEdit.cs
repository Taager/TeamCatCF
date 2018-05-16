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
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                DBOpenClose.OpenConnection();
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
                DBOpenClose.CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                DBOpenClose.CloseConnection();
                Log.WriteFail(ex);
                return false;
            }
        }
        public static bool EditCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand UpdateUser = new SqlCommand("UPDATE [Customer] SET [Name]=@Name, StreetAndNumber=@StreetAndNumber, ZipCode=@ZipCode, City=@City, ContactInfo=@ContactInfo, SpokesPerson=@SpokesPerson, AnnualIncome=@AnnualIncome WHERE CustomerID=@CustomerID", DBOpenClose.myConnection);
                UpdateUser.Parameters.Add("@Name", SqlDbType.VarChar);
                UpdateUser.Parameters["@Name"].Value = customer.Name;
                UpdateUser.Parameters.Add("@StreetAndNumber", SqlDbType.VarChar);
                UpdateUser.Parameters["@StreetAndNumber"].Value = customer.StreetAndNumber;
                UpdateUser.Parameters.Add("@ZipCode", SqlDbType.Int);
                UpdateUser.Parameters["@ZipCode"].Value = customer.ZipCode;
                UpdateUser.Parameters.Add("@City", SqlDbType.VarChar);
                UpdateUser.Parameters["@City"].Value = customer.City;
                UpdateUser.Parameters.Add("@ContactInfo", SqlDbType.VarChar);
                UpdateUser.Parameters["@ContactInfo"].Value = customer.ContactInfo;
                UpdateUser.Parameters.Add("@SpokesPerson", SqlDbType.VarChar);
                UpdateUser.Parameters["@SpokesPerson"].Value = customer.SpokesPerson;
                UpdateUser.Parameters.Add("@AnnualIncome", SqlDbType.Float);
                UpdateUser.Parameters["@AnnualIncome"].Value = customer.AnnualIncome;
                UpdateUser.Parameters.Add("@CustomerID", SqlDbType.Int);
                UpdateUser.Parameters["@CustomerID"].Value = customer.customerID;
                UpdateUser.ExecuteNonQuery();
                DBOpenClose.CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                DBOpenClose.CloseConnection();
                Log.WriteFail(ex);
                return false;
            }
        }
    }
}