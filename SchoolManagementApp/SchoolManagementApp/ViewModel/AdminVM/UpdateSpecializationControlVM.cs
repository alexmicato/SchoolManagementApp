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
using SchoolManagementApp.Helpers;

namespace SchoolManagementApp.ViewModel.AdminVM
{
    public class UpdateSpecializationControlVM : INotifyPropertyChanged
    {
        public ICommand UpdateSpecializationCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public UpdateSpecializationControlVM()
        {
            UpdateSpecializationCommand = new RelayCommand(UpdateSpecialization);
            SelectionChangedCommand = new RelayCommand(OnSelectionChanged);
            specializationList = SpecializationBLL.GetAllSpecializations();
        }

        public void UpdateSpecialization()
        {
            if (SelectedSpecialization == null)
            {
                ErrorMessage = "Please select a specialization";
                return;
            }
            if (string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "First name field cannot be empty";
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "Last name field cannot be empty";
                return;
            }

            if(!Utility.ValidateNumber(Name)) 
            {
                ErrorMessage = "Enter a valid year";
                return;
            }

            SelectedSpecialization.Name = Name;
            SelectedSpecialization.Year = int.Parse(Year);

            SpecializationBLL.UpdateSpecialization(SelectedSpecialization);

            SelectedSpecialization = null;
            Name = string.Empty; Year = string.Empty;
            MessageBox.Show("Specialization modified successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            specializationList = SpecializationBLL.GetAllSpecializations();
            ErrorMessage = string.Empty;


        }

        private void OnSelectionChanged()
        {
            if (SelectedSpecialization != null)
            {
                Name = SelectedSpecialization.Name;
                Year = SelectedSpecialization.Year.ToString();
            }
        }

        private ObservableCollection<Specialization> specializationList;

        public ObservableCollection<Specialization> SpecializationList
        {
            get { return specializationList; }
            set { SetProperty(ref specializationList, value); }
        }

        private Specialization selectedSpecialization;

        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set { SetProperty(ref selectedSpecialization, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }

        }

        private string year;
        public string Year
        {
            get { return year; }
            set { SetProperty(ref year, value); }

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
