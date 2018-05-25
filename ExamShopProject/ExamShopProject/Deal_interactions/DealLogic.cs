using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject.Deal_interactions
{
    class DealLogic
    {
        Deals deals = new Deals();
        public bool CreateDeal(Deals deal)
        {
            try
            {
                bool wasSuccess = DB.InsertDeal(deal);
                if (wasSuccess)
                    throw new DealWasAdded(deal);
                return false;
            }
            //Only thrown if creating user was a succes
            catch (DealWasAdded ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
    }
}
