using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class ClassTeacherSubject : INotifyPropertyChanged
    {
        private int classID;
        private int teacherID;
        private int subjectID;
        private int? materialID;

        public int ClassID
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

        public int? MaterialID
        {
            get { return materialID; }
            set
            {
                if (materialID != value)
                {
                    materialID = value;
                    OnPropertyChanged(nameof(MaterialID));
                }
            }
        }

        public ClassTeacherSubject()
        {

        }

        public ClassTeacherSubject(int classID, int teacherID, int subjectID, int? materialID)
        {
            this.classID = classID;
            this.teacherID = teacherID;
            this.subjectID = subjectID;
            this.materialID = materialID;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
