using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class UserBLL
    {
        private static UserDAL userDAL = new UserDAL();

        public static ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public static int AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                int? userID = userDAL.AddUser(user);

                if (userID.HasValue)
                {
                    return userID.Value;
                }
                else
                {
                    throw new Exception("Failed to retrieve the user ID after adding the user.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a user: " + ex.Message);
                throw;
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                userDAL.DeleteUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a user: " + ex.Message);
                throw;
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                userDAL.UpdateUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a user: " + ex.Message);
                throw;
            }
        }

        public static User GetUserByNameAndPassword(string name, string password)
        {
            try
            {
                return userDAL.GetUserByUsernameAndPassword(name, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a user: " + ex.Message);
                throw;
            }
        }
    }
}
