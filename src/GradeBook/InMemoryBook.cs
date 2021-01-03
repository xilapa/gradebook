using System;
using System.Collections.Generic;


namespace GradeBook 
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string Name) : base(Name)
        {
            grades = new List<double>();
            instanceCount += 1;
        }

        public static int CountInstances()
        {
            return instanceCount;
        }

        public string GetBookName()
        {
            return Name;
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, it should be between 0 and 100");
            }
        }   

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }

        private List<double> grades;
    
        private static int instanceCount = 0;
    }
}