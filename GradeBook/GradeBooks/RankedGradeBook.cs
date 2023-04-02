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
            if (Students.Count < LetterGrades.Length) throw new InvalidOperationException();

            uint countOfBetterStudents = 0;
            foreach (Student student in Students)
                if (student.AverageGrade > averageGrade) countOfBetterStudents++;

            double countOfStudentsPerGrade = Students.Count / LetterGrades.Length;
            double countOfGradesToDrop = countOfBetterStudents / countOfStudentsPerGrade;
            uint gradeIndex = 0 + (uint)Math.Round(countOfGradesToDrop);

            return LetterGrades[gradeIndex];
        }
    }
}
