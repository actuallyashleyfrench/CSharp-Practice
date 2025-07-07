// See https://aka.ms/new-console-template for more information
/*===================================================================================================
 * 🔹 Challenge 2: Nested Conditionals                                                  Ashley French
📌 Ask for a person’s age and whether they’re a student. Print:

“Child” (<13)

“Teen” (13–17)

“Adult” (18+)

If they are a student and under 18, add: “Eligible for student discount.”

Stretch:

Ask for another boolean (e.g., isMember) and stack more logic


 *====================================================================================================== 
 */

using System.Data;
using System.Runtime.CompilerServices;

namespace NestedConditionals
{
    class Program
    {

        /*
         * Reads input for age & makes sure it's valid int
         * If invalid, prompts user for valid age
         * Returns age
         * 
         */
        static int GetAge()
        {
            int age;
            while(!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input. Please enter valid age. ");
            }
            return age;
        }


        /*
         * Reads input to determine Y or N answer
         * Prompts for valid input if invalid
         * Returns true or false
         */
        static bool GetStatus()
        {
            while(true)
            {
                string answer = Console.ReadLine().Trim().ToUpper();
                if (answer == "Y") return true;
                else if (answer == "N") return false;
                else Console.Write("Invalid input. Please enter 'Y' or 'N'. ");
            }
        }

      


        static void Main(string[] args)
        {

            // Gets age
            Console.Write("Please enter your age: ");
            int age = GetAge();


            // If they are 18 or over, prints adult
            if (age >= 18)
            {
                Console.WriteLine("You are an adult.");

                // Get member status
                Console.Write("Are you a member of our Savings Reward Program? Enter Y/N: ");
                bool isMember = GetStatus();
                if (isMember) Console.WriteLine("Yay! You save 10% today."); // If member, print savings
            }

            else // Under 18
            {
                // Gets student status
                Console.Write("Are you a student? Enter Y/N ");

                // If student, prints eligible for student discount
                if (GetStatus()) Console.WriteLine("Eligible for student discount.");

                // Under 13, prints user is child
                if (age < 13) Console.WriteLine("You are a child.");

                // If over 13, prints user is teen
                else Console.WriteLine("You are a teen");
            }
        }
    }
}
