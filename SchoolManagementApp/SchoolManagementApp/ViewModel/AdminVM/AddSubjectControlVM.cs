using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.Model.BusinessLogicLayer;
using System.Windows;

namespace SchoolManagementApp.ViewModel
{
    class AddSubjectControlVM : INotifyPropertyChanged
    {
        public ICommand AddSubjectCommand { get; set; }
        public AddSubjectControlVM()
        {
            AddSubjectCommand = new RelayCommand(AddSubject);
        }

        public void AddSubject()
        {
            if(string.IsNullOrEmpty(Name))
            {
                ErrorMessage = "Name field cannot be empty";
                return;
            }

            Subject subject = new Subject(Name);

            SubjectBLL.AddSubject(subject);

            MessageBox.Show("Subject added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Name = string.Empty;
            ErrorMessage = string.Empty;
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
