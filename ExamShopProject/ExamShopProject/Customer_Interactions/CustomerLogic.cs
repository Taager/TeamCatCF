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
                validationSucces = customerValidation.AnnualIncomeValidation(customer.AnnualIncome);
                if (!validationSucces)
                {
                    MessageBox.Show("Zip code or annual incomes values were incorrect, try again.");
                    return false;
                }
                bool wasSuccess = DB.InsertCustomer(customer);
                if (wasSuccess)
                    throw new CustomerWasAdded(customer);
                return false;
            }
            //Only thrown if creating user was a succes
            catch (CustomerWasAdded ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        public bool EditCustomer(int IDToEdit)
        {
            try
            {
                bool wasSucces = DB.EditCustomer(customer);
                if (wasSucces)
                    throw new CustomerWasEdited(customer);
                return wasSucces;
            }
            catch (CustomerWasEdited ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        public bool DeleteCustomer(string callerClass, int callerID)
        {
            try
            {
                bool wasSucces = DB.DeleteCustomer(callerClass, callerID);
                if (wasSucces)
                    throw new CustomerWasDeleted(customer);
                return wasSucces;
            }
            catch (CustomerWasDeleted ex)
            {
                ErrorHandler.Log.WriteEvent(ex);
                return true;
            }
        }
        //private void ViewCustomer()
        //{
        //    // DB command
        //}
        //private void ViewCustomerStat()
        //{
        //    // Stat command
        //}
        //public void Log()
        //{
        //    // Log command
        //}
    }
}

