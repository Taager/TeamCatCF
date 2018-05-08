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

namespace ExamShopProject
{
    // Made by Helena Brunsgaard Madsen
    public partial class CreateCustomer : Page
    {
        Customers customer = new Customers();
        Customer cObj = new Customer();
        public CreateCustomer()
        {
            InitializeComponent();
            DataContext = customer;
        }

        private void btn_SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            customer.CreateCustomer(cObj.Name, cObj.Adress, cObj.ContactInfo, cObj.SpokesPerson, Convert.ToDouble(cObj.AnnualIncome));
            MessageBox.Show("Kunde gemt!");
            this.Content = null;
        }
    }
}
