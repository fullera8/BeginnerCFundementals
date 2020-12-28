using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{        
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public List<double> grades;
        public Statistics result;
        public int GradeCount { get; set; }
        protected string output;

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract void AddGrade(char grade);
        public abstract void GetStatistics(List<double> grades);

        public abstract void showStatistics();
    }
}