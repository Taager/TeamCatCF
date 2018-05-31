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

namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    // Made by Mikkel E.R. Glerup
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Btn_Click_LogIn(object sender, RoutedEventArgs e)
        {
            CurrentUser.username = txtBox_Username.Text;
            CurrentUser.password = txtBox_Password.Text;
            bool loginSucces = DB.UserLogin();
            if (CurrentUser.currentUserID > 0)
            {
                CreateMessage.ShowSuccesfulLogin();
                this.Content = null;
            }
            if (CurrentUser.currentUserID == 0)
            {
                CreateMessage.ShowUnsuccesfulLogin();
            }
        }
    }
}
