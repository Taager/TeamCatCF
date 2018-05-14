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
        // Made by Mikkel Glerup
        public static List<User> SelectAllUsers()
        {
            try
            {
                List<User> userList = new List<User>();
                DBOpenClose.OpenConnection();
                SqlCommand getUsers = new SqlCommand(
                    "SELECT * FROM [User]", DBOpenClose.myConnection);
                SqlDataReader reader = getUsers.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.IsAdmin = reader.GetBoolean(4);
                    userList.Add(user);
                }
                DBOpenClose.CloseConnection();
                return userList;
            }
            catch (Exception ex)
            {
                List<User> userList = new List<User>();
                Log.WriteFail(ex);
                return userList;
            }
        }
        // Made by Mikkel Glerup
        public static User SelectUser(int ID)
        {
            try
            {
                User user = new User();
                DBOpenClose.OpenConnection();
                SqlCommand getUser = new SqlCommand(
                    "SELECT * FROM [User] WHERE UserID=@UserID", DBOpenClose.myConnection);
                getUser.Parameters.Add("@UserID", SqlDbType.Int);
                getUser.Parameters["@UserID"].Value = ID;
                SqlDataReader reader = getUser.ExecuteReader();
                while (reader.Read())
                {
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.IsAdmin = reader.GetBoolean(4);
                }
                DBOpenClose.CloseConnection();
                return user;
            }
            catch (Exception ex)
            {
                User user = new User();
                Log.WriteFail(ex);
                return user;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public static List<Customer> SelectAllCustomers()
        {
            try
            {
                List<Customer> customerList = new List<Customer>();
                DBOpenClose.OpenConnection();
                SqlCommand getCustomers = new SqlCommand(
                    "SELECT * FROM [Customer]", DBOpenClose.myConnection);
                SqlDataReader reader = getCustomers.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.customerID = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customer.StreetAndNumber = reader.GetString(2);
                    customer.ZipCode = reader.GetInt32(3);
                    customer.City = reader.GetString(4);
                    customer.ContactInfo = reader.GetString(5);
                    customer.SpokesPerson = reader.GetString(6);
                    customer.AnnualIncome = reader.GetDouble(7); // commented out, fix later
                    customerList.Add(customer);
                }
                DBOpenClose.CloseConnection();
                return customerList;
            }
            catch (Exception ex)
            {
                List<Customer> customerList = new List<Customer>();
                Log.WriteFail(ex);
                return customerList;
            }
        }
        public static Customer SelectCustomer(int ID)
        {
            try
            {
                Customer customer = new Customer();
                DBOpenClose.OpenConnection();
                SqlCommand getCustomer = new SqlCommand(
                    "SELECT * FROM [Customer] WHERE CustomerID=@CustomerID", DBOpenClose.myConnection);
                getCustomer.Parameters.Add("@CustomerID", SqlDbType.Int);
                getCustomer.Parameters["@CustomerID"].Value = ID;
                SqlDataReader reader = getCustomer.ExecuteReader();
                while (reader.Read())
                {
                    customer.customerID = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customer.StreetAndNumber = reader.GetString(2);
                    customer.ZipCode = reader.GetInt32(3);
                    customer.City = reader.GetString(4);
                    customer.ContactInfo = reader.GetString(5);
                    customer.SpokesPerson = reader.GetString(6);
                    customer.AnnualIncome = reader.GetDouble(7);
                }
                DBOpenClose.CloseConnection();
                return customer;
            }
            catch (Exception ex)
            {
                Customer customer = new Customer();
                Log.WriteFail(ex);
                return customer;
            }
        }


    }
}
