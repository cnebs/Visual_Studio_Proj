using System;

namespace NotAScamATM 
{
	public class Menu
	{
		public static void MainMenu(string userCardNo)
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("| ScamTrust ATM Secure Menu |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|  Welcome back, {}   |", userCardNo);
			Console.WriteLine("|  1. Check Balance         |");
			Console.WriteLine("|  2. Make A Deposit        |");
			Console.WriteLine("|  3. Withdraw Money        |");
			Console.WriteLine("|  4. Logout                |");
			Console.WriteLine("|                           |");
			Console.WriteLine("-----------------------------");

			switch (Console.ReadLine())
			{
				case "1":
					Console.Clear();
					CheckBalance();
					break;
				case "2":
					Console.Clear();
					Deposit();
					break;
				case "3":
					Console.Clear();
					Withdraw();
					break;
				case "4":
					Console.Clear();
					Exit();
					break;
			}
		}

		private static void CheckBalance()
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("| ScamTrust ATM Secure Menu |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("-----------------------------");


		}

		private static void Deposit()
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("| ScamTrust ATM Secure Menu |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("-----------------------------");
		}

		private static void Withdraw()
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine("| ScamTrust ATM Secure Menu |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|  Please enter             |");
			Console.WriteLine("|  amount to withdraw       |");
			Console.WriteLine("|  in multiples of $20.     |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("-----------------------------");

			Console.Write("\nEnter withdrawal amount: ");

			//ulong withdrawAmt = Console.ReadLine();
			//if (withdrawAmt < 20 || withdrawAmt > accountBalance || (withdrawAmt % 20) != 0)
			{
                Console.WriteLine("Invalid selection.");
				Console.ReadKey(true);
				Withdraw();
			}

			//string.Format("{0:C}", withdrawAmt);
		}
				
		

		private static void Exit()
        {
            Console.WriteLine("Thanks for the card info, loser!");
			Console.ReadKey();
			Environment.Exit(1);
        }
	}
}