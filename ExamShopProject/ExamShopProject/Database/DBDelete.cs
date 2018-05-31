using System;
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
        public bool Delete(string callerClass, int callerID) // can be used for every element wanted deleted in Database
        {
            if (callerClass == null)
            {
                throw new ArgumentNullException(nameof(callerClass));
            }
            try
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.OpenConnection(con);
                string tablestring = "[" + callerClass + "]";
                string iDColumn = callerClass + "ID";
                SqlCommand delete = new SqlCommand("DELETE FROM " + tablestring + " WHERE " + iDColumn + " = @ID;", con);
                delete.Parameters.Add("@ID", SqlDbType.Int);
                delete.Parameters["@ID"].Value = callerID;
                delete.ExecuteNonQuery();
                DBOpenClose.CloseConnection(con);
                return true;
            }
            catch (Exception)
            {
                SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                return false;
            }
        }
    }
}
