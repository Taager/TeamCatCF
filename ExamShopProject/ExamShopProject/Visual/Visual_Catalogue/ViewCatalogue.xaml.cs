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
    /// Interaction logic for ViewCatalogue.xaml
    /// </summary>
    public partial class ViewCatalogue : Page
    {
        public ViewCatalogue()
        {
            InitializeComponent();
            ListBox_Categories.ItemsSource = DB.SelectAllCategories();
            ListBox_Categories.DisplayMemberPath = "Name";
            ListBox_Products.ItemsSource = DB.SelectAllProducts();
            ListBox_Products.DisplayMemberPath = "Name";
        }

        private void ListBox_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categories chosenCategory = (Categories)ListBox_Categories.SelectedItem;
            var ProductFiltered = from category in DB.SelectAllProducts()
                                  let categoryID = category.CategoryID
                                  where
                                  categoryID.Equals(chosenCategory.CategoryID)
                                  select category;
            ListBox_Products.ItemsSource = ProductFiltered;
        }

        private void ListBox_Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
