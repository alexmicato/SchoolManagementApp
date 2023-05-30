using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class SpecializationSubject : INotifyPropertyChanged
    {

        private int subjectID;
        private int specializationID;
        private bool isFinalSubject;

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

        public bool IsFinalSubject
        {
            get { return isFinalSubject; }
            set
            {
                if (isFinalSubject != value)
                {
                    isFinalSubject = value;
                    OnPropertyChanged(nameof(IsFinalSubject));
                }
            }
        }

        public SpecializationSubject(int specializationID, int subjectID, bool isFinal)
        {
            this.specializationID = specializationID;
            this.subjectID = subjectID;
            this.isFinalSubject = isFinal;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
