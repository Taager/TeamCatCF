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
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        #region Insert*
        //made by Mikkel. E.R. Glerup
        public static bool InsertUser(User user)
        {
            return DBInsert.InsertUser(user);
        }
        public static bool InsertCustomer(Customer customer)
        {
            return DBInsert.InsertCustomer(customer);
        }
        public static bool InsertProduct(Product product)
        {
            return DBInsert.InsertProduct(product);
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
        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User user)
        {
            return DBEdit.EditUser(user);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditCustomer(Customer customer)
        {
            return DBEdit.EditCustomer(customer);
        }
        // Made by Helena Brunsgaard Madsen
        public static bool EditProduct(Product product)
        {
            return DBEdit.EditProduct(product);
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