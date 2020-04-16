using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Chapter_1
{
    public class TextFunction
    {
        public static string[] allTextLines = File.ReadAllLines(@"..\..\Text.txt");
        public string[] lineText = new string[10];
        public string[] partText = new string[5];
        public string[,] allPartsText = new string[10,5];

        public class Sentence : TextFunction
        {
            // Pass through min and max values for allTextLines[] line numbers
            public Sentence(int i, int n) 
            {
                // Get lines for specific sentence
                for (int k = 0; i < n && i != -1; i++, k++)
                {
                    this.lineText[k] = allTextLines[i];
                    if (lineText[i] == null)
                    {
                        i = -1;
                    }
                }
                // Break down lines into parts to be sorted
                for (int j = 0; j < 9 && j != -1; j++)
                {
                    this.partText = PartBuilder(lineText[j]);
                    if (partText == null)
                    {
                        j = -1;
                    }
                    else
                    {
                        allPartsText[j, 0] = "partText[0]";
                        allPartsText[j, 1] = "partText[1]";
                        allPartsText[j, 2] = "partText[2]";
                        allPartsText[j, 3] = "partText[3]";
                    }
                }
            }
            public string[] PartBuilder(string line)
            {
                char[] charSeparators = new char[] { '|' };
                return line.Split(charSeparators, 5, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        
        public static string MadLibPrompt(string oldFragment, string wordType)
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
            string newFragment = oldFragment.Replace("___", Console.ReadLine());
            Console.Clear();
            return newFragment;
        }

        public string[] SentenceBuilder(string partText)
        {
            string[] newpart = { };
            return newpart;
        }
    }
}
