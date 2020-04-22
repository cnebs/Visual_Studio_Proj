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
            
            public static void CraftPotionMenu()
            {
                Ingredient firstIng = ChooseFirstIng(ingMasterList);
                while (firstIng == null)
                {
                    ErrorGeneral("Invalid entry.\n");
                    firstIng = ChooseFirstIng(ingMasterList);
                }

                Ingredient secondIng = ChooseSecondIng(firstIng, ingMasterList);
                while (secondIng == null || secondIng.name == firstIng.name)
                {
                    if (secondIng.name == firstIng.name)
                    {
                        ErrorGeneral("Cannot combine two of the same ingredient.\n");
                    }
                    else
                    {
                        ErrorGeneral("Invalid entry.\n");
                    }
                    secondIng = ChooseSecondIng(firstIng, ingMasterList);
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
                            Console.WriteLine("DEBUG: prop1 = prop 2 : {0} = {1}", props1[i], props2[j]);
                            Console.WriteLine("DEBUG: i = {0}, j = {1}", i, j);
                            Console.ReadKey(true);
                            return props1[i];
                        } else if (i == j && i == propLength - 1) {
                            Console.ReadKey(true);
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

            static void WriteDebug(Ingredient ingredient)
            {
                string name = ingredient.name.ToUpper();
                Console.WriteLine(name + " Effects: " + ingredient.props[0] + ", " + ingredient.props[1]);
            }

            static Ingredient ChooseFirstIng(Ingredient[] ingMasterList)
            {
                Ingredient firstIng;

                Console.WriteLine("Choose first ingredient. \nInventory: Basil, Thyme, Oregano");

                string input = Console.ReadLine();
                if (GetIngredient(ingMasterList, input) != null)
                {
                    firstIng = GetIngredient(ingMasterList, input);
                    WriteDebug(firstIng);
                    return firstIng;
                }
                else
                {
                    return null;
                }
            }

            static Ingredient ChooseSecondIng(Ingredient firstIng, Ingredient[] ingMasterList)
            {
                Ingredient secondIng;

                Console.WriteLine("Choose second ingredient. Basil, Thyme, Oregano");

                string input = Console.ReadLine();
                if (GetIngredient(ingMasterList, input) != null)
                {
                    secondIng = GetIngredient(ingMasterList, input);
                    WriteDebug(secondIng);
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

                Ingredient[] ingMasterList = { basil, thyme, oregano, ganja };
                return ingMasterList;
            }

            static Ingredient GetIngredient(Ingredient[] ingMasterList, string input)
            {
                Ingredient[] ingredients = ingMasterList;

                for (int i = 0; i < 3; i++)
                {
                    if (ingredients[i].name == input)
                    {
                        return ingredients[i];
                    }
                }
                return null;
            }
        } // end of class Session
    } 
}
