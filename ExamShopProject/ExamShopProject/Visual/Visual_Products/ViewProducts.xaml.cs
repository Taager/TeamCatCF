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
    /// Interaction logic for ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Page
    {
        public ViewProducts()
        {
            InitializeComponent();
            lstbx_Products.ItemsSource = DB.SelectAllProducts();
            lstbx_Products.DisplayMemberPath = "Name";
        }

        private void lstbx_Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                Product chosenProduct = (Product)lstbx_Products.SelectedItem;
                NavigationService.Navigate(new ViewProductDetails(chosenProduct.ProductID));
        }
        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            var ProductFiltered = from product in DB.SelectAllProducts()
                                   let productName = product.Name
                                   where
                                   productName.StartsWith(TextBox_Search.Text.ToLower())
                                   || productName.StartsWith(TextBox_Search.Text.ToUpper())
                                   || productName.Contains(TextBox_Search.Text)
                                   select product;
            lstbx_Products.ItemsSource = ProductFiltered;
        }
    }
}
