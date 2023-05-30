using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Class : INotifyPropertyChanged
    {
        private int classID;
        private int specializationID;
        private int classTeacherID;
        private string className;

        public string ClassName
        {
            get { return className; } 
            set 
            {
                if (className != value) 
                {
                    className = value;
                    OnPropertyChanged(ClassName);
                }
            }
        }


        public int ClassTeacherID
        {
            get { return classTeacherID; }
            set
            {
                if (classTeacherID != value)
                {
                    classTeacherID = value;
                    OnPropertyChanged(nameof(ClassTeacherID));
                }
            }
        }

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

        public int SpecializationID
        {
            get { return specializationID; }
            set
            {
                if (specializationID != value)
                {
                    specializationID = value;
                    OnPropertyChanged(nameof(SpecializationID));
                }
            }
        }
        public Class()
        {

        }
        public Class(int specializationID)
        {
            this.specializationID = specializationID;
        }

        public Class(int specializationID, int classTeacherID, string className)
        {
            this.specializationID = specializationID;
            this.classTeacherID = classTeacherID;
            this.className = className;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


   
}
