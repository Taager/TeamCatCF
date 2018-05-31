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
        #region User
        // Made by Mikkel E.R Glerup
        public List<User> SelectAllUsers()
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                List<User> userList = new List<User>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getUsers = new SqlCommand(
                    "SELECT * FROM [User]", con);
                SqlDataReader reader = getUsers.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = Convert.ToInt32(reader["UserID"]);
                    user.Username = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Name = Convert.ToString(reader["Name"]);
                    user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    userList.Add(user);
                }
                DBOpenClose.CloseConnection(con);
                return userList;
            }
            catch (Exception ex)
            {
                List<User> userList = new List<User>();
                Log.WriteFail(ex);
                return userList;
            }
        }
        // Made by Mikkel E.R. Glerup
        public User SelectUser(int ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                User user = new User();
                DBOpenClose.OpenConnection(con);
                SqlCommand getUser = new SqlCommand(
                    "SELECT * FROM [User] WHERE UserID=@UserID", con);
                getUser.Parameters.Add("@UserID", SqlDbType.Int);
                getUser.Parameters["@UserID"].Value = ID;
                SqlDataReader reader = getUser.ExecuteReader();
                while (reader.Read())
                {
                    user.ID = Convert.ToInt32(reader["UserID"]);
                    user.Username = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Name = Convert.ToString(reader["Name"]);
                    user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                }
                DBOpenClose.CloseConnection(con);
                return user;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                User user = new User();
                Log.WriteFail(ex);
                return user;
            }
        }
        //Made by Mikkel E.R. Glerup
        public bool GetUserIdByUsernameAndPassword()
        {
            try
            {
                CurrentUser.currentUserID = 0;
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                using (SqlCommand cmd = new SqlCommand("SELECT UserID, [Password], UserGuid FROM [User] WHERE Username=@Username", con))
                {
                    cmd.Parameters.AddWithValue("@Username", CurrentUser.username);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int DBuserID = Convert.ToInt32(reader["UserID"]);
                        string DBPassword = Convert.ToString(reader["Password"]);
                        string DBGuid = Convert.ToString(reader["UserGuid"]);
                        CurrentUser.hashedPassword = Security.HashSHA256(CurrentUser.password + DBGuid);
                        if (DBPassword == CurrentUser.hashedPassword)
                        {
                            CurrentUser.currentUserID = DBuserID;
                        }
                    }
                    con.Close();
                }
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
        public List<Customer> SelectAllCustomers()
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                List<Customer> customerList = new List<Customer>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getCustomers = new SqlCommand(
                    "SELECT * FROM [Customer]", con);
                SqlDataReader reader = getCustomers.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.customerID = Convert.ToInt32(reader["CustomerID"]);
                    customer.Name = Convert.ToString(reader["Name"]);
                    customer.StreetAndNumber = Convert.ToString(reader["StreetAndNumber"]);
                    customer.ZipCode = Convert.ToInt32(reader["ZipCode"]);
                    customer.City = Convert.ToString(reader["City"]);
                    customer.ContactInfo = Convert.ToString(reader["ContactInfo"]);
                    customer.SpokesPerson = Convert.ToString(reader["SpokesPerson"]);
                    customer.AnnualIncome = Convert.ToDouble(reader["AnnualIncome"]);
                    customerList.Add(customer);
                }
                DBOpenClose.CloseConnection(con);
                return customerList;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Customer> customerList = new List<Customer>();
                Log.WriteFail(ex);
                return customerList;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public Customer SelectCustomer(int ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Customer customer = new Customer();
                DBOpenClose.OpenConnection(con);
                SqlCommand getCustomer = new SqlCommand(
                    "SELECT * FROM [Customer] WHERE CustomerID=@CustomerID", con);
                getCustomer.Parameters.Add("@CustomerID", SqlDbType.Int);
                getCustomer.Parameters["@CustomerID"].Value = ID;
                SqlDataReader reader = getCustomer.ExecuteReader();
                while (reader.Read())
                {
                    customer.customerID = Convert.ToInt32(reader["CustomerID"]);
                    customer.Name = Convert.ToString(reader["Name"]);
                    customer.StreetAndNumber = Convert.ToString(reader["StreetAndNumber"]);
                    customer.ZipCode = Convert.ToInt32(reader["ZipCode"]);
                    customer.City = Convert.ToString(reader["City"]);
                    customer.ContactInfo = Convert.ToString(reader["ContactInfo"]);
                    customer.SpokesPerson = Convert.ToString(reader["SpokesPerson"]);
                    customer.AnnualIncome = Convert.ToDouble(reader["AnnualIncome"]);
                }
                DBOpenClose.CloseConnection(con);
                return customer;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Customer customer = new Customer();
                Log.WriteFail(ex);
                return customer;
            }
        }
        #endregion
        #region Category
        // Made by Helena Brunsgaard Madsen
        public List<Categories> SelectAllCategories()
        {
            try
            {
                Categories category = new Categories();
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                List<Categories> categoryList = new List<Categories>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getCategories = new SqlCommand(
                    "SELECT * FROM [ProductCategories]", con);
                SqlDataReader reader = getCategories.ExecuteReader();
                while (reader.Read())
                {
                    Categories categories = new Categories();
                    categories.CategoryID = reader["CategoryID"] == System.DBNull.Value ? default(int) : (int)reader["CategoryID"]; //get a nullable int from database
                    categories.Name = Convert.ToString(reader["Name"]);
                    categories.Description = Convert.ToString(reader["Decription"]);
                    categoryList.Add(categories);
                }
                DBOpenClose.CloseConnection(con);
                //Removes the empty category from the list.
                return categoryList;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Categories> categoryList = new List<Categories>();
                Log.WriteFail(ex);
                return categoryList;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public Categories SelectCategory(int? ID) //not sure we need this
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Categories category = new Categories();
                DBOpenClose.OpenConnection(con);
                SqlCommand getCategory = new SqlCommand(
                    "SELECT * FROM [ProductCategories] WHERE CategoryID=@CategoryID", con);
                getCategory.Parameters.Add("@CategoryID", SqlDbType.Int);
                getCategory.Parameters["@CategoryID"].Value = ID;
                SqlDataReader reader = getCategory.ExecuteReader();
                while (reader.Read())
                {
                    category.CategoryID = reader["CategoryID"] == System.DBNull.Value ? default(int) : (int)reader["CategoryID"]; //get a nullable int from database
                    category.Name = Convert.ToString(reader["Name"]);
                    category.Description = Convert.ToString(reader["Decription"]);
                }
                DBOpenClose.CloseConnection(con);
                return category;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Categories category = new Categories();
                Log.WriteFail(ex);
                return category;
            }
        }
        #endregion
        #region Products
        // Made by Helena Brunsgaard Madsen
        public List<Product> SelectAllProducts()
        {
            try
            {
                Product product = new Product();
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                List<Product> productList = new List<Product>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getProducts = new SqlCommand(
                    "SELECT * FROM [Product]", con);
                SqlDataReader reader = getProducts.ExecuteReader();
                while (reader.Read())
                {
                    Product products = new Product();
                    products.ProductID = reader["ProductID"] == System.DBNull.Value ? default(int) : (int)reader["ProductID"]; //get a nullable int from database
                    products.Name = Convert.ToString(reader["Name"]);
                    products.Description = Convert.ToString(reader["Decription"]);
                    products.Price = Convert.ToDouble(reader["Price"]);
                    products.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    productList.Add(products);
                }
                DBOpenClose.CloseConnection(con);
                return productList;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Product> productList = new List<Product>();
                Log.WriteFail(ex);
                return productList;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public Product SelectProduct(int? ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Product product = new Product();
                DBOpenClose.OpenConnection(con);
                SqlCommand getProduct = new SqlCommand(
                    "SELECT * FROM [Product] WHERE ProductID=@ProductID", con);
                getProduct.Parameters.Add("@ProductID", SqlDbType.Int);
                getProduct.Parameters["@ProductID"].Value = ID;
                SqlDataReader reader = getProduct.ExecuteReader();
                while (reader.Read())
                {
                    product.ProductID = reader["ProductID"] == System.DBNull.Value ? default(int) : (int)reader["ProductID"]; //get a nullable int from database
                    product.Name = Convert.ToString(reader["Name"]);
                    product.Description = Convert.ToString(reader["Decription"]);
                    product.Price = Convert.ToDouble(reader["Price"]);
                    product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                }
                DBOpenClose.CloseConnection(con);
                return product;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Product product = new Product();
                Log.WriteFail(ex);
                return product;
            }
        }
        #endregion
        #region Subscription
        // Made by Mikkel E.R. Glerup
        public Subscription SelectSubscription(int ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Subscription output = new Subscription();
                DBOpenClose.OpenConnection(con);
                SqlCommand getSubscription = new SqlCommand(
                    "SELECT * FROM [Subscription] WHERE CustomerID=@CustomerID", con);
                getSubscription.Parameters.Add("@CustomerID", SqlDbType.Int);
                getSubscription.Parameters["@CustomerID"].Value = ID;
                SqlDataReader reader = getSubscription.ExecuteReader();
                while (reader.Read())
                {
                    output.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    output.Renew = Convert.ToBoolean(reader["Renew"]);
                    output.SubscriptionID = Convert.ToInt32(reader["SubscriptionID"]);
                    output.RenewLength = Convert.ToInt32(reader["RenewLength"]);
                }
                DBOpenClose.CloseConnection(con);
                return output;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Subscription output = new Subscription();
                Log.WriteFail(ex);
                return output;
            }
        }
        // Made by Mikkel. E.R. Glerup
        public List<Subscription> SelectAllSubscriptions()
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Subscription input = new Subscription();
                List<Subscription> SubscriptionList = new List<Subscription>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getSubscriptions = new SqlCommand(
                    "SELECT * FROM [Subscription]", con);
                    SqlDataReader reader = getSubscriptions.ExecuteReader();
                while (reader.Read())
                {
                    input.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    input.Renew = Convert.ToBoolean(reader["Renew"]);
                    input.SubscriptionID = Convert.ToInt32(reader["SubscriptionID"]);
                    input.RenewLength = Convert.ToInt32(reader["RenewLength"]);
                    SubscriptionList.Add(input);
                }
                DBOpenClose.CloseConnection(con);
                return SubscriptionList;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Subscription> SubscriptionList = new List<Subscription>();
                Log.WriteFail(ex);
                return SubscriptionList;
            }
        }
        #endregion
        #region Deals
        // Made by Helena Brunsgaard Madsen
        public List<Deals> SelectAllDeals()
        {
            try
            {
                Deals deal = new Deals();
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                List<Deals> dealsList = new List<Deals>();
                DBOpenClose.OpenConnection(con);
                SqlCommand getDeals = new SqlCommand(
                    "SELECT * FROM [Deals]", con);
                SqlDataReader reader = getDeals.ExecuteReader();
                while (reader.Read())
                {
                    Deals deals = new Deals();
                    deals.DealsID = Convert.ToInt32(reader["DealsID"]);
                    deals.Name = Convert.ToString(reader["Name"]);
                    deals.PriceDecrease = Convert.ToDouble(reader["PriceDecrease"]);
                    deals.DealType = Convert.ToString(reader["DealType"]);
                    deals.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    deals.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    //Product and categoryID can be null, thus we have to check, and convert if they are.
                    if (reader["CategoryID"] == DBNull.Value)
                    {
                        deals.CategoryID = 0;
                    }
                    else
                    {
                        deals.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    }
                    if (reader["ProductID"] == DBNull.Value)
                    {
                        deals.ProductID = 0;
                    }
                    else
                    {
                        deals.ProductID = Convert.ToInt32(reader["ProductID"]);
                    }
                    deals.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    dealsList.Add(deals);
                }
                DBOpenClose.CloseConnection(con);
                return dealsList;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Deals> dealsList = new List<Deals>();
                Log.WriteFail(ex);
                return dealsList;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public Deals SelectDeal(int ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Deals deals = new Deals();
                DBOpenClose.OpenConnection(con);
                SqlCommand getDeal = new SqlCommand(
                    "SELECT * FROM [Deals] WHERE DealsID=@DealsID", con);
                getDeal.Parameters.Add("@DealsID", SqlDbType.Int);
                getDeal.Parameters["@DealsID"].Value = ID;
                SqlDataReader reader = getDeal.ExecuteReader();
                while (reader.Read())
                {
                    deals.DealsID = Convert.ToInt32(reader["DealsID"]);
                    deals.Name = Convert.ToString(reader["Name"]);
                    deals.PriceDecrease = Convert.ToDouble(reader["PriceDecrease"]);
                    deals.DealType = Convert.ToString(reader["DealType"]);
                    deals.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    deals.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    //Product and categoryID can be null, thus we have to check, and convert if they are.
                    if (reader["CategoryID"] == DBNull.Value)
                    {
                        deals.CategoryID = 0;
                    }
                    else
                    {
                        deals.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    }
                    if (reader["ProductID"] == DBNull.Value)
                    {
                        deals.ProductID = 0;
                    }
                    else
                    {
                        deals.ProductID = Convert.ToInt32(reader["ProductID"]);
                    }
                    deals.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                }
                DBOpenClose.CloseConnection(con);
                return deals;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Deals deals = new Deals();
                Log.WriteFail(ex);
                return deals;
            }
        }
        #endregion
        #region SubscribetoCategory
        public Subscription SelectSubscriptionwithCategory(int ID)
        {
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                Subscription output = new Subscription();
                DBOpenClose.OpenConnection(con);
                SqlCommand getSubscription = new SqlCommand(
                    "SELECT * FROM [SubscribedToCategories] WHERE SubscriptionID=@SubscriptionID", con);
                getSubscription.Parameters.Add("@SubscriptionID", SqlDbType.Int);
                getSubscription.Parameters["@SubscriptionID"].Value = ID;
                SqlDataReader reader = getSubscription.ExecuteReader();
                while (reader.Read())
                {
                    output.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                }
                DBOpenClose.CloseConnection(con);
                return output;
            }
            catch (Exception ex)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                Subscription output = new Subscription();
                Log.WriteFail(ex);
                return output;
            }
        }
        #endregion
    }
}