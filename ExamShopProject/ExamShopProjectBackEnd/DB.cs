using System;
//using ExamShopProject.ErrorHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace ExamShopProjectBackEnd
{
    // made by Brian K. Petersen
    static class DB
    {
        #region open and close connection
        //made by Mikkel. E.R. Glerup
        public static SqlConnection myConnection;
        private static bool openConnection()
        {
            try
            {
                myConnection = new SqlConnection(
                    "Data Source=.;Initial Catalog=Charlie-APE;Integrated Security=True"
                    );
                myConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                //Log.WriteFail(ex);
                return false;
            }
        }
        private static bool closeConnection()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log.WriteFail(ex);
                return false;
            }
        }
        #endregion

        #region import/export catalogue

        #endregion
    }
}
