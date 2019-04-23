using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birthday!");
            Console.WriteLine("Enter the Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Month: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Day: ");
            int day = int.Parse(Console.ReadLine());
            DateTime birthday = new DateTime(year, month, day);
            
            DateTime today = DateTime.Now;
            int numberOfLeapYears = LeapYearsBetween(year, today.Year);
            TimeSpan span = (today - birthday);
            int totalDays = (int)span.TotalDays;
            double span2 = (today - birthday).TotalDays;
            int ageInYears = totalDays / 365;
            int ageDaysAfterYears = (totalDays - numberOfLeapYears) % 365;
            string age = $"Age: {ageInYears}yrs {ageDaysAfterYears}days";
            Console.WriteLine(age);
        }
        static int LeapYearsBetween(int start, int end)
        {
            return LeapYearsBefore(end) - LeapYearsBefore(start + 1);
        }

        static int LeapYearsBefore(int year)
        {
            year--;
            return (year / 4) - (year / 100) + (year / 400);
        }
    }
}
