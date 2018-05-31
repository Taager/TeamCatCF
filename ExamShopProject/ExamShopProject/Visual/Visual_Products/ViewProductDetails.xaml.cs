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
using ExamShopProject.Product_Interactions;
using ExamShopProject.Object;

namespace ExamShopProject
{
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for ViewProductDetails.xaml
    /// </summary>
    public partial class ViewProductDetails : Page
    {
        ProductLogic interaction = new ProductLogic();
        Product product = new Product();
        Categories category = new Categories();
        public ViewProductDetails(int ID)
        {
            product = DB.SelectProduct(ID);
            category.CategoryID = product.CategoryID;
            InitializeComponent();
            DataContext = product;
            lstbx_Categories.DataContext = category;
            lstbx_Categories.ItemsSource = DB.SelectAllCategories();
            lstbx_Categories.DisplayMemberPath = "Name";
            lstbx_Categories.SelectedItem = category.CategoryID;
        }

        private void btn_DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            bool wasSucces = interaction.DeleteProduct("product", product.ProductID);
            if (wasSucces)
                CreateMessage.ShowDeleteSuccesful("Product");
            if (!wasSucces)
                CreateMessage.ShowFailureMessage();
            NavigationService.Navigate(new ViewProducts());
        }

        private void btn_EditProduct_Click(object sender, RoutedEventArgs e)
        {
            txtbx_Name.IsEnabled = true;
            txtbx_Price.IsEnabled = true;
            txtbx_Description.IsEnabled = true;
            lstbx_Categories.IsEnabled = true;
            lstbx_Categories.SelectedIndex = product.CategoryID; //I want to show user which category the product is in.
            btn_Save.IsEnabled = true;
            btn_EditProduct.IsEnabled = false;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveInfo();
                bool wasSuccess = interaction.EditProduct(product);
                if (wasSuccess)
                    CreateMessage.ShowEditSuccesful("Product");
                if (!wasSuccess)
                    CreateMessage.ShowFailureMessage();
                NavigationService.Navigate(new ViewProductDetails(product.ProductID));
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    CreateMessage.ShowInputNotValid();
                ErrorHandler.Log.WriteFail(ex);
            }
        }
        private void SaveInfo()
        {
                product.Name = txtbx_Name.Text;
                product.Price = Convert.ToDouble(txtbx_Price.Text);
                product.Description = txtbx_Description.Text;
        }
    }
}
