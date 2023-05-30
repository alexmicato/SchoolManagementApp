using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class StudentAverage : INotifyPropertyChanged
    {
        private int studentID;
        private int subjectID;
        private int semester;
        private float average;


        public int SubjectID
        {
            get { return subjectID; }
            set
            {
                if (subjectID != value)
                {
                    subjectID = value;
                    OnPropertyChanged(nameof(SubjectID));
                }
            }
        }

        public int StudentID
        {
            get { return studentID; }
            set
            {
                if (studentID != value)
                {
                    studentID = value;
                    OnPropertyChanged(nameof(StudentID));
                }
            }
        }

        public int Semester
        {
            get { return semester; }
            set
            {
                if (semester != value)
                {
                    semester = value;
                    OnPropertyChanged(nameof(Semester));
                }
            }
        }

        public float Average
        {
            get { return average; }
            set
            {
                if (average != value)
                {
                    average = value;
                    OnPropertyChanged(nameof(Average));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
