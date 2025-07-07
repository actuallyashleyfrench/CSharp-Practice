using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    /*
     * Represents a studen with a name, numeric grade, and letter grade equivalent
     * 
     */
    public class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }

        // Returns letter grade (A-F) based on student's numeric grade
        public string LetterGrade =>
            Grade >= 90 ? "A" :
            Grade >= 80 ? "B" :
            Grade >= 70 ? "C" :
            Grade >= 60 ? "D" : "F";

        /*
         * Ensures name is not empty and only contains letters and spaces
         * Returns true if name meets criteria
         */
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(c => char.IsLetter(c) || c == ' ');
        }

        /*
         * Ensures grade is between 0 and 100
         * Returns true if grade meets criteria
         */
        public static bool IsValidGrade(double grade)
        {
            return grade >= 0 && grade <= 100;
        }

        /*
         * Defines how student is displayed
         */
        public override string ToString()
        {
            return $"{Name}: {Grade:F2} ({LetterGrade})";
            
        }
    }


}
