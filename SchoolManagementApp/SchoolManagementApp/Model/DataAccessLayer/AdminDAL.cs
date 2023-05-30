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
    public class AdminDAL
    {
        public ObservableCollection<Admin> GetAllAdmins()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllAdmins", con);
                ObservableCollection<Admin> result = new ObservableCollection<Admin>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Admin()
                        {
                            AdminID = (int)reader["id_admin"],
                            FirstName = (string)reader["first_name"],
                            LastName = (string)reader["last_name"],
                            UserID = (int)reader["id_user"]
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public void AddAdmin(Admin item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@first_name", item.FirstName);
                cmd.Parameters.AddWithValue("@last_name", item.LastName);
                cmd.Parameters.AddWithValue("@id_user", item.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteAdmin(Admin item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_admin", item.AdminID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateAdmin(Admin item)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_admin", item.AdminID);
                cmd.Parameters.AddWithValue("@first_name", item.FirstName);
                cmd.Parameters.AddWithValue("@last_name", item.LastName);
                cmd.Parameters.AddWithValue("@id_user", item.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Admin GetAdminByUserID(int userID)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAdminByUserID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_user", userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Admin admin = null;

                if (reader.Read())
                {
                    admin = new Admin()
                    {
                        AdminID = (int)reader["id_admin"],
                        FirstName = reader["first_name"].ToString().Trim(),
                        LastName = reader["last_name"].ToString().Trim(),
                        UserID = (int)reader["id_user"]

                    };
                }

                reader.Close();
                return admin;
            }
        }
    }
}
