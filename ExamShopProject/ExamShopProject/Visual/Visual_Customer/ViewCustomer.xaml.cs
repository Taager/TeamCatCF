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

namespace ExamShopProject
{
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for ViewCustomer.xaml
    /// </summary>
    public partial class ViewCustomer : Page
    {
        Customer customer = new Customer();
        public ViewCustomer()
        {
            InitializeComponent();
            lstbx_Customer.ItemsSource = DB.SelectAllCustomers();
            lstbx_Customer.DisplayMemberPath = "Name";
        }

        private void lstbx_Customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer chosenCustomer = (Customer)lstbx_Customer.SelectedItem;
            NavigationService.Navigate(new ViewCustomerDetails(chosenCustomer.customerID));
        }
        // Made by Mikkel E.R. Glerup
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            var CustomerFiltered = from customer in DB.SelectAllCustomers()
                                   let customerName = customer.Name
                                   where
                                   customerName.StartsWith(TextBox_Search.Text.ToLower())
                                   || customerName.StartsWith(TextBox_Search.Text.ToUpper())
                                   || customerName.Contains(TextBox_Search.Text)
                                   select customer;
            lstbx_Customer.ItemsSource = CustomerFiltered;
        }
    }
}
