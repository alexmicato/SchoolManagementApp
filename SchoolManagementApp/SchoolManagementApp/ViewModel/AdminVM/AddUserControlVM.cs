using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.Model.BusinessLogicLayer;
using System.Windows;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.ViewModel
{
    public class AddUserControlVM : INotifyPropertyChanged
    {
        public ICommand AddUserCommand { get; private set; }

      
        public AddUserControlVM() 
        {
            AddUserCommand = new RelayCommand(OnAddUser);

            classList = ClassBLL.GetAllClasses();
        }

        private ObservableCollection<Class> classList;

        public ObservableCollection<Class> ClassList
        {
            get { return classList; }
            set { SetProperty(ref classList, value); }
        }

        private Class selectedClass;

        public Class SelectedClass
        {
            get { return selectedClass; }
            set { SetProperty(ref selectedClass, value); }
        }

        public void OnAddUser()
        {
            if (string.IsNullOrEmpty(Username))
            {
                ErrorMessage = "The username field is required";
                return;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "The password field is required";
                return;
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                ErrorMessage = "The first name field is required";
                return;
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                ErrorMessage = "The last name field is required";
                return;
            }

            User user = new User(username, password, SelectedUserType);
            int userID = UserBLL.AddUser(user);

            if(SelectedUserType == "Teacher")
            {
                Teacher teacher = new Teacher(firstName, lastName, userID);

                TeacherBLL.AddTeacher(teacher);
            }
            else if(SelectedUserType == "Admin")
            {
                Admin admin = new Admin(firstName, lastName, userID);

                AdminBLL.AddAdmin(admin);
            }
            else if(SelectedUserType == "Student")
            {
                if(SelectedClass == null) 
                {
                    ErrorMessage = "You must select a class";
                    return;
                }

                int classID = SelectedClass.ClassID;

                Student student = new Student(firstName, lastName, classID, userID);

                StudentBLL.AddStudent(student);

            }


            MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            FirstName = string.Empty;
            LastName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            ErrorMessage = string.Empty;
            SelectedUserType = null;
        

    }


        public bool IsStudentUserType
        {
            get { return SelectedUserType == "Student"; }
        }

        public string selectedUserType;

        public string SelectedUserType
        {
            get { return selectedUserType; }
            set {
                if (SetProperty(ref selectedUserType, value))
                {
                    OnPropertyChanged(nameof(IsStudentUserType));
                }
            }
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
