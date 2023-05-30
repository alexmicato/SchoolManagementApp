using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class StudentAverageBLL
    {
        private static StudentAverageDAL studentAverageDAL = new StudentAverageDAL();

        public static void AddStudentAverage(StudentAverage studentAverage)
        {
            try
            {
                if (studentAverage == null)
                {
                    throw new ArgumentNullException(nameof(studentAverage), "Average cannot be null.");
                }

                studentAverageDAL.AddStudentAverage(studentAverage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static StudentAverage GetStudentAverage(int studentID, int subjectID, int semester)
        {
            return studentAverageDAL.GetStudentAverage(studentID, subjectID, semester); 
        }
    }
}
