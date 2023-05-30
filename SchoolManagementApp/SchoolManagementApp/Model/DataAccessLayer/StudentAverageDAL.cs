using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.PdfViewer.Base;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class StudentAverageDAL
    {
        public void AddStudentAverage(StudentAverage studentAverage)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudentAverage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", studentAverage.StudentID);
                cmd.Parameters.AddWithValue("@id_subject", studentAverage.SubjectID);
                cmd.Parameters.AddWithValue("semester", studentAverage.Semester);
                cmd.Parameters.AddWithValue("average", studentAverage.Average);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public StudentAverage GetStudentAverage(int studentID, int subjectID, int semester)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetStudentAverage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_student", studentID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@semester", semester);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                StudentAverage result = null;

                if (reader.Read())
                {
                    result = new StudentAverage()
                    {
                        StudentID = (int)reader["id_student"],
                        SubjectID = (int)reader["id_subject"],
                        Semester = (int)reader["semester"],
                        Average = (float)(double)reader["average"]
                    };
                }

                reader.Close();
                return result;
            }
        }
    }
}
