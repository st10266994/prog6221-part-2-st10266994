using PROG6221_POE_PART_TWO;
using System;

internal class Program
{
    //CODE ATTRIBUTION
    //SWITCH CASE
    //AUTHOR: W3Schools
    //SOURCE:https://www.w3schools.com/cs/cs_switch.php
    //DATE ACCESSED: 12 APRIL 2024

    //CODE ATTRIBUTION
    //FONT COLOUR FOR SPECIFIC LINES
    //AUTHOR: FATIMA SHAIK
    //SOURCE:https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/BurgersAndShakes_App/Program.cs
    //DATE ACCESSED: 12 APRIL 2024

    static void Main(string[] args)
    {
        MenuDisplay();
    }

    static void MenuDisplay()
    {
        RecipeManagement recipeManager = new RecipeManagement();
        Recipe recipe  = new Recipe();  

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("--------Recipe Application--------");
            Console.ResetColor(); // Reset font color

            Console.WriteLine("        Main Menu");
            Console.WriteLine("1. Enter the Recipe details");
            Console.WriteLine("2. Display the Recipe");
            Console.WriteLine("3. Scale the Recipe quantities");
            Console.WriteLine("4. Reset quantities");
            Console.WriteLine("5. Clear Recipe Data");
            Console.WriteLine("6. Exit");

            Console.Write("Please enter your selection from the above menu (1-6): ");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        // Enter recipe details
                        recipeManager.AddRecipe();
                        break;
                    }
                case "2":
                    {
                        // Display recipe details
                        recipeManager.DisplayRecipes();
                        break;
                    }
                case "3":
                    {
                        // Scale recipe quantities
                        recipe.ScaleRecipeByFactorMenu();
                        break;
                    }
                case "4":
                    {
                        // Reset recipe values
                        recipe.ResetRecipeValues();
                        break;
                    }
                case "5":
                    {
                        // Clear recipe data
                      recipe.ClearRecipeData();
                        break;
                    }
                case "6":
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Exiting Application. Thank you for using the Recipe Application.");
                        Console.ResetColor(); // Reset font color
                        return;
                    }
                default:
                    {
                        // Error handling for invalid menu options
                        Console.ForegroundColor = ConsoleColor.Red; // Set font color to red for error message
                        Console.WriteLine("*Invalid menu option entered. Please re-enter a valid choice (1-6).*\n\n");
                        Console.ResetColor(); // Reset font color
                        break;
                    }
            }
        }
    }
}
