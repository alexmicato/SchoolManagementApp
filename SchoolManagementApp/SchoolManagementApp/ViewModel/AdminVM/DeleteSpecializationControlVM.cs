using CommunityToolkit.Mvvm.Input;
using SchoolManagementApp.Model.BusinessLogicLayer;
using SchoolManagementApp.Model.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class DeleteSpecializationControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteSpecializationCommand { get; set; }
        public DeleteSpecializationControlVM()
        {
            DeleteSpecializationCommand = new RelayCommand(DeleteSpecialization);
            specializationList = SpecializationBLL.GetAllSpecializations();
        }

        public void DeleteSpecialization()
        {
            if (selectedSpecialization == null)
            {
                ErrorMessage = "Please select a specialization to delete";
                return;
            }

            SpecializationBLL.DeleteSpecialization(selectedSpecialization);

            MessageBox.Show("Specialization deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            selectedSpecialization = null;
            SpecializationList = SpecializationBLL.GetAllSpecializations();
            ErrorMessage = string.Empty;
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
