using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var cnt = Students.Count;
            if (cnt < 5)
            {
                throw new InvalidOperationException();
            }

            var grades = Students.Select(q => q.AverageGrade).OrderByDescending(q => q).ToList();

            var divisions = cnt * 0.2;
            if (grades.IndexOf(averageGrade) < divisions) return 'A';
            if (grades.IndexOf(averageGrade) >= divisions && grades.IndexOf(averageGrade) < 2 * divisions) return 'B';
            if (grades.IndexOf(averageGrade) >= 2 * divisions && grades.IndexOf(averageGrade) < 3 * divisions) return 'C';
            if (grades.IndexOf(averageGrade) >= 3 * divisions && grades.IndexOf(averageGrade) < 4 * divisions) return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
