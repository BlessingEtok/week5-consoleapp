using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models.DTO;

namespace Week5.UI
{
    public class UserDataDisplay
    {
        public static void Print(DisplayDTO data)
        {
            if (data.UserRecords.Count == 0)
            {
                Console.WriteLine("**No records found!**");
                return;
            }



            int widthOfTable = 90;




            Utility.Display.PrintLine(widthOfTable);
            Utility.Display.PrintRow(widthOfTable, "Name", "Email", "Phone Number", "GitHub Url");
            Utility.Display.PrintLine(widthOfTable);



            foreach (var user in data.UserRecords)
            {
                Utility.Display.PrintRow(widthOfTable, user.Name, user.Email, user.PhoneNumber, user.GitHub);
            }
            Utility.Display.PrintLine(widthOfTable);
        }


    }
}
