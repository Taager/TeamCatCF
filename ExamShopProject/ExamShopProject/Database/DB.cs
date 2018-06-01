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
            DBSelect dBSelect = new DBSelect();
            return dBSelect.GetUserIdByUsernameAndPassword();
        }
        #region Insert*
        //made by Mikkel. E.R. Glerup
        public static bool InsertUser(User input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertUser(input);
        }
        public static bool InsertCustomer(Customer input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertCustomer(input);
        }
        public static bool InsertProduct(Product input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertProduct(input);
        }
        public static bool InsertSubscription(Subscription input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertSubscription(input);
        }
        public static bool InsertSubscriptionWCategory(Subscription input)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertSubscriptionWCategory(input);
        }
        public static bool InsertDealProduct(Deals deal)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertDealProduct(deal);
        }
        public static bool InsertDealCategory(Deals deal)
        {
            DBInsert dBInsert = new DBInsert();
            return dBInsert.InsertDealCategory(deal);
        }
        #endregion
        #region View*
        // Made by Mikkel E.R. Glerup
        public static List<User> SelectAllUsers()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllUsers();
        }
        //Made by Mikkel E.R. Glerup
        public static User SelectUser(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectUser(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Customer> SelectAllCustomers()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllCustomers();
        }
        public static List<StatDeals> SelectCustomersWithDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCustomersWithDeals();
        }
        // Made by Helena Brunsgaard Madsen
        public static Customer SelectCustomer(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCustomer(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Categories> SelectAllCategories()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllCategories();
        }
        // Made by Helena Brunsgaard Madsen
        public static Categories SelectCategory(int? ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCategory(ID);
        }
        public static List<Categories> SelectCategoriesAndProducts()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectCategoryWithProducts();
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Product> SelectAllProducts()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllProducts();
        }
        // Made by Helena Brunsgaard Madsen
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
        public static List<Subscription> SelectAllSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllSubscriptions();
        }
        public static List<Subscription> SelectActiveSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectActiveSubscriptions();
        }
        public static List<Subscription> SelectInactiveSubscriptions()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectInactiveSubscriptions();
        }
        public static List<Deals> SelectActiveDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectActiveDeals();
        }
        public static List<Deals> SelectInactiveDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectInactiveDeals();
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Deals> SelectAllDeals()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectAllDeals();
        }
        // Made by Helena Brunsgaard Madsen
        public static Deals SelectDeal(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectDeal(ID);
        }
        public static Subscription SelectSubscriptionwithCategory(int ID)
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectSubscriptionwithCategory(ID);
        }
        public static List<StatDeals> SelectDealTypes()
        {
            DBSelect dBSelect = new DBSelect();
            return dBSelect.SelectDealTypes();
        }
        
        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditUser(input);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditCustomer(Customer input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditCustomer(input);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditProduct(Product input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditProduct(input);
        }
        // Made by Mikkel. E.R. Glerup
        public static bool EditSubscription(Subscription input)
        {
            DBEdit dBEdit = new DBEdit();
            return dBEdit.EditSubscription(input);
        }
        #endregion
        #region Delete*
        // Made by Mikkel. E.R. Glerup
        public static bool Delete(string callerClass, int CallerID)
        {
            DBDelete dBDelete = new DBDelete();
            return dBDelete.Delete(callerClass, CallerID);
        }
        #endregion
    }
}