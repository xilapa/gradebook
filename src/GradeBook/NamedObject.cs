using System;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name {             
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Name)} is invalid, it can't be null or empty");
                } 
            }
        }

        private string name;
    } 
}