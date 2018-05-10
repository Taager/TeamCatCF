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
    /// Interaction logic for ViewUser.xaml
    /// </summary>
    public partial class ViewUser : Page
    {
        // Made by Mikkel. E.R. Glerup
        public ViewUser()
        {
            InitializeComponent();
            ListBox_Show.ItemsSource = DB.SelectAllUsers();
            ListBox_Show.DisplayMemberPath = "Username";
        }

        private void ListBox_Show_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User chosenUser = (User)ListBox_Show.SelectedItem;
            //NavigationService is used, because ViewUserDetails would otherwise be part of ViewUser's frame,
            // this is bad because there's already existing elements on that page.
            // Making it a part of _mainFrame would result in smelly code.
            NavigationService.Navigate(new ViewUsersDetail(chosenUser.ID));
        }
    }
}
