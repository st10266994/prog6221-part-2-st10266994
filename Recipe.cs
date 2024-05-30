using PROG6221_POE_PART_TWO;
using System;
using System.Collections.Generic;

namespace PROG6221_POE_PART_TWO
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

    //CODE ATTRIBUTION
    //TRY CATCH 
    //AUTHOR: FATIMA SHAIK
    //SOURCE:https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/AddressBookApp/AddressBook.cs
    //DATE ACCESSED: 13 APRIL 2024

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

    public class Recipe
    {
        public string? recipeName { get; set; } //name of recipe
        public int numIngredients { get; set; } //number of ingredients used in a recipe
        public int numSteps { get; set; } // number of steps in a recipe
        public List<string?> StepList = new List<string?>(); //list to store the steps
        public List<Ingredient> IngredientList = new List<Ingredient>();//list to store the ingredient details for each recipe
        public List<Ingredient> OriginalIngredientList = new List<Ingredient>();//copy of the list to store ingredient details for each ingredient, so that user can reset values after scaling
        //delegate for alert when a recipes total calories exceed 300 calories
        public delegate void RecipeCaloriesExceededHandler(string recipeName, double totalCalories);
        public event RecipeCaloriesExceededHandler RecipeCaloriesExceeded;

        public void EnterRecipeDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("....Enter Recipe Details....");
            Console.ResetColor();//reset font colour

            bool nameValid = false;
            while (!nameValid)//error-handling for blank recipe name
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
                    Console.ResetColor(); //reset font colour
                }
            }
            //number of ingredients
            bool valid = false;
            while (!valid)
            {// while invalid- reprompt user for correct input
                try
                {//error-handling
                    Console.Write("Please enter the Number of Ingredients used in the Recipe: ");
                    numIngredients = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }//try
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //set font colour to red for error message
                    Console.WriteLine("Error: Invalid number of Ingredients entered. Please enter a numeric value");
                    Console.ResetColor();
                }//catch
            }//while

            //storing the details for each ingredient- name, quantity, units, food group, calories
            for (int i = 0; i < numIngredients; i++)
            {
                double ingredientQuantity = 0.0;
                bool validQuantity = false;
                Console.Write($"Enter the name of Ingredient {i + 1} : ");
                string? ingredientName = Console.ReadLine();

                while (!validQuantity)
                {// while invalid- reprompt user for correct input
                    try
                    {//error-handling
                        Console.Write($"Enter quantity of {ingredientName} needed: ");
                        ingredientQuantity = Convert.ToDouble(Console.ReadLine());// checks if user has entered a numeric amount
                        if (!(ingredientQuantity <= 0)) // validation- user cannot enter 0 or a negative amount for quantity amount
                        {
                            validQuantity = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //set font colour to red for error message
                            Console.WriteLine("Error: Invalid Quantity value entered. Quantity value must be greater than 0.");
                            Console.ResetColor();
                        }
                    }//try
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                        Console.WriteLine("Error: Invalid Quantity value entered. Please enter a numeric value");
                        Console.ResetColor();
                    }
                }
                //unit of measurement
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
                            Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                            Console.WriteLine("*Invalid unit of measurement option entered. Please re-enter a valid choice (1-7).*");
                            Console.ResetColor();
                            break;
                    }
                }//while - display until correct unit of measurement input

                //number of calories in this ingredient
                double ingredientCalories = 0.0;
                bool validCalories = false;
                while (!validCalories)
                {
                    try
                    {
                        Console.Write("Please enter the Number of Calories in this Ingredient: ");
                       ingredientCalories= Convert.ToDouble(Console.ReadLine());
                        if (!(ingredientCalories < 0)) // validation- user cannot enter a negative amount for calories 
                        {
                            validCalories = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                            Console.WriteLine("Error: Invalid Calorie amount entered. Calorie amount cannot be negative.");
                            Console.ResetColor();
                        }
                    }//try
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                        Console.WriteLine("Error: Invalid number of Calories entered. Please enter a numeric value");
                        Console.ResetColor();
                    }//catch
                }
               

                bool foodGroupSelection = false;
                string foodGroup = "";
                while (!foodGroupSelection)
                {
                  //give user a menu for selecting the food group, instead of making them enter a food group by typing the word
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
                                Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
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
                            Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                        Console.WriteLine("Error: Invalid number of Steps entered. Number of Steps must be greater than 0.");
                            Console.ResetColor();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
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
        public double CalculateTotalCalories()
        {
            double totalCalories = 0.0;
            foreach (Ingredient ingredient in IngredientList)
            {
                totalCalories += ingredient.Calories;
            }

            if (totalCalories > 300)
            {
               // if total is over 300, raise the event 
                RecipeCaloriesExceeded(recipeName, totalCalories);
            }

            return totalCalories;
        }//enter recipe details method
        public void DisplayRecipeDetails()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n....Recipe Details For {recipeName}....");
            Console.ResetColor();// reset font colour

            Console.WriteLine($"Number of Ingredients: {numIngredients}");
            Console.WriteLine($"Number of Steps: {numSteps}");
            Console.WriteLine("Ingredients:");

            //display each ingredient (name, quantity, unit of measurement, food group, calories)
            foreach (Ingredient ingredient in IngredientList)
            {
                Console.WriteLine($"* {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}\nFood Group: {ingredient.FoodGroup}\nCalories: {ingredient.Calories}\n");
            }//end ingredient display

            Console.WriteLine("Steps:");

            for (int i = 0; i < StepList.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {StepList[i]}");
            }

            // calculate total calories in the recipe using the CalculateTotalCalories method
            double totalCalories = CalculateTotalCalories();

            //display total calories
            Console.WriteLine($"Total Calories: {totalCalories}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"....Recipe Details For {recipeName}....\n");
            Console.ResetColor();
        }//display method


        public bool ClearRecipeData()
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
                        Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                        Console.WriteLine("*Error: Please re-enter a valid choice (1-2).*");
                        Console.ResetColor();
                        break;
                }
            }

            if (clearRecipe)// if users response is YES: clear data
            {
                recipeName = null;
                numIngredients = 0;
                numSteps = 0;
                IngredientList.Clear();
                StepList.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"......Recipe Details Cleared......\n");
                Console.ResetColor();
                return true;  // Indicate that the recipe was cleared
            }
            else // if users respone is NO: cancel clear data request
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"......Clear Request Cancelled......\n");
                Console.ResetColor();
                return false; // Indicate that the recipe was not cleared
            }
        }//clear recipe data method

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
                    //scale by half method
                    {
                        ScaleRecipeByHalf();
                        DisplayRecipeDetails();
                        break;
                    }
                case "2":
                    {
                        //scale by double method
                        ScaleRecipeByDouble();
                        DisplayRecipeDetails();
                        break;
                    }
                case "3":
                    {
                        //scale by triple method
                        ScaleRecipeByTriple();
                        DisplayRecipeDetails();
                        break;
                    }
                default:
                    {
                    //error-handling: if user enters any other input besides menu options (1-3), an error message will be displayed and the user will be taken back to the main menu.
                            Console.ForegroundColor = ConsoleColor.Red;//set font colour to red for error message
                        Console.WriteLine("*Invalid menu option entered. Please re-enter a valid choice (1-3).*");
                        Console.ResetColor();
                        break;
                    }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Scale Recipe......\n");
            Console.ResetColor();
        }//scale recipe by a factor method

        public void ScaleRecipeByDouble()
        {
            foreach (Ingredient ingredient in IngredientList)
            {
                switch (ingredient.Unit)
                {
                    case "Tablespoon/s":
                        
                        ingredient.Calories = ingredient.Calories * 2; // double calories when scaling by a factor of 2
                        if (ingredient.Quantity >= 8) //if above 8 - doubling by 8 or more will require a unit change

                        {
                            double numCups = Math.Floor(((ingredient.Quantity * 2) / 16)); //double then divide by 16 as 16 tablespoons make one cup

                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity * 2) % 16)); //get remainder tablespoons
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of"; //change unit to cups and add remainder to unit 
                                break;
                            } //if it doesnt have a remainder just need to output the scaled quantity and unit change

                            ingredient.Quantity = numCups;
                            ingredient.Unit = "Cup/s";
                        }
                        else
                        {  //if its below 8 and scaling it by 2 wont require a unit of measurement change, just change the quantity according to scale 

                            ingredient.Quantity *= 2;
                        }
                        break; //tablespoon
                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories * 2; // double calories when scaling by a factor of 2


                        if (ingredient.Quantity >= 1.5)
                        {
                            double numTablespoons = Math.Floor(((ingredient.Quantity * 2) / 3)); //double then divide by 3 as 3 teaspoons make one tablespoon
                            int remainderTeaspoons = Convert.ToInt32(((ingredient.Quantity * 2) % 3)); //get remainder teaspoons
                            if (remainderTeaspoons > 0)
                            {
                                ingredient.Quantity = numTablespoons;
                                ingredient.Unit = $"Tablespoon/s and {remainderTeaspoons} Teaspoon/s of";
                                break;
                            } 
                            //if it doesnt have a remainder just need to output the scaled quantity and unit change

                            ingredient.Quantity = numTablespoons;
                            ingredient.Unit = "Tablespoon/s";
                        }
                        else
                        {
                            //if its below 1.5 and scaling it by 2 wont require a unit of measurement change, just change the quantity according to scale
                            ingredient.Quantity *= 2;
                        }
                        break;
                    case "Cup/s":
                    case "Small":
                    case "Medium":
                    case "Large":
                    case "Extra-Large":
                        ingredient.Quantity *= 2;
                        ingredient.Calories = ingredient.Calories * 2; // double calories when scaling by a factor of 2

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
                        ingredient.Calories = ingredient.Calories * 3; // triple calories when scaling by a factor of 3

                        if (ingredient.Quantity > 5) //if above 5 - tripling more than 5 tablespoons will require a unit change to cups

                        {
                            double numCups = Math.Floor(((ingredient.Quantity * 3) / 16)); //triple then divide by 16 as 16 tablespoons make one cup

                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity * 3) % 16));
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of"; //get remainder tablespoons
                                break;
                            }
                            //if it doesnt have a remainder just need to output the scaled quantity and unit change

                            ingredient.Quantity = numCups;
                            ingredient.Unit = "Cup/s";
                        }
                        else
                        { //if its less than 5 and scaling it by 3 wont require a unit of measurement change, just change the quantity according to scale 
                            ingredient.Quantity *= 3;
                        }
                        break;
                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories * 3; // triple calories when scaling by a factor of 3

                        if (ingredient.Quantity == 1.0) //no need to perform any calculation when tripiling as when tripiling you need to multiply number of teaspoons by 3, and and every 3 teaspoons makes one tablespoon, therefore it cancels out 
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
                        ingredient.Calories = ingredient.Calories * 3; // triple calories when scaling by a factor of 3

                        break;
                    default:
                        break;
                }//switch
            } //for
        }//scale by triple method

        public void ScaleRecipeByHalf()
        {
            foreach (Ingredient ingredient in IngredientList)
            {
                switch (ingredient.Unit)
                {
                    case "Tablespoon/s":
                        ingredient.Calories = ingredient.Calories /2; // half calories when scaling by a factor of half

                        if (ingredient.Quantity > 1) //if above 1 tablespoon

                        {
                            double numTablespoons = Math.Floor((ingredient.Quantity / 2));  //divide by 2 (scale by half)

                            double remainderTeaspoons = (((ingredient.Quantity % 2) * 1.5));  //get remainder teaspoons

                            if (remainderTeaspoons > 0)  //if there is a remainder after scaling

                            {
                                ingredient.Quantity = numTablespoons;
                                ingredient.Unit = $"Tablespoon/s and {remainderTeaspoons} Teaspoon/s of"; //add remainder tablespoons to unit 
                                break;
                            }
                            //if it doesnt have a remainder just need to output the scaled quantity 
                            ingredient.Quantity = numTablespoons;
                        }
                        else
                        {
                            //if one or less tablespoons then  divide by 2 (scale by half) and multiply by 3 to get number of teaspoons
                            ingredient.Quantity = ((ingredient.Quantity / 2) * 3);
                            ingredient.Unit = "Teaspoons";
                        }
                        break;//tablespoon

                    case "Teaspoon/s":
                        ingredient.Calories = ingredient.Calories / 2;// half calories when scaling by a factor of half

                        ingredient.Quantity /= 2;
                        break;//teaspoon
                    case "Cup/s":
                        ingredient.Calories = ingredient.Calories / 2;// half calories when scaling by a factor of half

                        if (ingredient.Quantity > 1) //if above 1 

                        {
                            double numCups = Math.Floor((ingredient.Quantity / 2)); //divide by 2 (scale by half)
                            int remainderTablespoons = Convert.ToInt32(((ingredient.Quantity % 2) * 8)); //get remainder tablespoons
                            if (remainderTablespoons > 0)
                            {
                                ingredient.Quantity = numCups;
                                ingredient.Unit = $"Cup/s and {remainderTablespoons} Tablespoon/s of"; //add remainder tablespoons to unit 
                                break;
                            }
                            //if it doesnt have a remainder just need to output the scaled quantity 
                            ingredient.Quantity = numCups;
                        }
                        else
                        {
                            //if one or less cups then  divide by 2 (scale by half) and multiply by 16 to get number of tablespoons

                            ingredient.Quantity = ((ingredient.Quantity / 2) * 16);
                            ingredient.Unit = "Tablespoons";
                        }
                        break;//cup/s

                    case "Small":
                    case "Medium":
                    case "Large":
                    case "Extra-Large":
                        ingredient.Quantity /= 2;
                        ingredient.Calories = ingredient.Calories / 2;

                        break;
                    default:
                        break;
                }//switch
            }//for
        }//scale by half method

        public void ResetRecipeValues()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Reset Recipe Values......");
            Console.ResetColor();
            IngredientList.Clear(); //clear all values in ingredient list that might have been changed when scaling


            foreach (Ingredient ingredient in OriginalIngredientList)
            {
                //replace the scaled values with the orginal values stored in a copy of the ingredient list

                IngredientList.Add(new Ingredient { Name = ingredient.Name, Quantity = ingredient.Quantity, Unit = ingredient.Unit , FoodGroup=ingredient.FoodGroup,Calories=ingredient.Calories});
            }//for

            DisplayRecipeDetails();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("......Reset Recipe Values......\n");
            Console.ResetColor();
        }//reset recipe values method


        //for test unit
        public void AddIngredient(Ingredient ingredient)
        {
            IngredientList.Add(ingredient);
        }


    }
}


