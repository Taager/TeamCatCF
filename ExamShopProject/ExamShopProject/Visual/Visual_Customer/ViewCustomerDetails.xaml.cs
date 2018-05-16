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
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for ShowCustomerInfo.xaml
    /// </summary>
    public partial class ViewCustomerDetails : Page
    {
        Customer customer = new Customer();
        CustomerLogic customerLogic = new CustomerLogic();

        public ViewCustomerDetails(int ID)
        {
            customer = DB.SelectCustomer(ID);
            InitializeComponent();
            DataContext = customer;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            bool wasSucces = customerLogic.DeleteCustomer("customer", customer.customerID);
            if (wasSucces)
                MessageBox.Show("Customer was succesfully deleted");
            if (!wasSucces)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
            NavigationService.Navigate(new ViewUser());
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            txtbx_Name.IsEnabled = true;
            txtbx_AnnualIncome.IsEnabled = true;
            txtbx_City.IsEnabled = true;
            txtbx_ContactInfo.IsEnabled = true;
            txtbx_Spokesperson.IsEnabled = true;
            txtbx_StreetNumber.IsEnabled = true;
            txtbx_Zip.IsEnabled = true;
            btn_Edit.IsEnabled = false;
            btn_Save.IsEnabled = true;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            customer.AnnualIncome = Convert.ToDouble(txtbx_AnnualIncome.Text);
            customer.City = txtbx_City.Text;
            customer.ContactInfo = txtbx_ContactInfo.Text;
            customer.Name = txtbx_Name.Text;
            customer.SpokesPerson = txtbx_Spokesperson.Text;
            customer.StreetAndNumber = txtbx_StreetNumber.Text;
            customer.ZipCode = Convert.ToInt32(txtbx_Zip.Text);

            bool wasSuccess = customerLogic.EditCustomer(customer);
            if (wasSuccess)
                MessageBox.Show("Customer was edited successfully.");
            if (!wasSuccess)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
            NavigationService.Navigate(new ViewCustomerDetails(customer.customerID));

        }
    }
}
