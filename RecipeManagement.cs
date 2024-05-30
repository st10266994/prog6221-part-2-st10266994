using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_PART_TWO
{
    //CODE ATTRIBUTION
    //GENERIC COLLECTION LISTS<T> COLLECTION
    //AUTHOR: FATIMA SHAIK
    //SOURCE:https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/Generics_Library_App/LibraryManagementSystem.cs
    //DATE ACCESSED: 28 MAY 2024

    //CODE ATTRIBUTION
    //GENERIC COLLECTION LISTS<T> COLLECTION
    //AUTHOR: TutorialsTeacher
    //SOURCE:https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20%2D%20List,Collections.
    //DATE ACCESSED: 28 MAY 2024

    //CODE ATTRIBUTION
    //DELEGATE
    //AUTHOR: GeeksForGeeks
    //SOURCE:https://www.geeksforgeeks.org/c-sharp-delegates/
    //DATE ACCESSED: 28 MAY 2024
    internal class RecipeManagement
    {
        private List<Recipe> recipe = new List<Recipe>();

        public int RecipesCount => recipe.Count;

        public void AddRecipe()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.EnterRecipeDetails();
            newRecipe.RecipeCaloriesExceeded += HandleRecipeCaloriesExceeded;
            recipe.Add(newRecipe);
        }

        public void DisplayRecipes()
        {
            if (recipe.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been entered yet. Please enter a recipe first.");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipes:");
            Console.ResetColor();

            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
            }

            Console.Write("Enter the Number of the Recipe you would like to Display: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= sortedRecipes.Count)
            {
                sortedRecipes[choice - 1].DisplayRecipeDetails();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
                Console.ResetColor();
            }
        }


        public void ScaleSelectedRecipe()
        {
            if (recipe.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been entered yet. Please enter a recipe first.");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipes:");
            Console.ResetColor();

            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
            }

            Console.Write("Enter the Number of the Recipe you would like to Scale: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= sortedRecipes.Count)
            {
                sortedRecipes[choice - 1].ScaleRecipeByFactorMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }
        }

        public void ClearSelectedRecipe()
        {
            if (recipe.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been entered yet. Please enter a recipe first.");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipes:");
            Console.ResetColor();
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
            }

            Console.Write("Enter the Number of the Recipe you would like to Clear: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= sortedRecipes.Count)
            {
                bool isCleared = sortedRecipes[choice - 1].ClearRecipeData();
                if (isCleared)
                {
                    // Remove the cleared recipe from the original list
                    recipe.Remove(sortedRecipes[choice - 1]);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The Recipe has been cleared and removed from your recipe list.");
                    Console.ResetColor();

                    // Reorder the list after removal
                    sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();

              
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
                Console.ResetColor();
            }
        }
        public void ResetSelectedRecipe()
        {
            if (recipe.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Recipes have been entered yet. Please enter a recipe first.");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipe.OrderBy(r => r.recipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipes:");
            Console.ResetColor();
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
            }

            Console.Write("Enter the Number of the Recipe you would like to Reset: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= sortedRecipes.Count)
            {
                sortedRecipes[choice - 1].ResetRecipeValues();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
                Console.ResetColor();
            }
        }

        private void HandleRecipeCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total Calories for recipe [{recipeName}] exceed 300 calories. Total Calories is {totalCalories}");
            Console.ResetColor();
        }
    }
}
