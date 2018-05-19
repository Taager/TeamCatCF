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
    public partial class ViewSubscriptionsDetails : Page
    {
        Subscription subscription = new Subscription();
        public ViewSubscriptionsDetails(int ID)
        {
            Customer tempCustomer = DB.SelectCustomer(ID);
            subscription = DB.SelectSubcription(ID);
            subscription.CustomerName = tempCustomer.Name;
            subscription.CustomerID = ID;
            InitializeComponent();
            DataContext = subscription;
        }

        private void Btn_Edit_Enable(object sender, RoutedEventArgs e)
        {
            Btn_Save.IsEnabled = true;
            Btn_Delete.IsEnabled = true;
            Btn_Delete.Opacity = 100;
            DatePicker_EndDate.IsEnabled = true;
            CheckBox_AutoRenew.IsEnabled = true;
            ListBox_CategoriesSubscripeTo.IsEnabled = true;
        }
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            bool wasCreate = false;
            subscription.EndDate = DatePicker_EndDate.DisplayDate;
            if (CheckBox_AutoRenew.IsChecked == true)
                subscription.Renew = true;
            if (CheckBox_AutoRenew.IsChecked == false)
                subscription.Renew = false;
            if (subscription.SubscriptionID == 0)
                wasCreate = true;
            //Add categories later
            SubscriptionLogic subscriptionLogic = new SubscriptionLogic();
            bool wasSuccess = subscriptionLogic.CheckEditOrCreate(subscription);
            if (wasSuccess == true)
            {
                if (wasCreate == true)
                    CreateMessage.ShowCreateSuccesful("Subscription");
                if (wasCreate == false)
                    CreateMessage.ShowEditSuccesful("Subscription");
            }
            if (wasSuccess == false)
                CreateMessage.ShowFailureMessage();
        }
        private void Btn_Click_DeleteSubscription(object sender, RoutedEventArgs e)
        {

        }
    }
}
