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

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class ViewAbsencesControlVM : INotifyPropertyChanged
    {
        public ICommand MotivateAbsenceCommand { get; set; }
        public ICommand StudentSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        private Teacher currentTeacher;
        public ViewAbsencesControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            MotivateAbsenceCommand = new RelayCommand(MotivateAbsence);
            StudentSelectionChangedCommand = new RelayCommand(OnStudentSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            studentList = StudentBLL.GetAllStudents();
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);
        }


        public void MotivateAbsence()
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

            if (SelectedAbsence == null)
            {
                ErrorMessage = "You must select an absence";
                return;
            }

            SelectedAbsence.IsMotivated = true;

            AbsenceBLL.UpdateAbsence(SelectedAbsence);

            MessageBox.Show("Absence motivated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            AbsenceList = AbsenceBLL.GetAbsencesByStudentTeacherSubject(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID);

            SelectedSubject = null;
            SelectedStudent = null;
            SelectedClass = null;
            SelectedAbsence = null;
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
            if (SelectedStudent != null && SelectedClass != null && SelectedSubject != null)
            {
                AbsenceList = AbsenceBLL.GetAbsencesByStudentTeacherSubject(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID);
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

        private ObservableCollection<Absence> absenceList;

        public ObservableCollection<Absence> AbsenceList
        {
            get { return absenceList; }
            set { SetProperty(ref absenceList, value); }
        }


        private Absence selectedAbsence;

        public Absence SelectedAbsence
        {
            get { return selectedAbsence; }
            set { SetProperty(ref selectedAbsence, value); }
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
