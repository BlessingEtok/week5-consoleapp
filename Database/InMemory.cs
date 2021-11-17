using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;

namespace Week5.Database
{
    public static class InMemory
    {
      public static Dictionary<string, User> Database { get; set; }
        static InMemory()
        {
            Database = new Dictionary<string, User>();
        }
    }
}
