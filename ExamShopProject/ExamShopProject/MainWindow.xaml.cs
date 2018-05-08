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

        private void btn_CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CreateCustomer());
        }

        private void btn_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CreateUser());
        }
    }
}
