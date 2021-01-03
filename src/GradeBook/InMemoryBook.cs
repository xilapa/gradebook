using System;
using System.Collections.Generic;


namespace GradeBook 
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string Name) : base(Name)
        {
            grades = new List<double>();
            addGradeMethod = addGradeInMemory;
        }  

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }

        private void addGradeInMemory(double grade)
        {
            grades.Add(grade);
        }

        private List<double> grades;
    }
}