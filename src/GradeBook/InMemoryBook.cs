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
            Statistics result = new Statistics();
            if (grades.Count >= 1)
            {                
                double sum = 0;
                foreach (var grade in grades)
                {
                    result.Low = Math.Min(grade,result.Low);
                    result.High = Math.Max(grade, result.High);
                    sum += grade;
                }  
                result.Average = sum / grades.Count;

                switch (result.Average)
                {
                    case var avg when avg >= 90.0:
                        result.Letter = 'A';
                        break;
                    case var avg when avg >= 80.0:
                        result.Letter = 'B';
                        break;
                    case var avg when avg >= 70.0:
                        result.Letter = 'C';
                        break;
                    case var avg when avg >= 60.0:
                        result.Letter = 'D';
                        break;
                    case var avg when avg >= 50.0:
                        result.Letter = 'E';
                        break;
                    default:
                        result.Letter = 'F';
                        break;
                }
                return result;
            }
            else
            {
                result.Low = result.High = result.Average = 0;
                result.Letter = '-';
                return result;
            }
        }

        private List<double> grades;
    
        private static int instanceCount = 0;
    }
}