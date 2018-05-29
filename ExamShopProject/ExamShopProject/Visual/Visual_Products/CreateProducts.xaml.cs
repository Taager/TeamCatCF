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
using ExamShopProject.Product_Interactions;

namespace ExamShopProject
{
    //Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for CreateProducts.xaml
    /// </summary>
    public partial class CreateProducts : Page
    {
        Product product = new Product();
        ProductLogic interaction = new ProductLogic();
        public CreateProducts()
        {
            InitializeComponent();
            DataContext = product;
            lstbx_Categories.ItemsSource = DB.SelectAllCategories();
            lstbx_Categories.DisplayMemberPath = "Name";
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Categories chosenCategory = (Categories)lstbx_Categories.SelectedItem;
            product.CategoryID = chosenCategory.CategoryID;
            bool wasSuccess = interaction.CreateProduct(product);
            if (wasSuccess)
                MessageBox.Show("Product was created successfully.");
            if (!wasSuccess)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
            this.Content = null;
            NavigationService.Navigate(new ViewProducts());
        }
    }
}
