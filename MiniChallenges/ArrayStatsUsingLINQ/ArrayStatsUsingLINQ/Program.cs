// See https://aka.ms/new-console-template for more information
/*===================================================================================
 *                                                                      Ashley French
 * 🔹 Challenge 6 (LINQ Version): Array Statistics
 * 📌 Ask for any number of inputs and store them in an array or List<int>.
 * 
 * ✅ Use LINQ to:
 * Get the minimum and maximum values
 * Calculate the sum and average
 * Filter and print all odd numbers
 * 
 * ✅ Stretch Goals:
 * Let the user choose whether to sort the numbers ascending or descending
 * Group numbers by even/odd and print each group
 * 
 * 
 *===================================================================================
 */

namespace ArrayStatsWithLINQ
{
    class Program
    {
        /*
         * Tries to convert input to int
         * If it can't, prompts for valid input
         * Returns valid int
         */
        static int GetValidNumber()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Invalid input. Please enter valid number: ");
            }
            return num;
        }

        /*
         * Asks if user wants to sort array ascending or descending
         * Returns array with corresponding order
         * Keeps prompting until valid input entered 
         */
        static int[] GetSorted(int[] nums)
        {
            Console.Write("Sort ascending or descending? A/D: ");

            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "a") return nums.OrderBy(x => x).ToArray();
                else if (answer == "d") return nums.OrderByDescending(x => x).ToArray();
                else Console.Write("Invalid input. Please enter 'A' or 'D': ");
            }
        }

        /*
         * Asks user how many numbers to enter
         * Gets those numbers and puts in array
         * Prints min, max, sum, average, odds
         * Prints sorted array
         */
        static void Main(string[] args)
        {
            // Get length from user
            Console.Write("How many numbers would you like to enter? ");
            int length = GetValidNumber();

            // Creates and fills array with user input
            int[] numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = GetValidNumber();
            }

            // Print min and max values
            Console.WriteLine($"Minimum: {numbers.Min()}");
            Console.WriteLine($"Maximum: {numbers.Max()}");

            // Print sum and average
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");

            // Filters odds and prints them out
            var odds = numbers.Where(n => n % 2 != 0);
            Console.WriteLine("Odd Numbers:");
            foreach (var num in odds)
            {
                Console.WriteLine(num);
            }

            // Creates sorted array based on user input and prints sorted values
            int[] sortedNumbers = GetSorted(numbers);
            Console.WriteLine("Sorted full list:");
            foreach(var num in sortedNumbers)
            {
                Console.WriteLine(num);
            }

        }
    }
}
