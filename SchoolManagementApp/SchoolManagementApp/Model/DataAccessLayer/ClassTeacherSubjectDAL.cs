using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Input;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class ClassTeacherSubjectDAL
    {
        public void AddCourse(ClassTeacherSubject course)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClassTeacherSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", course.ClassID);
                cmd.Parameters.AddWithValue("@id_teacher", course.TeacherID);
                cmd.Parameters.AddWithValue("@id_subject", course.SubjectID);
                if (course.MaterialID.HasValue)
                {
                    cmd.Parameters.AddWithValue("@id_material", course.MaterialID.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_material", DBNull.Value);
                }


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteClassTeacherSubjectByClass(int classID, int teacherID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassTeacherSubjectByClass", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteClassTeacherSubjectBySubject(int subjectID, int teacherID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClassTeacherSubjectBySubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClassTeacherSubjectMaterial(ClassTeacherSubject classTeacherSubject)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClassTeacherSubjectMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classTeacherSubject.ClassID);
                cmd.Parameters.AddWithValue("@id_teacher", classTeacherSubject.TeacherID);
                cmd.Parameters.AddWithValue("@id_subject", classTeacherSubject.SubjectID);
                cmd.Parameters.AddWithValue("@id_material", classTeacherSubject.MaterialID);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
