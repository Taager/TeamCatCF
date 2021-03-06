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
using ExamShopProject.Deal_interactions;

namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for ViewDealDetails.xaml
    /// </summary>
    // Madse by Helena Brunsgaard Madsen
    public partial class ViewDealDetails : Page
    {
        Deals deal = new Deals();
        DealLogic interaction = new DealLogic();
        public ViewDealDetails(int ID)
        {
            deal = DB.SelectDeal(ID);            
            InitializeComponent();
            DataContext = deal;
            //refactor into db-->db.select
            Customer selectedCustomer = DB.SelectCustomer(deal.CustomerID);
            txtbx_ChosenCustomer.Text = selectedCustomer.Name;

            txtbx_Discount.Text = Convert.ToString(deal.PriceDecrease) + " " + Convert.ToString(deal.DealType);
            if (deal.CategoryID != 0) // want to show the name of the category or product which the deal has been made to
            {
                lbl_Category.Opacity = 100;
                List<Categories> listOfCategories = new List<Categories>();
            }
            else if (deal.ProductID != 0)
            {
                lbl_Product.Opacity = 100;
                Product selectedProduct = DB.SelectProduct(deal.ProductID);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            bool wasSucces = interaction.DeleteDeal("deals", deal.DealsID); 
            if (wasSucces)
                CreateMessage.ShowDeleteSuccesful("deal");
            if (!wasSucces)
                CreateMessage.ShowFailureMessage();
            NavigationService.Navigate(new ViewDeals());
        }
    }
}
