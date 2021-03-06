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

namespace ExamShopProject
{
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for OpenProducts.xaml
    /// </summary>
    public partial class OpenProducts : Page
    {
        public OpenProducts()
        {
            InitializeComponent();
            _products.Navigate(new ViewProducts());
            if (CurrentUser.isAdmin == true)
            {
                btn_CreateProducts.IsEnabled = true;
            }
        }

        private void btn_ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            _products.Navigate(new ViewProducts());
        }

        private void btn_CreateProducts_Click(object sender, RoutedEventArgs e)
        {
            _products.Navigate(new CreateProducts());
        }
    }
}
