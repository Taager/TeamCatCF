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
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class Open : Page
    {
        public Open()
        {
            InitializeComponent();
            _viewCustomer.Navigate(new ViewCustomer());
        }

        private void btn_ViewCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewCustomer.Navigate(new ViewCustomer());
        }

        private void btn_CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewCustomer.Navigate(new CreateCustomer());
        }
    }
}
