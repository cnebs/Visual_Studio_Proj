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


		public AccountInfo(string name, string acc, string pin, string balance)
		{
			this.name = name;
			this.accountNo = acc;
			this.pinNo = pin;
			this.balance = balance;
		}

		public class Accounts
		{
			public Accounts(string cardNum, string pin)
			{
				CheckCred(cardNum, pin);
			}

			public bool CheckCred(string cardNum, string pin)
			{

				for (int i = ClientDB.GetLength(1); i > 0; i--)
				{
					if (cardNum == ClientDB[1, i])
					{
						if (pin == ClientDB[2, i])
						{
							return true;
						}
					}
				}
				return false;
			}

			private string[,] ClientDB =
			{
				{ "Betty White", "145812", "1488", "14037.59" },
				{ "Melania Trump", "502314", "1999", "675450112.80"},
				{ "Davy Jones", "692011", "6969", "3.24"}
			};
			
		}
	}
}