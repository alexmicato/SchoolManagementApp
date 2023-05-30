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
    public class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Teacher()
                        {
                            TeacherID = (int)reader["id_teacher"],
                            FirstName = reader["first_name"].ToString().Trim(),
                            LastName = reader["last_name"].ToString().Trim(),
                            UserID = (int)reader["id_user"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void AddTeacher(Teacher teacher)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", teacher.FirstName);
                cmd.Parameters.AddWithValue("@last_name", teacher.LastName);
                cmd.Parameters.AddWithValue("@id_user", teacher.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool CheckIfClassTeacher(Teacher teacher)
        {
            bool isClassTeacher = false;

            using (SqlConnection con = DatabaseHelper.Connection) 
            {
                SqlCommand cmd = new SqlCommand("CheckIfClassTeacher", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", teacher.TeacherID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isClassTeacher = Convert.ToBoolean(reader["IsClassTeacher"]);
                }

                reader.Close();
            }

            return isClassTeacher;
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_teacher", teacher.TeacherID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_teacher", teacher.TeacherID);
                cmd.Parameters.AddWithValue("@first_name", teacher.FirstName);
                cmd.Parameters.AddWithValue("@last_name", teacher.LastName);
                cmd.Parameters.AddWithValue("@id_user", teacher.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ObservableCollection<Teacher> GetTeachersNotClassTeachers()
        {
            ObservableCollection<Teacher> availableTeachers = new ObservableCollection<Teacher>();

            using (SqlConnection con = DatabaseHelper.Connection)
            {
                using (SqlCommand cmd = new SqlCommand("GetTeachersNotClassTeachers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teacher teacher = new Teacher
                            {
                                TeacherID = (int)(reader["id_teacher"]),
                                FirstName = reader["first_name"].ToString().Trim(),
                                LastName = reader["last_name"].ToString().Trim(),
                                UserID = (int)reader["id_user"]
                            };

                            availableTeachers.Add(teacher);
                        }
                    }

                    con.Close();
                }
            }

            return availableTeachers;
        }

        public Teacher GetTeacherByUserID(int userID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherByUserID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_user", userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Teacher teacher = null;

                if (reader.Read())
                {
                    teacher = new Teacher()
                    {
                        TeacherID = (int)reader["id_teacher"],
                        FirstName = reader["first_name"].ToString().Trim(),
                        LastName = reader["last_name"].ToString().Trim(),
                        UserID = (int)reader["id_user"]

                    };
                }

                reader.Close();
                return teacher;
            }
        }
    }
}
