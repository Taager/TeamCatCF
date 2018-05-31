using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject.Product_Interactions
{
    // Made by Helena Brunsgaard Madsen
    class ProductLogic
    {
        Product product = new Product();
        public bool CreateProduct(Product product)
        {
            try
            {
                bool wasSuccess = DB.InsertProduct(product);
                if (wasSuccess)
                    throw new ProductWasAdded(product);
                return false;
            }
            //Only thrown if creating product was a success
            catch (ProductWasAdded ex)
            {

                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        public bool EditProduct(Product product)
        {
            try
            {
                bool wasSucces = DB.EditProduct(product);
                if (wasSucces)
                    throw new ProductWasEdited(product); //writes in log when a product is edited
                return wasSucces;
            }
            catch (ProductWasEdited ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
            public bool DeleteProduct(string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.Delete(callerClass, callerID); 
                if (wasSucces)
                    throw new ProductWasDeleted(product); //writes in log when a product is deleted
                return wasSucces;
            }
            catch (ProductWasDeleted ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        //private void UpdateProduct()
        //{

        //}
        //private void CalcTax()
        //{

        //}
        //private void CheckDiscount()
        //{

        //}
    }
}
