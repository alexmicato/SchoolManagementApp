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
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.ViewModel.StudentVM;

namespace SchoolManagementApp.View.StudentView
{
    /// <summary>
    /// Interaction logic for ViewStudentGradesControl.xaml
    /// </summary>
    public partial class ViewStudentInfoControl : UserControl
    {
        public ViewStudentInfoControl(Student student)
        {
            InitializeComponent();

            DataContext = new ViewStudentInfoControlVM(student);
        }
    }
}
