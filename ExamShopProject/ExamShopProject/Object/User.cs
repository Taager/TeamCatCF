using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    //lavet af Mikkel E.R. Glerup

    class User : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        private string currentUser;

        public string CurrentUser
        {
            get { return currentUser; }
            set{ currentUser = value;}
        }
        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        private bool isAdmin;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        private string isAdminString;
        public string IsAdminString
        {
            get { return isAdminString; }
            set
            {
                isAdminString = value;
                NotifyPropertyChanged();
            }
        }
        private int id;
        public int ID
        {
            get { return id;}
            set { id = value;}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Guid userGuid { get; set; }
    }
}
