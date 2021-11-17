using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;
using Week5.Models.DTO;
using Week5.Reposervice.Interface;
using Week5.Service.Implementation;
using Week5.Service.Interface;
using Week5.Utility;

namespace Week5.Service
{
    public class Controller
    {
        private IInput input;
        private ICRUD inMemory;
        private ICRUD outMemory;
        private IQueries queries;
        public Controller(IInput input, IQueries _queries, ICRUD inMemory = null, ICRUD outMemory = null)
        {
            this.input = input;
            this.inMemory = inMemory;
            this.outMemory = outMemory;
            this.queries = new Queries(input, inMemory, outMemory);

        }



        //gets the user input and saves it
        public void GetUserData()
        {
            var value = input.GetUserInput();
            inMemory.Add(value);
            outMemory.Add(value);
        }




        //displays a single user
        public void GetSingleuser()
        {
            DisplayDTO result;
            string id = "";
            while (true)
            {
                try
                {
                    id = input.GetUserId();
                    result = queries.DisplayData(id);
                    break;
                }
                catch (Exception e)
                {
                    Logger.Log(e.Message);
                    Console.WriteLine("***Invalid id****\a");
                }



            }


            UI.UserDataDisplay.Print(result);



        }
        //displays all users
        public void DisplayAllUserData()
        {
            DisplayDTO result = queries.DisplayAllUserData();
            UI.UserDataDisplay.Print(result);
        }



        //displays users by name
        public void DisplayUsersByName()
        {
            var result = queries.DisplayUsersByName();
            UI.UserDataDisplay.Print(result);
        }



        //fetches users by list of id's
        public void FetchUsersById()
        {
            var results = queries.FetchUsersById();
            UI.UserDataDisplay.Print(results);
        }



        //deletes users by id
        public void DeleteUsersById()
        {
            string val = "";
            val = input.GetUserId();
            outMemory.Delete(val);
        }



        //delete multiple users
        public void DeleteMultipleUsersById()
        {
            queries.DeleteMultipleUsersById();
        }
        public void ClearDatabase()
        {
            outMemory.ClearDatabase();
        }



        //Updates user data
        public void UpdateUser()
        {
            User value;
            string id = "";
            while (true)
            {
                try
                {
                    id = input.GetUserId();
                    value = queries.Update(id);
                    break;
                }
                catch (Exception e)
                {
                    Logger.Log(e.Message);
                    Console.WriteLine("***Invalid id****\a");
                }
            }
            outMemory.Update(id, value);
        }
    }
}
