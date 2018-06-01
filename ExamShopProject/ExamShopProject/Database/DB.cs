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
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Checks username and password with the data in the database
        /// </summary>
        /// <returns></returns>
        public static bool UserLogin()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.GetUserIdByUsernameAndPassword();
        }
        #region Insert*
        //made by Mikkel. E.R. Glerup
        /// <summary>
        /// Inserts user into database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InsertUser(User input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertUser(input);
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Inserts a customer into database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InsertCustomer(Customer input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertCustomer(input);
        }
        //Made by Helena Madsen
        /// <summary>
        /// Inserts a product into the database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InsertProduct(Product input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertProduct(input);
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Inserts a subscription into the database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InsertSubscription(Subscription input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertSubscription(input);
        }
        // Made by Helena Madsen

        /// <summary>
        /// Inserts a subscription ID and Category ID into a database column containing foreign keys
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InsertSubscriptionWCategory(SubscribedToCategory input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertSubscriptionWCategory(input);
        }
        // Made by Helena Madsen
        /// <summary>
        /// Editing subscription from picked subscriptionID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EditSubscriptionWCategory(SubscribedToCategory input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditSubscriptionWCategory(input);
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a deal for a product
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public static bool InsertDealProduct(Deals deal)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertDealProduct(deal);
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a deal for a category
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public static bool InsertDealCategory(Deals deal)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertDealCategory(deal);
        }
        #endregion
        #region View*
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of all users in the database
        /// </summary>
        /// <returns></returns>
        public static List<User> SelectAllUsers()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllUsers();
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Selects a user with the given ID from the database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static User SelectUser(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectUser(ID);
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates a list of all customers in the database
        /// </summary>
        /// <returns></returns>
        public static List<Customer> SelectAllCustomers()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllCustomers();
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list with all customers that has a deal
        /// </summary>
        /// <returns></returns>
        public static List<StatDeals> SelectCustomersWithDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCustomersWithDeals();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Returns a Customer with the ID specified
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Customer SelectCustomer(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCustomer(ID);
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates a list of all categories in the database
        /// </summary>
        /// <returns></returns>
        public static List<Categories> SelectAllCategories()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllCategories();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates a category with the ID specified
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Categories SelectCategory(int? ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCategory(ID);
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of categories with the amount of products contained
        /// </summary>
        /// <returns></returns>
        public static List<Categories> SelectCategoriesAndProducts()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCategoryWithProducts();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates a list of all products in the database
        /// </summary>
        /// <returns></returns>
        public static List<Product> SelectAllProducts()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllProducts();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates an object based of the given ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Product SelectProduct(int? ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectProduct(ID);
        }
        public static Subscription SelectSubcription(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectSubscription(ID);
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of all subscriptions in the database
        /// </summary>
        /// <returns></returns>
        public static List<Subscription> SelectAllSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllSubscriptions();
        }
        // Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of subscriptions which are active
        /// </summary>
        /// <returns></returns>
        public static List<Subscription> SelectActiveSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectActiveSubscriptions();
        }
        //Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of subscriptions which are inactive
        /// </summary>
        /// <returns></returns>
        public static List<Subscription> SelectInactiveSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectInactiveSubscriptions();
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of deals which are active
        /// </summary>
        /// <returns></returns>
        public static List<Deals> SelectActiveDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectActiveDeals();
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Creates a list of deals which are inactive
        /// </summary>
        /// <returns></returns>
        public static List<Deals> SelectInactiveDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectInactiveDeals();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Creates a list of all deals in the database
        /// </summary>
        /// <returns></returns>
        public static List<Deals> SelectAllDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllDeals();
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// return a Deals with the given ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Deals SelectDeal(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectDeal(ID);
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Returns a list of subscriptions which cotains a category
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static List<Categories> SelectSubscriptionwithCategory(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectSubscriptionwithCategory(ID);
        }
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Returns a list of DealTypes with the amount of times used
        /// </summary>
        /// <returns></returns>
        public static List<StatDeals> SelectDealTypes()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectDealTypes();
        }
        
        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        /// <summary>
        /// Edits user in database by UserID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EditUser(User input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditUser(input);
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Edits customer in database by CustomerID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EditCustomer(Customer input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditCustomer(input);
        }
        // Made by Helena Brunsgaard Madsen
        /// <summary>
        /// Edits product in database by productID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EditProduct(Product input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditProduct(input);
        }
        // Made by Mikkel. E.R. Glerup
        /// <summary>
        /// Edits subsription in database by SubscriptionID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EditSubscription(Subscription input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditSubscription(input);
        }
        #endregion
        #region Delete*
        // Made by Mikkel. E.R. Glerup
        /// <summary>
        /// Deletes everything in the database in the column=callerClass at ID=CallerID
        /// </summary>
        /// <param name="callerClass"></param>
        /// <param name="CallerID"></param>
        /// <returns></returns>
        public static bool Delete(string callerClass, int CallerID)
        {
            DBDelete dBDelete = new DBDelete();
            return dBDelete.Delete(callerClass, CallerID);
        }
        #endregion
    }
}