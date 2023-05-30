using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Helpers
{
    public class Utility
    {
        public static bool ValidateNumber(string input)
        {
            if (int.TryParse(input, out int number))
            {
                if (number >= 9 && number <= 12)
                {
                    return true; // Number is valid
                }
            }
            return false; // Number is invalid
        }

        public static bool IsDateStringValid(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime date))
            {
                // The string is a valid date
                return true;
            }
            else
            {
                // The string is not a valid date
                return false;
            }
        }
    }
}
