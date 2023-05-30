using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.BusinessLogicLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class UpdateUserControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateUserCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UpdateUserControlVM()
        {
            UpdateUserCommand = new RelayCommand(UpdateUser);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            userList = UserBLL.GetAllUsers();
        }

        public void UpdateUser()
        {
            if (SelectedUser == null)
            {
                ErrorMessage = "Please select an user";
                return;
            }
            if (string.IsNullOrEmpty(Username))
            {
                ErrorMessage = "First name field cannot be empty";
                return;
            }

            if (string.IsNullOrEmpty(Username))
            {
                ErrorMessage = "Last name field cannot be empty";
                return;
            }

            SelectedUser.Username = Username;
            SelectedUser.Password = Password;

            UserBLL.UpdateUser(SelectedUser);

            SelectedUser = null;
            Username = string.Empty; Password = string.Empty;
            MessageBox.Show("User modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            userList = UserBLL.GetAllUsers();
            ErrorMessage = string.Empty;


        }

        private void OnSelectionChanged()
        {
            if (SelectedUser != null)
            {
                Username = SelectedUser.Username;
                Password = SelectedUser.Password;
            }
        }

        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set { SetProperty(ref userList, value); }
        }

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }

        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }

        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
