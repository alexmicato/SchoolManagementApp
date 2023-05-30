using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Grade : INotifyPropertyChanged
    {
        private int gradeID;
        private int studentID;
        private int subjectID;
        private int teacherID;
        private float gradeValue;
        private int semester;
        private DateTime date;
        private bool isFinal;
        private bool isAveraged;

        public int GradeID
        {
            get { return gradeID; } 
            set 
            {
                if (gradeID != value)
                {
                    gradeID = value;
                    OnPropertyChanged(nameof(GradeID));
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

        public float GradeValue
        {
            get { return gradeValue; }
            set
            {
                if(gradeValue != value)
                {
                    gradeValue = value;
                    OnPropertyChanged(nameof(GradeValue));
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

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public bool IsFinal
        {
            get { return isFinal; }
            set
            {
                if (isFinal != value)
                {
                    isFinal = value;
                    OnPropertyChanged(nameof(IsFinal));
                }
            }
        }

        public bool IsAveraged
        {
            get { return isAveraged; }
            set
            {
                if (isAveraged != value)
                {
                    isAveraged = value;
                    OnPropertyChanged(nameof(IsAveraged));
                }
            }
        }

        public Grade()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
