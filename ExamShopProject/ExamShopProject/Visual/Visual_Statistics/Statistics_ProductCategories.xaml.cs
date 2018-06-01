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
        StatProductCategory statProductCategory = new StatProductCategory();
        public Statistics_ProductCategories()
        {
            CalculateStatistics();
            InitializeComponent();
            DataContext = statProductCategory;
        }
        private void CalculateStatistics()
        {
            List<Categories> categoriesList = DB.SelectAllCategories();
            List<Categories> categoryBucket = DB.SelectAllCategories();
            Categories categories = new Categories();
            statProductCategory.TotalCategories = categoriesList.Count;
            List<Product> productsList = DB.SelectAllProducts();
            statProductCategory.TotalProducts = productsList.Count;
            categoryBucket = DB.SelectCategoriesAndProducts();
            //Rangere den category i categoryBucket der er højest sidst i listen
            categoryBucket = categoryBucket.OrderBy(o => o.AmountOfProducts).ToList();
            categories = categoryBucket[categoryBucket.Count - 1];
            statProductCategory.MostPopulatedCategory = categories.Name;
            // Da den category med flest produkter er det højeste tal, må det laveste tal være den med færrest.
            categories = categoryBucket[0];
            statProductCategory.LeastPopulatedCategory = categories.Name;
        }
    }
}
