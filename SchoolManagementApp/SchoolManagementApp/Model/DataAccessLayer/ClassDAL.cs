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
    public class ClassDAL
    {
        public ObservableCollection<Class> GetAllClasses()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["id_class"],
                            SpecializationID = (int)reader["id_specialization"],
                            ClassTeacherID = (int)reader["id_classTeacher"],
                            ClassName = reader["class_name"].ToString().Trim()
                        }
                        ) ;
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Class> GetClassesByTeacherID(int teacherID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetClassesByTeacherID", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["id_class"],
                            SpecializationID = (int)reader["id_specialization"],
                            ClassTeacherID = (int)reader["id_classTeacher"],
                            ClassName = reader["class_name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<Class> GetClassesBySubjectAndTeacher(int teacherID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetClassesBySubjectAndTeacher", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Class()
                        {
                            ClassID = (int)reader["id_class"],
                            SpecializationID = (int)reader["id_specialization"],
                            ClassTeacherID = (int)reader["id_classTeacher"],
                            ClassName = reader["class_name"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void AddClass(Class item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_specialization", item.SpecializationID);
                cmd.Parameters.AddWithValue("@id_classTeacher", item.ClassTeacherID);
                cmd.Parameters.AddWithValue("class_name", item.ClassName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteClass(Class item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", item.ClassID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClass(Class item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", item.ClassID);
                cmd.Parameters.AddWithValue("@id_specialization", item.SpecializationID);
                cmd.Parameters.AddWithValue("@id_classTeacher", item.ClassTeacherID);
                cmd.Parameters.AddWithValue("@class_name", item.ClassName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
