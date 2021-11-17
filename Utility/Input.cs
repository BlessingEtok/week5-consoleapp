using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;

namespace Week5.Utility
{
  public class Input:IInput
    {
       
        public User GetUserInput()
        {
            string firstName = "";
            string lastName = "";
            string phoneNo = "";
            string email = "";
            string gitHub = "";
            while (true)
            {
                Console.WriteLine("PlEASE ENTER YOUR FIRST NAME");
                firstName = Console.ReadLine();
                if (Validator.NameValidator(firstName) == true)
                    break;
            } while (true)
            {
                Console.WriteLine("PlEASE ENTER YOUR LAST NAME");
                lastName = Console.ReadLine();
                if (Validator.NameValidator(lastName) == true)
                    break;
            } while (true)
            {
                Console.WriteLine("PlEASE ENTER YOUR PHONE NUMBER");
                phoneNo = Console.ReadLine();
                if (Validator.NumberValidator(phoneNo) == true)
                    break;
            } while (true)
            {
                Console.WriteLine("PlEASE ENTER YOUR EMAIL");
                email = Console.ReadLine();
                if (Validator.EmailValidator(email) == true)
                    break;
            } while (true)
            {
                Console.WriteLine("PlEASE ENTER YOUR GITHUB LINK");
                gitHub = Console.ReadLine();
                if (Validator.GitValidator(gitHub) == true)
                    break;
            }
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNo;
            user.Email = email;
            user.GitHub = gitHub;
            return user;
        }
        public string GetUserId()
        {
            Console.WriteLine("PlEASE ENTER YOUR USER ID");
            string val = Console.ReadLine();
            return val.Trim();
        }


    }
}
