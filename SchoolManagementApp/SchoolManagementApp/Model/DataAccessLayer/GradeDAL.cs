using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class GradeDAL
    {
        public ObservableCollection<Grade> GetAllGrades()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllGrades", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["id_grade"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            GradeValue = (float)reader["value"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsFinal = (bool)reader["isFinal"],
                            IsAveraged = (bool)reader["isAveraged"]
                            
                        }
                        ) ;
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Grade> GetGradesByStudentTeacherSubject(int teacherID, int studentID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetGradesByStudentTeacherSubject", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["id_grade"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            GradeValue = (float)(double)reader["value"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsFinal = (bool)reader["isFinal"],
                            IsAveraged = (bool)reader["isAveraged"]

                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Grade> GetGradesByStudentSubject(int studentID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetGradesByStudentSubject", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["id_grade"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            GradeValue = (float)(double)reader["value"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsFinal = (bool)reader["isFinal"],
                            IsAveraged = (bool)reader["isAveraged"]

                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Grade> GetGradesByStudentSubjectSemester( int studentID, int subjectID, int semester)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetGradesByStudentSubjectSemester", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@semester", semester);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["id_grade"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            GradeValue = (float)(double)reader["value"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsFinal = (bool)reader["isFinal"],
                            IsAveraged = (bool)reader["isAveraged"]

                        }
                        );
                }
                reader.Close();
                return result;

            }
        }


        public ObservableCollection<Grade>GetGradesByStudentTeacherSubjectSemester (int teacherID, int studentID, int subjectID, int semester)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetGradesByStudentTeacherSubjectSemester", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);
                cmd.Parameters.AddWithValue("@semester", semester);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Grade()
                        {
                            GradeID = (int)reader["id_grade"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            GradeValue = (float)(double)reader["value"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsFinal = (bool)reader["isFinal"],
                            IsAveraged = (bool)reader["isAveraged"]

                        }
                        );
                }
                reader.Close();
                return result;

            }
        }


        public void AddGrade(Grade grade)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", grade.StudentID);
                cmd.Parameters.AddWithValue("@id_subject", grade.SubjectID);
                cmd.Parameters.AddWithValue("@id_teacher", grade.TeacherID);
                cmd.Parameters.AddWithValue("@value", grade.GradeValue);
                cmd.Parameters.AddWithValue("@semester", grade.Semester);
                cmd.Parameters.AddWithValue("@date", grade.Date);
                cmd.Parameters.AddWithValue("@isFinal", grade.IsFinal);
                cmd.Parameters.AddWithValue("@isAveraged", grade.IsAveraged);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteGrade(Grade grade)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_grade", grade.GradeID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateGrade(Grade grade)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_grade", grade.GradeID);
                cmd.Parameters.AddWithValue("@id_student", grade.StudentID);
                cmd.Parameters.AddWithValue("@id_subject", grade.SubjectID);
                cmd.Parameters.AddWithValue("@id_teacher", grade.TeacherID);
                cmd.Parameters.AddWithValue("@value", grade.GradeValue);
                cmd.Parameters.AddWithValue("@semester", grade.Semester);
                cmd.Parameters.AddWithValue("@date", grade.Date);
                cmd.Parameters.AddWithValue("@isFinal", grade.IsFinal);
                cmd.Parameters.AddWithValue("@isAveraged", grade.IsAveraged);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
