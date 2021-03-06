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
    /// <summary>
    /// Interaction logic for ViewDeals.xaml
    /// </summary>
    // Made by Helena Brunsgaard Madsen
    public partial class ViewDeals : Page
    {
        public ViewDeals()
        {
            InitializeComponent();
            lstbx_Deals.ItemsSource = DB.SelectAllDeals();
            lstbx_Deals.DisplayMemberPath = "Name";
        }

        private void lstbx_Deals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Deals chosenDeal = (Deals)lstbx_Deals.SelectedItem;
            NavigationService.Navigate(new ViewDealDetails(chosenDeal.DealsID));
        }
        //By Mikkel E.R. Glerup
        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            var dealFiltered = from deal in DB.SelectAllDeals()
                                  let dealName = deal.Name
                                  where
                                  dealName.StartsWith(TextBox_Search.Text.ToLower())
                                  || dealName.StartsWith(TextBox_Search.Text.ToUpper())
                                  || dealName.Contains(TextBox_Search.Text)
                                  select deal;
            lstbx_Deals.ItemsSource = dealFiltered;
        }
    }
}
