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
        public bool InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [User] (UserName, Password, Name, IsAdmin, UserGuid) VALUES (@username, @password, @name, @isAdmin, @UserGuid)", con);
                command.Parameters.Add("@username", SqlDbType.VarChar);
                command.Parameters["@username"].Value = user.Username;
                command.Parameters.Add("@password", SqlDbType.VarChar);
                command.Parameters["@password"].Value = user.Password;
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = user.Name;
                command.Parameters.Add("@isAdmin", SqlDbType.Bit);
                command.Parameters["@isAdmin"].Value = user.IsAdmin;
                command.Parameters.AddWithValue("@UserGUid", user.userGuid);
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region Customer
        // Made by Helena Brunsgaard Madsen
        public bool InsertCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Customer ([Name], StreetAndNumber, ZipCode, City, ContactInfo, SpokesPerson, AnnualIncome) " +
                    "VALUES (@Name, @StreetAndNumber, @ZipCode, @City, @ContactInfo, @SpokesPerson, @AnnualIncome)", con);
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
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region Product
        // Made by Helena Brunsgaard Madsen
        public bool InsertProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Product] (Name, description, Price, CategoryID) " +
                    "VALUES (@name, @description, @price, @CategoryID)" +
                    "SELECT CategoryID From ProductCategories WHERE CategoryID=@CategoryID", con);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = product.Name;
                command.Parameters.Add("@description", SqlDbType.Text);
                command.Parameters["@description"].Value = product.Description;
                command.Parameters.Add("@price", SqlDbType.Float);
                command.Parameters["@price"].Value = product.Price;
                command.Parameters.Add("@CategoryID", SqlDbType.Int);
                command.Parameters["@CategoryID"].Value = product.CategoryID;
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
                // need to get CategoryID somehow, right now from a listbox i imagine categories are placed in and sends an ID with the product object.
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
        #region Subscription
        //Made by Mikkel E.R. Glerup
        public bool InsertSubscription(Subscription input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Subscription] (CustomerID, Renew, EndDate, RenewLength) VALUES (@CustomerID, @Renew, @EndDate, @RenewLength)", con);
                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = input.CustomerID;
                command.Parameters.Add("@Renew", SqlDbType.Bit);
                command.Parameters["@Renew"].Value = input.Renew;
                command.Parameters.Add("@EndDate", SqlDbType.Date);
                command.Parameters["@EndDate"].Value = input.EndDate;
                command.Parameters.Add("@RenewLength", SqlDbType.Int);
                command.Parameters["@RenewLength"].Value = input.RenewLength;
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }
        public bool InsertSubscriptionWCategory(Subscription input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [SubscribedToCategories] (CategoryID, SubscriptionID) VALUES (@CategoryID, @SubscriptionID)", con);
                command.Parameters.Add("@CategoryID", SqlDbType.Int);
                command.Parameters["@CategoryID"].Value = input.CategoryID;
                command.Parameters.Add("@SubscriptionID", SqlDbType.Int);
                command.Parameters["@SubscriptionID"].Value = input.SubscriptionID;
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }

        #endregion
        #region Deal
        public bool InsertDeal(Deals deal)
        {
            if (deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Deals] (Name, PriceDecrease, DealType, EndDate, CategoryID, ProductID, CustomerID, StartDate) VALUES (@Name, @PriceDecrease, @DealType, @EndDate, @CategoryID, @ProductID, @CustomerID, @StartDate)", con);
                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = deal.Name;
                command.Parameters.Add("@PriceDecrease", SqlDbType.Float);
                command.Parameters["@PriceDecrease"].Value = deal.PriceDecrease;
                command.Parameters.Add("@DealType", SqlDbType.VarChar);
                command.Parameters["@DealType"].Value = deal.DealType;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime);
                command.Parameters["@EndDate"].Value = deal.EndDate;
                command.Parameters.Add("@CategoryID", SqlDbType.Int);
                command.Parameters["@CategoryID"].Value = deal.CategoryID;
                command.Parameters.Add("@ProductID", SqlDbType.Int);
                command.Parameters["@ProductID"].Value = deal.ProductID;
                command.Parameters.Add("@CustomerID", SqlDbType.Int);
                command.Parameters["@CustomerID"].Value = deal.CustomerID;
                command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                command.Parameters["@StartDate"].Value = deal.StartDate;
                command.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Log.WriteFail(ex);
                return false;
            }
        }
        #endregion
    }
}
