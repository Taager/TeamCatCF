using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject.Deal_interactions
{
    // Made by Helena Brunsgaard Madsen
    class DealLogic
    {
        Deals deals = new Deals();
        public bool CreateDeal(Deals deal)
        {
            try
            {
                if (deal.ProductID > 0 && deal.CategoryID == null) // checks if it is product og catogory which have been made a deal to.
                {
                    bool wasSuccess = DB.InsertDealProduct(deal);
                    if (wasSuccess)
                        throw new DealWasAdded(deal); // writes in log when deal is added 
                }
                else if (deal.CategoryID > 0 && deal.ProductID == null)
                {
                    bool wasSuccess = DB.InsertDealCategory(deal);
                    if (wasSuccess)
                        throw new DealWasAdded(deal);
                }
                return false;
            }
            //Only thrown if creating user was a succes
            catch (DealWasAdded ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        public bool DeleteDeal(string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.Delete(callerClass, callerID);
                if (wasSucces)
                    throw new DealWasDeleted(deals); //writes in log when a deal is deleted
                return wasSucces;
            }
            catch (DealWasDeleted ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }

    }
}
