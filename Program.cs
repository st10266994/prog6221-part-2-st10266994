
using PROG6221_POE_PART_TWO;

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
    }//main

    static void MenuDisplay()
    {
        Recipe recipe = new Recipe();

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
                        //enter method
                        recipe.EnterRecipeDetails();
                        break;
                    }
                case "2":
                    {
                        //display method
                        recipe.DisplayRecipeDetails();

                        break;
                    }
                case "3":
                    {
                        //scale method
                        recipe.ScaleRecipeByFactorMenu();
                        break;
                    }
                case "4":
                    {
                        //reset method
                        recipe.ResetRecipeValues();
                        break;
                    }
                case "5":
                    {
                        //clear data method
                        recipe.ClearRecipeData();
                        break;
                    }
                case "6":
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Exiting Application. Thank you for using the Recipe Application.");
                        Console.ResetColor(); // Reset font color

                        return;

                    }//exit method
                default:
                    {//error-handling: if user enters any other input besides menu options (1-6), an error message will be displayed and the user will be prompted to re-enter a valid option
                        Console.ForegroundColor = ConsoleColor.Red; // Set font color to red for error message

                        Console.WriteLine("*Invalid menu option entered. Please re-enter a valid choice (1-6).*\n\n");
                        Console.ResetColor(); // Reset font color
                        break;
                    }
            }//switch
        }//while- for menu display until exit


    }



}