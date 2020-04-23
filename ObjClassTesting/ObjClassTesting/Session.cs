using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace ObjClassTesting
{
    public class Session
    {
        // Stores each ingredient in an object array
        static Ingredient[] ingMasterList = IngArrayPopulate();
        // Unused code for player inventory
        static Inventory playerInv = new Inventory();
        // Makes a single string of all ingredients loaded into the program
        public static string ingString = IngString();


        // Main method for crafting, return here when potion is crafted or failed
        public static void CraftPotionMenu()
        {
            // Choose first ingredient, gets user input and checks validity
            Ingredient firstIng = ChooseFirstIng();
            // If ChooseFirstIng() returns null, loop it until a valid selection is made
            while (firstIng == null)
            {
                firstIng = ChooseFirstIng();
            }

            Ingredient secondIng = ChooseSecondIng(firstIng);
            while (secondIng == null || secondIng.name == firstIng.name)
            {
                if (secondIng.name == firstIng.name)
                {
                    Util.ErrorGeneral("Cannot combine two of the same ingredient.\n");
                    WriteIngredient(firstIng);
                }
                else
                {
                    Util.ErrorGeneral("Invalid entry.\n");
                    WriteIngredient(firstIng);
                }
                secondIng = ChooseSecondIng(firstIng);
            }

            // Finalize potion creation
            Console.WriteLine("Make a potion with {0} and {1}? Y/N", firstIng.name, secondIng.name);
            if (Util.YesOrNo())
            {
                CreatePotion(firstIng, secondIng);
            }
            else
            {
                Console.Clear();
                CraftPotionMenu();
            }
        }

        // 
        static void CreatePotion(Ingredient firstIng, Ingredient secondIng)
        {
            // check if ingredients are compatible
            string potionCreationType = CheckCompat(firstIng.props, secondIng.props);
            if (potionCreationType == "Potion creation failed.")
            {
                Util.ErrorGeneral(potionCreationType);
                CraftPotionMenu();
            }
            else
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
                    }
                    else if (i == j && i == propLength - 1)
                    {
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

        // 
        static void WriteIngredient(Ingredient ingredient)
        {
            string name = ingredient.name.ToUpper();
            Console.WriteLine(name + " Effects: " + ingredient.props[0] + ", " + ingredient.props[1]);
        }

        // 
        static string IngString()
        {
            string ingString = "";
            foreach (Ingredient ing in ingMasterList)
            {
                ingString += ing.name.ToUpper() + ". ";
            }
            return ingString;
        }

        // Take user input and compare to ingredients, 
        // Return the matching ingredient or null
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
                Util.ErrorGeneral("Invalid entry.\n");
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
            Ingredient ganja = new Ingredient("dude weed", "Cure disease", "Fortify IQ");
            Ingredient bong = new Ingredient("epic bong", "Cure disease", "Fortify IQ");

            Ingredient[] ingMasterList = { basil, thyme, oregano, ganja };
            return ingMasterList;
        }

        // Takes ingredient name as input
        // Returns the matching ingredient or null
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
    }
}
