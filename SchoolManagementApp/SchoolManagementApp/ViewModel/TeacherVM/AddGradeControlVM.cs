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
using SchoolManagementApp.Helpers;

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    class AddGradeControlVM : INotifyPropertyChanged
    {
        public ICommand AddGradeCommand { get; set; }
        public ICommand StudentSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        private Teacher currentTeacher;
        public AddGradeControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            AddGradeCommand = new RelayCommand(AddGrade);
            StudentSelectionChangedCommand = new RelayCommand(OnStudentSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            studentList = StudentBLL.GetAllStudents();
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);
        }

       
        public void AddGrade()
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

            if(SelectedClass == null)
            {
                ErrorMessage = "You must select a class";
                return;
            }
            if(GradeDate == string.Empty)
            {
                ErrorMessage = "Please enter a date";
                return;
            }

            if(!Utility.IsDateStringValid(GradeDate)) 
            {
                ErrorMessage = "Please enter a valid date";
                return;
            }

            if (GradeSemester == string.Empty)
            {
                ErrorMessage = "Please choose the semester";
                return;
            }

            if (Grade == string.Empty)
            {
                ErrorMessage = "Please enter a grade";
                return;
            }
            
            Grade grade = new Grade()
            {
                StudentID = selectedStudent.StudentID,
                SubjectID = selectedSubject.SubjectID,
                TeacherID = currentTeacher.TeacherID,
                Date = DateTime.Parse(GradeDate),
                Semester = int.Parse(GradeSemester),
                GradeValue = float.Parse(Grade),
                IsFinal = IsFinalGrade,
                IsAveraged = false
            };

            GradeBLL.AddGrade(grade);

            MessageBox.Show("Grade added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedStudent = null;
            SelectedClass = null;
            GradeDate = string.Empty;
            Grade = string.Empty;
            IsFinalGrade = false;
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
            if(SelectedClass != null)
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

        private bool isFinalGrade;

        public bool IsFinalGrade
        {
            get { return isFinalGrade; }
            set { SetProperty(ref isFinalGrade, value); }
        }

        private string gradeDate;

        public string GradeDate
        {
            get { return gradeDate; }
            set { SetProperty(ref gradeDate, value); }
        }

        private string gradeSemester;

        public string GradeSemester
        {
            get { return gradeSemester; }
            set { SetProperty(ref gradeSemester, value); }
        }

        private string grade;

        public string Grade
        {
            get { return grade; }
            set { SetProperty(ref grade, value); }
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
