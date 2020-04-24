using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TextGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press any key to start demo.");
            Console.ReadKey();
            DisplayModule(0);
        }

        static void Modules()
        {
            XmlTextReader reader = new XmlTextReader(@"C:\Users\Christian\source\repos\TextGame\TextGame\Dialogue.xml");
            
        }

        static int DisplayModule(int module)
        {
            return 0;
        }
    }

    class Dialogue
    {
        public string Text { get; private set; }
        public string[] Options { get; private set; }


        public Dialogue()
        {

        }

        static int Input()
        {
            return 0;
        }
    }
}
