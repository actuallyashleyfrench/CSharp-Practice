using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CookbookGenerator
{
    /// <summary>
    /// Represents a single recipe with a name, list of ingredients, preparation time, and instructions.
    /// </summary>
    internal class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public int PrepTimeInMinutes { get; set; }
        public string Instructions { get; set; }

        /// <summary>
        /// Returns a formatted string with all recipe details for display purposes.
        /// </summary>
        /// <returns>A string containing the name, ingredients, prep time, and instructions.</returns>
        public override string ToString()
        {
            string formattedIngredients = "- " + string.Join("\n- ", Ingredients);

            int hours = PrepTimeInMinutes / 60;
            int minutes = PrepTimeInMinutes % 60;

            string timeDisplay = hours > 0 ? $"{hours} hr {minutes} min" : $"{minutes} min";

            return $"\n{Name}\n" +
                $"\nIngredients:\n{formattedIngredients}\n" +
                $"\nPrep Time: {timeDisplay}\n" +
                $"\nInstructions:\n{Instructions}";

        }


    }
}
