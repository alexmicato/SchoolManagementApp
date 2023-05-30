using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.View.TeacherView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    public class NavigationServices : INavigationService
    {
        
        public event EventHandler<TeacherPageRequestedEventArgs> TeacherPageRequested;
        public NavigationServices(Frame mainFrame)
        {
            
        }

        public void NavigateToTeacherPage(Teacher teacher)
        {
            TeacherPageRequested?.Invoke(this, new TeacherPageRequestedEventArgs(teacher));
        }
    }

    public class TeacherPageRequestedEventArgs : EventArgs
    {
        public Teacher Teacher { get; }

        public TeacherPageRequestedEventArgs(Teacher teacher)
        {
            Teacher = teacher;
        }
    }
}
