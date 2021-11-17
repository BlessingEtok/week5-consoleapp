using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;
using Week5.Models.DTO;

namespace Week5.Service.Interface
{
   public interface IQueries
    {
        void DeleteMultipleUsersById();
        DisplayDTO DisplayAllUserData();
        DisplayDTO DisplayData(string id);
        DisplayDTO DisplayUsersByName();
        DisplayDTO FetchUsersById();
        User Update(string Id);
    }
}
