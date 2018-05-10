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
using ExamShopProject.User_Interactions;

namespace ExamShopProject
{
    // Made By Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        User user = new User();
        public CreateUser()
        {
            InitializeComponent();
            DataContext = user;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            bool isAdmin=false;
            UserLogic userLogic = new UserLogic();
            if (CheckBox_IsAdmin.IsChecked == true)
                isAdmin = true;
            if (CheckBox_IsAdmin.IsChecked == false)
                isAdmin = false;
            bool wasSuccess = userLogic.CreateUser(user.Name = TxtBox_Name.Text, user.IsAdmin = isAdmin);
            if (wasSuccess)
                MessageBox.Show("User was created successfully.");
            if (!wasSuccess)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
        }
    }
}
