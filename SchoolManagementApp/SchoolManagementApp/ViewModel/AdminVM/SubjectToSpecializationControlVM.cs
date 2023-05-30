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
using System.Windows;
using System.Windows.Input;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class SubjectToSpecializationControlVM : INotifyPropertyChanged
    {
        public ICommand AddSubjectCommand { get; set; } 
        public ICommand SpecializationSelectionChangedCommand { get; set; }
        public ICommand SubjectSelectionChangedCommand { get; set; }
        public ICommand PresentSubjectSelectionChangedCommand { get; set; }
        public SubjectToSpecializationControlVM() 
        {
            AddSubjectCommand = new RelayCommand(AddSubject);
            SpecializationSelectionChangedCommand = new RelayCommand(OnSpecializationSelectionChanged);
            PresentSubjectSelectionChangedCommand = new RelayCommand(OnPresentSubjectSelectionChanged);
            SubjectSelectionChangedCommand = new RelayCommand(OnSubjectSelectionChanged);

            subjectList = SubjectBLL.GetAllSubjects();
            specializationList = SpecializationBLL.GetAllSpecializations();
            presentSubjectList = SubjectBLL.GetAllSubjects();
        }

        public void AddSubject()
        {
            if(SelectedSpecialization == null)
            {
                ErrorMessage = "You must select a specialization";
                return;
            }
            if (SelectedSubject == null)
            {
                ErrorMessage = "You must select a subject";
                return;
            }

            SpecializationSubject specializationSubject = new SpecializationSubject(SelectedSpecialization.SpecializationID, SelectedSubject.SubjectID, IsFinal);

            SpecializationSubjectBLL.AddSpecializationSubject(specializationSubject);

            MessageBox.Show("Subject added to specialization!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedSubject = null;
            SelectedSpecialization = null;
            SelectedPresentSubject = null;
            IsFinal = false;
            ErrorMessage = string.Empty;


        }

        public void OnSubjectSelectionChanged()
        {
            if(SelectedSubject != null)
            {
                IsFinal = false;
            }
        }

        public void OnPresentSubjectSelectionChanged()
        {
            if(SelectedPresentSubject != null && SelectedSpecialization != null)
            {
                IsFinal = SpecializationSubjectBLL.GetSubjectFinalStatus(SelectedPresentSubject.SubjectID, SelectedSpecialization.SpecializationID);
            }
        }

        public void OnSpecializationSelectionChanged()
        {
            if(SelectedSpecialization != null)
            {
                SubjectList = SubjectBLL.GetSubjectsNotInSpecialization(SelectedSpecialization.SpecializationID);
                PresentSubjectList = SubjectBLL.GetSubjectsInSpecialization(SelectedSpecialization.SpecializationID);

                IsFinal = false;

                
            }
        }

        private bool isFinal;

        public bool IsFinal
        {
            get { return isFinal; }
            set { SetProperty(ref isFinal, value); }
        }

        private Specialization selectedSpecialization;

        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set { SetProperty(ref selectedSpecialization, value); }
        }


        private ObservableCollection<Specialization> specializationList;

        public ObservableCollection<Specialization> SpecializationList
        {
            get { return specializationList; }
            set { SetProperty(ref specializationList, value); }
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

        private Subject selectedPresentSubject;

        public Subject SelectedPresentSubject
        {
            get { return selectedPresentSubject; }
            set { SetProperty(ref selectedPresentSubject, value); }
        }

        private ObservableCollection<Subject> presentSubjectList;

        public ObservableCollection<Subject> PresentSubjectList
        {
            get { return presentSubjectList; }
            set { SetProperty(ref presentSubjectList, value); }
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
