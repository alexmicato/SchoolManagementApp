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
    public class DeleteUserControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteUserCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public DeleteUserControlVM()
        {
            DeleteUserCommand = new RelayCommand(DeleteUser);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            userList = UserBLL.GetAllUsers();
        }

        public void DeleteUser()
        {
            if (SelectedUser == null)
            {
                ErrorMessage = "Please select an user to delete";
                return;
            }

            UserBLL.DeleteUser(SelectedUser);

            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedUser = null;
            LastName = string.Empty;
            FirstName = string.Empty;
            UserList = UserBLL.GetAllUsers();
            ErrorMessage = string.Empty;
        }

        private void OnSelectionChanged()
        {
            if (SelectedUser != null)
            {
                if(SelectedUser.UserType == "Admin")
                {
                    Admin admin = AdminBLL.GetAdminByUserId(SelectedUser.UserID);

                    FirstName = admin.FirstName;    
                    LastName = admin.LastName;
                }
                else if(SelectedUser.UserType == "Student")
                {
                    Student student = StudentBLL.GetStudentByUserId(SelectedUser.UserID);
                    FirstName = student.FirstName;
                    LastName = student.LastName;
                }
                else if(SelectedUser.UserType == "Teacher")
                {
                    Teacher teacher = TeacherBLL.GetTeacherByUserId(SelectedUser.UserID);
                    FirstName = teacher.FirstName;
                    LastName = teacher.LastName;
                }
            }
        }

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }

        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }

        }

        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set { SetProperty(ref userList, value); }
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
