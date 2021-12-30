using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        } 

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        
    }


     public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        { 
            grades = new List<double>();
            Name = name ;   
        }   


        public void AddLetterGrade(char Letter)
        {
            switch(Letter)
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
        public override void AddGrade(double grade)
        {
           
            if (grade <= 100 && grade >= 0)
            { 
                grades.Add(grade);   
            }
            else
            {
                throw new ArgumentException($"Input {nameof(grade)} was not valid");
            }
        

        }

        public override Statistics GetStatistics()
        {

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

           
            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                result.Letter = 'A';
                break;

                case var d when d >= 80.0:
                result.Letter = 'B';
                break;

                case var d when d >= 70.0:
                result.Letter = 'C';
                break;

                case var d when d >= 60.0:
                result.Letter = 'D';
                break;

                default:
                result.Letter = 'F';
                break;
            }

            return result;
        

        }

        private List <double> grades;

        const string category = "Math";
    }
}