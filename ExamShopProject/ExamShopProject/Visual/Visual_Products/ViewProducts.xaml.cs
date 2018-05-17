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
            _productsView.Navigate(new ViewProductDetails(chosenProduct.ProductID));
        }
    }
}
