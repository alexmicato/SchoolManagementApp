using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Model.BusinessLogicLayer;
using System.Windows;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class UpdateStudentControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateStudentCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UpdateStudentControlVM() 
        {
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            studentList = StudentBLL.GetAllStudents();
            classList = ClassBLL.GetAllClasses();
        }

        public void UpdateStudent()
        {
            if (SelectedStudent == null)
            {
                ErrorMessage = "Please select a student";
                return;
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                ErrorMessage = "First name field cannot be empty";
                return;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                ErrorMessage = "Last name field cannot be empty";
                return;
            }

            SelectedStudent.FirstName = FirstName;
            SelectedStudent.LastName = LastName;

            if(SelectedClass != null) 
            {

                if(SelectedClass.ClassID == SelectedStudent.ClassID) 
                {
                    ErrorMessage = "This class already assigned";
                    return;
                }

                SelectedStudent.ClassID = SelectedClass.ClassID;    
            }

            StudentBLL.UpdateStudent(SelectedStudent);

            SelectedStudent = null;
            FirstName = string.Empty; LastName = string.Empty;
            SelectedClass = null;
            ClassName = string.Empty;
            SelectedClass = null;
            MessageBox.Show("Student modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            StudentList = StudentBLL.GetAllStudents();
            ErrorMessage = string.Empty;


        }

        private void OnSelectionChanged()
        {
            if(SelectedStudent != null)
            {
                FirstName = SelectedStudent.FirstName;
                LastName = SelectedStudent.LastName;

                if (SelectedStudent.ClassID != null)
                {
                    SelectedClass = ClassList.FirstOrDefault(c => c.ClassID == SelectedStudent.ClassID);
                    if (SelectedClass != null)
                    {
                        ClassName = SelectedClass.ClassName;
                    }
                }
                else
                {
                    SelectedClass = null;
                    ClassName = "None yet";
                }


            }
        }

        private ObservableCollection<Student> studentList;

        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { SetProperty(ref studentList, value); }
        }

        private ObservableCollection<Class> classList;

        public ObservableCollection<Class> ClassList
        {
            get { return classList; }
            set { SetProperty(ref classList, value); }
        }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { SetProperty(ref selectedStudent, value); }
        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { SetProperty(ref className, value); }

        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }

        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }

        }
        private Class selectedClass;

        public Class SelectedClass
        {
            get { return selectedClass; }
            set { SetProperty(ref selectedClass, value); }
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
