using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            addGradeMethod = null;
        }
        public virtual event GradeAddedDelegate GradeAdded;
        protected AddGradeDelegate addGradeMethod;
        public void AddGrade(double grade)
        {
            if (addGradeMethod == null)
                throw new NotImplementedException($"{nameof(addGradeMethod)} is not set");

            if (grade >= 0 && grade <= 100)
            {
                addGradeMethod(grade);
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
        public abstract Statistics GetStatistics();
    }
}