using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Utility
{
  public  class Display
    {
        public static void PrintLine(int widthOfTable)
        {
            Console.WriteLine(new string('-', widthOfTable));
        }



        public static void PrintRow(int widthOfTable, params string[] columns)
        {
            int width = (widthOfTable - columns.Length) / columns.Length;
            string row = "|";



            foreach (string column in columns)
            {
                row += CenterText(column, width) + "|";
            }



            Console.WriteLine(row);
        }



        public static string CenterText(string column, int width)
        {
            column = column.Length > width ? column.Substring(0, width - 3) + "..." : column;



            if (!string.IsNullOrEmpty(column))
            {
                return column.PadRight(width - (width - column.Length) / 2).PadLeft(width);
            }
            else
            {
                return new string(' ', width);
            }
        }
    }
}
