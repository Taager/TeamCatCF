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
    /// <summary>
    /// Interaction logic for ViewUsersDetail.xaml
    /// </summary>
    public partial class ViewUsersDetail : Page
    {
        User user = new User();
        public ViewUsersDetail(int ID)
        {
           user = DB.SelectUser(ID);
            if (user.IsAdmin)
                user.IsAdminString = "User is admin";
            if (!user.IsAdmin)
                user.IsAdminString = "User is not an admin";
            InitializeComponent();
            DataContext = user;
        }

        private void Btn_Edit_Enable(object sender, RoutedEventArgs e)
        {
            TxtBox_Name.IsEnabled = true;
            TxtBox_Username.IsEnabled = true;
            TxtBox_Password.IsEnabled = true;
            TxtBox_IsAdmin.Opacity = 0;
            CheckBox_IsAdmin.IsEnabled = true;
            CheckBox_IsAdmin.Opacity = 100;
            Btn_Save.Opacity = 100;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            user.Name = TxtBox_Name.Text;
            user.Username = TxtBox_Username.Text;
            user.Password = TxtBox_Password.Text;
            if (CheckBox_IsAdmin.IsChecked == true)
                user.IsAdmin = true;
            if (CheckBox_IsAdmin.IsChecked == false)
                user.IsAdmin = false;
            UserLogic userLogic = new UserLogic();
            bool wasSuccess = userLogic.EditUser(user);
            if (wasSuccess)
                MessageBox.Show("User was edited successfully.");
            if (!wasSuccess)
                MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
            NavigationService.Navigate(new ViewUser());
        }
    }
}
