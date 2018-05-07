using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;

namespace ExamShopProject.Customer_Interactions
{
    // Made by Helena Brunsgaard Madsen
    class Customers
    {
        Customer customer = new Customer();
        string name, adress, contactInfo, spokesPerson;
        float annualIncome;

        private void ViewCustomer()
        {
            // DB command
        }
        private void CreateCustomer()
        {
            // DB command (name, adress, contactInfo, spokesPerson)
        }
        private void EditCustomer()
        {
            // DB command(IDToEdit)
        }
        private void DeleteCustomer()
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
