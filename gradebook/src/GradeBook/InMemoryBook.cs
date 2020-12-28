using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{    
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    
    public class InMemoryBook : Book
    {
        //Create default book values and establish the user's name
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            result = new Statistics();

            if (name.Length == 0){name = "Anonymous";}
        }
        public InMemoryBook(string name, string category) : base(name)
        {
            grades = new List<double>();
            result = new Statistics();

            if (category.Length > 0) {this.category = category;} 
            if (name.Length == 0){name = "Anonymous";}
        }

        //global grades and result computations
        // List<double> grades;
        // Statistics result;
        
        readonly string category = "Science";
        

        //If no information is provided, display this message
        public void noBookInfoProvided()
        {
            string intro = $"Welcome {Name}, ";
            Console.WriteLine($"{intro}No Grade information provided.");
        }
        
        public override void AddGrade(char letter)
        {
            letter = Char.ToUpper(letter);
            switch (letter)
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
        
        //Dynamically pushes grades
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                GradeCount++;
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }    
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        //Generate the statistics, return is for testing
        public override void GetStatistics(List<double> grades)
        {
            this.grades = result.GetStatistics(grades);            
        }

        //displays the statistics
        public override void showStatistics() 
        {
            output = $"The grade results are as follows: \r\n   ";
            output += $"Average: {result.Average:N2} \r\n   ";
            output += $"Highest Grade: {result.High:N2}  \r\n   ";
            output += $"Lowest Grade: {result.Low:N2}  \r\n   ";
            output += $"The letter grade is {result.letter}";
            
            Console.WriteLine(output);
        }

        

        

        /*
            Old methods to do individual steps, mainly for testing
        */

        // public double averageGrade()
        // {
        //     double average = grades.Sum()/grades.Count();
        //     output += $"Average: {average:N2} \r\n   ";
        //     return average;
        // }

        // public double lowestGrade()
        // {
        //     double lowGrade = grades.Min();
        //     output += $"Lowest Grade: {lowGrade:N2}  \r\n   ";
        //     return grades.Min();
        // }

        // public double highestGrade()
        // {
        //     double highGrade = grades.Max();
        //     output += $"Highest Grade: {highGrade:N2}";
        //     return highGrade;
        // }

        // public string intro()
        // {
        //     string intro = $"Welcome {name}, ";
        //     output = $"{intro}the grade results are as follows: \r\n ";
        //     return intro;
        // }
    }
}