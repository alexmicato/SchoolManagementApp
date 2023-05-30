using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Helpers;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.Model.BusinessLogicLayer;
using System.Windows;

namespace SchoolManagementApp.ViewModel
{
    class AddSpecializationVM : INotifyPropertyChanged
    {
        public ICommand AddSpecializationCommand { get; private set; }
        public AddSpecializationVM() 
        {
            AddSpecializationCommand = new RelayCommand(AddSpecialization);
        }

        public void AddSpecialization()
        {
            if(string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "Name field cannot be empty";
                return;
            }
            if(string.IsNullOrEmpty(Year))
            {
                ErrorMessage = "Please enter year";
                return;
            }
            else if(!Utility.ValidateNumber(Year)) {
                ErrorMessage = "Please enter a valid year";
                return;
            }

            Specialization specialization = new Specialization(Name, int.Parse(Year));

            SpecializationBLL.AddSpecialization(specialization);

            MessageBox.Show("Specialization added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Name = string.Empty;
            Year = string.Empty;
            ErrorMessage = string.Empty;
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
