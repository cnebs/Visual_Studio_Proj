using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_1
{
    public class TextFunction
    {
        public string[,] text = new string[5, 5];
        string wordType;
        string gender;
        string[] wuz = { "was", "were" };

        public TextFunction()
        {
            this.text[0,0] = "fuck you";
            this.wordType = wordType;
        }
        


        public static string MadLibPrompt(string oldSentence, string wordType)
        {
            // Convert word type into string and prompt player to enter
            if (wordType != null)
            {
                Console.Write("Enter {0}: ", wordType);
            }
            else
            {
                Console.Write("Enter a word: ");
            }

            // Take user input and replace blank in string
            string newSentence = oldSentence.Replace("___", Console.ReadLine());
            Console.Clear();
            return newSentence;
        }
    }
}
