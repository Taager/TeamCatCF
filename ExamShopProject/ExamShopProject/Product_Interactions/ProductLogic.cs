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
            //Only thrown if creating user was a succes
            catch (ProductWasAdded ex)
            {

                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        private void EditProduct()
        {

        }
        private void DeleteProduct()
        {

        }
        private void UpdateProduct()
        {

        }
        private void CalcTax()
        {

        }
        private void CheckDiscount()
        {

        }
    }
}
