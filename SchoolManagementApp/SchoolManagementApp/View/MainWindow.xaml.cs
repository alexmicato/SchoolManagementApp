using SchoolManagementApp.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using SchoolManagementApp.View.TeacherView;
using SchoolManagementApp.View.ClassTeacher;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModel;
using SchoolManagementApp.Model.EntityLayer;
using SchoolManagementApp.View.StudentView;

namespace SchoolManagementApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly NavigationServices _navigationService;
        public MainWindow()
        {
            InitializeComponent();
            LoginPage loginPage = new LoginPage();
            LoginPageVM loginPageVM = loginPage.DataContext as LoginPageVM;

            //_navigationService = navigationService;
            //_navigationService.TeacherPageRequested += OnTeacherPageRequested;

            loginPageVM.AdminLoggedIn += (sender, args) =>
            {
                MainFrame.Navigate(new AdminPage());
            };

            loginPageVM.TeacherLoggedIn += (sender, args) =>
            {
                Teacher teacher = args.Teacher;
                MainFrame.Navigate(new TeacherPage(teacher));
            };

            loginPageVM.ClassTeacherLoggedIn += (sender, args) =>
            {
                MainFrame.Navigate(new ClassTeacherPage());
            };

            loginPageVM.StudentLoggedIn += (sender, args) =>
            {
                Student student = args.Student;
                MainFrame.Navigate(new StudentPage(student));
            };

            MainFrame.Navigate(loginPage);

        }

        //private void OnTeacherPageRequested(object sender, TeacherPageRequestedEventArgs e)
        //{
        //    MainFrame.Navigate(new TeacherPage(e.Teacher));
        //}
    }
}
