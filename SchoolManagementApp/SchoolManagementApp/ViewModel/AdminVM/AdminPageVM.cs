using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.View;
using SchoolManagementApp.View.AdminView;

namespace SchoolManagementApp.ViewModel
{
    public class AdminPageVM : INotifyPropertyChanged
    {
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
   
        public AdminPageVM() 
        {
            MenuItemSelectedCommand = new RelayCommand<string>(OnMenuItemSelected);
           
        }

        private void OnMenuItemSelected(string menuItem)
        {
            switch (menuItem)
            {
                
                case "AddSubject":
                    SelectedMenuItemContent = new AddSubjectControl();
                    break;
                case "AddClass":
                    SelectedMenuItemContent = new AddClassControl();
                    break;
                case "AddSpecialization":
                    SelectedMenuItemContent = new AddSpecialization();
                    break;
                case "AddUser":
                    SelectedMenuItemContent = new AddUserControl();
                    break;
                case "ViewSubjects":
                    SelectedMenuItemContent = new DeleteSubjectControl();
                    break;
                case "ViewClasses":
                    SelectedMenuItemContent = new DeleteClassControl();
                    break;
                case "ViewSpecializations":
                    SelectedMenuItemContent = new DeleteSpecializationControl();
                    break;
                case "ViewUsers":
                    SelectedMenuItemContent = new DeleteUserControl();
                    break;
                case "ViewTeacherSubjects":
                    SelectedMenuItemContent = new ViewTeacherSubjectsControl();
                    break;
                case "UpdateStudent":
                    SelectedMenuItemContent = new UpdateStudentControl();
                    break;
                case "UpdateTeacher":
                    SelectedMenuItemContent = new UpdateTeacherControl();
                    break;
                case "UpdateSubject":
                    SelectedMenuItemContent = new UpdateSubjectControl();
                    break;
                case "UpdateClass":
                    SelectedMenuItemContent = new UpdateClassControl();
                    break;
                case "UpdateSpecialization":
                    SelectedMenuItemContent = new UpdateSpecializationControl();
                    break;
                case "UpdateUser":
                    SelectedMenuItemContent = new UpdateUserControl();
                    break;
                case "AddSubjectToSpecialization":
                    SelectedMenuItemContent = new SubjectToSpecializationUserControl();
                    break;
                case "AddCourse":
                    SelectedMenuItemContent = new AddCourseControl();
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
