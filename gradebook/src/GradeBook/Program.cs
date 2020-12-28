using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {           
            //first iteration creates the gradebook
            Console.WriteLine("Please enter your name: ");
            Book book = new DiskBook(Console.ReadLine());
            book.GradeAdded += OnGradeAdded;

            //Adds the grades
            AddGrades(book);

            //Determines if the gradeboook is blank and displays accordingly
            if (book.GradeCount > 0)
            {
                book.GetStatistics(book.grades);
                book.showStatistics();
            }
            else
            {
                Console.WriteLine("The gradebook is empty, no grades provided.");
            }
            
        }

        //Event demonstration that writes that a number was added in the class
        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A Grade was added.");
        }    

        //Adds grades taking the input for the initial name
        public static void AddGrades(IBook book) 
        {
            //Generates fields needed to calculate the grades
            string input = "";

            //Loops for grades until the user types "exit"
            while (!string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Hello {book.Name}, please enter the students grade or type 'Exit' when you would like to see the gradebook: ");
                input = Console.ReadLine();
                //if numeric grade
                if (!string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        if (double.TryParse(input, out double grade))
                        {
                            book.AddGrade(grade);
                        }
                        else if (char.TryParse(input, out char gradeChar))
                        {
                            book.AddGrade(gradeChar);
                        }
                        
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                // else if (!double.TryParse(input, out grade) && !char.TryParse(input, out gradeChar) && !string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                // {
                //     Console.WriteLine("Please enter a valid numeric/letter grade");
                // }
            }
        }

        //check parameters were provided.
        //     if (args.Length > 0)
        //     {
        //         var book = new Book(args[0]);
        //         //Check that more than a name was provided and generate gradebook.
        //         if (args.Length > 1)
        //         {
        //             generateGradeBook(args, book);             
        //         }
        //         //No grades provided error message.
        //         else
        //         {
        //             book.noBookInfoProvided();
        //         }
        //     }
        //     //No params provided error message.
        //     else
        //     {
        //        Console.WriteLine("Please login."); 
        //     }            
        // }
        // public static void generateGradeBook(string[] args, Book book)
        // {
        //     var grades = args.Skip(1).Select(double.Parse).ToList();
        //     foreach (var grade in grades)
        //     {
        //         book.AddGrade(grade);
        //     }
        //     book.getStatistics();
        //     book.showStatistics();    
        // }

    }
}
