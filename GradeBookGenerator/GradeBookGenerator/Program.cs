// See https://aka.ms/new-console-template for more information
/*===========================================================================================
 *                                                                              Ashley French
 *  GradeBook Summary Generator
 * Ask the user how many students are in the class.
 * Then ask for each student’s name and grade (0–100).
 * At the end, print:
 * 
 * Highest and lowest score
 * 
 * Class average
 * 
 * Count of A/B/C/D/F students
 * 
 * Stretch: Save it to a file or allow filtering (“Show all students who got an A”).
 * 
 *=========================================================================================== 
 */

using System.Dynamic;

namespace GradeBook
{
    


    class Program
    {

 

        /*
         * Gets the highest or lowest grade depending on parameter
         * Gets students with corresponding grade
         * Prints those students names and grades in alphabetical order
         * 
         */
        static void PrintGradeSummary(Student[] students, bool highest = true)
        {
            // Highest or lowest grade depending on bool passed
            double targetGrade = highest ? students.Max(s => s.Grade) : students.Min(s => s.Grade);

            // Students with corresponding grade in alphabetical order
            var selectedStudents = students.Where(s => s.Grade == targetGrade).OrderBy(s => s.Name);

            /* LINQ Query Syntax
             * 
             * var selectedStudents = from student in students
             *                        where student.Grade == targetGrade
             *                        orderby student.Name
             *                        select student;
             */

            // Display those students' names & grades
            Console.WriteLine($"\n{(highest ? "Highest" : "Lowest")} Grade: {targetGrade:F2}");

            foreach (var student in selectedStudents)
            {
                Console.WriteLine($"{(highest ? "Top" : "Lowest")} Student: {student.ToString()}");
            }
        }

        static string GetValidName()
        {
            string inputName;
            do
            {
                inputName = Console.ReadLine().Trim();
                if (!Student.IsValidName(inputName)) 
                    Console.Write("Invalid input. Please enter valid name: ");
            } while (!Student.IsValidName(inputName));
            return inputName;
        }


        static double GetValidGrade()
        {
            double inputGrade;
            bool isValid;
            do
            {
                isValid = double.TryParse(Console.ReadLine(), out inputGrade) && Student.IsValidGrade(inputGrade);
                if (!isValid)
                    Console.Write("Invalid input. Please enter grade 0-100: ");
            } while(!isValid);
            return inputGrade;
        }

        /*
         * Groups students by letter grade
         * Creates dictionary with letter grade as key and count as value
         * Displays each letter grade & count of students with that grade
         */
        static void DisplayGradeCounts(Student[] students)
        {
            var gradeGroups = students
                .GroupBy(s => s.LetterGrade)
                .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine("\nGrade Distribution:");

            foreach (var grade in new[] { "A", "B", "C", "D", "F" })        
            {
                Console.WriteLine($"{grade}'s: {gradeGroups.GetValueOrDefault(grade, 0)}");
            }
        }

       
        /*
         * Prompts user if they would like to filter by letter grade
         * Keeps prompting until valid 'y' or 'n' entered
         * Returns true if y, false if n
         */
        static bool AskToFilterGrade()
        {
            Console.Write("\nWould you like to filter by grade? Y/N: ");

            string answer;

            do
            {
                answer = Console.ReadLine().Trim().ToUpper();
                if (answer != "Y" && answer != "N")
                {
                    Console.Write("Invalid input. Please enter 'Y' or 'N': ");
                }
            }while (answer != "Y" && answer != "N");

            return answer == "Y";
        }


        /*
         * Prompts user for letter grade to filter by
         * Matches input to a valid letter grade
         * Returns that letter grade 
         */
        static string GetTargetGrade()
        {
            string[] validLetterGrades = [ "A", "B", "C", "D", "F" ];
            string grade;


            do
            {
                Console.Write("\nEnter grade to filter by: A/B/C/D/F ");
                grade = Console.ReadLine().Trim().ToUpper();

            } while (!validLetterGrades.Contains(grade));

            return grade;
        }


        /*
         * Takes in students and target letter grade
         * Gets students with that letter grade in descending grade order
         * Displays students' name & grade if there are any with target letter grade
         */
        static void DisplayStudentsByGrade(Student[] students, string grade)
        {
            // Group of students with target letter grade in descending order by number grade
            var filtered = students.Where(s => s.LetterGrade == grade).OrderByDescending(s => s.Grade);

            if (filtered.Any()) // If group isn't empty
            {
                // Display each student name & grade
                Console.WriteLine($"\nStudents with grade {grade}");
                foreach (Student student in filtered)
                {
                    Console.WriteLine($"{student.ToString()}");
                }
            }
            else Console.WriteLine($"No students received a grade of {grade}."); // If group is empty
            
        }

        static void Main(string[] args)
        {
            int numOfStudents;

            // Prompt user for valid number of students (whole number greater than 0)
            Console.Write("How many students are in the class?: ");
            while (!int.TryParse(Console.ReadLine(), out numOfStudents) || numOfStudents <= 0)
            {
                Console.Write("Invalid input. Please enter valid number: ");
            }

            // Create array of Students
            Student[] students = new Student[numOfStudents];

            // Get name and grade for each student 
            for (int i = 0; i < numOfStudents; i++)
            {
                students[i] = new Student();
                Console.Write("Enter student's name: ");
                students[i].Name = GetValidName();

                Console.Write("Enter student's grade: ");
                students[i].Grade = GetValidGrade();
            }

            // Display highest grade and students with that grade
            PrintGradeSummary(students, highest: true);

            // Display lowest grade and students with that grade
            PrintGradeSummary(students, highest: false);

            // Calculate & display average grade
            double average = students.Average(student => student.Grade);
            Console.WriteLine($"\nClass Average: {average:F2}");

            // Displays letter grades with count of students with each grade
            DisplayGradeCounts(students);

            // Prompts user if they want to filter by letter grade
            // Gets preferred letter grade and displays students with that grade
            if(AskToFilterGrade())
            {
                string grade = GetTargetGrade();
                DisplayStudentsByGrade(students, grade);

            }
        }

    }
}