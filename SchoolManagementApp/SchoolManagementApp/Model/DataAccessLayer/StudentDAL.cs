using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class StudentDAL
    {
   
        public ObservableCollection<Student> GetAllStudents()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student()
                    {
                        StudentID = (int)reader["id_student"],
                        FirstName = reader["first_name"].ToString().Trim(),
                        LastName = reader["last_name"].ToString().Trim(),
                        UserID = (int)reader["id_user"]
                    };

                    if (reader["id_class"] != DBNull.Value)
                    {
                        student.ClassID = (int)reader["id_class"];
                    }

                    result.Add(student);
                }
                reader.Close();
                return result;
            }
        }

        public ObservableCollection<Student> GetStudentsByClass(int classID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentsByClass", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student()
                    {
                        StudentID = (int)reader["id_student"],
                        FirstName = reader["first_name"].ToString().Trim(),
                        LastName = reader["last_name"].ToString().Trim(),
                        UserID = (int)reader["id_user"]
                    };

                    if (reader["id_class"] != DBNull.Value)
                    {
                        student.ClassID = (int)reader["id_class"];
                    }

                    result.Add(student);
                }
                reader.Close();
                return result;
            }
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", student.FirstName);
                cmd.Parameters.AddWithValue("@last_name", student.LastName);
                cmd.Parameters.AddWithValue("@id_class", student.ClassID);
                cmd.Parameters.AddWithValue("@id_user", student.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", student.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", student.StudentID);
                cmd.Parameters.AddWithValue("@first_name", student.FirstName);
                cmd.Parameters.AddWithValue("@last_name", student.LastName);
                cmd.Parameters.AddWithValue("@id_class", student.ClassID);
                cmd.Parameters.AddWithValue("@id_user", student.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Student GetStudentByUserID(int userID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentByUserID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_user", userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Student student = null;

                if (reader.Read())
                {
                    student = new Student()
                    {
                        StudentID = (int)reader["id_student"],
                        FirstName = reader["first_name"].ToString().Trim(),
                        LastName = reader["last_name"].ToString().Trim(),
                        UserID = (int)reader["id_user"]

                    };

                    if (reader["id_class"] != DBNull.Value)
                    {
                        student.ClassID = (int)reader["id_class"];
                    }
                }

                reader.Close();
                return student;
            }
        }


    }
}
