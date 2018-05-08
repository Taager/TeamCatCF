using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamShopProject.Customer_Interactions;
using ExamShopProject.Object;

namespace ExamShopProject.Visual_Customer
{
    // Made by Helena Brunsgaard Madsen
    public partial class CreateCustomer : Page
    {
        CustomerLogic customer = new CustomerLogic();
        Customer cObj = new Customer();
        public CreateCustomer()
        { 
            InitializeComponent(); 
            DataContext = customer; 
        }

        //    For button event:
        //    customer.CreateCustomer(cObj.Name, cObj.Adress, cObj.ContactInfo, cObj.SpokesPerson, Convert.ToDouble(cObj.AnnualIncome));
        //    MessageBox.Show("Customer saved!");
        //    this.Content = null;

    }
}
