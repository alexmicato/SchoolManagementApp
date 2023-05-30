using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class TeacherMaterial : INotifyPropertyChanged
    {
        private int materialID;
        private string name;
        private string filePath;

        public int MaterialID
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

        public string FilePath
        {
            get { return filePath; }
            set 
            {
                if (filePath != value) 
                {
                    filePath = value;
                    OnPropertyChanged(nameof(FilePath));    
                }
            }
        }

        public TeacherMaterial()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
