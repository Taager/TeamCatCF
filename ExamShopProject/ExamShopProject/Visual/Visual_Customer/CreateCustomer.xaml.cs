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
using ExamShopProject.Object;
using ExamShopProject.Customer_Interactions;

namespace ExamShopProject
{
    // Made By Helena Brunsgaard Madsen
    public partial class CreateCustomer : Page
    {
        Customer customer = new Customer();
        CustomerLogic interaction = new CustomerLogic();
        public CreateCustomer()
        {
            InitializeComponent();
            DataContext = customer;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            interaction.CreateCustomer(customer.Name, customer.Adress, customer.ContactInfo, customer.SpokesPerson, customer.AnnualIncome);
            MessageBox.Show("Successfully saved!");
            this.Content = null;
        }
    }
}
