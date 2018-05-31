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
    //Made bu Mikkel E.R. Glerup
    /// <summary>
    /// Interaction logic for EditCatalogue.xaml
    /// </summary>
    public partial class EditCatalogue : Page
    {
        bool wasSuccess;
        private List<int> productList { get; set; }
        public EditCatalogue(List<int> tempProductList)
        {
            InitializeComponent();
            productList = tempProductList;
            
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            foreach (int productIDs in productList)
            {
                Product product = DB.SelectProduct(productIDs);
                product.Price = double.Parse(TextBox_Price.Text);
                wasSuccess = DB.EditProduct(product);
            }
            if (wasSuccess == true)
            {
                CreateMessage.ShowEditSuccesful("Product");
                NavigationService.Navigate(new ViewCatalogue());
            }
            if (wasSuccess == false)
            {
                CreateMessage.ShowFailureMessage();
                NavigationService.Navigate(new ViewCatalogue());
            }
        }
    }
}
