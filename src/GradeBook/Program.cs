using System;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {   // reescrever
            Console.WriteLine("What's the student name?");
            var inputName = Console.ReadLine();
            var book = new InMemoryBook(inputName);
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book); 

            var stats = book.GetStatistics();

            Console.WriteLine($"{book.Name}'s book statistics:\n\tMinimum grade: {stats.Low:N2}\n\tMaximum grade: {stats.High:N2}\n\tAverage grade: {stats.Average:N2}\n\tLetter grade: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            string inputGrade;
            do
            {
                Console.WriteLine("Type a grade or press \"Q\" to quit and show statistics");
                inputGrade = Console.ReadLine().ToLower();

                if (inputGrade == "q")
                    continue;

                try
                {
                    var grade = double.Parse(inputGrade);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (inputGrade != "q");
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Grade Added");
        }
    }
}
