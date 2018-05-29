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
    public partial class ViewSubscriptionsDetails : Page
    {
        SubscriptionLogic subscriptionLogic = new SubscriptionLogic();
        Subscription subscription = new Subscription();
        public ViewSubscriptionsDetails(int ID)
        {
            Customer tempCustomer = DB.SelectCustomer(ID);
            subscription = DB.SelectSubcription(ID);
            subscription.CustomerName = tempCustomer.Name;
            subscription.CustomerID = ID;
            if (subscription.SubscriptionID == 0)
            {
                subscription.EndDate = DateTime.Now;
            }
            InitializeComponent();
            DataContext = subscription;
            ListBox_CategoriesSubscripeTo.ItemsSource = DB.SelectAllCategories();
            ListBox_CategoriesSubscripeTo.DisplayMemberPath = "Name";
            ListBox_Customer.ItemsSource = DB.SelectAllCustomers();
            ListBox_Customer.DisplayMemberPath = "Name";
        }

        private void Btn_Edit_Enable(object sender, RoutedEventArgs e)
        {
            ListBox_Customer.IsEnabled = true;
            Btn_Save.IsEnabled = true;
            Btn_Delete.IsEnabled = true;
            Btn_Delete.Opacity = 100;
            DatePicker_EndDate.IsEnabled = true;
            CheckBox_AutoRenew.IsEnabled = true;
            ListBox_CategoriesSubscripeTo.IsEnabled = true;
        }
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            CheckEditOrCreate();
            CreateSubscriptionWCategory();
        }
        private void Btn_Click_DeleteSubscription(object sender, RoutedEventArgs e)
        {
            bool wasSuccess = subscriptionLogic.DeleteSubscription(subscription, "Subscription", subscription.SubscriptionID);
            if (wasSuccess == true)
                CreateMessage.ShowDeleteSuccesful("Subscription");
            if (wasSuccess == false)
                CreateMessage.ShowFailureMessage();
            this.Content = null;
            NavigationService.Navigate(new ViewCustomer());
        }
        private void CheckEditOrCreate()
        {
            bool wasCreate = false;
            DateTime now = DateTime.Now;
            // had to cast because DatePicker_EndDate.SelectedDate is DateTime?
            subscription.EndDate = (DateTime)DatePicker_EndDate.SelectedDate;
            subscription.RenewLength = (subscription.EndDate.Month - DateTime.Now.Month);
            if (CheckBox_AutoRenew.IsChecked == true)
                subscription.Renew = true;
            if (CheckBox_AutoRenew.IsChecked == false)
                subscription.Renew = false;
            if (subscription.SubscriptionID == 0)
                wasCreate = true;
            bool wasSuccess = subscriptionLogic.CheckEditOrCreate(subscription);
            if (wasSuccess == true)
            {
                if (wasCreate == true)
                {
                    CreateMessage.ShowCreateSuccesful("Subscription");
                    NavigationService.Navigate(new ViewSubscriptionsDetails(subscription.CustomerID));
                }
                if (wasCreate == false)
                {
                    CreateMessage.ShowEditSuccesful("Subscription");
                    NavigationService.Navigate(new ViewSubscriptionsDetails(subscription.CustomerID));
                }
            }
            if (wasSuccess == false)
                CreateMessage.ShowFailureMessage();
        }
        private void CreateSubscriptionWCategory()
        {
            Categories chosenCategory = (Categories)ListBox_CategoriesSubscripeTo.SelectedItem;
            subscription.CategoryID = chosenCategory.CategoryID;
            bool wasSuccess = subscriptionLogic.CreateSubscriptionWCategory(subscription);
            if (wasSuccess == true)
            {
                    CreateMessage.ShowCreateSuccesful("Subscription");
                    NavigationService.Navigate(new ViewSubscriptionsDetails(subscription.CustomerID));
            }
            if (wasSuccess == false)
                CreateMessage.ShowFailureMessage();
        }
    }
}
