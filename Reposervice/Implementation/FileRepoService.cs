using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Week5.Models;
using Week5.Reposervice.Interface;
using Week5.Utility;

namespace Week5.Reposervice.Implementation
{
   public class FileRepoService:ICRUD

    {
        private readonly string folderPath = @"C:\Users\hp\Documents\Records";
        private readonly string filePath = @"C:\Users\hp\Documents\Records\userRecords.txt";
        private readonly DirectoryInfo directory;
        private readonly FileInfo file;



        public FileRepoService()
        {
            file = new FileInfo(filePath);
            directory = new DirectoryInfo(folderPath);
            if (!directory.Exists)
                directory.Create();
        }



        public void Add(User user)
        {
            using (StreamWriter writer = new StreamWriter(file.Open(FileMode.Append)))
            {
                writer.WriteLine($"{user.Id},{user.LastName},{user.FirstName},{user.Email},{user.PhoneNumber},{user.GitHub},");
                writer.Close();
            }
        }



        public void ClearDatabase()
        {
            file.Delete();
        }



        public void Delete(string Id)
        {
            List<User> result = new List<User>();
            try
            {
                var user = GetAllUsers().Result;
                user.ForEach(x => { if (x.Id != Id) { result.Add(x); } });
                if (user.Count > result.Count)
                {
                    ClearDatabase();
                    result.ForEach(x => Add(x));

                }



            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

        }



        public Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (StreamReader reader = new StreamReader(file.Open(FileMode.Open, FileAccess.Read)))
                {



                    var result = reader.ReadToEnd();
                    reader.Close();
                    var recordsList = result.Split(Environment.NewLine);
                    foreach (var item in recordsList)
                    {
                        if (item != "")
                        {
                            User user = new User();
                            var list2 = item.Split(',');
                            user.Id = list2[0];
                            user.LastName = list2[1];
                            user.FirstName = list2[2];
                            user.Email = list2[3];
                            user.PhoneNumber = list2[4];
                            user.GitHub = list2[5];
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex.Message);
            }
            return Task.Run(() => users);
        }



        public User GetUser(string Id)
        {
            User result = new User();
            try
            {
                var user = GetAllUsers().Result;
                user.ForEach(x => { if (x.Id == Id) { result = x; } });
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return result;
        }



        public void Update(string Id, User user)
        {



            List<User> result = new List<User>();
            try
            {
                var userRecords = GetAllUsers().Result;
                userRecords.ForEach(x => { if (x.Id == Id) { x = user; } result.Add(x); });
                ClearDatabase();
                result.ForEach(x => Add(x));
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }


    }
}
