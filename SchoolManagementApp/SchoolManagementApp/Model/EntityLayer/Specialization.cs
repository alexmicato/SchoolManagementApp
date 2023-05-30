using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class Specialization : INotifyPropertyChanged
    {
        private int specializationID;
        private string name;
        private int year;

        public int SpecializationID
        {
            get { return specializationID; }
            set
            {
                if( specializationID != value )
                {
                    specializationID = value;
                    OnPropertyChanged( nameof( specializationID ) );
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

        public int Year
        {
            get { return year; }
            set
            {
                if (year != value)
                {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        public Specialization()
        {

        }

        public Specialization(string name, int year)
        {
            this.name = name;
            this.year = year;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
