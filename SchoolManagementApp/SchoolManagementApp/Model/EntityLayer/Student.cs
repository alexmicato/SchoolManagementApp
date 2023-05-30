using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Student : INotifyPropertyChanged
    {
        private int studentID;
        private string firstName;
        private string lastName;
        private int? classID;
        private int userID;

        public int StudentID
        {
            get { return studentID; } 
            set
            {
                if(studentID != value)
                {
                    studentID = value;
                    OnPropertyChanged(nameof(StudentID));
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

        public int? ClassID
        {
            get { return classID; }
            set
            {
                if (classID != value)
                {
                    classID = value;
                    OnPropertyChanged(nameof(ClassID));
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

        public Student()
        {

        }

        public Student(string firstName, string lastName, int classID, int userID)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.classID = classID;
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.classID = classID;
            this.userID = userID;
        }

        public Student(int studentID, string firstName, string lastName, int classID, int userID)
        {
            this.studentID = studentID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.classID = classID;
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.classID = classID;
            this.userID = userID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     

    }
}
