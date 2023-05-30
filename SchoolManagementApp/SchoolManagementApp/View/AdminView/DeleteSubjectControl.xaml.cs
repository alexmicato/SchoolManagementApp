﻿using System;
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
using SchoolManagementApp.ViewModel;
using SchoolManagementApp.ViewModel.AdminVM;

namespace SchoolManagementApp.View.AdminView
{
    /// <summary>
    /// Interaction logic for DeleteSubjectControl.xaml
    /// </summary>
    public partial class DeleteSubjectControl : UserControl
    {
        public DeleteSubjectControl()
        {
            InitializeComponent();
            DataContext = new DeleteSubjectControlVM();
        }
    }
}
