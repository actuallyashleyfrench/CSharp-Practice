// See https://aka.ms/new-console-template for more information
/*=======================================================================================
 *                                                                          Ashley French
 * 🔹 Challenge 7: Delegates Lite
 * 
 * 📌 Objective:
 * Create a delegate that performs math operations. Prompt the user to choose 
 * which operation to apply: Subtract, Modulus, or Power.
 * 
 * ✅ Requirements:
 * - Define a delegate that takes two integers and returns an integer.
 * - Use user input to determine which operation to execute.
 * - Implement and assign appropriate methods to the delegate.
 * - Execute the delegate based on the user's selection.
 * 
 * 🔄 Stretch Goal:
 * - Use the ternary operator (? :) to simplify decision logic.
 * - Add this as an additional feature or layer to your previous delegate challenge.
 * 
 * 💡 Example Operations:
 * - Subtract: a - b
 * - Modulus: a % b
 * - Power: Math.Pow(a, b) → cast to int
 * 
 *=======================================================================================*/

namespace DelegatesPractice
{
    class Program
    {
        delegate int MathOperation(int x, int y);
        static int Subtract(int x, int y) => x - y;
        static int Modulus(int x, int y) => y != 0 ? x % y : x;
        static int Power(int x, int y) => (int)Math.Pow(x, y);

        static int GetValidNumber()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Invalid input. Please enter valid number: ");
            }
            return num;
        }

        static MathOperation GetOperation()
        {
            MathOperation op;
            Console.Write("Would you like to subtract, get modulus, or get power? Enter sub/mod/pow: ");
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                op = answer == "sub" ? Subtract
                    : answer == "mod" ? Modulus
                    : answer == "pow" ? Power
                    : null;

                if (op != null) break;
                Console.Write("Invalid input. Please enter 'sub' 'mod' or 'pow': ");
            }
            return op;

        }

        static bool AskToPerformAnotherOperation()
        {
            Console.Write("Would you like to perform another operation? Enter Y/N: ");
            
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "y") return true;
                else if (answer == "n") return false;
                else Console.Write("Invalid input. Please enter 'Y' or 'N': ");
            }
            
        }
        
        static void Main(string[] args)
        {
            MathOperation mathOp = null;
            int[] numbers = new int[2];

            for(int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = GetValidNumber();

            }

            do
            {
                mathOp = GetOperation();

                Console.WriteLine(mathOp(numbers[0], numbers[1]));
            } while(AskToPerformAnotherOperation());
            
        }
    }
}