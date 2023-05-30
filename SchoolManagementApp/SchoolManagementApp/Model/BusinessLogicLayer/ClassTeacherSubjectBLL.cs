using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class ClassTeacherSubjectBLL
    {
        private static ClassTeacherSubjectDAL classTeacherSubjectDAL = new ClassTeacherSubjectDAL();
        public static void AddCourse(ClassTeacherSubject course)
        {
            try
            {
                if (course == null)
                {
                    throw new ArgumentNullException(nameof(course), "Subject cannot be null.");
                }

                classTeacherSubjectDAL.AddCourse(course);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static void DeleteClassTeacherSubjectByClass(int classID, int teacherID)
        {
            try
            {
                classTeacherSubjectDAL.DeleteClassTeacherSubjectByClass(classID, teacherID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static void DeleteClassTeacherSubjectBySubject(int subjectID, int teacherID)
        {
            try
            {
                classTeacherSubjectDAL.DeleteClassTeacherSubjectBySubject(subjectID, teacherID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static void UpdateClassTeacherSubjectMaterial(ClassTeacherSubject classTeacherSubject)
        {
            try
            {
                if(classTeacherSubject == null)
                {
                    throw new ArgumentNullException(nameof(classTeacherSubject), "Class teacher subject cannot be null.");
                }

                classTeacherSubjectDAL.UpdateClassTeacherSubjectMaterial(classTeacherSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }
    }
}
