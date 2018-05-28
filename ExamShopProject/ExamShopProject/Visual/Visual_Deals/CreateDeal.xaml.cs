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
    /// <summary>
    /// Interaction logic for CreateDeal.xaml
    /// </summary>
    /// Made by Helena Brunsgaard Madsen
    public partial class CreateDeal : Page
    {
        Deals deals = new Deals();
        public CreateDeal()
        {
            InitializeComponent();
            deals.EndDate = DateTime.Now;
            deals.StartDate = DateTime.Now;
            DataContext = deals;
            lstbx_Customer.ItemsSource = DB.SelectAllCustomers();
            lstbx_Customer.DisplayMemberPath = "Name";
        }

        private void btn_Product_Click(object sender, RoutedEventArgs e)
        {
            lstbx_ProductOrCategory.ItemsSource = DB.SelectAllProducts();
            lstbx_ProductOrCategory.DisplayMemberPath = "Name";
        }

        private void btn_Category_Click(object sender, RoutedEventArgs e)
        {
            lstbx_ProductOrCategory.ItemsSource = DB.SelectAllCategories();
            lstbx_ProductOrCategory.DisplayMemberPath = "Name";
        }

        private void rdbtn_Percent_Checked(object sender, RoutedEventArgs e)
        {
            lbl_Currency.Opacity = 0;
            txtbx_Discount.IsEnabled = true;
            lbl_Percent.Opacity = 100;
            deals.DealType = "%";
            //show percent in textbox
        }
        private void rdbtn_Currency_Checked(object sender, RoutedEventArgs e)
        {
            lbl_Percent.Opacity = 0;
            txtbx_Discount.IsEnabled = true;
            lbl_Currency.Opacity = 100;
            deals.DealType = "kr.";
            //show currency in textbox
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            // Get customer ID
            // Get Product or category ID
        }
    }
}
