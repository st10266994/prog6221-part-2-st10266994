using PROG6221_POE_PART_TWO;
using System;
using System.Collections.Generic;

namespace PROG6221_POE_PART_TWO
{
    internal class Recipe
    {
        private string? recipeName { get; set; }
        private int numIngredients { get; set; }
        private int numSteps { get; set; }
        private List<string?> StepList = new List<string?>();
        private List<Ingredient> IngredientList = new List<Ingredient>();
        private List<Ingredient> OriginalIngredientList = new List<Ingredient>();

        public void EnterRecipeDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("....Enter Recipe Details....");
            Console.ResetColor();

            bool nameValid = false;
            while (!nameValid)
            {
                Console.Write("\nPlease enter the Name of the Recipe: ");
                recipeName = Console.ReadLine();

                if (!string.IsNullOrEmpty(recipeName))
                {
                    nameValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Recipe Name cannot be blank.");
                    Console.ResetColor();
                }
            }

            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.Write("Please enter the Number of Ingredients used in the Recipe: ");
                    numIngredients = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid number of Ingredients entered. Please enter a numeric value");
                    Console.ResetColor();
                }
            }

            for (int i = 0; i < numIngredients; i++)
            {
                double ingredientQuantity = 0.0;
                bool validQuantity = false;
                Console.Write($"Enter the name of Ingredient {i + 1} : ");
                string? ingredientName = Console.ReadLine();

                while (!validQuantity)
                {
                    try
                    {
                        Console.Write($"Enter quantity of {ingredientName} needed: ");
                        ingredientQuantity = Convert.ToDouble(Console.ReadLine());
                        if (!(ingredientQuantity <= 0))
                        {
                            validQuantity = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Invalid Quantity value entered. Quantity value must be greater than 0.");
                            Console.ResetColor();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Invalid Quantity value entered. Please enter a numeric value");
                        Console.ResetColor();
                    }
                }

                string ingredientUnit = "";
                bool unitselection = false;
                while (!unitselection)
                {
                    Console.WriteLine($"Enter the Unit of Measurement for {ingredientName}");
                    Console.WriteLine("1. Tablespoon/s");
                    Console.WriteLine("2. Teaspoon/s");
                    Console.WriteLine("3. Cup/s");
                    Console.WriteLine("4. Small");
                    Console.WriteLine("5. Medium");
                    Console.WriteLine("6. Large");
                    Console.WriteLine("7. Extra-Large");
                    Console.Write("Please enter your selection from the above menu (1-7): ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            ingredientUnit = "Tablespoon/s";
                            unitselection = true;
                            break;
                        case "2":
                            ingredientUnit = "Teaspoon/s";
                            unitselection = true;
                            break;
                        case "3":
                            ingredientUnit = "Cup/s";
                            unitselection = true;
                            break;
                        case "4":
                            ingredientUnit = "Small";
                            unitselection = true;
                            break;
                        case "5":
                            ingredientUnit = "Medium";
                            unitselection = true;
                            break;
                        case "6":
                            ingredientUnit = "Large";
                            unitselection = true;
                            break;
                        case "7":
                            ingredientUnit = "Extra-Large";
                            unitselection = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*Invalid unit of measurement option entered. Please re-enter a valid choice (1-7).*");
                            Console.ResetColor();
                            break;
                    }
                }//while

                double ingredientCalories = 0.0;
                bool validCalories = false;
                while (!validCalories)
                {
                    try
                    {
                        Console.Write("Please enter the Number of Calories in this Ingredient: ");
                       ingredientCalories= Convert.ToDouble(Console.ReadLine()); 
                        validCalories = true;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Invalid number of Calories entered. Please enter a numeric value");
                        Console.ResetColor();
                    }
                }
               

                bool foodGroupSelection = false;
                string foodGroup = "";
                while (!foodGroupSelection)
                {
                    // New code for selecting food group
                    Console.WriteLine($"Enter the food group for {ingredientName}:");
                    Console.WriteLine("1. Starchy foods");
                    Console.WriteLine("2. Vegetables and fruits");
                    Console.WriteLine("3. Dry beans, peas, lentils and soya");
                    Console.WriteLine("4. Chicken, fish, meat and eggs");
                    Console.WriteLine("5. Milk and dairy products");
                    Console.WriteLine("6. Fats and oil");
                    Console.WriteLine("7. Water");
                    Console.Write("Please enter the number corresponding to the food group: ");

                 
                        switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                foodGroup = "Starchy foods";
                                foodGroupSelection = true;
                                break;
                            }
                        case "2":
                            {
                                foodGroup = "Vegetables and fruits";
                                foodGroupSelection = true;
                                break;
                            }
                        case "3":
                            {
                                foodGroup = "Dry beans, peas, lentils and soya";
                                foodGroupSelection = true;
                                break;
                            }
                        case "4":
                            {
                                foodGroup = "Chicken, fish, meat and eggs";
                                foodGroupSelection = true;
                                break;
                            }
                        case "5":
                            {
                                foodGroup = "Milk and dairy products";
                                foodGroupSelection = true;
                                break;
                            }
                        case "6":
                            {
                                foodGroup = "Fats and oil";
                                foodGroupSelection = true;
                                break;
                            }
                        case "7":
                            { 
                            foodGroup = "Water";
                                foodGroupSelection = true;
                            break;
                                 }
                        default:
                            { 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("*Invalid Food Group option entered. Please re-enter a valid choice (1-7).*");
                                Console.ResetColor();
                                break;
                            }
                    }//switch
                }//while display until correct unit of measurement input


                Ingredient ingredientdetails = new Ingredient { Name = ingredientName, Quantity = ingredientQuantity, Unit = ingredientUnit, FoodGroup = foodGroup, Calories=ingredientCalories };
                    Ingredient ingredientdetailscopy = new Ingredient { Name = ingredientName, Quantity = ingredientQuantity, Unit = ingredientUnit, FoodGroup = foodGroup, Calories = ingredientCalories };

                    IngredientList.Add(ingredientdetails);
                    OriginalIngredientList.Add(ingredientdetailscopy);
                }//while

                bool stepsValid = false;
                while (!stepsValid)
                {
                    try
                    {
                        Console.Write("Please enter the Number of Steps used in the Recipe: ");
                        numSteps = Convert.ToInt32(Console.ReadLine());
                        if (!(numSteps <= 0))
                        {
                            stepsValid = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Invalid number of Steps entered. Number of Steps must be greater than 0.");
                            Console.ResetColor();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Invalid number of Steps entered. Please enter a numeric value");
                        Console.ResetColor();
                    }
                }

                for (int j = 0; j < numSteps; j++)
                {
                    Console.Write($"Enter a description of what the user should do in Step {j + 1}: ");
                    StepList.Add(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Recipe details entered successfully!\n");
                Console.ResetColor();
            
        }

        public void DisplayRecipeDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n....Recipe Details For {recipeName}....");
            Console.ResetColor();

            Console.WriteLine($"Number of Ingredients: {numIngredients}");
            Console.WriteLine($"Number of Steps: {numSteps}");
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in IngredientList)
            {
                Console.WriteLine($"* {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}\nFood Group: {ingredient.FoodGroup}\nCalories: {ingredient.Calories}\n");
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < StepList.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {StepList[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"....Recipe Details For {recipeName}....\n");
            Console.ResetColor();
        }

        public void ClearRecipeData()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"......Clear Recipe Data for {recipeName}......");
            Console.ResetColor();
            bool userFeedback = false;
            bool clearRecipe = false;
            while (!userFeedback)
            {
                Console.WriteLine($"Are you sure you want to clear Recipe Data for {recipeName} ?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Please enter your selection from the above menu (1-2): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        clearRecipe = true;
                        userFeedback = true;
                        break;
                    case "2":
                        clearRecipe = false;
                        userFeedback = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*Error: Please re-enter a valid choice (1-2).*");
                        Console.ResetColor();
                        break;
                }
            }

            if (clearRecipe)
            {
                recipeName = null;
                numIngredients = 0;
                numSteps = 0;
                IngredientList.Clear();
                StepList.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"......Recipe Details Cleared......\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"......Clear Request Cancelled......\n");
                Console.ResetColor();
            }
        }

        public void ScaleRecipeByFactorMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Scale Recipe......");
            Console.ResetColor();

            Console.WriteLine("1. Scale Recipe by a factor of 0.5 (Half)");
            Console.WriteLine("2. Scale Recipe by a factor of 2 (Double)");
            Console.WriteLine("3. Scale Recipe by a factor of 3 (Triple)");

            Console.Write("Please enter your selection from the above menu (1-3): ");
            switch (Console.ReadLine())
            {
                case "1":
                    ScaleRecipeByHalf();
                    DisplayRecipeDetails();
                    break;
                case "2":
                    ScaleRecipeByDouble();
                    DisplayRecipeDetails();
                    break;
                case "3":
                    ScaleRecipeByTriple();
                    DisplayRecipeDetails();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*Invalid menu option entered. Please re-enter a valid choice (1-3).*");
                    Console.ResetColor();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Scale Recipe......\n");
            Console.ResetColor();
        }

        public void ScaleRecipeByDouble()
        {
            foreach (Ingredient ingredient in IngredientList)
            {
                switch (ingredient.Unit)
                {
                    case "Tablespoon/s":
                        ingredient.Calories = ingredient.Calories *2;
                        if (ingredient.Quantity >= 8)
                        {
                            double numCups = Math.Floor(((ingredient.Quantity * 2) / 16));
                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity * 2) % 16));
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of";
                                break;
                            }
                            ingredient.Quantity = numCups;
                            ingredient.Unit = "Cup/s";
                        }
                        else
                        {
                            ingredient.Quantity *= 2;
                        }
                        break;
                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories * 2;


                        if (ingredient.Quantity >= 1.5)
                        {
                            double numTablespoons = Math.Floor(((ingredient.Quantity * 2) / 3));
                            int remainderTeaspoons = Convert.ToInt32(((ingredient.Quantity * 2) % 3));
                            if (remainderTeaspoons > 0)
                            {
                                ingredient.Quantity = numTablespoons;
                                ingredient.Unit = $"Tablespoon/s and {remainderTeaspoons} Teaspoon/s of";
                                break;
                            }
                            ingredient.Quantity = numTablespoons;
                            ingredient.Unit = "Tablespoon/s";
                        }
                        else
                        {
                            ingredient.Quantity *= 2;
                        }
                        break;
                    case "Cup/s":
                    case "Small":
                    case "Medium":
                    case "Large":
                    case "Extra-Large":
                        ingredient.Quantity *= 2;
                        ingredient.Calories = ingredient.Calories * 2;

                        break;
                    default:
                        break;
                }
            }
        }

        public void ScaleRecipeByTriple()
        {
            foreach (Ingredient ingredient in IngredientList)
            {
                switch (ingredient.Unit)
                {
                    case "Tablespoon/s":
                        ingredient.Calories = ingredient.Calories * 3;

                        if (ingredient.Quantity > 5)
                        {
                            double numCups = Math.Floor(((ingredient.Quantity * 3) / 16));
                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity * 3) % 16));
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of";
                                break;
                            }
                            ingredient.Quantity = numCups;
                            ingredient.Unit = "Cup/s";
                        }
                        else
                        {
                            ingredient.Quantity *= 3;
                        }
                        break;
                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories * 3;

                        if (ingredient.Quantity == 1.0)
                        {
                            ingredient.Unit = "Tablespoon";
                        }
                        else
                        {
                            ingredient.Unit = "Tablespoons";
                        }
                        break;
                    case "Cup/s":
                    case "Small":
                    case "Medium":
                    case "Large":
                    case "Extra-Large":
                        ingredient.Quantity *= 3;
                        ingredient.Calories = ingredient.Calories * 3;

                        break;
                    default:
                        break;
                }
            }
        }

        public void ScaleRecipeByHalf()
        {
            foreach (Ingredient ingredient in IngredientList)
            {
                switch (ingredient.Unit)
                {
                    case "Tablespoon/s":
                        ingredient.Calories = ingredient.Calories /2;

                        if (ingredient.Quantity > 1)
                        {
                            double numTablespoons = Math.Floor((ingredient.Quantity / 2));
                            double remainderTeaspoons = (((ingredient.Quantity % 2) * 1.5));
                            if (remainderTeaspoons > 0)
                            {
                                ingredient.Quantity = numTablespoons;
                                ingredient.Unit = $"Tablespoon/s and {remainderTeaspoons} Teaspoon/s of";
                                break;
                            }
                            ingredient.Quantity = numTablespoons;
                        }
                        else
                        {
                            ingredient.Quantity = ((ingredient.Quantity / 2) * 3);
                            ingredient.Unit = "Teaspoons";
                        }
                        break;
                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories / 2;

                        ingredient.Quantity /= 2;
                        break;
                    case "Cup/s":
                        ingredient.Calories = ingredient.Calories / 2;

                        if (ingredient.Quantity > 1)
                        {
                            double numCups = Math.Floor((ingredient.Quantity / 2));
                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity % 2) * 8));
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of";
                                break;
                            }
                            ingredient.Quantity = numCups;
                        }
                        else
                        {
                            ingredient.Quantity = ((ingredient.Quantity / 2) * 16);
                            ingredient.Unit = "Tablespoons";
                        }
                        break;
                    case "Small":
                    case "Medium":
                    case "Large":
                    case "Extra-Large":
                        ingredient.Quantity /= 2;
                        ingredient.Calories = ingredient.Calories / 2;

                        break;
                    default:
                        break;
                }
            }
        }

        public void ResetRecipeValues()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Reset Recipe Values......");
            Console.ResetColor();
            IngredientList.Clear();

            foreach (Ingredient ingredient in OriginalIngredientList)
            {
                IngredientList.Add(new Ingredient { Name = ingredient.Name, Quantity = ingredient.Quantity, Unit = ingredient.Unit , FoodGroup=ingredient.FoodGroup,Calories=ingredient.Calories});
            }

            DisplayRecipeDetails();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Reset Recipe Values......\n");
            Console.ResetColor();
        }
    }
}


