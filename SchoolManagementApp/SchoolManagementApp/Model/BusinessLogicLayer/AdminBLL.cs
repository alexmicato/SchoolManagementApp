using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class AdminBLL
    {
        private static AdminDAL adminDAL = new AdminDAL();

        public static void AddAdmin(Admin admin)
        {
            try
            {
                if (admin == null)
                {
                    throw new ArgumentNullException(nameof(admin), "Teacher cannot be null.");
                }

                adminDAL.AddAdmin(admin);   
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }

        public static Admin GetAdminByUserId(int userID)
        {
            try
            {
                return adminDAL.GetAdminByUserID(userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a teacher: " + ex.Message);
                throw;
            }
        }
    }
}
