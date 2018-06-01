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
    //Made by Mikkel E.R. Glerup
    public partial class ViewUsersDetail : Page
    {
        UserLogic userLogic = new UserLogic();
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
            if (CurrentUser.isAdmin == true)
            {
                Btn_Edit.IsEnabled = true;
                Btn_Delete.IsEnabled = true;
            }
        }
        //Made by Mikkel E.R. Glerup
        private void Btn_Edit_Enable(object sender, RoutedEventArgs e)
        {
            Btn_Edit.IsEnabled = false;
            TxtBox_Name.IsReadOnly = false;
            TxtBox_Username.IsReadOnly = false;
            TxtBox_Password.IsReadOnly = false;
            TxtBox_IsAdmin.Opacity = 0;
            CheckBox_IsAdmin.IsEnabled = true;
            CheckBox_IsAdmin.Opacity = 100;
            Btn_Save.IsEnabled = true;
            Btn_Delete.IsEnabled = true;
            Btn_Delete.Opacity = 100;
        }
        //Made by Mikkel E.R. Glerup
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            user.Name = TxtBox_Name.Text;
            user.Username = TxtBox_Username.Text;
            user.Password = TxtBox_Password.Text;
            if (CheckBox_IsAdmin.IsChecked == true)
                user.IsAdmin = true;
            if (CheckBox_IsAdmin.IsChecked == false)
                user.IsAdmin = false;
            bool wasSuccess = userLogic.EditUser(user);
            if (wasSuccess)
                CreateMessage.ShowEditSuccesful("User");
            if (!wasSuccess)
                CreateMessage.ShowFailureMessage();
            NavigationService.Navigate(new ViewUsersDetail(user.ID));
        }

        private void Btn_Click_DeleteUser(object sender, RoutedEventArgs e)
        {
            bool wasSucces = userLogic.DeleteUser("user", user.ID);
            if (wasSucces)
                CreateMessage.ShowDeleteSuccesful("User");
            if (!wasSucces)
                CreateMessage.ShowFailureMessage();
            this.Content = null;
            NavigationService.Navigate(new ViewUser());
        }
    }
}
