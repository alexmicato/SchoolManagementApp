using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Subject : INotifyPropertyChanged
    {
        private int subjectID;
        private string name;

        public int SubjectID
        {
            get { return subjectID; }
            set
            {
                if(subjectID != value)
                {
                    subjectID = value;
                    OnPropertyChanged(nameof(SubjectID));
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public Subject()
        {

        }

        public Subject(string name)
        {
            this.name = name;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
}
