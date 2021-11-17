using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Utility
{
   public static class Validator
    {
        
public static bool NameValidator(string value)
        {
            bool isValid = false;
            if (!String.IsNullOrWhiteSpace(value))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("***please enter a valid name****");
                isValid = false;
                return isValid;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if ((((int)value[i]) >= 'A' && ((int)value[i] <= 'z')) || value[i] == ' ')
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("***please enter a valid name without numbers***");
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }
        public static bool NumberValidator(string value)
        {
            bool isValid = false;
            if ((!String.IsNullOrWhiteSpace(value)) && (value.Length == 11))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("***please enter a valid phone number upto 11 digits****");
                isValid = false;
                return isValid;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if ((Char.IsDigit(value[i])))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("***number can only contain numeric digits from 0 - 9***");
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }
        public static bool EmailValidator(string value)
        {
            bool isValid = false;
            if (!String.IsNullOrWhiteSpace(value))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("***please enter a valid email****");
                isValid = false;
                return isValid;
            }
            return isValid;
        }
        public static bool GitValidator(string value)
        {
            bool isValid = false;
            if (!String.IsNullOrWhiteSpace(value))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("***please enter a valid phone number upto 11 digits****");
                isValid = false;
                return isValid;
            }
            return isValid;
        }


    }
}
