using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public class Book
    {
        public Book(string Name)
        {
            grades = new List<double>();
            this.Name = Name;
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

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }   

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            double sum = 0;
            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade,result.Low);
                result.High = Math.Max(grade, result.High);
                sum += grade;
            }  
            result.Average = sum / grades.Count;
            return result;
        }

        private List<double> grades;
        public string Name;
        private static int instanceCount = 0;
              
    }
}