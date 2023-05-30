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
using System.Collections.Specialized;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class UpdateTeacherControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateTeacherCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UpdateTeacherControlVM()
        {
            UpdateTeacherCommand = new RelayCommand(UpdateTeacher);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            teacherList = TeacherBLL.GetAllTeachers();
        }

        public void UpdateTeacher()
        {
            if (SelectedTeacher == null)
            {
                ErrorMessage = "Please select a teacher";
                return;
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                ErrorMessage = "First name field cannot be empty";
                return;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                ErrorMessage = "Last name field cannot be empty";
                return;
            }

            SelectedTeacher.FirstName = FirstName;
            SelectedTeacher.LastName = LastName;

            TeacherBLL.UpdateTeacher(SelectedTeacher);

            SelectedTeacher = null;
            FirstName = string.Empty; LastName = string.Empty;
            MessageBox.Show("Teacher modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            teacherList = TeacherBLL.GetAllTeachers();
            ErrorMessage = string.Empty;


        }

        private void OnSelectionChanged()
        {
            if (SelectedTeacher != null)
            {
                FirstName = SelectedTeacher.FirstName;
                LastName = SelectedTeacher.LastName;
            }
        }

        private ObservableCollection<Teacher> teacherList;

        public ObservableCollection<Teacher> TeacherList
        {
            get { return teacherList; }
            set { SetProperty(ref teacherList, value); }
        }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { SetProperty(ref selectedTeacher, value); }
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
