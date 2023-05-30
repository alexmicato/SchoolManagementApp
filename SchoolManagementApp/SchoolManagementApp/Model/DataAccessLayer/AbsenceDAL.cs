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
    public class AbsenceDAL
    {
        public ObservableCollection<Absence> GetAllAbsences()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsences", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["id_absence"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsMotivated = (bool)reader["isMotivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Absence> GetAbsencesByStudentTeacherSubject(int teacherID, int studentID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesByStudentTeacherSubject", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["id_absence"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsMotivated = (bool)reader["isMotivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Absence> GetAbsencesByStudentSubject(int studentID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesByStudentSubject", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
       
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["id_absence"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsMotivated = (bool)reader["isMotivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Absence> GetAbsencesByStudentSubjectSemester(int studentID, int subjectID, int semester)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesByStudentSubjectSemester", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@semester", semester);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Absence()
                        {
                            AbsenceID = (int)reader["id_absence"],
                            StudentID = (int)reader["id_student"],
                            SubjectID = (int)reader["id_subject"],
                            TeacherID = (int)reader["id_teacher"],
                            Semester = (int)reader["semester"],
                            Date = (DateTime)reader["date"],
                            IsMotivated = (bool)reader["isMotivated"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void AddAbsence(Absence absence)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", absence.StudentID);
                cmd.Parameters.AddWithValue("@id_subject", absence.SubjectID);
                cmd.Parameters.AddWithValue("@id_teacher", absence.TeacherID);
                cmd.Parameters.AddWithValue("@semester", absence.Semester);
                cmd.Parameters.AddWithValue("@date", absence.Date);
                cmd.Parameters.AddWithValue("@isMotivated", absence.IsMotivated);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteAbsence(Absence absence)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_absence", absence.AbsenceID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateAbsence(Absence absence)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_absence", absence.AbsenceID);
                cmd.Parameters.AddWithValue("@id_student", absence.StudentID);
                cmd.Parameters.AddWithValue("@id_subject", absence.SubjectID);
                cmd.Parameters.AddWithValue("@id_teacher", absence.TeacherID);
                cmd.Parameters.AddWithValue("@semester", absence.Semester);
                cmd.Parameters.AddWithValue("@date", absence.Date);
                cmd.Parameters.AddWithValue("@isMotivated", absence.IsMotivated);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
