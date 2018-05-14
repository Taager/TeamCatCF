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
using ExamShopProject.ErrorHandler;
using ExamShopProject.User_Interactions;
using System.Xaml;
using System.IO;


namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void btn_User_Click(object sender, RoutedEventArgs e) //=> _mainFrame.Navigate(new OpenUser()); overvej, om dette er bedre.
        {
            _mainFrame.Navigate(new OpenUser());
        }
        private void btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenCustomer());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LogIn());
        }
    }
}
