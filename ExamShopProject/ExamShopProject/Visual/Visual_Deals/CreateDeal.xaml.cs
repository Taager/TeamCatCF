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
using ExamShopProject.Deal_interactions;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for CreateDeal.xaml
    /// </summary>
    // Made by Helena Brunsgaard Madsen
    public partial class CreateDeal : Page
    {
        //public event EventHandler<SelectionChangedEventArgs> SelectedDateChanged;
        TextBoxCheck check = new TextBoxCheck();
        bool wasSuccess;
        Deals deals = new Deals();
        DealLogic interaction = new DealLogic();
        public CreateDeal()
        {
            InitializeComponent();
            deals.StartDate = DateTime.Now;
            deals.EndDate = DateTime.Now;
            DataContext = deals;
            lstbx_Customer.ItemsSource = DB.SelectAllCustomers();
            lstbx_Customer.DisplayMemberPath = "Name";
        }
        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dtpckr_EndDate.IsEnabled = true;
            dtpckr_EndDate.DisplayDateStart = dtpckr_StartDate.SelectedDate.Value;
        }
        private void rdbtn_Product_Checked(object sender, RoutedEventArgs e)
        {
            lstbx_ProductOrCategory.ItemsSource = DB.SelectAllProducts();
            lstbx_ProductOrCategory.DisplayMemberPath = "Name";
        }
        private void rdbtn_Category_Checked(object sender, RoutedEventArgs e)
        {
            lstbx_ProductOrCategory.ItemsSource = DB.SelectAllCategories();
            lstbx_ProductOrCategory.DisplayMemberPath = "Name";
        }
        private void rdbtn_Percent_Checked(object sender, RoutedEventArgs e)
        {
            lbl_Currency.Opacity = 0;
            txtbx_Discount.IsEnabled = true;
            lbl_Percent.Opacity = 100;
            deals.DealType = "percentage";
            //show percent next to textbox 
        }
        private void rdbtn_Currency_Checked(object sender, RoutedEventArgs e)
        {
            lbl_Percent.Opacity = 0;
            txtbx_Discount.IsEnabled = true;
            lbl_Currency.Opacity = 100;
            deals.DealType = "cost";
            //show currency next to textbox
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int customerID = 0;
            List<int> selectedCustomersList = new List<int>();
            for (int i = 0; i < lstbx_Customer.SelectedItems.Count; i++)
            {
                Customer chosenCustomer = (Customer)lstbx_Customer.Items[i];
                customerID = chosenCustomer.customerID;
                selectedCustomersList.Add(customerID);
            }
            int[] arrayOfCustomerIDs = selectedCustomersList.ToArray();
            foreach (int customerIDs in arrayOfCustomerIDs)
            {
                wasSuccess = CreateDeals(customerIDs); // Creates a deal for every customer selected
            }
            if (txtbx_Discount.Text == "" || txtbx_Name.Text == "")
            {
                CreateMessage.ShowInputNotValid();
            }
            else if (check.CheckTextBoxInputInteger(txtbx_Discount.Text) == true)
            {
                CreateMessage.ShowInputNotValid();
            }
            else
            {
                if (wasSuccess)
                    CreateMessage.ShowCreateSuccesful("Deal");
                if (!wasSuccess)
                    CreateMessage.ShowFailureMessage();
                NavigationService.Navigate(new ViewDeals());
            }
        }
        private bool CreateDeals(int customerID)
        {
            try
            {
                deals.CustomerID = customerID;
                if (rdbtn_Category.IsChecked == true) //find out if the deal is made to product or category
                {
                    Categories chosenCategory = (Categories)lstbx_ProductOrCategory.SelectedItem;
                    deals.CategoryID = chosenCategory.CategoryID;
                }
                else if (rdbtn_Product.IsChecked == true)
                {
                    Product chosenProduct = (Product)lstbx_ProductOrCategory.SelectedItem;
                    deals.ProductID = chosenProduct.ProductID;
                }
                return interaction.CreateDeal(deals);
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
