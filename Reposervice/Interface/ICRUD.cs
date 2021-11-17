using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Week5.Models;

namespace Week5.Reposervice.Interface
{
    public interface ICRUD
    {

void Add(User user);
        void Delete(string Id);
        void ClearDatabase();
        User GetUser(string Id);
        Task<List<User>> GetAllUsers();
        void Update(string Id, User user);


    }
}
