using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;
using ExamShopProject.ErrorHandler;
using System.Windows;
using System.Windows.Navigation;

namespace ExamShopProject
{
    // Made by Helena Brunsgaard Madsen
    class CustomerLogic
    {
        Customer customer = new Customer();
        CustomerValidation customerValidation = new CustomerValidation();
        public bool CreateCustomer(Customer customer)
        {
            try
            {
                bool validationSucces = customerValidation.ZipCodeValidation(customer.ZipCode); 
                validationSucces = customerValidation.AnnualIncomeValidation(customer.AnnualIncome); // makes sure the zip code and annual income isn't 0
                if (!validationSucces)
                {
                    CreateMessage.ShowInputNotValid();
                    return false;
                }
                bool wasSuccess = DB.InsertCustomer(customer);
                if (wasSuccess)
                    throw new CustomerWasAdded(customer); // writes in log when customer is added
                return false;
            }
            //Only thrown if creating user was a succes
            catch (CustomerWasAdded ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public bool EditCustomer(Customer customer)
        {
            try
            {
                bool wasSucces = DB.EditCustomer(customer);
                if (wasSucces)
                    throw new CustomerWasEdited(customer); //writes in log when a customer is edited
                return wasSucces;
            }
            catch (CustomerWasEdited ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        // Made by Helena Brunsgaard Madsen
        public bool DeleteCustomer(string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.Delete(callerClass, callerID); 
                if (wasSucces)
                    throw new CustomerWasDeleted(customer); //writes in log when a customer is deleted
                return wasSucces;
            }
            catch (CustomerWasDeleted ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
    }
}

