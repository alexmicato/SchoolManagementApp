using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Helpers;
using System.Windows.Input;
using System.Windows;
using SchoolManagementApp.Model.BusinessLogicLayer;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class ViewGradesControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteGradeCommand { get; set; }
        public ICommand StudentSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }
        public ICommand CalculateAverageCommand { get; set; }

        private int gradesSemester;
        public int GradesSemester
        {
            get { return gradesSemester; }
            set
            {
                if (gradesSemester != value)
                {
                    gradesSemester = value;
                    OnPropertyChanged(nameof(GradesSemester));
                }
            }
        }

        private Teacher currentTeacher;
        public ViewGradesControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            DeleteGradeCommand = new RelayCommand(DeleteGrade);
            CalculateAverageCommand = new RelayCommand(CalculateAverage);   
            StudentSelectionChangedCommand = new RelayCommand(OnStudentSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            PropertyChanged += OnViewModelPropertyChanged;

            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            studentList = StudentBLL.GetAllStudents();
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);

            hasFinalText = "Selected subject has final: ";
            IsSemester1 = true;
            GradesSemester = 1;
            IsSemester2 = false;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsSemester1) || e.PropertyName == nameof(IsSemester2))
            {
                if (IsSemester1)
                {
                    UpdateGradeListForSemester1();

                }
                else if (IsSemester2)
                {
                    UpdateGradeListForSemester2();
                }
            }
        }

        private void UpdateGradeListForSemester1()
        {
            if (SelectedStudent != null && SelectedClass != null && SelectedSubject != null)
            {

                GradeList = GradeBLL.GetGradesByStudentTeacherSubjectSemester(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID, 1);
            }
        }

        private void UpdateGradeListForSemester2()
        {
            if (SelectedStudent != null && SelectedClass != null && SelectedSubject != null)
            {

                GradeList = GradeBLL.GetGradesByStudentTeacherSubjectSemester(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID, 2);
            }
        }

        public void CalculateAverage()
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

            if(GradeList.All(grade => grade.IsAveraged))
            {
                ErrorMessage = "Average has already been calculated";
                return;
            }

            if (!HasFinal && GradeList.Count < 3)
            {
                ErrorMessage = "You need at least 3 grades to calculate average";
                return;
            }

            if (HasFinal)
            {
                var finalGrade = GradeList.Where(grade => grade.IsFinal).ToList();

                if(finalGrade.Count < 1 && GradeList.Count < 3)
                {
                    ErrorMessage = "This subject has final. You need 4 grades, and 1 must be the final";
                    return;
                }

            }

            float average;

            if(HasFinal)
            {
                var finalGrade = GradeList.Where(grade => grade.IsFinal).ToList();
                var nonFinalGrades = GradeList.Where(grade => !grade.IsFinal);
                float nonFinalMean = nonFinalGrades.Average(grade => grade.GradeValue);

                average = (nonFinalMean * 3 + finalGrade[0].GradeValue) / 4;
            }
            else
            {
                average = GradeList.Average(grade => grade.GradeValue);
            }

            foreach(Grade grade in GradeList)
            {
                grade.IsAveraged = true;
                GradeBLL.UpdateGrade(grade);
            }

            int semester;

            if (IsSemester1) semester = 1;
            else
            {
                semester = 2;
            }

            StudentAverage studentAverage = new StudentAverage()
            {
                StudentID = SelectedStudent.StudentID,
                SubjectID = SelectedSubject.SubjectID,
                Semester = 1,
                Average = average,

            };


            StudentAverageBLL.AddStudentAverage(studentAverage);

            MessageBox.Show("Average calculated: " + average.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedStudent = null;
            SelectedClass = null;
            SelectedGrade = null;
            ErrorMessage = string.Empty;
        }

        public void DeleteGrade()
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

            if (SelectedGrade == null)
            {
                ErrorMessage = "You must select a grade";
                return;
            }

            if(SelectedGrade.IsAveraged == true)
            {
                ErrorMessage = "You cannot delete an averaged grade";
                return;
            }


            GradeBLL.DeleteGrade(SelectedGrade);

            MessageBox.Show("Grade deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            GradeList = GradeBLL.GetGradesByStudentTeacherSubject(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID);

            SelectedSubject = null;
            SelectedStudent = null;
            SelectedClass = null;
            SelectedGrade = null;
            ErrorMessage = string.Empty;
        }

        public void OnSubjectSelectionChanged()
        {
            if (SelectedSubject != null && SelectedClass != null)
            {
                HasFinal = SpecializationSubjectBLL.GetSubjectFinalStatus(SelectedSubject.SubjectID, SelectedClass.SpecializationID);
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
                int semester;

                if (IsSemester1) semester = 1;
                else
                {
                    semester = 2;
                }
                GradeList = GradeBLL.GetGradesByStudentTeacherSubjectSemester(currentTeacher.TeacherID, SelectedStudent.StudentID, SelectedSubject.SubjectID, semester);
            }
        }

        private bool hasFinal;

        public bool HasFinal
        {
            get { return hasFinal; }
            set { SetProperty(ref hasFinal, value); }
        }

        private bool isSemester1;
        public bool IsSemester1
        {
            get { return isSemester1; }
            set
            {
                if (isSemester1 != value)
                {
                    isSemester1 = value;
                    OnPropertyChanged(nameof(IsSemester1));

                    if (isSemester1)
                    {
                        IsSemester2 = false;
                        GradesSemester = 1;
                    }
                }
            }
        }

        private bool isSemester2;
        public bool IsSemester2
        {
            get { return isSemester2; }
            set
            {
                if (isSemester2 != value)
                {
                    isSemester2 = value;
                    OnPropertyChanged(nameof(IsSemester2));

                    if (isSemester2)
                    {
                        IsSemester1 = false;
                        GradesSemester = 2;
                    }
                }
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

        private ObservableCollection<Grade> gradeList;

        public ObservableCollection<Grade> GradeList
        {
            get { return gradeList; }
            set { SetProperty(ref gradeList, value); }
        }


        private Grade selectedGrade;

        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set { SetProperty(ref selectedGrade, value); }
        }

        private string hasFinalText;
        public string HasFinalText
        {
            get { return hasFinalText; }
            set { SetProperty(ref hasFinalText, value); }
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
