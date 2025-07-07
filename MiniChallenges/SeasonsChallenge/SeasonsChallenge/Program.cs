// See https://aka.ms/new-console-template for more information
/*============================================================================================
 *                                                                               Ashley French
 * 🔹 Challenge 3: Switch Statement Upgrade
 * 📌 Ask the user for a month (e.g., "April") and print the season.
 * e.g., “Spring”, “Summer”
 *
 *
 * Normalize input with .ToLower() or .ToUpperInvariant()
 *
 *
 * Stretch:
 * Use HashSet<string> or Dictionary<string, string> instead of switch
 * 
 * 
 *============================================================================================
 */

namespace SeasonsChallenge
{


    class Program
    {
        /*
         * Uses switch case to match months to seasons
         * Gets month from user and prints season accordingly
         * Prompts until valid month is given
         */
        static void GetSeason()
        {
            bool validMonth = false;

            while (!validMonth)
            {
                string month = Console.ReadLine().Trim().ToLower();
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        Console.WriteLine("Spring");
                        validMonth = true;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        Console.WriteLine("Summer");
                        validMonth = true;
                        break;
                    case "september":
                    case "october":
                    case "november":
                        Console.WriteLine("Fall");
                        validMonth = true;
                        break;
                    case "december":
                    case "january":
                    case "february":
                        Console.WriteLine("Winter");
                        validMonth = true;
                        break;
                    default:
                        Console.Write("Invalid input. Please enter a valid month. ");
                        break;

                }
            }
        }

        /*
         * Creates dictionary to match all months to seasons
         * Gets month from user and prints season accordingly
         * Prompts until valid month entered         
         */
        static void GetSeasonWithDictionary()
        {
            var monthToSeason = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["march"] = "Spring",
                ["april"] = "Spring",
                ["may"] = "Spring",
                ["june"] = "Summer",
                ["july"] = "Summer",
                ["august"] = "Summer",
                ["september"] = "Fall",
                ["october"] = "Fall",
                ["november"] = "Fall",
                ["december"] = "Winter",
                ["january"] = "Winter",
                ["february"] = "Winter",
            };

            while(true)
            {
                string input = Console.ReadLine().Trim();
                if (monthToSeason.TryGetValue(input, out string season))
                {
                    Console.WriteLine(season);
                    break;
                }
                else Console.Write("Invalid input. Please enter a valid month: ");
            }
        }

        static void GetSeasonWithHashSet()
        {
            var spring = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "march", "april", "may"};
            var summer = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "june", "july", "august" };
            var fall = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "september", "october", "november" };
            var winter = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "december", "january", "february" };

            while (true)
            {
                string input = Console.ReadLine().Trim();

                if (spring.Contains(input))
                {
                    Console.WriteLine("Spring");
                    break;
                }
                else if (summer.Contains(input))
                {
                    Console.WriteLine("Summer");
                    break;
                }
                else if (fall.Contains(input))
                {
                    Console.WriteLine("Fall");
                    break;
                }
                else if (winter.Contains(input))
                {
                    Console.WriteLine("Winter");
                    break;
                }
                else
                {
                    Console.Write("Invalid input. Please enter valid month: ");
                }
            }

        }


        /*
         * Asks user if they want to play again 
         * Returns true or false
         * Prompts until valid 'y' or 'n' is given
         * 
         */
        static bool AskToPlayAgain()
        {
            while(true)
            {
                Console.Write("Would you like to play again? Enter Y/N ");
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "y") return true;
                else if (answer == "n") return false;
                else Console.WriteLine("Invalid input. Please enter 'Y' or 'N' ");
            }
        }


        /*
         *  Prompts user for month, prints the season
         *  Repeats until user does not want to play again
         */
        static void Main(string[] args)
        {
            bool goAgain; // Whether user wants to play again

            do
            {
                Console.Write("Please enter a month: ");
                //GetSeason();                // Uses switch case to print season
                //GetSeasonWithDictionary();  // Uses dictionary to print season
                GetSeasonWithHashSet();       // Uses HashSet to print season
                goAgain = AskToPlayAgain();   // Asks user if they want to play again
            } while (goAgain);


        }
    }
}
