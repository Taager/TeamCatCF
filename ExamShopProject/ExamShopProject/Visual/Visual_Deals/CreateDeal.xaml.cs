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

namespace ExamShopProject.Visual.Visual_Deals
{
    /// <summary>
    /// Interaction logic for CreateDeal.xaml
    /// </summary>
    public partial class CreateDeal : Page
    {
        Deals deals = new Deals();
        public CreateDeal()
        {
            InitializeComponent();
            DataContext = deals;
            lstbx_Customer.ItemsSource = DB.SelectAllCustomers();
            lstbx_Customer.DisplayMemberPath = "Name";

            if (rcbtn_Percent.IsChecked == true)
            {
                txtbx_Discount.IsEnabled = true;
                txtbx_Discount.SetBinding(TextBox.TextProperty, "Percent");
                //show percent in textbox
            }
            else if (rdbtn_Currency.IsChecked == true)
            {
                txtbx_Discount.IsEnabled = true;
                txtbx_Discount.SetBinding(TextBox.TextProperty, "Currency");
                //show currency in textbox
            }
            else
            {
                txtbx_Discount.IsEnabled = false;
            }
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
    }
}
