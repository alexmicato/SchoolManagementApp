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
    public class AddCourseControlVM : INotifyPropertyChanged
    {
        public ICommand AddCourseCommand { get; set; }
        public ICommand TeacherSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }
        public AddCourseControlVM()
        {
            AddCourseCommand = new RelayCommand(AddCourse);
            TeacherSelectionChangedCommand = new RelayCommand(OnTeacherSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            subjectList = SubjectBLL.GetAllSubjects();
            teacherList = TeacherBLL.GetAllTeachers();
            classList = ClassBLL.GetAllClasses();
        }

        public void AddCourse()
        {
            if (SelectedTeacher == null)
            {
                ErrorMessage = "You must select a teacher";
                return;
            }
            if (SelectedSubject == null)
            {
                ErrorMessage = "You must select a subject";
                return;
            }

            if(SelectedClass == null)
            {
                ErrorMessage = "You must select a class";
                return;
            }


            ClassTeacherSubject classTeacherSubject = new ClassTeacherSubject(SelectedClass.ClassID, SelectedTeacher.TeacherID, SelectedSubject.SubjectID, null);

            ClassTeacherSubjectBLL.AddCourse(classTeacherSubject);

            MessageBox.Show("Course added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedTeacher = null;
            SelectedClass = null;
            ErrorMessage = string.Empty;


        }

        public void OnSubjectSelectionChanged()
        {

        }

        public void OnClassSelectionChanged()
        {
           
        }

        public void OnTeacherSelectionChanged()
        {
           
        }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set { SetProperty(ref selectedTeacher, value); }
        }


        private ObservableCollection<Teacher> teacherList;

        public ObservableCollection<Teacher> TeacherList
        {
            get { return teacherList; }
            set { SetProperty(ref teacherList, value); }
        }


        private Subject selectedSubject;

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set { SetProperty(ref selectedSubject, value); }
        }

        private ObservableCollection<Subject> subjectList;

        public ObservableCollection<Subject> SubjectList
        {
            get { return subjectList; }
            set { SetProperty(ref subjectList, value); }
        }

        private Class selectedClass;

        public Class SelectedClass
        {
            get { return selectedClass; }
            set { SetProperty(ref selectedClass, value); }
        }

        private ObservableCollection<Class> classList;

        public ObservableCollection<Class> ClassList
        {
            get { return classList; }
            set { SetProperty(ref classList, value); }
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
