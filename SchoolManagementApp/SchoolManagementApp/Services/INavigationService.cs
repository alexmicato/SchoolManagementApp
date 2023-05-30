using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Services
{
    public interface INavigationService
    {
        void NavigateToTeacherPage(Teacher teacher);
    }
}
