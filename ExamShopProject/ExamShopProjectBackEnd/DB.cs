using System;
//using ExamShopProject.ErrorHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using System.Data;
using System.Threading;

namespace ExamShopProjectBackEnd
{
    // made by Brian K. Petersen
    static class DB
    {
        #region open and close connection
        //made by Mikkel. E.R. Glerup
        public static SqlConnection myConnection;
        private static bool OpenConnection()
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
        private static bool CloseConnection()
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
        public static bool ImportCatalogue(string fileName)
        {
            if (File.Exists(fileName))
            {

                bool succes = OutdateProducts();

                OpenConnection();
                SqlCommand import = new SqlCommand("BULK INSERT [Product] FROM '"+ @fileName + "' WITH(CODEPAGE = '1252', FIRSTROW = 2, ROWTERMINATOR = '0x0a', FIELDTERMINATOR = ';'); ", myConnection);
                import.ExecuteNonQuery();
                CloseConnection();

                
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool OutdateProducts()
        {
            OpenConnection();
            SqlCommand move = new SqlCommand("INSERT INTO dbo.OldProducts (ProductID, [Name], [Description], [Price], [CategoryId], OutdatedDate) SELECT ProductID, [Name], [Description], [Price], [CategoryId], SYSDATETIME() FROM dbo.Product", myConnection);
            move.ExecuteNonQuery();
            SqlCommand delete = new SqlCommand("DELETE FROM dbo.Product", myConnection);
            delete.ExecuteNonQuery();
            CloseConnection();
            return true;

        }

        public static bool ExportCatalogue()
        {
            try
            {
                OpenConnection();
                List<Deals> deals = SelectAllActiveDeals();
                SqlCommand getSubscription = new SqlCommand(
                    "SELECT S.[SubscriptionID], C.[Name], C.CustomerID FROM dbo.Subscription as S, dbo.Customer as C WHERE C.[CustomerID] = S.[CustomerID] AND S.EndDate > SYSDATETIME()", myConnection);
                SqlDataReader reader = getSubscription.ExecuteReader();
                while (reader.Read())
                {
                    int subscriptionID = Convert.ToInt32(reader["SubscriptionID"]);
                    int customerID = Convert.ToInt32(reader["CustomerID"]);
                    string customerName = Convert.ToString(reader["Name"]);
                    string fileName = customerName + DateTime.Today.ToString();

                    StreamWriter customerCatalogue = FileManager.CreateExportFileHeader(fileName);

                    SqlCommand getSubscribedProducts = new SqlCommand(
                    "SELECT * FROM [dbo].[Product] as P WHERE EXISTS( SELECT * FROM dbo.SubscribedToCategories as STC WHERE STC.[SubscriptionID] = @SubscriptionID AND STC.CategoryID=P.CategoryID)", myConnection);
                    getSubscribedProducts.Parameters.Add("@SubscriptionID", SqlDbType.Int);
                    getSubscribedProducts.Parameters["@SubscriptionID"].Value = subscriptionID;
                    SqlDataReader productReader = getSubscribedProducts.ExecuteReader();
                    while (productReader.Read())
                    {
                        int productID = Convert.ToInt32(reader["ProductID"]);
                        int categoryID = Convert.ToInt32(reader["CategoryID"]);
                        string productName = Convert.ToString(reader["Name"]);
                        string productDesc = Convert.ToString(reader["Description"]);
                        double productPrice = Convert.ToDouble(reader["Price"]);

                        Deals result = new Deals();
                        if (deals.Exists(x => x.ProductID == productID && x.CustomerID == customerID))
                        {
                            result = deals.Find(x => x.ProductID == productID && x.CustomerID == customerID);
                        }
                        else if (deals.Exists(x => x.CategoryID == categoryID && x.CustomerID == customerID))
                        {
                            result = deals.Find(x => x.CategoryID == categoryID && x.CustomerID == customerID);
                        }
                        else if (deals.Exists(x => x.ProductID == productID))
                        {
                            result = deals.Find(x => x.ProductID == productID );
                        }
                        else if (deals.Exists(x => x.CategoryID == categoryID))
                        {
                            result = deals.Find(x => x.CategoryID == categoryID );
                        }

                        if (result.DealType == "percentage")
                        {
                            productPrice = productPrice * (1 - result.PriceDecrease);
                        }
                        else if(result.DealType == "cost")
                        {
                            productPrice = productPrice - result.PriceDecrease;
                        }


                        string productLine =  productID.ToString() + ";" + productName + ";" + productDesc + ";" + productPrice.ToString() + ";";
                        bool lineWritten = FileManager.WriteExportProductLine(customerCatalogue, productLine);
                        if (!lineWritten)
                        {
                            return false;
                        }
                    }
                    customerCatalogue.Close();

                    bool succes = FileManager.ExportFile(fileName);

                }
                CloseConnection();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        private static List<Deals> SelectAllActiveDeals()
        {
            try
            {
                Deals deal = new Deals();
                OpenConnection();
                List<Deals> dealsList = new List<Deals>();
                SqlCommand getDeals = new SqlCommand(
                    "SELECT PriceDecrease, DealType, CategoryID, ProductID, CustomerID FROM [Deals] WHERE StartDate < SYSDATETIME() AND EndDateTime > SYSDATETIME()", myConnection);
                SqlDataReader reader = getDeals.ExecuteReader();
                while (reader.Read())
                {
                    Deals deals = new Deals();
                    deals.PriceDecrease = reader.GetDouble(0);
                    deals.DealType = reader.GetString(1);
                    deals.CategoryID = reader.GetInt32(2);
                    deals.ProductID = reader.GetInt32(3);
                    deals.CustomerID = reader.GetInt32(4);
                    dealsList.Add(deals);
                }
                CloseConnection();
                return dealsList;
            }
            catch (Exception ex)
            {
                /*SqlConnection con = new SqlConnection(DBOpenClose.conStr);
                DBOpenClose.CloseConnection(con);
                List<Deals> dealsList = new List<Deals>();
                Log.WriteFail(ex);
                */List<Deals> dealsList = new List<Deals>();
                return dealsList;
            }
        }

        public static void RenewSubscriptions()
        {
            do
            {
                OpenConnection();
                SqlCommand renew = new SqlCommand("UPDATE dbo.Subscription SET EndDate=DATEADD(m, RenewLength, EndDate) WHERE Renew=1 AND EndDate<SYSDATETIME()", myConnection);
                renew.ExecuteNonQuery();
                CloseConnection();
                Thread.Sleep(900000);
            } while (true);
        }
    }
}
