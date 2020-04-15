using System;
using System.Collections.Generic;
using System.Text;

class BigBoyCoding
{
    static void Main()
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
                Console.Write("not prime. It is divisible by ");
                foreach (double x in divBy)
                {
                    Console.Write(x);
                }
                divBy.Clear();
            }
        }
        // Summary list of primes found in query
        Console.WriteLine("\n\nPrimes detected in your search: ");
        foreach (double x in primesDetected)
        {
            Console.Write(x + ", ");
        }
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
    }
}