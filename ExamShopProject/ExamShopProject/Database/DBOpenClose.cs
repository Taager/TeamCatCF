using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.ErrorHandler;
using System.Configuration;

namespace ExamShopProject
{
    class DBOpenClose
    {
        //made by Mikkel. E.R. Glerup
        public static string conStr = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        public static bool OpenConnection(SqlConnection conn)
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
        //Made by Mikkel E.R. Glerup
        public static bool CloseConnection(SqlConnection conn)
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
    }
}
