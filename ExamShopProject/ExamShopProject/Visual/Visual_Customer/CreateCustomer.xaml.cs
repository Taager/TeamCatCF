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
using ExamShopProject.ErrorHandler;


namespace ExamShopProject
{
    // Made By Helena Brunsgaard Madsen
    public partial class CreateCustomer : Page
    {
        TextBoxCheck check = new TextBoxCheck();
        Customer customer = new Customer();
        CustomerLogic interaction = new CustomerLogic();
        public CreateCustomer()
        {
            InitializeComponent();
            DataContext = customer;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            // Checks input for wrong information
            if (txtbx_City.Text == "" || txtbx_ContactInfo.Text == "" || txtbx_Income.Text == "" || txtbx_Name.Text == "" || txtbx_StreetNumber.Text == "" || txtbx_Zip.Text == "" || txt_SpokesPerson.Text == "")
            {
                CreateMessage.ShowInputNotValid();
            }
            else if (check.CheckTextBoxInputChars(txt_SpokesPerson.Text) == false)
            {
                CreateMessage.ShowInputNotValid();
            }
            else if (check.CheckTextBoxInputInteger(txtbx_Zip.Text) == true || check.CheckTextBoxInputInteger(txtbx_Income.Text) == true)
            {
                CreateMessage.ShowInputNotValid();
            }
            else
            {
            bool wasSuccess = interaction.CreateCustomer(customer);
                if (wasSuccess)
                    CreateMessage.ShowCreateSuccesful("Customer");
                NavigationService.Navigate(new ViewCustomer());
                if (!wasSuccess)
                    CreateMessage.ShowFailureMessage();
            }
        }
    }
}
