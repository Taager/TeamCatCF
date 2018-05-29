﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject
{
    //Entire class by Mikkel E.R. Glerup
    class SubscriptionLogic
    {
        public bool CheckEditOrCreate(Subscription input)
        {
            bool wasSuccess = false;
            try
            {
                if (input.SubscriptionID == 0)
                {
                    wasSuccess = CreateSubscription(input);
                    if (wasSuccess == true)
                        throw new SubscriptionWasAdded(input);
                }
                if (input.SubscriptionID > 0)
                {
                    wasSuccess = EditSubscription(input);
                    if (wasSuccess == true)
                        throw new SubscriptionWasEdited(input);
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.WriteEvent(ex);
                return true;
            }
        }
        private bool CreateSubscription(Subscription input)
        {
            return DB.InsertSubscription(input);
        }
        private bool EditSubscription(Subscription input)
        {
            return DB.EditSubscription(input);
        }
        public bool DeleteSubscription(Subscription input, string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.Delete(callerClass, callerID);
                if (wasSucces)
                    throw new SubscriptionWasDeleted(input);
                return wasSucces;
            }
            catch (SubscriptionWasDeleted ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
    }
}
