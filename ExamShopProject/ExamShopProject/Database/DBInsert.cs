﻿using System;
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
                    "INSERT INTO Customer ([Name], StreetAndNumber, ZipCode, City, ContactInfo, SpokesPerson, AnnualIncome) VALUES (@Name, @StreetAndNumber, @ZipCode, @City, @ContactInfo, @SpokesPerson, @AnnualIncome)", DBOpenClose.myConnection);
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
    }
}
