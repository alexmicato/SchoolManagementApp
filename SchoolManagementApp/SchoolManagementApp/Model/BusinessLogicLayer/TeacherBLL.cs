using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class TeacherBLL
    {
        private static TeacherDAL teacherDAL = new TeacherDAL();

        public static ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }

        public static Teacher GetTeacherByUserId(int userID)
        {
            try
            {
                return teacherDAL.GetTeacherByUserID(userID);
            }
            catch (Exception ex )
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static bool CheckIfClassTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                return teacherDAL.CheckIfClassTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static void AddTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                teacherDAL.AddTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static void DeleteTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                teacherDAL.DeleteTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a teacher: " + ex.Message);
                throw;
            }
        }

        public  static void UpdateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
                }

                teacherDAL.UpdateTeacher(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a teacher: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Teacher> GetTeachersNotClassTeachers()
        {
            try
            {
                return teacherDAL.GetTeachersNotClassTeachers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a teacher: " + ex.Message);
                throw;
            }
        }
    }
}
