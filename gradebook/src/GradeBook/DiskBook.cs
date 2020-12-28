using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{

    public class DiskBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;

        
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            result = new Statistics();
            
            if (name.Length == 0){name = "Anonymous";}
            Name = name;

            if (File.Exists($"{Name}.txt"))
            {
                using (var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        GradeCount++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public override void AddGrade(double grade)
        {
            using(StreamWriter sw = File.AppendText($"{Name}.txt"))
            {
                sw.WriteLine(grade);
            }
            
            // if (grade <= 100 && grade >= 0)
            // {
            //     grades.Add(grade);
            //     GradeCount++;
            //     if (GradeAdded != null)
            //     {
            //         GradeAdded(this, new EventArgs());
            //     }    
            // }
            // else 
            // {
            //     throw new ArgumentException($"Invalid {nameof(grade)}");
            // }
        }

        public override void AddGrade(char grade)
        {
            grade = Char.ToUpper(grade);
            switch (grade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void GetStatistics(List<double> grades)
        {
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    grades.Add(number);
                    line = reader.ReadLine();
                }
            }
            result.GetStatistics(grades);
        }

        public override void showStatistics() 
        {
            output = $"The grade results are as follows: \r\n   ";
            output += $"Average: {result.Average:N2} \r\n   ";
            output += $"Highest Grade: {result.High:N2}  \r\n   ";
            output += $"Lowest Grade: {result.Low:N2}  \r\n   ";
            output += $"The letter grade is {result.letter}";
            
            Console.WriteLine(output);
        }
    }
}