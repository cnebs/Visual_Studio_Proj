using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    class Util
    {
        public static void ErrorGeneral(string msg)
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static bool YesOrNo()
        {
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }
            return false;
        }
    }
}
