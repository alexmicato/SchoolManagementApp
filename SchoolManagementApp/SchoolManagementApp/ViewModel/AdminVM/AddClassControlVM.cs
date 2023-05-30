using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Model.BusinessLogicLayer;
using SchoolManagementApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class AddClassControlVM : INotifyPropertyChanged
    {
        public ICommand AddClassCommand { get; set; }
        public AddClassControlVM()
        {
            AddClassCommand = new RelayCommand(AddClass);

            specializationList = SpecializationBLL.GetAllSpecializations();
            teacherList = TeacherBLL.GetTeachersNotClassTeachers();
        }

        public void AddClass()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "Name field cannot be empty";
                return;
            }
            if (SelectedSpecialization == null)
            {
                ErrorMessage = "Please select specialization";
                return;
            }
            if (SelectedTeacher == null)
            {
                ErrorMessage = "Please select class teacher";
                return;
            }

            Class c = new Class(SelectedSpecialization.SpecializationID, SelectedTeacher.TeacherID, Name);

            ClassBLL.AddClass(c);

            MessageBox.Show("Class added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            TeacherList = TeacherBLL.GetTeachersNotClassTeachers();
            Name = string.Empty;
            SelectedTeacher = null;
            SelectedSpecialization = null;
            ErrorMessage = string.Empty;

        }

        private ObservableCollection<Specialization> specializationList;

        public ObservableCollection<Specialization> SpecializationList
        {
            get { return specializationList; }
            set { SetProperty(ref specializationList, value); }
        }

        private ObservableCollection<Teacher> teacherList;

        public ObservableCollection<Teacher> TeacherList
        {
            get { return teacherList; }
            set { SetProperty(ref teacherList, value); }
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

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }

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
