Update from part 1: I was not advised to make any code changes. However I was instructed to create a neater layout and format of my ReadMe.
This is my new ReadMe:
# PROG6221_POE_PART_TWO

Additional in part two: 
-Users can now add unlimited recipes
-Users can view a list of their recipes in alphabetical order
-Removal of array lists, the program now makes use of generic collection type T lists
-A delegate for alerting the user when the total calories in a recipe they have added is over 300 calories
-Allows the user to add the food group for each ingredient by choosing from a list of food groups displayed to them
-Allows the user to add the calories for each ingredient
-A unit test to test the calculate total calories method

Main Menu
When the program is launched the user is presented with the main menu ( displays until they choose to exit), where they can choose from the following options:
*Add A New Recipe*
Allows users to create a new recipe by entering a recipe name, adding ingredients and its details such as quanitity, unit of measurement, food group, and the calories for each ingredient.

*Display Recipes*
Displays a list of existing recipes for the user to choose from and view details for their chosen recipe in alphabetical order.
Program will display the chosen recipes details.
When the user views a recipe, if said recipe has a total calorie count that is over 300, the delegate ensures that an alert is displayed to the user in the display, stating that the recipe's total calories exceed 300.

*Scale Recipe*
Program will display a list of all the recipes in alphabetical order.
The user is prompted to choose a recipe from the list of  recipes to scale the chosen recipe by a factor.
Once the user chooses a recipe to scale they are presented with a menu option display, that prompts them to choose what factor they would like to scale their recipe by.
The user will input the menu option of the factor of their preference.
The program will display the scaled recipe.

*Reset Recipe*
Choose a recipe from the list of existing recipes to reset the chosen recipe to its orgininal values if it had been changed when scaling.
The program will display the original recipe.

*Clear Recipe*
Choose a recipe from the list of existing recipes to clear.
>Confirm to clear the recipe from the list
OR
>Cancel Clear Request

*Exit*
Displays a thank you message and exits the application.
