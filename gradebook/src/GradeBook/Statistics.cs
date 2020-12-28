using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char letter;

        public virtual List<double> GetStatistics(List<double> grades)
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index++)
            {
            //    if (grades[index] == 42.1)
            //    {
            //        //break; get out of the loop
            //        //continue; skip this value
            //        //goto done;
            //    }
                Average += grades[index];
                Low = Math.Min(grades[index], Low);
                High = Math.Max(grades[index], High);
            }; 
            Average = Average/grades.Count;
            switch (Average)
            {
                case var d when d >= 90.0:
                    letter = 'A';
                    break;
                case var d when d >= 80.0:
                    letter = 'B';
                    break;
                case var d when d >= 70.0:
                    letter = 'C';
                    break;
                case var d when d >= 60.0:
                    letter = 'D';
                    break;
                default:
                    letter = 'F';
                    break;
            }

            return grades;
        }
    }
}