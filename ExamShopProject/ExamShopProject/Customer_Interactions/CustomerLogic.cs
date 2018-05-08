using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;

namespace ExamShopProject.Customer_Interactions
{
    // Made by Helena Brunsgaard Madsen
    class CustomerLogic
    {
        Customer customer = new Customer();

        public void CreateCustomer(string name, string adress, string contactInfo, string spokesPerson, double annualIncome)
        {
            // DB command (name, adress, contactInfo, spokesPerson)
        }
        private void EditCustomer(int IDToEdit)
        {
            // DB command(IDToEdit)
        }
        private void DeleteCustomer(int IDToDelete)
        {
            // DB command(IDToDelete)
        }
        private void ViewCustomer()
        {
            // DB command
        }
        private void ViewCustomerStat()
        {
            // Stat command
        }
        public void Log()
        {
            // Log command
        }
    }
}
