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
    public class UpdateClassControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateClassCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        public ICommand SpecializationSelectionChangedCommand { get; set; }
        public ICommand TeacherSelectionChangedCommand { get; set; }

        private ObservableCollection<Teacher> allTeachers;
        public UpdateClassControlVM()
        {
            UpdateClassCommand = new RelayCommand(UpdateClass);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SpecializationSelectionChangedCommand = new RelayCommand(OnSpecializationSelectionChanged);
            TeacherSelectionChangedCommand = new RelayCommand(OnTeacherSelectionChanged);
            classList = ClassBLL.GetAllClasses();
            specializationList = SpecializationBLL.GetAllSpecializations();
            teacherList = TeacherBLL.GetTeachersNotClassTeachers();
            allTeachers = TeacherBLL.GetAllTeachers();
        }

        public void UpdateClass()
        {
            if(SelectedClass == null)
            {
                ErrorMessage = "Please select a class";
                return;
            }
            if (string.IsNullOrEmpty(ClassName))
            {
                ErrorMessage = "Name field cannot be empty";
                return;
            }


            SelectedClass.ClassName = ClassName;
            SelectedClass.SpecializationID = SelectedSpecialization.SpecializationID;

            if (SelectedTeacher != null)
            { 
                SelectedClass.ClassTeacherID = SelectedTeacher.TeacherID; 
            }

            ClassBLL.UpdateClass(SelectedClass);

            SelectedClass = null;
            ClassName = string.Empty;
            TeacherName = string.Empty;
            SelectedSpecialization = null;
            SelectedTeacher = null;
            MessageBox.Show("Class modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            ClassList = ClassBLL.GetAllClasses();
            TeacherList = TeacherBLL.GetTeachersNotClassTeachers();
            ErrorMessage = string.Empty;


        }

        private void OnTeacherSelectionChanged()
        {

        }

        private void OnSpecializationSelectionChanged()
        {

        }

        private void OnClassSelectionChanged()
        {
            if (SelectedClass != null)
            {
                ClassName = SelectedClass.ClassName;

                Teacher teacher = allTeachers.FirstOrDefault(t => t.TeacherID == SelectedClass.ClassTeacherID);
                TeacherName = teacher.FirstName + " " + teacher.LastName;

                SelectedSpecialization = SpecializationList.FirstOrDefault(s => s.SpecializationID == SelectedClass.SpecializationID);
                SelectedTeacher = TeacherList.FirstOrDefault(t => t.TeacherID == SelectedClass.ClassTeacherID);
            }
        }

        private ObservableCollection<Specialization> specializationList;

        public ObservableCollection<Specialization> SpecializationList
        {
            get { return specializationList; }
            set { SetProperty(ref specializationList, value); }
        }

        private ObservableCollection<Class> classList;

        public ObservableCollection<Class> ClassList
        {
            get { return classList; }
            set { SetProperty(ref classList, value); }
        }

        private ObservableCollection<Teacher> teacherList;

        public ObservableCollection<Teacher> TeacherList
        {
            get { return teacherList; }
            set { SetProperty(ref teacherList, value); }
        }

        private Class selectedClass;

        public Class SelectedClass
        {
            get { return selectedClass; }
            set { SetProperty(ref selectedClass, value); }
        }

        private Specialization selectedSpecialization;

        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set { SetProperty(ref selectedSpecialization, value); }
        }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { SetProperty(ref selectedTeacher, value); }
        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { SetProperty(ref className, value); }

        }

        private string teacherName;
        public string TeacherName
        {
            get { return teacherName; }
            set { SetProperty(ref teacherName, value); }

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
