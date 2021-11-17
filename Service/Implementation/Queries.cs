using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;
using Week5.Models.DTO;
using Week5.Reposervice.Interface;
using Week5.Service.Interface;
using Week5.Utility;

namespace Week5.Service.Implementation
{
   public class Queries:IQueries
    {

        private ICRUD inMemory;
        private ICRUD outMemory;
        private IInput input; public Queries(IInput input, ICRUD inMemory = null, ICRUD outMemory = null)
        {
            this.inMemory = inMemory;
            this.input = input;
            this.outMemory = outMemory;
        }
        public Queries()
        {
        }
        private UserDTO MapUserDTO(User value)
        {
            UserDTO user = new UserDTO();
            user.Email = value.Email;
            user.PhoneNumber = value.PhoneNumber;
            user.Name = value.FirstName + " " + value.LastName;
            user.GitHub = value.GitHub;
            return user;
        }
        private DisplayDTO MapToDTO(List<User> values)
        {
            DisplayDTO users = new DisplayDTO(); foreach (User value in values)
            {
                UserDTO user = new UserDTO();
                user.Email = value.Email;
                user.PhoneNumber = value.PhoneNumber;
                user.Name = value.FirstName + " " + value.LastName;
                user.GitHub = value.GitHub; users.UserRecords.Add(user);
            }
            return users;
        }
        //displays a single user
        public DisplayDTO DisplayData(string id)
        {
            User val = outMemory.GetUser(id);
            DisplayDTO displayDTO = new DisplayDTO();
            displayDTO.UserRecords.Add(MapUserDTO(val));
            return displayDTO;
        } //displays All users
        public DisplayDTO DisplayAllUserData()
        {
            var values = outMemory.GetAllUsers();
            DisplayDTO users = new DisplayDTO();
            users = MapToDTO(values.Result);
            return users;
        } //displays users by name
        public DisplayDTO DisplayUsersByName()
        {
            var val = input.GetUserId(); var values = outMemory.GetAllUsers();
            DisplayDTO users = new DisplayDTO();
            DisplayDTO result = new DisplayDTO();
            users = MapToDTO(values.Result);
            users.UserRecords.ForEach(x =>
            {
                if (x.Name.StartsWith(val))
                {
                    result.UserRecords.Add(x);
                }
            }); return result;
        } //fetches users by id's
        public DisplayDTO FetchUsersById()
        {
            List<string> uid = new List<string>();
            DisplayDTO result = new DisplayDTO();
            int loopcounter = 0; Console.WriteLine("How many users are you fetching?");
            loopcounter = Convert.ToInt32(Console.ReadLine());
            while (loopcounter > 0)
            {
                var val = input.GetUserId();
                uid.Add(val);
                loopcounter--;
            }
            inMemory.GetAllUsers().Result.ForEach(x =>
            {
                if (uid.Contains(x.Id))
                    result.UserRecords.Add(MapUserDTO(x));
            });
            return result;
        }
        public void DeleteMultipleUsersById()
        {
            List<string> uid = new List<string>();
            int loopcounter = 0; Console.WriteLine("How many users are you deleting?");
            loopcounter = Convert.ToInt32(Console.ReadLine());
            while (loopcounter > 0)
            {
                var val = input.GetUserId();
                uid.Add(val);
                loopcounter--;
            }
            outMemory.GetAllUsers().Result.ForEach(x =>
            {
                if (uid.Contains(x.Id))
                    outMemory.Delete(x.Id);
            });
        } //updates user data
        public User Update(string Id)
        {
            var user = outMemory.GetUser(Id);
            string value = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 to update first name\n2 to update last name\n3 to update phone number\n4 to update email\n5 to update github account url ");
                int val = Convert.ToInt32(Console.ReadLine());
                if (val == 1)
                {
                    Console.WriteLine($"current first name is --{user.FirstName}");
                    Console.WriteLine("enter new first name");
                    value = Console.ReadLine();
                    user.FirstName = value;
                }
                else if (val == 2)
                {
                    Console.WriteLine($"current last name is --{user.LastName}");
                    Console.WriteLine("enter new last name");
                    value = Console.ReadLine();
                    user.LastName = value;
                }
                else if (val == 3)
                {
                    Console.WriteLine($"current phone number is --{user.PhoneNumber}");
                    Console.WriteLine("enter new phone number");
                    value = Console.ReadLine();
                    user.PhoneNumber = value;
                }
                else if (val == 4)
                {
                    Console.WriteLine($"current email is --{user.Email}");
                    Console.WriteLine("enter new email");
                    value = Console.ReadLine();
                    user.Email = value;
                }
                else if (val == 5)
                {
                    Console.WriteLine($"current Github account address is --{user.GitHub}");
                    Console.WriteLine("enter new GitHub address");
                    value = Console.ReadLine();
                    user.GitHub = value;
                }
                Console.WriteLine("input 'y' to save changes or 'n' to keep modifying this user");
                value = Console.ReadLine().ToLower();
                if (value == "y")
                {
                    break;
                }
                else if (value == "n") { }
            }
            return user;
        }


    }
}
