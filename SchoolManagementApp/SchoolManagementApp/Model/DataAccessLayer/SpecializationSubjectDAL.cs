using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class SpecializationSubjectDAL
    {
        public void AddSpecializationSubject(SpecializationSubject subject)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSpecializationSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_subject", subject.SubjectID);
                cmd.Parameters.AddWithValue("@id_specialization", subject.SpecializationID);
                cmd.Parameters.AddWithValue("@isFinalSubject", subject.IsFinalSubject);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool GetSubjectFinalStatus(int subjectId, int specializationId)
        {
            int isFinal = 0;

            using (SqlConnection connection = DatabaseHelper.Connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetSubjectFinalStatus", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id_subject", subjectId);
                command.Parameters.AddWithValue("@id_specialization", specializationId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isFinal = reader.GetInt32(0);
                    }
                }
            }

            return isFinal == 1;
        }


    }
}
