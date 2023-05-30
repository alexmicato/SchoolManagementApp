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
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new User()
                        {
                            UserID = (int)reader["id_user"],
                            Username = reader["username"].ToString().Trim(),
                            Password = reader["password"].ToString().Trim(),
                            UserType = reader["user_type"].ToString().Trim()
                        }
                        );
                }
                reader.Close();
                return result;

            }
        }

        public int? AddUser(User user)
        {
            int? userId = null;

            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@user_type", user.UserType);

                SqlParameter outputParameter = new SqlParameter("@id_user", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                if (outputParameter.Value != DBNull.Value)
                {
                    userId = Convert.ToInt32(outputParameter.Value);
                }

                con.Close();
            }

            return userId;
        }

        public void DeleteUser(User user)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_user", user.UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = DatabaseHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_user", user.UserID);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@user_type", user.UserType);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password) 
        {
            using (SqlConnection connection = DatabaseHelper.Connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetUserByUsernameAndPassword", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userId = (int)reader["id_user"];
                        string userType = ((string)reader["user_type"]).Trim();

                        return new User(userId, username, password, userType);
                    }
                }

                reader.Close();
            }

            return null;
        }
    }
}
