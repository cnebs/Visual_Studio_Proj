using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Chapter_1
{

    class Madlibs
    {
        public static int[] version = { 0, 3, 1 };

        public static void Main()
        {
            IntroScreen();
            Run();
        }

        public static void IntroScreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Epic mad libs game v{0}.{1}.{2}", version[0], version[1], version[2]);
            Console.Write(" by your ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nigga: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!!!!!C - VAC!!!!!\n");

            Console.WriteLine("+++++++++++++++++++++");
            Console.WriteLine("++++P  R  E  S  S++++");
            Console.WriteLine("+++++++++++++++++++++");
            Console.WriteLine("+++A N Y+++++K E Y+++");
            Console.WriteLine("+++++++++++++++++++++");
            Console.WriteLine("++++T O+++P L A Y++++");
            Console.WriteLine("+++++++++++++++++++++");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        
        public static void Run()
        {
            Console.WriteLine("testing");
            TextFunction sentence1 = new TextFunction();
            Console.WriteLine(sentence1.text[0,0]);
            
            
            // Using string[0] as the sentence text and string[1] as sentence type for filtering purposes
            //
            // Sentence 1 generation
            //string[] firstSentData = SentenceOne();
            //Console.WriteLine(firstSentData[0]);
            //string firstSentence = firstSentData[0];

            // Sentence 2 generation
            //string secondSentData = SentenceTwo(firstSentData[1]);
            //Console.WriteLine(secondSentData[0]);
            //string secondSentence = secondSentData;

            Console.ForegroundColor = ConsoleColor.Blue;

            //Console.WriteLine(firstSentence + "\n" + secondSentence);


            // Replay
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to play again.");
            Console.ReadKey(true);
            Console.Clear();
            Run();
        }

        /*public static string MadLibInsert(string oldSentence, string wordType)
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

        public static string[] SentenceOne()
        {
            Random roll = new Random();

            string[] result = { "sentence", "result type" };
            string[,] text = new string[,] { { "There once was ", "In a small town, ", "Once upon a time, " },
               { "a man named ___. ", "a woman named ___. ", "a band of adventurers who called themselves ___. " },
               { "a man named ___ ", "a woman named ___ ", "a band of adventurers who called themselves ___ " },
               { "set out on an epic journey. ", "wanted to see the world. ", "lusted for riches. "},
               };

            int beginningRoll = roll.Next(0, 3);
            int middleRoll = roll.Next(0, 3);
            int endRoll = roll.Next(0, 3);
            string wordType = "";

            // test for gender/plural condition and set word type for madlibs data
            switch (middleRoll)
            {
                case 0:
                    result[1] = "0";
                    wordType = "a man's name";
                    break;
                case 1:
                    result[1] = "1";
                    wordType = "a woman's name";
                    break;
                case 2:
                    result[1] = "2";
                    wordType = "the name of a group";
                    break;
            }

            // test for local sorting condition and assemble epic meme sentence
            if (beginningRoll == 0)
            {
                result[0] = text[0, beginningRoll] + text[1, middleRoll];
            }
            else
            {
                result[0] = text[0, beginningRoll] + text[2, middleRoll] + text[3, endRoll];
            }

            result[0] = MadLibInsert(result[0], wordType);
            return result;
        }

        public static string SentenceTwo(string genderNum)
        {
            // take value from sentence 1 to avoid misgendering the player character
            string pronoun1 = "the dragonkin";
            string pronoun2 = "the dragonkin's";
            string pronoun3 = "the dragonkin";
            string pronoun4 = "the dragonkin";
            string weWuz = "";
            switch (genderNum)
            {
                case "0":
                    pronoun1 = "He";
                    pronoun2 = "His";
                    pronoun3 = "His";
                    pronoun4 = "Him";
                    weWuz = wuz[0];
                    break;
                case "1":
                    pronoun1 = "She";
                    pronoun2 = "Hers";
                    pronoun3 = "Her";
                    pronoun4 = "Her";
                    weWuz = wuz[0];
                    break;
                case "2":
                    pronoun1 = "They";
                    pronoun2 = "Their";
                    pronoun3 = "Their";
                    pronoun4 = "Them";
                    weWuz = wuz[1];
                    break;
            }

            Random roll = new Random();

            // This will actually produce a paragraph but for consistency it is named Sentence*
            string[,] text = new string[,] {
               { pronoun1 + " woke up one day and decided to go to ___. ", "Today, " + pronoun1.ToLower() + " felt ___. ", pronoun1 + " wanted something new and exciting, like ___! " },
               { pronoun1 + " grabbed " + pronoun3.ToLower() + " lucky ___ and left. ", "Before " + pronoun1.ToLower() + " could go, ___ called out to " + pronoun4.ToLower() + ". ", "It's been a long time since " + pronoun1.ToLower() +  " ___. " },
               { "Off " + pronoun1.ToLower() + " went, into the ___ horizon. ", pronoun2 + " bags packed full of ___, " + pronoun1.ToLower() + " " + weWuz + " destined for success. ", "\"Wait! Don't forget to bring your ___!\" And " + pronoun1.ToLower() + " didn't forget. " },
               };

            int beginningRoll = roll.Next(0, 3);
            int middleRoll = roll.Next(0, 3);
            int endRoll = roll.Next(0, 2);
            string part1Type = "", part2Type = "", part3Type = "";

            switch (beginningRoll)
            {
                case 0:
                    part1Type = "a place";
                    break;
                case 1:
                    part1Type = "a mood";
                    break;
                case 2:
                    part1Type = "something exciting";
                    break;
            }
            switch (middleRoll)
            {
                case 0:
                    part2Type = "an object";
                    break;
                case 1:
                    part2Type = "a famous person";
                    endRoll = 2;
                    break;
                case 2:
                    part2Type = "verb, past tense";
                    break;
            }
            switch (endRoll)
            {
                case 0:
                    part3Type = "adjective";
                    break;
                case 1:
                    part3Type = "noun(s)";
                    break;
                case 2:
                    part3Type = "an object(s)";
                    break;
            }

            string part1 = text[0, beginningRoll];
            string part2 = text[1, middleRoll];
            string part3 = text[2, endRoll];

            part1 = MadLibInsert(part1, part1Type);
            part2 = MadLibInsert(part2, part2Type);
            part3 = MadLibInsert(part3, part3Type);

            string result = part1 + "\n" + part2 + "\n" + part3;
            return result;
        }*/

        /*static void PrimeNumberDetector()
        {
            // Get user input for prime detection query
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Prime number detector v1.0.0" + 
                "\nUse this tool to banish prime numbers from your realm." + 
                "\n\nEnter lower boundary to search for primes.");
            double y = Math.Round(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("\nEnter upper boundary to search for primes.");
            double z = Convert.ToDouble(Console.ReadLine());
            Console.ResetColor();

            // Init lists for storing values
            List<double> divBy = new List<double>();
            List<double> primesDetected = new List<double>();

            // Sorting algorithm
            for (double i = y; i <= z; i++)
            {
                for (double j = 2; j <= (i / 2); j++)
                {
                    if ((i % j == 0) && (i != 1))
                    {
                        divBy.Add(j);
                        j = i;
                        // Stops the sort from proceeding when a divisor is found
                    }
                }

                // If list of divisors is empty, it is prime
                Console.Write("\n{0} is ", i);
                if (divBy.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("a prime number.");
                    primesDetected.Add(i);
                    Console.ResetColor();
                }
                else
                // If divisor exists in list, it is not prime
                {
                    Console.Write("divisible by ");
                    foreach (double x in divBy)
                    {
                        Console.Write(x);
                    }
                    divBy.Clear();
                }
            }
            // Summary list of primes found in query
            Console.Write("\n\nPrimes detected in your search: ");
            foreach (double x in primesDetected)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("");
            Console.ReadKey(true);
        }

        public static void WriteOnlyPrimes()
        {
            Console.WriteLine("Here's a list of prime numbers.");

            for (uint i = 1; i < 200; i++)
            {
                List<uint> divBy = new List<uint>();
                for (uint j = (i / 2); j > 1; j--)
                {

                    if ((i % j == 0) && (i != 1))
                    {
                        divBy.Add(j);
                    }

                }
                if (divBy.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n{0} is a prime number.", i);
                    Console.ResetColor();
                }
                divBy.Clear();
            }
        }*/
    }
}