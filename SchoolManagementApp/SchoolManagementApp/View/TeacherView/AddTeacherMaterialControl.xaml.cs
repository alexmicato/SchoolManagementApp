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
using SchoolManagementApp.ViewModel.TeacherVM;

namespace SchoolManagementApp.View.TeacherView
{
    /// <summary>
    /// Interaction logic for AddTeacherMaterialControl.xaml
    /// </summary>
    public partial class AddTeacherMaterialControl : UserControl
    {
        public AddTeacherMaterialControl(Teacher teacher)
        {
            InitializeComponent();

            DataContext = new AddTeacherMaterialControlVM(teacher);
        }
    }
}
