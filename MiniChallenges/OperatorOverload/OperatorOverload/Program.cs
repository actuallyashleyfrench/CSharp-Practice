// See https://aka.ms/new-console-template for more information
/*================================================================================================
 *                                                                                   Ashley French
 * 🔹 Challenge 1: Operator Overload
 * Ask for 3 numbers. Print the sum, product, average, and whether all 3 are equal.
 *
 * Input validation using int.TryParse
 *
 * Use methods like GetValidNumber() and AreAllEqual(int x, int y, int z)
 *
 * Add Remainder() if you want a stretch
 * 
 *================================================================================================= 
 */

namespace OperatorOverload
{
    class Program
    {
        // Operator methods for sum, product, average
        static int Sum(int x, int y, int z) => x + y + z;
        static int Product(int x, int y, int z) => x * y * z;
        static int Average(int x, int y, int z) => Sum(x, y, z) / 3;

        static int Remainder(int x, int y) => y != 0 ? x % y : 0; // Returns remainder of first two numbers 
        static bool AreAllEqual(int x, int y, int z) => x == y && y == z; // Checks if all numbers are equal


        /* 
         * Checks that a valid integer is entered
         * If not, prompts user to try again
         * 
         */
        static int GetValidNumber()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            return num;
        }

        /*
         * 
         * Asks if user wants to play again
         * Returns true of false 
         * If invalid input, prompts again
         * 
         */
        static bool AskToPlayAgain()
        {
            while(true)
            {
                Console.Write("Play again? Please enter Y/N ");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y") return true;
                if (input == "N") return false;

                Console.Write("Invalid input. Please enter 'Y' or 'N'. ");
            }
        }


        static void Main(string[] args)
        {
            bool goAgain = false; // Whether user wants to go again or not

            do
            {
                // Get numbers
                Console.Write("Please enter first number: ");
                int a = GetValidNumber();
                Console.Write("Please enter second number: ");
                int b = GetValidNumber();
                Console.Write("Please enter third number: ");
                int c = GetValidNumber();

                // Perform operations
                Console.WriteLine($"Sum: {Sum(a, b, c)}");
                Console.WriteLine($"Product: {Product(a, b, c)}");
                Console.WriteLine($"Average: {Average(a, b, c)}");
                Console.WriteLine($"Remainder of {a} / {b} = {Remainder(a, b)}");
                Console.WriteLine(AreAllEqual(a, b, c) ? "All numbers are equal." : "Numbers are not all equal.");


                goAgain = AskToPlayAgain(); // Asks user if they want to play again
            }
            while (goAgain);

        }
    }
}