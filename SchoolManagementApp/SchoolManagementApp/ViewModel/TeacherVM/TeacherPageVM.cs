using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.View.AdminView;
using SchoolManagementApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.View.TeacherView;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class TeacherPageVM : INotifyPropertyChanged
    {

        private Teacher currentTeacher;
        
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

        public TeacherPageVM(Teacher teacher)
        {
            MenuItemSelectedCommand = new RelayCommand<string>(OnMenuItemSelected);
            currentTeacher = teacher;

        }

        private void OnMenuItemSelected(string menuItem)
        {
            switch (menuItem)
            {

                case "AddGrade":
                    SelectedMenuItemContent = new AddGradeControl(currentTeacher);
                    break;
                case "ViewGrades":
                    SelectedMenuItemContent = new ViewGradesControl(currentTeacher);
                    break;
                case "AddAbsence":
                    SelectedMenuItemContent = new AddAbsenceControl(currentTeacher);
                    break;
                case "ViewAbsences":
                    SelectedMenuItemContent = new ViewAbsencesControl(currentTeacher);
                    break;
                case "AddTeacherMaterial":
                    SelectedMenuItemContent = new AddTeacherMaterialControl(currentTeacher);
                    break;
                case "ViewTeacherMaterials":
                    SelectedMenuItemContent = new ViewTeacherMaterialControl(currentTeacher);
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
