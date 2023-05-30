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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SchoolManagementApp.ViewModel.TeacherVM
{
    public class ViewTeacherMaterialControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteMaterialCommand { get; set; }

        public ICommand DownloadMaterialCommand { get; set; }
        public ICommand MaterialSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand ClassSelectionChangedCommand { get; set; }

        private Teacher currentTeacher;
        public ViewTeacherMaterialControlVM(Teacher teacher)
        {
            currentTeacher = teacher;
            DeleteMaterialCommand = new RelayCommand(DeleteMaterial);
            DownloadMaterialCommand = new RelayCommand(DownloadMaterial);
            MaterialSelectionChangedCommand = new RelayCommand(OnMaterialSelectionChanged);
            ClassSelectionChangedCommand = new RelayCommand(OnClassSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);


            subjectList = SubjectBLL.GetSubjectsByTeacherID(currentTeacher.TeacherID);
            classList = ClassBLL.GetClassesByTeacherID(currentTeacher.TeacherID);
            materialList = new ObservableCollection<TeacherMaterial>();

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

            if (SelectedClass == null)
            {
                ErrorMessage = "You must select a class";
                return;
            }

            if (SelectedMaterial == null)
            {
                ErrorMessage = "Please select the material";
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

        public void DeleteMaterial()
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

            if(SelectedMaterial == null) 
            {
                ErrorMessage = "Please select the material";
                return;
            }

            TeacherMaterialBLL.DeleteTeacherMaterial(selectedMaterial);

            MessageBox.Show("Material deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            MaterialList = TeacherMaterialBLL.GetTeacherMaterialByClassTeacherSubject(selectedClass.ClassID, SelectedSubject.SubjectID, currentTeacher.TeacherID);

            SelectedSubject = null;
            SelectedMaterial = null;
            SelectedClass = null;
            ErrorMessage = string.Empty;
        }

        public void OnSubjectSelectionChanged()
        {
            if (SelectedSubject != null && SelectedClass != null)
            {
                MaterialList = TeacherMaterialBLL.GetTeacherMaterialByClassTeacherSubject(selectedClass.ClassID, SelectedSubject.SubjectID, currentTeacher.TeacherID);
                
            }
        }

        public void OnClassSelectionChanged()
        {
            if (SelectedClass != null)
            {
                SubjectList = SubjectBLL.GetSubjectsByTeacherAndClass(currentTeacher.TeacherID, SelectedClass.ClassID);
            }
        }

        public void OnMaterialSelectionChanged()
        {
            
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
