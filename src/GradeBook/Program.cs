using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Dirceu");
            book.AddGrade(12.8);
            book.AddGrade(12.4);
            var stats = book.GetStatistics();

            Console.WriteLine($"{book.GetBookName()}'s book statistics:\n\tMinimum grade: {stats.Low:N2}\n\tMaximum grade: {stats.High:N2}\n\tAverage grade: {stats.Average:N2}");
        }
    }
}
