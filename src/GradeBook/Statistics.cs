using System;

namespace GradeBook
{
    public class Statistics 
    {
        public double Low 
        {
            get
            {
                return low;
            }
            private set 
            {
                low = value;
            }
        }
        public double High 
        {
            get
            {
                if (Count >= 1)
                    return high;
                else
                    return 0;
            }
            private set 
            {
                high = value;
            }
        }
        
        public double Average 
        {
            get
            {
                if (Count >= 1)
                    return sum / Count;
                else
                    throw new DivideByZeroException($"{nameof(Count)} is zero");
                    // tratar este erro
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var avg when avg >= 90.0:
                        return 'A';
                    case var avg when avg >= 80.0:
                        return 'B';
                    case var avg when avg >= 70.0:
                        return 'C';
                    case var avg when avg >= 60.0:
                        return 'D';
                    case var avg when avg >= 50.0:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }
        private int Count;
        private double sum, low, high;

        public Statistics()
        {
            low = double.MaxValue;
            high = double.MinValue;
            sum = 0.0;
            Count = 0;
        }

        public void Add(double num)
        {
            sum += num;
            Count += 1;
            Low = Math.Min(num, low);
            High = Math.Max(num, high);
        }

    }
}