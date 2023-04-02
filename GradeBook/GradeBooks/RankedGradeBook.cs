using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            uint countOfBetterStudents = 0;
            foreach (Student student in Students)
                if (student.AverageGrade > averageGrade) countOfBetterStudents++;

            double countOfStudentsPerGrade = Students.Count / LetterGrades.Length;
            double countOfGradesToDrop = countOfBetterStudents / countOfStudentsPerGrade;
            uint gradeIndex = 0 + (uint)Math.Round(countOfGradesToDrop);

            return LetterGrades[gradeIndex];
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
