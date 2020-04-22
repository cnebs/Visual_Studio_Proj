using System;
using System.Collections.Generic;

/*  C-Vac's first fully original program (you can tell because the source is wack)
 *  Been coding for a week and a half as of 4-22-20
 *  Made this in 4 hours
 *  Comment level -->  Wtf wheres comments[-|---------------------]Lots of comments
 *  
 *  The dev needs to be taught a lesson
 * 
 *  I just figured out objects and classes but still not really sure where to store most variables most efficiently
 *  Also everything is in one cs file because for the time being i preferred to edit that way.
 */



namespace ObjClassTesting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Alchemy Lab Demo v1.0.0 by C-Vac\nEnter alchemy lab? Y/N");
            if (YesOrNo())
            {
                Session.CraftPotionMenu();
            } else
            {
                Environment.Exit(0);
            }
        }

        public static void ErrorGeneral(string msg)
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static bool YesOrNo()
        {
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            } return false;
        }

        public class Ingredient
        {
            public string name;
            public string[] props = new string[2];

            public Ingredient(string name, string prop1, string prop2)
            {
                this.name = name;
                this.props = new string[] { prop1, prop2 };
            }

        }
    
        public class Inventory
        {
            // public string[] playerInv;
            public uint numPotions = 0;
            public uint totalValue = 0;

        }

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
                if (YesOrNo())
                {
                    Session.CraftPotionMenu();
                } else
                {
                    Main();
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


        public class Session
        {
            static Ingredient[] ingMasterList = IngArrayPopulate();
            static Inventory playerInv = new Inventory();
            public static string ingString = IngString();
            public static bool firstIngInvalid = true;
            public static bool secondIngInvalid = true;

            public static void CraftPotionMenu()
            {
                

                Ingredient firstIng = ChooseFirstIng();
                while (firstIng == null && firstIngInvalid)
                {
                    ErrorGeneral("Invalid entry.\n");
                }

                Ingredient secondIng = ChooseSecondIng(firstIng);
                while (secondIng == null || secondIng.name == firstIng.name)
                {
                    if (secondIng.name == firstIng.name)
                    {
                        ErrorGeneral("Cannot combine two of the same ingredient.\n");
                        WriteIngredient(firstIng);
                    }
                    else
                    {
                        ErrorGeneral("Invalid entry.\n");
                        WriteIngredient(firstIng);
                    }
                    secondIng = ChooseSecondIng(firstIng);
                }

                Console.WriteLine("Make a potion with {0} and {1}? Y/N", firstIng.name, secondIng.name);
                if (YesOrNo())
                {
                    CreatePotion(firstIng, secondIng);
                } else
                {
                    Console.Clear();
                    CraftPotionMenu();
                }
            }

            static void CreatePotion(Ingredient firstIng, Ingredient secondIng)
            {
                // check if ingredients are compatible
                string potionCreationType = CheckCompat(firstIng.props, secondIng.props);
                if (potionCreationType == "Potion creation failed.")
                {
                    ErrorGeneral(potionCreationType);
                    CraftPotionMenu();
                } else
                {
                    Potion.NewPotion(potionCreationType);
                }

                static string CheckCompat(string[] props1, string[] props2)
                {
                    int propLength = props1.GetLength(0);
                    for (int i = 0, j = 0; i < propLength; i++)
                    {
                        if (props1[i] == props2[j])
                        {
                            return props1[i];
                        } else if (i == j && i == propLength - 1) {
                            i = 0;
                            j++;
                        }
                    }
                    return "Potion creation failed.";
                }

                // add... apply effects to new potion
                // add... keep track of inventory
                // add... add potion to inventory
            }

            static void WriteIngredient(Ingredient ingredient)
            {
                string name = ingredient.name.ToUpper();
                Console.WriteLine(name + " Effects: " + ingredient.props[0] + ", " + ingredient.props[1]);
            }

            static string IngString()
            {
                string ingString = "";
                foreach (Ingredient ing in ingMasterList)
                {
                    ingString += ing.name.ToUpper() + " ";
                }
                return ingString;
            }

            static Ingredient ChooseFirstIng()
            {
                Ingredient firstIng;

                Console.WriteLine("Choose first ingredient. \nInventory: {0}", ingString);

                string input = Console.ReadLine();
                if (GetIngredient(input) != null)
                {
                    firstIng = GetIngredient(input);
                    WriteIngredient(firstIng);
                    return firstIng;
                }
                else
                {
                    return null;
                }
            }

            static Ingredient ChooseSecondIng(Ingredient firstIng)
            {
                Ingredient secondIng;

                Console.WriteLine("Choose second ingredient. \nInventory: {0}", ingString);

                string input = Console.ReadLine();
                if (GetIngredient(input) != null)
                {
                    secondIng = GetIngredient(input);
                    WriteIngredient(secondIng);
                    return secondIng;
                }
                else
                {
                    return null;
                }

            }

            static Ingredient[] IngArrayPopulate()
            {
                Ingredient basil = new Ingredient("basil", "Fortify Italian", "Restore health");
                Ingredient thyme = new Ingredient("thyme", "Restore health", "Enhance flavor");
                Ingredient oregano = new Ingredient("oregano", "Fortify Italian", "Enhance flavor");
                Ingredient ganja = new Ingredient("dude, weed", "Cure disease", "Fortify IQ");
                Ingredient bong = new Ingredient("epic bong", "Cure disease", "Fortify IQ");

                Ingredient[] ingMasterList = { basil, thyme, oregano, ganja , bong};
                return ingMasterList;
            }

            static Ingredient GetIngredient(string input)
            {
                for (int i = 0; i <= ingMasterList.GetUpperBound(0); i++)
                {
                    if (ingMasterList[i].name == input)
                    {
                        return ingMasterList[i];
                    }
                }
                return null;
            }
        } // end of class Session
    } 
}
