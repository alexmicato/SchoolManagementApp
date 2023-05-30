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
    public class DeleteClassControlVM : INotifyPropertyChanged
    {
        public ICommand DeleteClassCommand { get; set; }
        public DeleteClassControlVM()
        {
            DeleteClassCommand = new RelayCommand(DeleteClass);
            classList = ClassBLL.GetAllClasses();
        }

        public void DeleteClass()
        {
            if (SelectedClass == null)
            {
                ErrorMessage = "Please select a class to delete";
                return;
            }

            ClassBLL.DeleteClass(SelectedClass);

            MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedClass = null;
            ClassList = ClassBLL.GetAllClasses();
            ErrorMessage = string.Empty;
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
