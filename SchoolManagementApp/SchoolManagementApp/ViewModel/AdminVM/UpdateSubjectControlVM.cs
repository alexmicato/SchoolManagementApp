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
    public class UpdateSubjectControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateSubjectCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UpdateSubjectControlVM()
        {
            UpdateSubjectCommand = new RelayCommand(UpdateSubject);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            subjectList = SubjectBLL.GetAllSubjects();
        }

        public void UpdateSubject()
        {
            if (SelectedSubject == null)
            {
                ErrorMessage = "Please select a subject";
                return;
            }
            if (string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "Name field cannot be empty";
                return;
            }

            SelectedSubject.Name = Name;


            SubjectBLL.UpdateSubject(SelectedSubject);

            SelectedSubject = null;
            Name = string.Empty;
            MessageBox.Show("Student modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SubjectList = SubjectBLL.GetAllSubjects();
            ErrorMessage = string.Empty;


        }

        private void OnSelectionChanged()
        {
            if (SelectedSubject != null)
            {
                Name = SelectedSubject.Name;
            }
        }

        private ObservableCollection<Subject> subjectList;

        public ObservableCollection<Subject> SubjectList
        {
            get { return subjectList; }
            set { SetProperty(ref subjectList, value); }
        }

        private Subject selectedSubject;

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set { SetProperty(ref selectedSubject, value); }
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
