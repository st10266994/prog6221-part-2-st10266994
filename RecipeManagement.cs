using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_PART_TWO
{
    internal class RecipeManagement
    {
        private List<Recipe> recipes = new List<Recipe>();

        public int RecipesCount => recipes.Count;

        public void AddRecipe()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.EnterRecipeDetails();
            newRecipe.RecipeCaloriesExceeded += HandleRecipeCaloriesExceeded;
            recipes.Add(newRecipe);
        }

        public void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available.");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.recipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipes:");
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].recipeName}");
            }

            Console.Write("Enter the number of the recipe to display: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= sortedRecipes.Count)
            {
                sortedRecipes[choice - 1].DisplayRecipeDetails();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }
        }




        private void HandleRecipeCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"WARNING: Calories for recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}");
            Console.ResetColor();
        }
    }
}
