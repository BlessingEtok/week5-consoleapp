using System;
using System.Collections.Generic;
using System.Text;
using Week5.Reposervice.Implementation;
using Week5.Reposervice.Interface;
using Week5.Service.Implementation;
using Week5.Service.Interface;
using Week5.Utility;

namespace Week5.Service
{
     public static class GlobalConfig
    {
      

        public static ICRUD InMemory { get; set; }
        public static ICRUD FileDb { get; set; }
        public static IInput Input { get; set; }
        public static IQueries Queries { get; set; }
        public static void Instantiate()
        {
            Queries = new Queries();
            InMemory = new InMemoryService();
            FileDb = new FileRepoService();
            Input = new Input();
        }


    }
}
