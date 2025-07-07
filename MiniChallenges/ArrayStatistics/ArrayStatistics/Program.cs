// See https://aka.ms/new-console-template for more information
/*=======================================================================================
 *                                                                          Ashley French
 * 🔹 Challenge 6: Array Statistics
 * 📌 Ask for 5 numbers and:
 * Print min, max, average, sum, and all odd numbers
 * 
 * Use foreach and maybe Array.Sort
 * 
 * Stretch:
 * Let the user decide how many numbers (dynamic array or List<int>)
 * 
 * **** SPECIFICALLY AVOIDING LINQ ****
 * 
 *======================================================================================= 
 */

using System.Collections.Immutable;
using System.Text;

namespace ArrayStats
{



    class Program
    {
        /* 
         * Reads user input & tries to convert to int
         * If it can't convert, prompts for valid input
         * Returns valid int
         * 
         */
        static int GetValidNumber()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return num;
        }

        /*
         * Manually calculates the sum of the values in array that is passed
         * Returns the sum         
         */
        static int GetSum(int[] nums)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
           
            return sum;
        }

        /* 
         * Creates & returns a string that holds all of the odd numbers in the array
         * 
         */
        static string GetOddNumbers(int[] nums)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Odd Numbers:");
            foreach (int num in nums)
            {
                if (num % 2 != 0)
                    sb.AppendLine(num.ToString());
            }
            return sb.ToString();
        }


        static void Main(string[] args)
        {
            // Prompts user for length of array
            Console.Write("How many numbers would you like to enter? ");
            int arrayLength = GetValidNumber();
            int[] numbers = new int[arrayLength]; // Create array with length given

            // Gets numbers from user and stores in array
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = GetValidNumber();
                
            }

            // Sort array & print min & max values
            Array.Sort(numbers);
            Console.WriteLine($"Min value: {numbers[0]}");
            Console.WriteLine($"Max value: {numbers[numbers.Length - 1]}");

            // Prints sum and average of values in array
            int sum = GetSum(numbers);
            Console.WriteLine($"Average: {sum / numbers.Length}");
            Console.WriteLine($"Sum: {sum}");

            // Prints all of the odd values in array
            string oddNums = GetOddNumbers(numbers);
            Console.WriteLine(oddNums);


        }
    }
}
