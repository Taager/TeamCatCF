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
        // MAde by Helena Brunsgaard Madsen
        public static List<Customer> SelectAllCustomers()
        {
            return DBSelect.SelectAllCustomers();
        }
        public static Customer SelectCustomer(int ID)
        {
            return DBSelect.SelectCustomer(ID);
        }

        #endregion
        #region Edit*
        //Made by Mikkel E.R. Glerup
        public static bool EditUser(User user)
        {
            return DBEdit.EditUser(user);
        }
        public static bool EditCustomer(Customer customer)
        {
            return DBEdit.EditCustomer(customer);
        }
        #endregion
        #region Delete*
        public static bool DeleteUser(string callerClass, int CallerID)
        {
            return DBDelete.DeleteUser(callerClass, CallerID);
        }
        public static bool DeleteCustomer(string callerClass, int CallerID)
        {
            return DBDelete.DeleteUser(callerClass, CallerID);
        }
        #endregion
    }
}