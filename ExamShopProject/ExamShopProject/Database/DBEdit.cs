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
        #region User
        // Made by Mikkel Glerup
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
        #endregion
        #region Customer
        // Made by Helena Brunsgaard Madsen
        public static bool EditCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand UpdateCustomer = new SqlCommand(
                    "UPDATE [Customer] SET [Name]=@Name, StreetAndNumber=@StreetAndNumber, ZipCode=@ZipCode, City=@City, ContactInfo=@ContactInfo, SpokesPerson=@SpokesPerson, AnnualIncome=@AnnualIncome " +
                    "WHERE CustomerID=@CustomerID", DBOpenClose.myConnection);
                UpdateCustomer.Parameters.Add("@Name", SqlDbType.VarChar);
                UpdateCustomer.Parameters["@Name"].Value = customer.Name;
                UpdateCustomer.Parameters.Add("@StreetAndNumber", SqlDbType.VarChar);
                UpdateCustomer.Parameters["@StreetAndNumber"].Value = customer.StreetAndNumber;
                UpdateCustomer.Parameters.Add("@ZipCode", SqlDbType.Int);
                UpdateCustomer.Parameters["@ZipCode"].Value = customer.ZipCode;
                UpdateCustomer.Parameters.Add("@City", SqlDbType.VarChar);
                UpdateCustomer.Parameters["@City"].Value = customer.City;
                UpdateCustomer.Parameters.Add("@ContactInfo", SqlDbType.VarChar);
                UpdateCustomer.Parameters["@ContactInfo"].Value = customer.ContactInfo;
                UpdateCustomer.Parameters.Add("@SpokesPerson", SqlDbType.VarChar);
                UpdateCustomer.Parameters["@SpokesPerson"].Value = customer.SpokesPerson;
                UpdateCustomer.Parameters.Add("@AnnualIncome", SqlDbType.Float);
                UpdateCustomer.Parameters["@AnnualIncome"].Value = customer.AnnualIncome;
                UpdateCustomer.Parameters.Add("@CustomerID", SqlDbType.Int);
                UpdateCustomer.Parameters["@CustomerID"].Value = customer.customerID;
                UpdateCustomer.ExecuteNonQuery();
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
        #endregion
        #region Product
        // Made by Helena Brunsgaard Madsen
        public static bool EditProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand update = new SqlCommand(
                    "UPDATE [Product] SET [Name]=@Name, Description=@Description, Price=@Price, CategoryID=@CategoryID " +
                    "WHERE ProductID=@ProductID", DBOpenClose.myConnection);
                update.Parameters.Add("@ProductID", SqlDbType.Int);
                update.Parameters["@ProductID"].Value = product.ProductID;
                update.Parameters.Add("@Name", SqlDbType.VarChar);
                update.Parameters["@Name"].Value = product.Name;
                update.Parameters.Add("@Description", SqlDbType.Text);
                update.Parameters["@Description"].Value = product.Description;
                update.Parameters.Add("@Price", SqlDbType.Float);
                update.Parameters["@Price"].Value = product.Price;
                update.Parameters.Add("@CategoryID", SqlDbType.Int);
                update.Parameters["@CategoryID"].Value = product.CategoryID;
                update.ExecuteNonQuery();
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
        #endregion
    }
}