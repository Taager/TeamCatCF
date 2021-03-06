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
                CreateMessage.ShowDeleteSuccesful("Customer");
            if (!wasSucces)
                CreateMessage.ShowFailureMessage();
            NavigationService.Navigate(new ViewCustomer());
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            txtbx_Name.IsReadOnly = false;
            txtbx_AnnualIncome.IsReadOnly = false;
            txtbx_City.IsReadOnly = false;
            txtbx_ContactInfo.IsReadOnly = false;
            txtbx_Spokesperson.IsReadOnly = false;
            txtbx_StreetNumber.IsReadOnly = false;
            txtbx_Zip.IsReadOnly = false;
            btn_Edit.IsEnabled = false;
            btn_Save.IsEnabled = true;
            btn_delete.IsEnabled = true;
            btn_delete.Opacity = 100;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveInfo();
                bool wasSuccess = customerLogic.EditCustomer(customer);
                if (wasSuccess)
                    CreateMessage.ShowEditSuccesful("Customer");
                if (!wasSuccess)
                    CreateMessage.ShowFailureMessage();
                NavigationService.Navigate(new ViewCustomerDetails(customer.customerID));
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    CreateMessage.ShowInputNotValid();
                ErrorHandler.Log.WriteFail(ex);
            }
        }
        private void SaveInfo()
        {
                //AnnualIncome create validation
                customer.AnnualIncome = Convert.ToDouble(txtbx_AnnualIncome.Text);
                customer.City = txtbx_City.Text;
                customer.ContactInfo = txtbx_ContactInfo.Text;
                customer.Name = txtbx_Name.Text;
                customer.SpokesPerson = txtbx_Spokesperson.Text;
                customer.StreetAndNumber = txtbx_StreetNumber.Text;
                //ZipCode create validation
                customer.ZipCode = Convert.ToInt32(txtbx_Zip.Text);
        }

        private void Btn_Subscriptions_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = null;
            NavigationService.Navigate(new ViewSubscriptionsDetails(customer.customerID));
        }
    }
}
