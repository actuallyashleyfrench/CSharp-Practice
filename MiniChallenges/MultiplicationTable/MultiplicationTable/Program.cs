// See https://aka.ms/new-console-template for more information
/*==================================================================================
 *                                                                     Ashley French
 * 🔹 Challenge 5: User-Defined Multiplication Table
 * 📌 Ask how many numbers they want, and print a multiplication table for each.
 * 
 * Ask how many numbers (n)
 *
 * Ask for n numbers (use a List<int>)
 *
 * For each number, print x1–x10
 *
 * Stretch:
 * Ask if they want to save the table to a text file
 *
 *==================================================================================
 */

using System.Text;

namespace MultiplicationTable
{
    class Program
    {
        /*
         * Gets valid int number from user
         * 
         */
        static int GetValidNumber()
        {
            int num;
            while(!int.TryParse(Console.ReadLine(), out num)) // If input can be converted to int, assigned to num
            {
                Console.Write("Invalid input. Please enter valid number: "); // Prompted until valid input given
            }
            return num;
        }

        /*
         * Create list of numbers entered by a user
         * Length of list is passed in
         * Returns list of numbers entered
         */
        static List<int> CreateList(int num)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= num; i++)
            {
                Console.Write($"Please enter number {i}: ");
                numbers.Add(GetValidNumber());
            }
            return numbers;
        }

        /*
         * For each number in the list
         * Creates mult table 1x - 10x and adds to string
         * Returns string 
         */
        static string CreateMultTable(List<int> nums)
        {
            StringBuilder str = new StringBuilder();

            foreach (int num in nums)
            {
                str.AppendLine($"Multiplication table for {num}");

                for (int i = 1; i <= 10; i++)
                {
                    str.AppendLine($"{num} x {i} = {num * i}");
                }
            }

            return str.ToString();
        }

        /*
         * Returns true or false depending on 'y' or 'n' answer
         * If invalid answer, prompts user for valid 'y' or 'n'
         * 
         */
        static bool AskToSaveToFile()
        {
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "y")
                    return true;
                else if (answer == "n")
                    return false;
                else Console.Write("Invalid input. Enter 'Y' or 'N' ");
            }
        }

      

        /*
         * Prompts user for number of inputs
         * Creates list to hold numbers entered
         * Creates string with mult table for each number in list 
         * Prompts user if they want to save to file
         * If yes, appends string to table.txt
         * 
         */
        static void Main(string[] args)
        {
            // Get length of list
            Console.Write("How many numbers would you like to enter?: ");
            int num = GetValidNumber();

            // Create list
            List<int> numbers = CreateList(num);

            // Create string with all multiplication tables
            string tableText = CreateMultTable(numbers);

            Console.WriteLine(tableText); // Prints string

            // Asks user if they want to save to file
            Console.Write("Would you like to save to file? Enter Y/N: ");
            bool saveYesorNo = AskToSaveToFile();

            // If answer is yes, adds string to file
            if (saveYesorNo) File.AppendAllText("table.txt", tableText);
        }
    }
}
