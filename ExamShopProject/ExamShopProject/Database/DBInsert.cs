using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExamShopProject.Object;
using System.Data;
using ExamShopProject.ErrorHandler;


namespace ExamShopProject
{
    class DBInsert
    {
        #region User
        //Made by Mikkel E.R. Glerup
        public static bool InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [User] (UserName, Password, Name, IsAdmin) VALUES (@username, @password, @name, @isAdmin)", DBOpenClose.myConnection);
                command.Parameters.Add("@username", SqlDbType.VarChar);
                command.Parameters["@username"].Value = user.Username;
                command.Parameters.Add("@password", SqlDbType.VarChar);
                command.Parameters["@password"].Value = user.Password;
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = user.Name;
                command.Parameters.Add("@isAdmin", SqlDbType.Bit);
                command.Parameters["@isAdmin"].Value = user.IsAdmin;
                command.ExecuteNonQuery();
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
        public static bool InsertCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Customer ([Name], StreetAndNumber, ZipCode, City, ContactInfo, SpokesPerson, AnnualIncome) " +
                    "VALUES (@Name, @StreetAndNumber, @ZipCode, @City, @ContactInfo, @SpokesPerson, @AnnualIncome)", DBOpenClose.myConnection);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = customer.Name;
                command.Parameters.Add("@StreetAndNumber", SqlDbType.VarChar);
                command.Parameters["@StreetAndNumber"].Value = customer.StreetAndNumber;
                command.Parameters.Add("@ZipCode", SqlDbType.Int);
                command.Parameters["@ZipCode"].Value = customer.ZipCode;
                command.Parameters.Add("@City", SqlDbType.VarChar);
                command.Parameters["@City"].Value = customer.City;
                command.Parameters.Add("@ContactInfo", SqlDbType.VarChar);
                command.Parameters["@ContactInfo"].Value = customer.ContactInfo;
                command.Parameters.Add("SpokesPerson", SqlDbType.VarChar);
                command.Parameters["SpokesPerson"].Value = customer.SpokesPerson;
                command.Parameters.Add("@AnnualIncome", SqlDbType.Float);
                command.Parameters["@AnnualIncome"].Value = customer.AnnualIncome;
                command.ExecuteNonQuery();
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
        public static bool InsertProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            try
            {
        DBOpenClose.OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Product] (Name, description, Price, CategoryID) " +
                    "VALUES (@name, @description, @price, @CategoryID)" +
                    "SELECT CategoryID From ProductCategories WHERE CategoryID=@CategoryID", DBOpenClose.myConnection);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = product.Name;
                command.Parameters.Add("@description", SqlDbType.Text);
                command.Parameters["@description"].Value = product.Description;
                command.Parameters.Add("@price", SqlDbType.Float);
                command.Parameters["@price"].Value = product.Price;
                command.Parameters.Add("@CategoryID", SqlDbType.Int);
                command.Parameters["@CategoryID"].Value = product.CategoryID;
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection();
                return true;
                // need to get CategoryID somehow, right now from a listbox i imagine categories are placed in and sends an ID with the product object.
            }
            catch (Exception ex)
            {
                DBOpenClose.CloseConnection();
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region Subscription
        //Made by Mikkel E.R. Glerup
        public static bool InsertSubscription(Subscription input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            try
            {
                DBOpenClose.OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Subscription] (CustomerID, Renew, EndDate, RenewLength) VALUES (@CustomerID, @Renew, @EndDate, @RenewLength)", DBOpenClose.myConnection);
                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = input.CustomerID;
                command.Parameters.Add("@Renew", SqlDbType.Bit);
                command.Parameters["@Renew"].Value = input.Renew;
                command.Parameters.Add("@EndDate", SqlDbType.Date);
                command.Parameters["@EndDate"].Value = input.EndDate;
                command.Parameters.Add("@RenewLength", SqlDbType.Date);
                command.Parameters["@RenewLength"].Value = input.RenewLength;
                command.ExecuteNonQuery();
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
