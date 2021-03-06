﻿using System;
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
    // Made by Mikkel E.R. Glerup
    /// <summary>
    /// Interaction logic for ViewCatalogue.xaml
    /// </summary>
    public partial class ViewCatalogue : Page
    {
        //Whole class by Mikkel E.R. Glerup
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
            //User choses Category(ID) method then add object to var where the chosen ID = products.CategoryID
            var ProductFiltered = from category in DB.SelectAllProducts()
                                  let categoryID = category.CategoryID
                                  where
                                  categoryID.Equals(chosenCategory.CategoryID)
                                  select category;
            ListBox_Products.ItemsSource = ProductFiltered;
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            int productID = 0;
            List<int> selectedProductList = new List<int>();
            for (int i = 0; i < ListBox_Products.SelectedItems.Count; i++)
            {
                Product chosenProduct = (Product)ListBox_Products.Items[i];
                productID = chosenProduct.ProductID;
                selectedProductList.Add(productID);
            }
            NavigationService.Navigate(new EditCatalogue(selectedProductList));

        }
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            var CustomerFiltered = from product in DB.SelectAllProducts()
                                   let ProductName = product.Name
                                   where
                                   ProductName.StartsWith(TextBox_Search.Text.ToLower())
                                   || ProductName.StartsWith(TextBox_Search.Text.ToUpper())
                                   || ProductName.Contains(TextBox_Search.Text)
                                   select product;
            ListBox_Products.ItemsSource = CustomerFiltered;
        }
    }
}
