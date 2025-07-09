// See https://aka.ms/new-console-template for more information
/*===========================================================================================
 *                                     Ashley French
 *                                   CookbookGenerator
 * 
 * This program allows users to create and manage recipes.
 * Users can enter recipe details including name, ingredients, and instructions.
 * Recipes are stored in a list and can be displayed on demand.
 * 
 * Features:
 * - Create Recipe objects with properties like Name, Ingredients, Instructions, and PrepTime.
 * - Add and remove ingredients for each recipe.
 * - Display recipe details with a formatted output.
 * - Allow users to input multiple recipes.
 * - Display all stored recipes.
 * 
 * Stretch Goals:
 * - Search recipes by name or ingredient.
 * - Save recipes to a file and load them back.
 * - Add editing functionality for existing recipes.
 * 
 * Instructions:
 * 1. Prompt user to enter recipe details.
 * 2. Validate user input as needed.
 * 3. Store recipes in a List<Recipe>.
 * 4. Provide options to view all recipes or search/filter recipes.
 * 5. Continue until user chooses to exit.
 * 
 *=========================================================================================== 
 */

using System.Text.Json;

namespace CookbookGenerator
{
    class Program
    {

        /// <summary>
        /// Adds a new recipe by collecting input from the user.
        /// Prompts user for name, ingredients, prep time, and instructions.
        /// Validates inputs and return fully populated Recipe object.
        /// </summary>
        /// <returns>A Recipe object populated with data entered by user.</returns>
        static Recipe AddARecipe()
        {
            // Gets recipe name, ensuring it's not empty
            Console.WriteLine("\n----ADD A RECIPE----\n");
            string name = GetNonEmptyInput("Recipe Name: ");

            // Gets list of ingredients, with option to add/remove
            List<string> ingredients = ManageIngredients();

            // Gets prep time in minutes & validates (int greater than 0)
            Console.Write("\nPrep time in minutes: ");
            int prepTime;
            while (!int.TryParse(Console.ReadLine(), out prepTime) || prepTime <= 0)
            {
                Console.Write("Invalid input. Please enter prep time in minutes: ");
            }

            // Gets instructions, ensuring it's not empty
            string instructions = GetNonEmptyInput("\nInstructions: ");

            // Create & return recipe object
            Recipe recipe = new Recipe
            {
                Name = name,
                Ingredients = ingredients,
                PrepTimeInMinutes = prepTime,
                Instructions = instructions
            };

            return recipe;
        }

        /// <summary>
        /// Gets a valid index for a recipe to be removed from user.
        /// </summary>
        /// <param name="recipes">The list of current <see cref="Recipe"/> objects.</param>
        /// <returns> A valid int index.</returns>
        static int ChooseRecipeToRemove(List<Recipe> recipes)
        {
            Console.WriteLine("\n----REMOVE A RECIPE----\n");
            int index;

            // Display all recipes with number assigned & prompts user for number to remove
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.Write("\nEnter number of recipe to remove: ");

            // Ensures input is valid & corresponds to a recipe
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > recipes.Count)
                Console.Write($"Invalid input. Please enter valid number: ");

            // Returns index of recipe to be removed
            return index - 1;
        }

        /// <summary>
        /// Displays list of recipes as long as count is not zero.
        /// </summary>
        /// <param name="recipes">The list of current <see cref="Recipe"/> objects.</param>
        static void DisplayRecipes(List<Recipe> recipes)
        {
            // Ensures list of recipes is not empty
            if (recipes.Count == 0)
            {
                Console.WriteLine("There are no recipes to display.");
                return;
            }
            
            // Displays all recipes in list
            Console.WriteLine("\nRecipes:\n");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine(recipe.ToString());
                Console.WriteLine("\n=====================================================");
            }
        }

        /// <summary>
        /// Gets a keyword from user, compares keyword to names and ingredients of recipes, displays matching recipes.
        /// </summary>
        /// <param name="recipes">The list of current <see cref="Recipe"/> objects.</param>
        static void SearchRecipes(List<Recipe> recipes)
        {
            // Get keyword from user to search by
            Console.WriteLine("\n----SEARCH RECIPES----\n");
            Console.Write("Enter keyword to search by name or ingredient: ");
            string keyword = Console.ReadLine().Trim().ToLower();

            // Select recipes that contain keyword in name or ingredients
            var results = recipes.Where(r => 
            r.Name.ToLower().Contains(keyword) || 
            r.Ingredients.Any(i => i.ToLower().Contains(keyword))
            ).ToList();

            // Display matching recipes if there are any
            if (results.Count == 0) 
                Console.WriteLine($"\nThere are no recipes that include the keyword '{keyword}'.");
            else DisplayRecipes(results);
            
        }

        /// <summary>
        /// Prompts the user to select a recipe and update one of its fields.
        /// </summary>
        /// <param name="recipes">The list of current <see cref="Recipe"/> objects.</param>
        static void EditARecipe(List<Recipe> recipes)
        {
            Console.WriteLine("\n----EDIT A RECIPE----\n");

            // Displays recipes with corresponding numbers
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.Write("\nWhich number recipe would you like to edit?: ");
            int editAtIndex;

            // Gets valid number associated with recipe
            while (!int.TryParse(Console.ReadLine(), out editAtIndex) || editAtIndex < 1 || editAtIndex > recipes.Count)
                Console.Write($"\nInvalid choice. Please enter valid number: ");

            editAtIndex -= 1;

            // Display edit options
            Console.WriteLine("\nWhat would you like to edit?\n");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Ingredients");
            Console.WriteLine("3. Prep Time");
            Console.WriteLine("4. Instructions");
            Console.WriteLine("5. Cancel");
            Console.Write("\nChoose an option: ");

            // Gets choice of edit options & validates
            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 5)
            {
                Console.Write("Invalid input. Please enter choice 1 - 5: ");
            }

            // Edit field corresponding to user choice
            switch (menuChoice)
            {
                case 1: // Edit name
                    string name = GetNonEmptyInput($"\nEnter new name for recipe '{recipes[editAtIndex].Name}': ");
                    recipes[editAtIndex].Name = name;
                    break;

                case 2: // Edit ingredients
                    Console.WriteLine("\nCurrent ingredients:");
                    foreach (var item in recipes[editAtIndex].Ingredients)
                        Console.WriteLine($"- {item}");
                    Console.WriteLine("\nEnter new list of ingredients:");
                    recipes[editAtIndex].Ingredients.Clear();
                    recipes[editAtIndex].Ingredients = ManageIngredients();
                    break;

                case 3: // Edit prep time
                    Console.Write("Please enter new prep time in minutes: ");
                    int prepTime;
                    while (!int.TryParse(Console.ReadLine(), out prepTime) || prepTime <= 0)
                    {
                        Console.Write("Invalid input. Please enter prep time in minutes: ");
                    }
                    recipes[editAtIndex].PrepTimeInMinutes = prepTime;
                    break;

                case 4: // Edit instructions
                    string instructions = GetNonEmptyInput("\nPlease enter new instructions: ");
                    recipes[editAtIndex].Instructions = instructions;
                    break;

                case 5: // Return to main
                    return;
            }

            // Display updated recipe
            Console.WriteLine("\nRecipe updated:");
            Console.WriteLine("=====================================================");
            Console.WriteLine(recipes[editAtIndex].ToString());
            Console.WriteLine("\n=====================================================");

        }

        /// <summary>
        /// Asks user if they would like to add another recipe and determines answer.
        /// </summary>
        /// <param name="recipes">The list of current recipes.</param>
        /// <returns> True or false depending on user answer.</returns>
        static bool AskToAddAnother()
        {
            Console.Write("\n\nAdd another recipe? Y/N: ");

            while (true)
            {
                string answer = Console.ReadLine().Trim().ToUpper();
           
                if (answer == "Y") return true;
                else if (answer == "N") return false;
                else Console.Write("Invalid input. Please enter 'Y' or 'N': ");
            }
        }

        /// <summary>
        /// Promtps user for string input & ensures input is not empty.
        /// </summary>
        /// <param name="prompt">String prompt for user input.</param>
        /// <returns>Valid non-empty string.</returns>
        static string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{prompt}");
                input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                      Console.WriteLine("Invalid input. Please try again.");
                
            }while(string.IsNullOrEmpty(input));
            return input;
        }

        /// <summary>
        /// Prompts user to add ingredients, remove ingredients, or enter done to finish.
        /// </summary>
        /// <returns>List of ingredients.</returns>
        static List<string> ManageIngredients()
        {
            // Create new list of ingredients & prompt user for input
            List<string> ingredients = new List<string>();
            string input;

            Console.WriteLine("\nEnter ingredients one at a time.\nType 'done' to finish or 'remove' to delete an ingredient.\n");

            while(true)
            {
                Console.Write("- ");
                input = Console.ReadLine().Trim();

                // Exit loop if user is done, restart loop if there are no ingredients added
                if (input.ToLower() == "done")
                {
                    if (ingredients.Count == 0)
                    {
                        Console.WriteLine("You must add at least one ingredient before finishing.");
                        continue;
                    }
                    break;
                } 
                

                else if (input.ToLower() == "remove")
                {
                    // No ingredients to remove
                    if (ingredients.Count == 0)
                    {
                        Console.WriteLine("\nThere are no ingredients to remove.");
                        Console.WriteLine("\nEnter ingredients one at a time.\nType 'done' to finish or 'remove' to delete an ingredient.\n");
                        continue;
                    }

                    Console.WriteLine("\n----REMOVE INGREDIENT----\n");

                    // Display ingredients with associated number
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ingredients[i]}");
                    }

                    // Prompt user for number ingredient to remove & validates
                    Console.Write("\nEnter number of ingredient to remove: ");
                    int numToRemove;
                    while(!int.TryParse(Console.ReadLine(), out numToRemove) || numToRemove < 1 || numToRemove > ingredients.Count)
                        Console.Write("Invalid input. Please enter valid number: ");
                    
                    // Remove chosen ingredient & prompts user to continue adding ingredients
                    Console.WriteLine($"\nRemoved {ingredients[numToRemove - 1]}");
                    ingredients.RemoveAt(numToRemove - 1);
                    Console.WriteLine("\nContinue entering ingredients.\n");
                    
                    
                }
                // Adds valid ingredient
                else if (!string.IsNullOrEmpty(input))
                {
                    ingredients.Add(input);
                }
                else
                {
                    Console.WriteLine("Input cannot be empty.");
                }

            }
            return ingredients;

        }

        /// <summary>
        /// Displays main menu to user and gets a valid choice.
        /// </summary>
        /// /// <returns>Valid choice of menu item.</returns>
        static int GetMenuChoice()
        {
            int choice;

            // Displays main menu
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("\n1. Add a recipe");
            Console.WriteLine("2. Remove a recipe");
            Console.WriteLine("3. View all recipes");
            Console.WriteLine("4. Search recipes");
            Console.WriteLine("5. Edit a recipe");
            Console.WriteLine("6. Exit\n");
            Console.Write("Choose an option: ");

            // Gets menu item choice & validates
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                Console.Write("Invalid choice. Enter number 1 - 6: ");

            return choice;

        }

        /// <summary>
        /// Saves the list of recipes to a JSON file at the specified file path.
        /// </summary>
        /// <param name="recipes">The list of recipes to save.</param>
        /// <param name="filePath">The path to the JSON file where the recipes will be saved.</param>
        static void SaveRecipesToFile(List<Recipe> recipes, string filePath)
        {
            var json = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"\nSaved {recipes.Count} recipe(s) to '{filePath}'.");
        }

        /// <summary>
        /// Loads a list of recipes from a JSON file at the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the JSON file to read from.</param>
        /// <returns>A list of <see cref="Recipe"/> objects loaded from the file. 
        /// Returns an empty list if the file doesn't exist or is invalid.</returns>
        static List<Recipe> LoadRecipesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No saved recipes found.");
                return new List<Recipe>();
            }

            try
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Recipe>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading recipes from file: {ex.Message}");
                return new List<Recipe>();
            }
            
        }


        /// <summary>
        /// Entry point for the CookBookGenerator program.
        /// Initializes the recipe list by loading from file (if available),
        /// then displays the main menu in a loop until the user chooses to exit.
        /// Handles user choices for adding, removing, viewing, searching,
        /// and editing recipes. Saves all changes to a JSON file on exit.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            const string filePath = "recipes.json";

            // Load recipes into list or create new list
            List<Recipe> recipes = LoadRecipesFromFile(filePath);

            Console.WriteLine("Welcome to the Cookbook Generator");

            while (true)
            {
                int choice = GetMenuChoice();

                switch (choice)
                {
                    case 1: // Add a recipe
                        do
                        {
                            Recipe newRecipe = AddARecipe();
                            recipes.Add(newRecipe);
                            Console.WriteLine($"\nRecipe '{newRecipe.Name}' added!");
                        } while (AskToAddAnother());
                        break;

                    case 2: // Remove a recipe
                        if (recipes.Count > 0)
                        {
                            int indexToRemove = ChooseRecipeToRemove(recipes);
                            Console.WriteLine($"\nRecipe '{recipes[indexToRemove].Name}' removed.");
                            recipes.RemoveAt(indexToRemove);
                        }
                        else Console.WriteLine("There are no recipes to remove.");
                        break;

                    case 3: // Display all recipes
                        DisplayRecipes(recipes);
                        break;

                    case 4: // Search recipes
                        if (recipes.Count > 0)
                        {
                            SearchRecipes(recipes);
                        }
                        else Console.WriteLine("There are no recipes to search.");
                        break;

                    case 5: // Edit a recipe
                        if (recipes.Count > 0)
                        {
                            EditARecipe(recipes);
                        }
                        else Console.WriteLine("\nThere are no recipes to edit.");
                        break;

                    case 6: // Exit
                        SaveRecipesToFile(recipes, filePath);
                        Console.WriteLine("Goodbye!");
                        return;
                }
            }
            Console.WriteLine();


            }
    }
}
