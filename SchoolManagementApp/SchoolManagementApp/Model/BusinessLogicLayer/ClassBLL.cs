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
    public class ClassBLL
    {
        private static ClassDAL classDAL = new ClassDAL();

        public static ObservableCollection<Class> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }

        public static ObservableCollection<Class> GetClassesByTeacherID(int teacherID)
        {
            return classDAL.GetClassesByTeacherID(teacherID);
        }

        public static ObservableCollection<Class> GetClassesBySubjectAndTeacher(int teacherID, int subjectID)
        {
            return classDAL.GetClassesBySubjectAndTeacher(teacherID, subjectID);
        }

        public static void AddClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "class cannot be null.");
                }

                classDAL.AddClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a class: " + ex.Message);
                throw;
            }
        }

        public static void DeleteClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "Class cannot be null.");
                }

                classDAL.DeleteClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a class: " + ex.Message);
                throw;
            }
        }

        public static void UpdateClass(Class item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item), "Class cannot be null.");
                }

                classDAL.UpdateClass(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a class: " + ex.Message);
                throw;
            }
        }
    }
}
