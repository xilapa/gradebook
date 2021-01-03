using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            addGradeMethod = addGradeInDisk;
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
                       // blank line in the file 
                    }

                    line = file.ReadLine();
                }
            }
            
            return result;
        }

        private void addGradeInDisk(double grade)
        {
            using(var file = File.AppendText($"{Name}.txt"))
            {
                file.WriteLine(grade);
            }
        }
    }
}