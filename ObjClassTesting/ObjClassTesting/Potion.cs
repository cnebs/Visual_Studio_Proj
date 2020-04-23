using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace ObjClassTesting
{
    public class Potion
    {
        string name;
        uint value;
        uint strength;
        string effect;

        public static Potion[] allEffects = PotionEffects();

        public Potion(string name, uint value, uint strength, string effect)
        {
            this.name = name;
            this.value = value;
            this.strength = strength;
            this.effect = effect;
        }

        public static void NewPotion(string type)
        {
            foreach (Potion potion in allEffects)
            {
                if (potion.name.ToLower() == type.ToLower())
                {
                    Potion newPotion = potion;
                    Console.WriteLine("Successfully created Potion of {0}.", type);
                    break;
                }
            }
            Console.WriteLine("Create another potion? Y/N");
            if (Util.YesOrNo())
            {
                Session.CraftPotionMenu();
            }
            else
            {
                Program.Main();
            }

        }

        public static Potion[] PotionEffects()
        {
            Potion fortifyItalian = new Potion("Fortify Italian", 45, 15, "Increases your Italian skill by {0} points");
            Potion restoreHealth = new Potion("Restore Health", 13, 25, "Restores {0} points of health");
            Potion enhanceFlavor = new Potion("Enhance Flavor", 8, 0, "Spices up any dish");

            Potion[] allEffects = { fortifyItalian, restoreHealth, enhanceFlavor };
            return allEffects;
        }
    }
}
