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
    public class SpecializationDAL
    {
        public ObservableCollection<Specialization> GetAllSpecializations()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecializations", con);
                ObservableCollection<Specialization> result = new ObservableCollection<Specialization>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Specialization()
                        {
                            SpecializationID = (int)reader["id_specialization"],
                            Name = (string)reader["name"].ToString().Trim(),
                            Year = (int)reader["year"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public Specialization GetSpecializationByClass(int classID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSpecializationByClass", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id_class", classID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Specialization result = null;

                if (reader.Read())
                {
                    result = new Specialization()
                    {
                        SpecializationID = (int)reader["id_specialization"],
                        Name = reader["name"].ToString().Trim(),
                        Year = (int)reader["year"]
                    };
                }

                reader.Close();
                return result;

            }
        }

        public void AddSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", specialization.Name);
                cmd.Parameters.AddWithValue("@year", specialization.Year);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_specialization", specialization.SpecializationID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateSpecialization", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_specialization", specialization.SpecializationID);
                cmd.Parameters.AddWithValue("@name", specialization.Name);
                cmd.Parameters.AddWithValue("@year", specialization.Year);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
