using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Models.DTO
{
   public class DisplayDTO
    {
        public List<UserDTO> UserRecords { get; set; }

        public DisplayDTO()
        {
            UserRecords = new List<UserDTO>();
        }
    }
}
