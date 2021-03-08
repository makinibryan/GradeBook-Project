using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Bryan's Gradebook");
            book.GradeAdded += OnGradeAdded;
          
            while (true)
            {
                System.Console.WriteLine("Please enter a grade or enter 'q' to quit!");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    
                }
                catch(FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("******");
                }
               
            }
            
            var stats = book.GetStatistics();

            System.Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The Average grade is {stats.Average :N1}");
            Console.WriteLine($"The Letter Grade is {stats.Letter}");
        }
        static void OnGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine("A Grade was Added!");
        }
    }


}
