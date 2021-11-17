using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Week5.Database;
using Week5.Models;
using Week5.Reposervice.Interface;

namespace Week5.Reposervice.Implementation
{
    public class InMemoryService:ICRUD
    {
        public void Add(User user)
        {
            InMemory.Database.Add(user.Id, user);
        }



        public void ClearDatabase()
        {
            InMemory.Database.Clear();
        }



        public void Delete(string Id)
        {
            InMemory.Database.Remove(Id);
        }



        public Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (User value in InMemory.Database.Values)
            {
                users.Add(value);
            }
            return Task.Run(() => users);
        }



        public User GetUser(string Id)
        {

            return InMemory.Database[Id];
        }



        public void Update(string Id, User user)
        {
            InMemory.Database[Id] = user;
        }
    }
}
