using SchoolManagementApp.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class StudentBLL
    {
        private static StudentDAL studentDAL = new StudentDAL();

        public static ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }

        public static ObservableCollection<Student> GetStudentsByClass(int classID)
        {
            try
            {
                return studentDAL.GetStudentsByClass(classID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static Student GetStudentByUserId(int userID)
        {
            try
            {
                return studentDAL.GetStudentByUserID(userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static void AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                studentDAL.AddStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a student: " + ex.Message);
                throw;
            }
        }

        public static void DeleteStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                studentDAL.DeleteStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a student: " + ex.Message);
                throw;
            }
        }

        public  static void UpdateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null.");
                }

                studentDAL.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a student: " + ex.Message);
                throw;
            }
        }
    }
}
