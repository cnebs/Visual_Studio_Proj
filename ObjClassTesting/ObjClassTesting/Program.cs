using System;
using System.Collections.Generic;
using Utils;

/* Known bugs: Second ingredient selection exception unhandled if invalid input
 * 
 * Planned features: Static inventory class that tracks ingredients you used and potions you made
 * Option to sell potions or consume them and increase stats
 * Player stats class
 * Migrate ingredient master list to a txt file and add infrastructure to read many ingredients
 * Separate player inventory from full ingredient list
 */


namespace ObjClassTesting
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Alchemy Lab Demo v1.0.0 by C-Vac\nEnter alchemy lab? Y/N");
            
            // Enter or exit program
            if (Util.YesOrNo())
            {
                // To Session.cs
                Session.CraftPotionMenu();
            } else
            {
                Environment.Exit(0);
            }
        }
    } 
}
