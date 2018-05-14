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
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for ShowCustomerInfo.xaml
    /// </summary>
    public partial class ViewCustomerDetails : Page
    {
        Customer cusObj = new Customer();
        CustomerLogic customerLogic = new CustomerLogic();

        public ViewCustomerDetails(int ID)
        {
            InitializeComponent();
            DataContext = cusObj;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            bool wasSucces = customerLogic.DeleteCustomer("customer", cusObj.customerID);
            if (wasSucces)
                MessageBox.Show("User was succesfully deleted");
            if (!wasSucces)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
            NavigationService.Navigate(new ViewUser());
        }
    }
}
