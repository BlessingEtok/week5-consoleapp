using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Week5.Utility
{
   public static class Logger
    {
        private readonly static string path = @"C:\Users\hp\Documents\RKS ErrorLog";
        private readonly static string filePath = @"C:\Users\hp\Documents\RKS ErrorLog\Logs.txt";
        private static DirectoryInfo directory;
        private static FileInfo file;



        static Logger()
        {
            file = new FileInfo(filePath);
            directory = new DirectoryInfo(path);
            if (!directory.Exists)
                directory.Create();
        }
        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(file.Open(FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine($"{DateTime.Now} ------------------------------------------------------------------------------------------------------------------");
                writer.WriteLine($"{message}\n\n");
            }
        }


    }
}
