using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolManagementApp.ViewModel.TeacherVM;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.View.TeacherView
{
    /// <summary>
    /// Interaction logic for AddGradeControl.xaml
    /// </summary>
    public partial class AddGradeControl : UserControl
    {
        public AddGradeControl(Teacher teacher)
        {
            InitializeComponent();
            DataContext = new AddGradeControlVM(teacher);
        }
    }
}
