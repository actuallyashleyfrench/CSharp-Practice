// See https://aka.ms/new-console-template for more information
/*====================================================================================================
 *                                                                                      Ashley French
 * 🔹 Challenge 4: Loop + Condition
 * 📌 Ask for a number. Print all even numbers from 1 to that number.
 * Use for loop and if (i % 2 == 0)
 * 
 * 
 * Add total count of evens at the end
 * 
 * 
 * Stretch:
 * Do it with a while loop instead
 * 
 *=====================================================================================================
 */

namespace LoopsPractice
{
    class Program
    {

        /*
         * Gets a valid integer from user
         * Returns number entered
         */
        static int GetValidNumber()
        {
            int num;

            Console.Write("Please enter number: ");
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Invalid input. Please try again: ");
            }
            return num;
        }

        /*
         * Uses a for loop to print each even number between 1 and input
         * Counts and prints the number of even numbers within range
         * 
         */
        static void GetEvenNumbersWithForLoop(int numInput)
        {
            int count = 0;

            for (int i = 1; i <= numInput; i++)
            {
                if (i % 2 == 0) // If number is even
                {
                    Console.WriteLine(i); // Prints even number
                    count++; // Increments count
                }
            }
            
            Console.WriteLine($"There are {count} even numbers between 1 and {numInput}"); // Prints count of even numbers

        }

        /*
         * Uses a while loop to print each even number between 1 and input
         * Counts and prints the number of even numbers within range
         * 
         */
        static void GetEvenNumbersWithWhileLoop(int numInput)
        {
            int count = 0;
            int i = 1;
            while (i <= numInput)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    count++;
                }
                i++;
            }

            Console.WriteLine($"There are {count} even numbers between 1 and {numInput}");
        }

        /*
         * Gets a number from user
         * Prints and counts all even numbers between 1 and number entered
         * Repeats until user doesn't want to play again
         * 
         */
        static void Main(string[] args)
        {
            bool goAgain;

            do
            {
                int number = GetValidNumber(); // Gets number from user
                GetEvenNumbersWithWhileLoop(number); // Gets even numbers
                goAgain = AskToPlayAgain(); // Finds out if user wants to play again

            } while (goAgain);
        }

        /*
         * Asks user if they want to play again
         * Checks for valid input 'y' or 'n'
         * Returns true if yes, false if no
         * 
         */
        static bool AskToPlayAgain()
        {
            Console.Write("Would you like to play again? Enter Y/N: ");

            while(true) // Continues until bool returned
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "y") return true;
                else if (answer == "n") return false;
                else Console.Write("Invalid input. Please enter 'Y' or 'N': ");
            }
        }
    }
}