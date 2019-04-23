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

            //Get Birth Year
            Console.WriteLine("Enter the Year: ");
            int year = int.Parse(Console.ReadLine());

            //Get Birth Month
            Console.WriteLine("Enter the Month: ");
            int month = int.Parse(Console.ReadLine());

            //Get Birth Day
            Console.WriteLine("Enter the Day: ");
            int day = int.Parse(Console.ReadLine());

            //Combine user input into a DateTime varible
            DateTime birthday = new DateTime(year, month, day);
            
            //Get today's date.
            DateTime today = DateTime.Now;

            //get time from birthday till today
            TimeSpan span = (today - birthday);

            //get total days from span and cast into int
            int totalDays = (int)span.TotalDays;

            // Get age in years
            int ageInYears = totalDays / 365; 

            /* When you take total days and divide by 365 it doesn't count for leapyears which have an extra day.
            * If you get the modulus of 365 then the remainder would be higher by the number of leap years.
            * We subtract the leap years from the total days before getting the modulus.
            * There might be some edge cases this may fail, but it is unknown what those cases are at this time.*/
            int numberOfLeapYears = LeapYearsBetween(year, today.Year);//Get number of leap years since born
            int ageDaysAfterYears = (totalDays - numberOfLeapYears) % 365; //subtract leapyears from total days and get modulus of 365 days

            // display our age.
            Console.WriteLine($"Age: {ageInYears}yrs {ageDaysAfterYears}days");
        }

        //Calculate the number of leap years between the start and end year
        static int LeapYearsBetween(int start, int end)
        {
            // subtract the leap years before the start from the leap years before the end date.
            return LeapYearsBefore(end) - LeapYearsBefore(start + 1);
        }

        //calculates leap years before the year passed as the parameter
        static int LeapYearsBefore(int year)
        {
            year--;
            return (year / 4) - (year / 100) + (year / 400);
        }
    }
}
