using System;

namespace NotAScamATM
{
    public class SecurityLogin
    {
        static void Main()
        {
			Console.WriteLine("-----------------------------");
			Console.WriteLine("| ScamTrust ATM Secure Menu |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|  Welcome to ScamTrust.    |");
			Console.WriteLine("|                           |");
			Console.WriteLine("|  Please insert your card. |");
			Console.WriteLine("|                           |");
			Console.WriteLine("-----------------------------");
			Console.ReadKey(true);

			int attempts = 0;
			while (attempts < 5) 
			{
				Console.Write("Enter your card number: ");
				string cardNumInput = "_" + Console.ReadLine();
				Console.Write("\nEnter your four-digit PIN: ");
				string pinInput = Console.ReadLine();

				AccountInfo.Accounts check = new AccountInfo.Accounts(cardNumInput, pinInput);
				if (check.CheckCred(cardNumInput, pinInput))
				{
					Menu.MainMenu(cardNumInput);
				}
				attempts++;
			}
		}
    }
}
