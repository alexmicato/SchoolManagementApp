using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.BusinessLogicLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class DeleteSubjectControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteSubjectCommand { get; set; }  
        public DeleteSubjectControlVM() 
        {
            DeleteSubjectCommand = new RelayCommand(DeleteSubject);
            subjectList = SubjectBLL.GetAllSubjects();
        }

        public void DeleteSubject()
        {
            if(SelectedSubject == null)
            {
                ErrorMessage = "Please select a subject to delete";
                return;
            }

            SubjectBLL.DeleteSubject(SelectedSubject);

            MessageBox.Show("Subject deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SubjectList = SubjectBLL.GetAllSubjects();
            ErrorMessage = string.Empty;
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
