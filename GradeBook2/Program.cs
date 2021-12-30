using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new InMemoryBook("Harry Potter Book");

            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The Highest Grade is {stats.High}.");
            Console.WriteLine($"The Average Grade is {stats.Average:N1}.");
            Console.WriteLine($"The Lowest Grade is {stats.Low}.");
            Console.WriteLine($"The Letter Grade is {stats.Letter}.");

        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit !!");
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
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("*****");
                }


            }
        }
    }
}