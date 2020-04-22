using System;

namespace NotAScamATM
{
	public class AccountInfo
	{
		string name;
		string accountNo;
		string pinNo;
		string balance;
		public string FormattedBalance
		{
			get { return string.Format("{0:C}", balance); }
		}


		/*
		public AccountInfo(int index)
		{
			var sessionInfo = Accounts.GetSessionInfo(index);
			

			this.name = sessionInfo[0];
			this.accountNo = sessionInfo[1];
			this.pinNo = sessionInfo[2];
			this.balance = sessionInfo[3];
		}
		*/

		public class Accounts
		{
			public Accounts(string cardNum, string pin)
			{
				CheckCred(cardNum, pin);
			}

			/*
			public static string[] GetSessionInfo(int row)
			{
				
				int bound0 = clientDB.GetUpperBound(row);
				string[] sessionInfo = new string[4];

				for (int i = 0; i < bound0; i++)
				{
					sessionInfo[i] = AccountInfo.clientDB[row, i];
				}
				return sessionInfo;
				
			}
			*/

			public bool CheckCred(string cardNum, string pin)
			{
				int row;
				bool cardNumMatch = false, pinMatch = false;

				for (row = 0; row > clientDB.GetLength(0) - 1; row++)
				{
					if (cardNum == clientDB[row, 1])
					{
						cardNumMatch = true;
						break;
					}
				}

				if (pin == clientDB[row, 2])
				{
					pinMatch = true;
				}

				if (cardNumMatch && pinMatch)
				{
					return true;
				}
				return false;
			}

			private string[,] clientDB =
				{
					{ "Betty White", "1111", "1488", "14037.59" },
					{ "Melania Trump", "2222", "1999", "675450112.80"},
					{ "Davy Jones", "3333", "6969", "3.24"}
				};
			
		}
	}
}