using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {           
            if (grade >= 0 && grade <= 100)
            {
                using(var file = File.AppendText($"{Name}.txt"))
                {
                    file.WriteLine(grade);
                }
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var file = File.OpenText($"{Name}.txt"))
            {
                var line = file.ReadLine();
                while (line != null)
                {
                    try
                    {
                        var grade = double.Parse(line);
                        result.Add(grade);
                    }
                    catch(FormatException)
                    {
                        
                    }

                    line = file.ReadLine();
                }
            }
            
            return result;
        }
    }
}