using System;
using Week5.Service;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfig.Instantiate();
            int loopcounter = 0;
            Controller controller = new Controller(GlobalConfig.Input, GlobalConfig.Queries, GlobalConfig.InMemory, GlobalConfig.FileDb);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("****User Database??****\n");



                Console.WriteLine(" 1 Enter new user record\n\n 2 Get user records\n\n 3 Update user records\n\n 4 Delete user records\n\n 5 Clear Database\n\n 0 Exit");
                int response = Convert.ToInt32(Console.ReadLine());
                if (response == 1)
                {



                    while (true)
                    {
                        //add user records
                        Console.Clear();
                        Console.WriteLine("How many records are you entering??");
                        loopcounter = Convert.ToInt32(Console.ReadLine());



                        while (loopcounter > 0)
                        {
                            controller.GetUserData();
                            loopcounter--;
                        }
                        Console.WriteLine("done");
                        Console.WriteLine("Do you want to add more records?? y/n");
                        string ans = Console.ReadLine();
                        if (ans == "y")
                        {



                        }
                        else if (ans == "n")
                        {
                            break;
                        }
                    }
                }
                else if (response == 2)
                {
                    //Get user records
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(" 1 Get all records\n 2 Get user by name\n 3 Get user by Id\n 4 Get multiple users by id's\n 5 Back");
                        int ans = int.Parse(Console.ReadLine());

                        if (ans == 1)
                        {
                            controller.DisplayAllUserData();
                            Console.ReadKey();
                        }
                        else if (ans == 2)
                        {
                            Console.WriteLine("Search with user name\n");
                            controller.DisplayUsersByName();
                            Console.ReadKey();
                        }
                        else if (ans == 3)
                        {
                            Console.WriteLine("Enter user Id");
                            controller.GetSingleuser();
                            Console.ReadKey();
                        }
                        else if (ans == 4)
                        {
                            controller.FetchUsersById();
                            Console.ReadKey();
                        }
                        else if (ans == 5)
                        {
                            break;
                        }
                    }
                }
                else if (response == 3)
                {
                    //update user records
                    controller.UpdateUser();



                }
                else if (response == 4)
                {
                    //delete user records
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(" 1 Delete a user record\n 2 Delete multiple user records\n 0 Back\n");
                        int ans = int.Parse(Console.ReadLine());
                        if (ans == 1)
                        {
                            controller.DeleteUsersById();
                            Console.WriteLine("\nDeleted!");
                            Console.ReadKey();
                        }
                        else if (ans == 2)
                        {
                            controller.DeleteMultipleUsersById();
                            Console.WriteLine("\nDeleted!");
                            Console.ReadKey();
                        }
                        else if (ans == 0)
                        {
                            break;
                        }
                    }
                }
                else if (response == 5)
                {
                    Console.WriteLine("*****Are you sure you want to clear the database??**** y/n");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                        controller.ClearDatabase();
                }
                else if (response == 0)
                {
                    break;
                }
                else { }






            }
        }
    }
}
