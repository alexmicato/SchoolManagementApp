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
    public class SpecializationBLL
    {
        private static SpecializationDAL specializationDAL = new SpecializationDAL();

        public static ObservableCollection<Specialization> GetAllSpecializations()
        {
            return specializationDAL.GetAllSpecializations();
        }

        public static Specialization GetSpecializationByClass(int classID)
        {
            return specializationDAL.GetSpecializationByClass(classID);
        }

        public static void AddSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                specializationDAL.AddSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a specialization: " + ex.Message);
                throw;
            }
        }

        public static void DeleteSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                specializationDAL.DeleteSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a specialization: " + ex.Message);
                throw;
            }
        }

        public  static void UpdateSpecialization(Specialization specialization)
        {
            try
            {
                if (specialization == null)
                {
                    throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null.");
                }

                specializationDAL.UpdateSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a specialization: " + ex.Message);
                throw;
            }
        }
    }
}
