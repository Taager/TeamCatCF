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

                ErrorHandler.Log.WritEvent(ex);
                return true;
            }
        }
        //private void EditCustomer(int IDToEdit)
        //{
        //    // DB command(IDToEdit)
        //}
        //private void DeleteCustomer(int IDToDelete)
        //{
        //    // DB command(IDToDelete)
        //}
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

