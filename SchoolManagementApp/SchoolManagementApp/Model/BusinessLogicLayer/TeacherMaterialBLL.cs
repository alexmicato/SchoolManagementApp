using SchoolManagementApp.Model.DataAccessLayer;
using SchoolManagementApp.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class TeacherMaterialBLL
    {
        private static TeacherMaterialDAL materialDAL = new TeacherMaterialDAL();
        public static ObservableCollection<TeacherMaterial> GetTeacherMaterials()
        {
            return materialDAL.GetTeacherMaterials();
        }

        public static ObservableCollection<TeacherMaterial> GetTeacherMaterialByClassTeacherSubject(int classID, int subjectID, int teacherID)
        {
            try
            {
                
               return materialDAL.GetTeacherMaterialByClassTeacherSubject(classID, subjectID, teacherID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a material: " + ex.Message);
                throw;
            }
        }

        public static ObservableCollection<TeacherMaterial> GetTeacherMaterialByClassSubject(int classID, int subjectID)
        {
            try
            {

                return materialDAL.GetTeacherMaterialByClassSubject(classID, subjectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a material: " + ex.Message);
                throw;
            }
        }

        public static int AddTeacherMaterial(TeacherMaterial material)
        {
            try
            {
                if (material == null)
                {
                    throw new ArgumentNullException(nameof(material), "Material cannot be null.");
                }

                int? materialID = materialDAL.AddTeacherMaterial(material);

                if (materialID.HasValue)
                {
                    return materialID.Value;
                }
                else
                {
                    throw new Exception("Failed to retrieve the material ID after adding the material.");
                }

                materialDAL.AddTeacherMaterial(material);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a material: " + ex.Message);
                throw;
            }
        }

        public static void DeleteTeacherMaterial(TeacherMaterial material)
        {
            try
            {
                if (material == null)
                {
                    throw new ArgumentNullException(nameof(material), "Material cannot be null.");
                }

                materialDAL.DeleteTeacherMaterial(material);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a material: " + ex.Message);
                throw;
            }
        }

        public static void UpdateMaterial(TeacherMaterial material)
        {
            try
            {
                if (material == null)
                {
                    throw new ArgumentNullException(nameof(material), "Material cannot be null.");
                }

                materialDAL.UpdateTeacherMaterial(material);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating a material: " + ex.Message);
                throw;
            }
        }
    }
}
