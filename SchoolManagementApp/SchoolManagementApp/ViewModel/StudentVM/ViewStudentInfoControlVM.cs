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
using System.Runtime.InteropServices;

namespace SchoolManagementApp.ViewModel.StudentVM
{
    public class ViewStudentInfoControlVM : INotifyPropertyChanged
    {
        public ICommand DownloadMaterialCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }

        private Student currentStudent;
        public ViewStudentInfoControlVM(Student student)
        {
            currentStudent = student;
            DownloadMaterialCommand = new RelayCommand(DownloadMaterial);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            PropertyChanged += OnViewModelPropertyChanged;

            if(currentStudent.ClassID.HasValue)
            {
                int classID = currentStudent.ClassID.Value; 
                subjectList = SubjectBLL.GetSubjectsByClass(classID);
            }

            IsSemester1 = true;
            IsSemester2 = false;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsSemester1) || e.PropertyName == nameof(IsSemester2))
            {
                if (IsSemester1)
                {
                    UpdateListForSemester1();

                }
                else if (IsSemester2)
                {
                    UpdateListForSemester2();
                }
            }
        }

        private void UpdateListForSemester1()
        {
            if (SelectedSubject != null)
            {


                StudentAverage average = StudentAverageBLL.GetStudentAverage(currentStudent.StudentID, SelectedSubject.SubjectID, 1);

                if (average != null)
                {
                    SemesterAverage = average.Average.ToString();
                }
                else
                {
                    SemesterAverage = "Not yet ";
                }

                GradeList = GradeBLL.GetGradesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID, 1);
                AbsenceList = AbsenceBLL.GetAbsencesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID,1);
            }
        }

        private void UpdateListForSemester2()
        {
            if (SelectedSubject != null)
            {
                StudentAverage average = StudentAverageBLL.GetStudentAverage(currentStudent.StudentID, SelectedSubject.SubjectID,2);

                if (average != null)
                {
                    SemesterAverage = average.Average.ToString();
                }
                else
                {
                    SemesterAverage = "Not yet ";
                }

                GradeList = GradeBLL.GetGradesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID, 2);
                AbsenceList = AbsenceBLL.GetAbsencesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID, 2);
            }
        }

        [DllImport("shell32.dll", SetLastError = true)]
        private static extern bool ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        public void DownloadMaterial()
        {
           
            if (SelectedSubject == null)
            {
                ErrorMessage = "You must select a subject";
                return;
            }

            if (SelectedMaterial == null)
            {
                ErrorMessage = "You must select a material";
                return;
            }

            string filePath = SelectedMaterial.FilePath;

            try
            {
                ShellExecute(IntPtr.Zero, "open", filePath, null, null, 5);
            }
            catch (Exception ex)
            {

            }
            ErrorMessage = string.Empty;

        }

        public void OnSubjectSelectionChanged()
        {
            if (SelectedSubject != null && currentStudent.ClassID.HasValue)
            {
                int classID = currentStudent.ClassID.Value;
                
                Specialization specialization = SpecializationBLL.GetSpecializationByClass(classID);


                HasFinal = SpecializationSubjectBLL.GetSubjectFinalStatus(SelectedSubject.SubjectID, specialization.SpecializationID);
                int semester;

                if (IsSemester1) semester = 1;
                else semester = 2;

                GradeList = GradeBLL.GetGradesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID, semester);
                AbsenceList = AbsenceBLL.GetAbsencesByStudentSubjectSemester(currentStudent.StudentID, SelectedSubject.SubjectID, semester);
                MaterialList = TeacherMaterialBLL.GetTeacherMaterialByClassSubject(classID, SelectedSubject.SubjectID);

                StudentAverage average = StudentAverageBLL.GetStudentAverage(currentStudent.StudentID, SelectedSubject.SubjectID, 1);
                StudentAverage average2 = StudentAverageBLL.GetStudentAverage(currentStudent.StudentID, SelectedSubject.SubjectID, 2);


                if (average != null)
                {
                    SemesterAverage = average.Average.ToString();
                }
                else
                {
                    SemesterAverage = "Not yet ";
                }

                if (average != null && average2 != null) 
                {
                    float final = (average.Average + average2.Average) / 2 ;

                    FinalAverage = final.ToString();
                }
                else
                {
                    FinalAverage = "Not yet ";
                }




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
                    }
                }
            }
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

        private ObservableCollection<Grade> gradeList;

        public ObservableCollection<Grade> GradeList
        {
            get { return gradeList; }
            set { SetProperty(ref gradeList, value); }
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

        private Grade selectedGrade;

        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set { SetProperty(ref selectedGrade, value); }
        }

        private TeacherMaterial selectedMaterial;

        public TeacherMaterial SelectedMaterial
        {
            get { return selectedMaterial; }
            set { SetProperty(ref selectedMaterial, value); }
        }


        private ObservableCollection<TeacherMaterial> materialList;

        public ObservableCollection<TeacherMaterial> MaterialList
        {
            get { return materialList; }
            set { SetProperty(ref materialList, value); }
        }


        private string semesterAverage;
        public string SemesterAverage
        {
            get { return semesterAverage; }
            set { SetProperty(ref semesterAverage, value); }
        }

        private string finalAverage;
        public string FinalAverage
        {
            get { return finalAverage; }
            set { SetProperty(ref finalAverage, value); }
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
