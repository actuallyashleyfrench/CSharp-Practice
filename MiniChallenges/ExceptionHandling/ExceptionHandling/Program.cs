// See https://aka.ms/new-console-template for more information
/*=====================================================================================
 *                                                                        Ashley French
 * 🔹 Challenge 8: Exception Handling
 * 📌 Ask for two numbers. Divide them. Catch:
 * 
 * FormatException (non-number)
 * 
 * DivideByZeroException
 * 
 * General Exception
 * 
 * Stretch:
 * Log errors to a file with File.AppendAllText()
 * 
 * =====================================================================================
 */

namespace ExceptionHandling
{
    class Program
    {

        /*
         * Writes date, time, error type, and error message to log.txt
         * 
         */
        static void LogError(string errorType, string message)
        {
            string log = $"[{DateTime.Now}] {errorType}: {message}\n";
            File.AppendAllText("log.txt", log);
        }


        /*
         * Attempts to get two numbers from user for division
         * Catches any exceptions, prints them and logs them to file log.txt
         */ 
        static void Main(string[] args)
        {
            
            try
            {
                // Get first number
                Console.Write("Enter number 1: ");
                int num1 = int.Parse(Console.ReadLine());

                // Get second number
                Console.Write("Enter number 2: ");
                int num2 = int.Parse(Console.ReadLine());

                // Divide them
                int result = num1 / num2;
                Console.WriteLine($"{num1} / {num2} = {result}");
            }
            
            catch (FormatException ex) // User entered invalid input
            {
                Console.WriteLine("Invalid input.");
                LogError("FormatException", ex.Message);
                
            }
            catch (DivideByZeroException ex) // User entered 0 for second number
            {
                Console.WriteLine("Can't divide by zero.");
                LogError("DivideByZeroException", ex.Message);

            }
            catch (Exception ex) // General exception
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
                LogError("Exception", ex.Message);

            }
            finally // Code executes every time
            {
                Console.WriteLine("This block always runs.");

            }

        }
    }
}