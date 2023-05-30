using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Helpers;
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

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class AddAbsenceControlVM : INotifyPropertyChanged
    {
        public ICommand AddAbsenceCommand { get; set; }
        public ICommand StudentSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        private Teacher currentTeacher;
        public AddAbsenceControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            AddAbsenceCommand = new RelayCommand(AddAbsence);
            StudentSelectionChangedCommand = new RelayCommand(OnStudentSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            studentList = StudentBLL.GetAllStudents();
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);
        }


        public void AddAbsence()
        {
            if (SelectedStudent == null)
            {
                ErrorMessage = "You must select a teacher";
                return;
            }
            if (SelectedSubject == null)
            {
                ErrorMessage = "You must select a subject";
                return;
            }

            if (SelectedClass == null)
            {
                ErrorMessage = "You must select a class";
                return;
            }
            if (AbsenceDate == string.Empty)
            {
                ErrorMessage = "Please enter a date";
                return;
            }

            if (!Utility.IsDateStringValid(AbsenceDate))
            {
                ErrorMessage = "Please enter a valid date";
                return;
            }

            if (AbsenceSemester == string.Empty)
            {
                ErrorMessage = "Please enter the semester";
                return;
            }


            Absence absence = new Absence()
            {
                StudentID = SelectedStudent.StudentID,
                TeacherID = currentTeacher.TeacherID,
                SubjectID = SelectedSubject.SubjectID,
                Date = DateTime.Parse(AbsenceDate),
                Semester = int.Parse(AbsenceSemester),
                IsMotivated = false

            };

            AbsenceBLL.AddAbsence(absence);

            MessageBox.Show("Absence added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedStudent = null;
            SelectedClass = null;
            AbsenceDate = string.Empty;
            AbsenceSemester = string.Empty;
            ErrorMessage = string.Empty;




        }

        public void OnSubjectSelectionChanged()
        {
            if (SelectedSubject != null && SelectedStudent != null)
            {

            }
        }

        public void OnClassSelectionChanged()
        {
            if (SelectedClass != null)
            {
                SubjectList = SubjectBLL.GetSubjectsByTeacherAndClass(currentTeacher.TeacherID, SelectedClass.ClassID);
                StudentList = StudentBLL.GetStudentsByClass(SelectedClass.ClassID);
            }
        }

        public void OnStudentSelectionChanged()
        {
            if (SelectedStudent != null)
            {

            }
        }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { SetProperty(ref selectedStudent, value); }
        }


        private ObservableCollection<Student> studentList;

        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { SetProperty(ref studentList, value); }
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


        private string absenceDate;

        public string AbsenceDate
        {
            get { return absenceDate; }
            set { SetProperty(ref absenceDate, value); }
        }

        private string absenceSemester;

        public string AbsenceSemester
        {
            get { return absenceSemester; }
            set { SetProperty(ref absenceSemester, value); }
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
