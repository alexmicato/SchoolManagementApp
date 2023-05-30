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
    public class SubjectBLL
    {
        private static SubjectDAL subjectDAL = new SubjectDAL();

        public static ObservableCollection<Subject> GetAllSubjects()
        {
            return subjectDAL.GetAllSubjects();
        }

        public static ObservableCollection<Subject> GetSubjectsByClass(int classID)
        {
            return subjectDAL.GetSubjectsByClass(classID);
        }

        public static ObservableCollection<Subject> GetSubjectsByTeacherAndClass(int teacherID, int classID)
        {
            return subjectDAL.GetSubjectsByTeacherAndClass(teacherID, classID);
        }

        public static ObservableCollection<Subject> GetSubjectsByTeacherID(int teacherID)
        {
            return subjectDAL.GetSubjectsByTeacherID(teacherID);
        }

        public static ObservableCollection<Subject> GetSubjectsNotInSpecialization(int specializationID)
        {
            return subjectDAL.GetSubjectsNotInSpecialization(specializationID);
        }

        public static ObservableCollection<Subject> GetSubjectsInSpecialization(int specializationID)
        {
            return subjectDAL.GetSubjectsInSpecialization(specializationID);
        }

        public  static void AddSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.AddSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static void DeleteSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.DeleteSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a subject: " + ex.Message);
                throw;
            }
        }

        public static void UpdateSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                subjectDAL.UpdateSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a subject: " + ex.Message);
                throw;
            }
        }
    }
}
