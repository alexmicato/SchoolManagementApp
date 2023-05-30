using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Teacher : INotifyPropertyChanged
    {
        private int teacherID;
        private string firstName;
        private string lastName;
        private int userID;

        public int TeacherID
        {
            get { return teacherID; }
            set
            {
                if (teacherID != value)
                {
                    teacherID = value;
                    OnPropertyChanged(nameof(TeacherID));
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public int UserID
        {
            get { return userID; }
            set
            {
                if (userID != value)
                {
                    userID = value;
                    OnPropertyChanged(nameof(UserID));
                }
            }
        }

        public Teacher()
        {

        }
        public Teacher(string firstName, string lastName, int userID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userID = userID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
