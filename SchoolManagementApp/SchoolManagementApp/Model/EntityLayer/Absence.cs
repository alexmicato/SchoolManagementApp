using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Absence : INotifyPropertyChanged
    {

        private int absenceID;
        private int studentID;
        private int subjectID;
        private int teacherID;
        private int semester;
        private DateTime date;
        private bool isMotivated;

        public int AbsenceID
        {
            get { return absenceID; }
            set
            {
                if (absenceID != value)
                {
                    absenceID = value;
                    OnPropertyChanged(nameof(AbsenceID));
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

        public bool IsMotivated
        {
            get { return isMotivated; }
            set
            {
                if (isMotivated != value)
                {
                    isMotivated = value;
                    OnPropertyChanged(nameof(IsMotivated));
                }
            }
        }

        public Absence()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
