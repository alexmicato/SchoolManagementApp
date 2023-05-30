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
using Microsoft.Win32;

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class AddTeacherMaterialControlVM : INotifyPropertyChanged
    {
        public ICommand AddMaterialCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        public ICommand ChooseMaterialCommand { get; set; } 

        private Teacher currentTeacher;
        public AddTeacherMaterialControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            AddMaterialCommand = new RelayCommand(AddMaterial);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);
            ChooseMaterialCommand = new RelayCommand(ChooseMaterial);

            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);
        }

        public void ChooseMaterial()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
        }


        public void AddMaterial()
        {
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

            if(FilePath == null)
            {
                ErrorMessage = "Please select a file";
                return;
            }

            TeacherMaterial material = new TeacherMaterial()
            {
                Name = MaterialName,
                FilePath = FilePath,

            };

            int materialID = TeacherMaterialBLL.AddTeacherMaterial(material);

            ClassTeacherSubject classTeacherSubject = new ClassTeacherSubject()
            {
                ClassID = SelectedClass.ClassID,
                SubjectID = SelectedSubject.SubjectID,
                TeacherID = currentTeacher.TeacherID,
                MaterialID = materialID
            };

            ClassTeacherSubjectBLL.UpdateClassTeacherSubjectMaterial(classTeacherSubject);

            MessageBox.Show("Teacher material added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedClass = null;
            MaterialName = string.Empty;
            FilePath = string.Empty;
            ErrorMessage = string.Empty;

        }

        public void OnSubjectSelectionChanged()
        {
            if (SelectedSubject != null)
            {

            }
        }

        public void OnClassSelectionChanged()
        {
            if (SelectedClass != null)
            {
                SubjectList = SubjectBLL.GetSubjectsByTeacherAndClass(currentTeacher.TeacherID, SelectedClass.ClassID);
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


        private string name;

        public string MaterialName
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { SetProperty(ref filePath, value); }
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
