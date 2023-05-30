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
    public class SubjectDAL
    {
        public ObservableCollection<Subject> GetAllSubjects()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetSubjectsByTeacherID(int teacherID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsByTeacherID", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetSubjectsByTeacherAndClass(int teacherID, int classID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsByTeacherAndClass", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);
                cmd.Parameters.AddWithValue("@id_class", classID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetSubjectsNotInSpecialization(int specializationID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsNotInSpecialization", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_specialization", specializationID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetSubjectsInSpecialization(int specializationID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsInSpecialization", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_specialization", specializationID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Subject> GetSubjectsByClass(int classID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsByClass", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Subject()
                        {
                            SubjectID = (int)reader["id_subject"],
                            Name = (string)reader["name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void AddSubject(Subject subject)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", subject.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_subject", subject.SubjectID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_subject", subject.SubjectID);
                cmd.Parameters.AddWithValue("@name", subject.Name);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
