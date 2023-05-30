using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.Model.BusinessLogicLayer;
using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.DataAccessLayer;
using System.Windows;
using SchoolManagementApp.View;
using System.Windows.Navigation;
using System.Windows.Controls;
using SchoolManagementApp.Services;

namespace SchoolManagementApp.ViewModel
{
    public class TeacherEventArgs : EventArgs
    {
        public Teacher Teacher { get; set; }

        public TeacherEventArgs(Teacher teacher)
        {
            Teacher = teacher;
        }
    }

    public class StudentEventArgs : EventArgs
    {
        public Student Student { get; set; }

        public StudentEventArgs(Student student)
        {
            Student = student;
        }
    }
    public class LoginPageVM : INotifyPropertyChanged
    {
        public event EventHandler AdminLoggedIn;
        public event EventHandler<TeacherEventArgs> TeacherLoggedIn;
        public event EventHandler<TeacherEventArgs> ClassTeacherLoggedIn;
        public event EventHandler <StudentEventArgs> StudentLoggedIn;

        private readonly INavigationService _navigationService;
        public Frame MainFrame { get; set; }
        public User currentUser { get; set; }
        public ICommand LoginCommand { get; private set; }

        public LoginPageVM()
        {
            LoginCommand = new RelayCommand(Login);
        }

           


        private string username;
        public string Username
        {
            get { return username; }
            set{ SetProperty(ref username, value);}

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
        public void Login()
        {
            if(string.IsNullOrEmpty(Username)) 
            {
                ErrorMessage = "The username field is required";
                return;
            }
            else if(string.IsNullOrEmpty(Password)) 
            {
                ErrorMessage = "The password field is required";
                return;
            }

            currentUser = UserBLL.GetUserByNameAndPassword(Username, Password);

            if(currentUser == null) 
            {
                ErrorMessage = "Username or password incorrect";
                return;
            }

            else if(currentUser.UserType == "Admin")
            {

                AdminLoggedIn?.Invoke(this, EventArgs.Empty);
                return;
            }

            else if(currentUser.UserType == "Teacher")
            {
                Teacher teacher = TeacherBLL.GetTeacherByUserId(currentUser.UserID);
                bool isClassTeacher = TeacherBLL.CheckIfClassTeacher(teacher);

                if (isClassTeacher)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to log in as class teacher? If you choose no, you'll be logged as a normal teacher.", "Teacher Login", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        TeacherLoggedIn?.Invoke(this, new TeacherEventArgs(teacher));
                    }
                    else
                    {
                        TeacherLoggedIn?.Invoke(this, new TeacherEventArgs(teacher));
                    }
                }
                else
                {
                    TeacherLoggedIn?.Invoke(this, new TeacherEventArgs(teacher));
                }
                return;
            }

            else if(currentUser.UserType == "Student")
            {
                Student student = StudentBLL.GetStudentByUserId(currentUser.UserID);

                StudentLoggedIn?.Invoke(this, new StudentEventArgs(student));

                return;
            }
            

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
