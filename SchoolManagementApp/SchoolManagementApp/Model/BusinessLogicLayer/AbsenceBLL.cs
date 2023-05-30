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
    public class AbsenceBLL
    {
        private static AbsenceDAL absenceDAL = new AbsenceDAL();

        public static ObservableCollection<Absence> GetAllAbsences()
        {
            return absenceDAL.GetAllAbsences();
        }

        public static ObservableCollection<Absence> GetAbsencesByStudentTeacherSubject(int teacherID, int studentID, int subjectID)
        {
            try
            {   
                return absenceDAL.GetAbsencesByStudentTeacherSubject(teacherID, studentID, subjectID);  
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a absence: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Absence> GetAbsencesByStudentSubject(int studentID, int subjectID)
        {
            try
            {
                return absenceDAL.GetAbsencesByStudentSubject(studentID, subjectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a absence: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Absence> GetAbsencesByStudentSubjectSemester(int studentID, int subjectID, int semester)
        {
            try
            {
                return absenceDAL.GetAbsencesByStudentSubjectSemester(studentID, subjectID, semester);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a absence: " + ex.Message);
                throw;
            }
        }

        public static void AddAbsence(Absence absence)
        {
            try
            {
                if (absence == null)
                {
                    throw new ArgumentNullException(nameof(absence), "Absence cannot be null.");
                }

                absenceDAL.AddAbsence(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a absence: " + ex.Message);
                throw;
            }
        }

        public static void DeleteAbsence(Absence absence)
        {
            try
            {
                if (absence == null)
                {
                    throw new ArgumentNullException(nameof(absence), "Absence cannot be null.");
                }

                absenceDAL.DeleteAbsence(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a absence: " + ex.Message);
                throw;
            }
        }

        public static void UpdateAbsence(Absence absence)
        {
            try
            {
                if (absence == null)
                {
                    throw new ArgumentNullException(nameof(absence), "Absence cannot be null.");
                }

                absenceDAL.UpdateAbsence(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a absence: " + ex.Message);
                throw;
            }
        }
    }
}
