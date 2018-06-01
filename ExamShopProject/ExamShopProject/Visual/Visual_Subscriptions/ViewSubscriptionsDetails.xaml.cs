using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    public partial class ViewSubscriptionsDetails : Page
    {
        SubscriptionLogic subscriptionLogic = new SubscriptionLogic();
        Subscription subscription = new Subscription();
        Categories category = new Categories();
        SubscribedToCategory subCat = new SubscribedToCategory();
        bool wasSuccess;
        public ViewSubscriptionsDetails(int ID)
        {
            Customer tempCustomer = DB.SelectCustomer(ID);
            subscription = DB.SelectSubcription(ID);
            subscription.CustomerName = tempCustomer.Name;
            subscription.CustomerID = ID;
            //subCat.SubscriptionID = subscription.SubscriptionID;
            if (subscription.SubscriptionID == 0)
            {
                subscription.EndDate = DateTime.Now;
            }
            InitializeComponent();
            DataContext = subscription;
            ListBox_CategoriesSubscripeTo.ItemsSource = DB.SelectAllCategories();
            ListBox_CategoriesSubscripeTo.DisplayMemberPath = "Name";
            List<Categories> selectedSubscriptionCategory = DB.SelectSubscriptionwithCategory(subscription.SubscriptionID);
            txtbx_Customer.Text = tempCustomer.Name;
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
            if (subscription.SubscriptionID > 0)
            {
                int categoryID = 0;
                List<int> selectedCategoriesList = new List<int>();
                for (int i = 0; i < ListBox_CategoriesSubscripeTo.SelectedItems.Count; i++)
                {
                    Categories chosenCategory = (Categories)ListBox_CategoriesSubscripeTo.Items[i];
                    categoryID = chosenCategory.CategoryID;
                    selectedCategoriesList.Add(categoryID);
                }
                int[] arrayOfCategoryIDs = selectedCategoriesList.ToArray();
                foreach (int categoryIDs in arrayOfCategoryIDs)
                {
                    subCat.CategoryID = categoryID;
                    wasSuccess = CreateSubscriptionWCategory(subCat); // Creates a subscription for every category subscribed to
                }
            }
            CheckEditOrCreate();
            //CreateSubscriptionWCategory();
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
            bool wasSuccess = subscriptionLogic.CheckEditOrCreate(subscription, subCat);
            if (wasSuccess == true)
            {
                if (wasCreate == true)
                {
                    CreateMessage.ShowCreateSuccesful("Subscription");
                    NavigationService.Navigate(new ViewSubscriptionsDetails(subscription.CustomerID));
                    Subscription updated = new Subscription();
                    updated = DB.SelectSubcription(subscription.CustomerID);
                    subCat.SubscriptionID = updated.SubscriptionID;
                    int categoryID = 0;
                    List<int> selectedCategoriesList = new List<int>();
                    for (int i = 0; i < ListBox_CategoriesSubscripeTo.SelectedItems.Count; i++)
                    {
                        Categories chosenCategory = (Categories)ListBox_CategoriesSubscripeTo.Items[i];
                        categoryID = chosenCategory.CategoryID;
                        selectedCategoriesList.Add(categoryID);
                    }
                    int[] arrayOfCategoryIDs = selectedCategoriesList.ToArray();
                    foreach (int categoryIDs in arrayOfCategoryIDs)
                    {
                        subCat.CategoryID = categoryID;
                        wasSuccess = CreateSubscriptionWCategory(subCat); // Creates a subscription for every category subscribed to
                    }
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
        private bool CreateSubscriptionWCategory(SubscribedToCategory subCat)
        {
            try
            {
                return subscriptionLogic.CreateSubscriptionWCategory(subCat);
            }
            catch (Exception ex)
            {
                ErrorHandler.Log.WriteFail(ex);
                CreateMessage.ShowInputNotValid();
                return false;
            }

        }
    }
}
