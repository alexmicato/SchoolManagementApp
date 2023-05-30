using SchoolManagementApp.Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.Model.EntityLayer;

namespace SchoolManagementApp.Model.BusinessLogicLayer
{
    public class SpecializationSubjectBLL
    {
        private static DataAccessLayer.SpecializationSubjectDAL specializationSubjectDAL = new DataAccessLayer.SpecializationSubjectDAL();

        public static void AddSpecializationSubject(SpecializationSubject subject)
        {
            try
            {
                if (subject == null)
                {
                    throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
                }

                specializationSubjectDAL.AddSpecializationSubject(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a subject: " + ex.Message);
                throw;
            }
        }

        public static bool GetSubjectFinalStatus(int subjectID, int specializationID)
        {
            return specializationSubjectDAL.GetSubjectFinalStatus(subjectID, specializationID);
        }
    }
}
