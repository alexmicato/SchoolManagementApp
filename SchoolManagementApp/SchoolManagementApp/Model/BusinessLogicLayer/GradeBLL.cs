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
    public class GradeBLL
    {
        private static GradeDAL gradeDAL = new GradeDAL();

        public static ObservableCollection<Grade> GetAllGrades()
        {
            return gradeDAL.GetAllGrades();
        }

        public static ObservableCollection<Grade> GetGradesByStudentTeacherSubjectSemester(int teacherID, int studentID, int subjectID, int semester)
        {
            try
            {

                return gradeDAL.GetGradesByStudentTeacherSubjectSemester(teacherID, studentID, subjectID, semester);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }
        public static ObservableCollection<Grade> GetGradesByStudentTeacherSubject(int teacherID, int studentID, int subjectID)
        {
            try
            {

                return gradeDAL.GetGradesByStudentTeacherSubject(teacherID, studentID, subjectID);  

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<Grade> GetGradesByStudentSubjectSemester(int studentID, int subjectID, int semester)
        {
            try
            {

                return gradeDAL.GetGradesByStudentSubjectSemester(studentID, subjectID, semester);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }
        public static ObservableCollection<Grade> GetGradesByStudentSubject(int studentID, int subjectID)
        {
            try
            {

                return gradeDAL.GetGradesByStudentSubject(studentID, subjectID);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }

        public static void AddGrade(Grade grade)
        {
            try
            {
                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
                }

                gradeDAL.AddGrade(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a grade: " + ex.Message);
                throw;
            }
        }

        public static void DeleteGrade(Grade grade)
        {
            try
            {
                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
                }

                gradeDAL.DeleteGrade(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a grade: " + ex.Message);
                throw;
            }
        }

        public static void UpdateGrade(Grade grade)
        {
            try
            {
                if (grade == null)
                {
                    throw new ArgumentNullException(nameof(grade), "Grade cannot be null.");
                }

                gradeDAL.UpdateGrade(grade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a grade: " + ex.Message);
                throw;
            }
        }
    }
}
