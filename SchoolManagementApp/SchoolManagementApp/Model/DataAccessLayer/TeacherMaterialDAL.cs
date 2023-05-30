using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SchoolManagementApp.Model.DataAccessLayer
{
    public class TeacherMaterialDAL
    {
        public ObservableCollection<TeacherMaterial> GetTeacherMaterials()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllTeacherMaterials", con);
                ObservableCollection<TeacherMaterial> result = new ObservableCollection<TeacherMaterial>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new TeacherMaterial()
                        {
                            MaterialID = (int)reader["id_material"],
                            Name = reader["name"].ToString().Trim(),
                            FilePath = reader["file_path"].ToString()
                        }

                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<TeacherMaterial> GetTeacherMaterialByClassTeacherSubject(int classID, int subjectID, int teacherID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherMaterialByClassTeacherSubject", con);
                ObservableCollection<TeacherMaterial> result = new ObservableCollection<TeacherMaterial>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
                cmd.Parameters.AddWithValue("@id_teacher", teacherID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new TeacherMaterial()
                        {
                            MaterialID = (int)reader["id_material"],
                            Name = reader["name"].ToString().Trim(),
                            FilePath = reader["file_path"].ToString()
                        }

                        );
                }
                reader.Close();
                return result;

            }
        }

        public ObservableCollection<TeacherMaterial> GetTeacherMaterialByClassSubject(int classID, int subjectID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherMaterialByClassSubject", con);
                ObservableCollection<TeacherMaterial> result = new ObservableCollection<TeacherMaterial>();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_class", classID);
                cmd.Parameters.AddWithValue("@id_subject", subjectID);
 

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new TeacherMaterial()
                        {
                            MaterialID = (int)reader["id_material"],
                            Name = reader["name"].ToString().Trim(),
                            FilePath = reader["file_path"].ToString()
                        }

                        );
                }
                reader.Close();
                return result;

            }
        }

        public int? AddTeacherMaterial(TeacherMaterial material)
        {
            int? materialID = null;
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddTeacherMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", material.Name);
                cmd.Parameters.AddWithValue("@file_path", material.FilePath);

                SqlParameter lastInsertedIdParam = new SqlParameter("@last_inserted_id", SqlDbType.Int);
                lastInsertedIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(lastInsertedIdParam);

                con.Open();
                cmd.ExecuteNonQuery();

                if(lastInsertedIdParam.Value != DBNull.Value)
                {
                    materialID = Convert.ToInt32(lastInsertedIdParam.Value);
                }

                con.Close();
            }

            return materialID;
        }

        public void DeleteTeacherMaterial(TeacherMaterial material)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_material", material.MaterialID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTeacherMaterial(TeacherMaterial material)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacherMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_material", material.MaterialID);
                cmd.Parameters.AddWithValue("@name", material.Name);
                cmd.Parameters.AddWithValue("@file_path", material.FilePath);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
