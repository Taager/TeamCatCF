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
    /// Interaction logic for Statistics_Products.xaml
    /// </summary>
    public partial class Statistics_ProductCategories : Page
    {
        StatProduct statProduct = new StatProduct();
        StatProductCategory statProductCategory = new StatProductCategory();
        public Statistics_ProductCategories()
        {
            CalculateStatistics();
            InitializeComponent();
            if (RadioBtn_Products.IsChecked == true)
                DataContext = statProduct;
            if (RadioBtn_Product_Category.IsChecked == true)
                DataContext = statProductCategory;
        }
        private void CalculateStatistics()
        {
            List<Categories> categoriesList = DB.SelectAllCategories();
            statProductCategory.TotalCategories = categoriesList.Count;
            List<Product> productsList = DB.SelectAllProducts();
            statProduct.TotalProducts = productsList.Count;
            
        }
    }
}
