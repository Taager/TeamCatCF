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
            return DBSelect.GetUserIdByUsernameAndPassword();
        }
        #region Insert*
        //made by Mikkel. E.R. Glerup
        public static bool InsertUser(User input)
        {
            return DBInsert.InsertUser(input);
        }
        public static bool InsertCustomer(Customer input)
        {
            return DBInsert.InsertCustomer(input);
        }
        public static bool InsertProduct(Product input)
        {
            return DBInsert.InsertProduct(input);
        }
        public static bool InsertSubscription(Subscription input)
        {
            return DBInsert.InsertSubscription(input);
        }
        public static bool InsertDeal(Deals deal)
        {
            return DBInsert.InsertDeal(deal);
        }
        #endregion
        #region viewList*
        // Made by Mikkel E.R. Glerup
        public static List<User> SelectAllUsers()
        {
            return DBSelect.SelectAllUsers();
        }
        //Made by Mikkel E.R. Glerup
        public static User SelectUser(int ID)
        {
            return DBSelect.SelectUser(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Customer> SelectAllCustomers()
        {
            return DBSelect.SelectAllCustomers();
        }
        // Made by Helena Brunsgaard Madsen
        public static Customer SelectCustomer(int ID)
        {
            return DBSelect.SelectCustomer(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Categories> SelectAllCategories()
        {
            return DBSelect.SelectAllCategories();
        }
        // Made by Helena Brunsgaard Madsen
        public static Categories SelectCategory(int ID)
        {
            return DBSelect.SelectCategory(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Product> SelectAllProducts()
        {
            return DBSelect.SelectAllProducts();
        }
        // Made by Helena Brunsgaard Madsen
        public static Product SelectProduct(int ID)
        {
            return DBSelect.SelectProduct(ID);
        }
        public static Subscription SelectSubcription(int ID)
        {
            return DBSelect.SelectSubscription(ID);
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Deals> SelectAllDeals()
        {
            return DBSelect.SelectAllDeals();
        }
        // Made by Helena Brunsgaard Madsen
        public static Deals SelectDeal(int ID)
        {
            return DBSelect.SelectDeal(ID);
        }

        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User input)
        {
            return DBEdit.EditUser(input);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditCustomer(Customer input)
        {
            return DBEdit.EditCustomer(input);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditProduct(Product input)
        {
            return DBEdit.EditProduct(input);
        }
        public static bool EditSubscription(Subscription input)
        {
            return DBEdit.EditSubscription(input);
        }
        #endregion
        #region Delete*
        public static bool Delete(string callerClass, int CallerID)
        {
            return DBDelete.Delete(callerClass, CallerID);
        }
        #endregion
    }
}