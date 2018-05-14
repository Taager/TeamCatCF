﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;
using System.Data.SqlClient;
using System.Data;

namespace ExamShopProject
{
    class DBDelete
    {
        // Made by Mikkel Glerup
        public static bool DeleteUser(string callerClass, int callerID)
        {
            if (callerClass == null)
            {
                throw new ArgumentNullException(nameof(callerClass));
            }
            try
            {
                DBOpenClose.OpenConnection();
                string tablestring = "[" + callerClass + "]";
                string iDColumn = callerClass + "ID";
                SqlCommand delete = new SqlCommand("DELETE FROM " + tablestring + " WHERE " + iDColumn + " = @ID;", DBOpenClose.myConnection);
                delete.Parameters.Add("@ID", SqlDbType.Int);
                delete.Parameters["@ID"].Value = callerID;
                delete.ExecuteNonQuery();
                DBOpenClose.CloseConnection();
                return true;
            }
            catch (Exception)
            {
                DBOpenClose.CloseConnection();
                return false;
            }
        }
        // Made by Mikkel
        public static bool DeleteCustomer(string callerClass, int callerID)
        {
            if (callerClass == null)
            {
                throw new ArgumentNullException(nameof(callerClass));
            }
            try
            {
                DBOpenClose.OpenConnection();
                string tablestring = "[" + callerClass + "]";
                string iDColumn = callerClass + "ID";
                SqlCommand delete = new SqlCommand("DELETE FROM " + tablestring + " WHERE " + iDColumn + " = @ID;", DBOpenClose.myConnection);
                delete.Parameters.Add("@ID", SqlDbType.Int);
                delete.Parameters["@ID"].Value = callerID;
                delete.ExecuteNonQuery();
                DBOpenClose.CloseConnection();
                return true;
            }
            catch (Exception)
            {
                DBOpenClose.CloseConnection();
                return false;
            }
        }

    }
}
