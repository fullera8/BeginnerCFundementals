using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{        
    public interface IBook
    {
        void AddGrade(double grade);
        void AddGrade(char grade);
        void GetStatistics(List<double> grades);
        string Name {get;}
        int GradeCount { get; set; }

        event GradeAddedDelegate GradeAdded;

        void showStatistics();
    }
}