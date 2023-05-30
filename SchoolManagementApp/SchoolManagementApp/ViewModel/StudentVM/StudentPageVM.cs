using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.View.TeacherView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.View.StudentView;

namespace SchoolManagementApp.ViewModel.StudentVM
{
    public class StudentPageVM : INotifyPropertyChanged
    {
        private Student currentStudent;

        private object selectedMenuItemContent;

        public object SelectedMenuItemContent
        {
            get { return selectedMenuItemContent; }
            set
            {
                selectedMenuItemContent = value;
                OnPropertyChanged(nameof(SelectedMenuItemContent));
            }
        }

        public ICommand MenuItemSelectedCommand { get; private set; }

        public StudentPageVM(Student student)
        {
            MenuItemSelectedCommand = new RelayCommand<string>(OnMenuItemSelected);
            currentStudent = student;

        }

        private void OnMenuItemSelected(string menuItem)
        {
            switch (menuItem)
            {

                case "View":
                    SelectedMenuItemContent = new ViewStudentInfoControl(currentStudent);
                    break;
                default:
                    // Handle unrecognized menu item
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
