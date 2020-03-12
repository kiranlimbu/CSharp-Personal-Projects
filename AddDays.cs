using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace askDate
{
    class Program
    {
        static void Main(string[] args)
        {
            int day, month, year, add, totalDay;
            var daysOfMonth = new[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            try
            {
                // Day
                Console.Write("Enter day: ");
                day = Convert.ToInt16(Console.ReadLine());

                // Month
                Console.Write("Enter month: ");
                month = Convert.ToInt16(Console.ReadLine());

                // Year
                Console.Write("Enter year: ");
                year = Convert.ToInt16(Console.ReadLine());

                // print given date. Ask for number of days to add
                Console.WriteLine($"\n\nYou have entered: {month}/{day}/{year}");
                Console.WriteLine("---------------------------------------------------------------");

                Console.WriteLine("\nHow many days would you like to add? ");
                add = Convert.ToInt16(Console.ReadLine());

                // add the given days to the Day
                totalDay = day + add;

                // Check if the total day is more then the number of days in the given month
                while (totalDay > daysOfMonth[month])
                {
                    // check if leap year
                    if (year % 4 == 0)
                    {
                        daysOfMonth[2] = 29; // leap year
                    }
                    else
                    {
                        daysOfMonth[2] = 28; // not leap year
                    }

                    // check if month is 12
                    if (month != 12)
                    {
                        totalDay = totalDay - daysOfMonth[month]; // if the total day is more then the number of days in that month, substract from TOTALDAY
                        month++; // moves to next month
                    }
                    else
                    {
                        // if month is 12, moves to next year. Month is set to 1. days substracted from total
                        totalDay = totalDay - daysOfMonth[month];
                        month = 1;
                        year++;
                    }
                }
                // display new Date
                Console.WriteLine($"\n\nNew Date: {month}/{totalDay}/{year}");
            }

            catch
            {
                Console.WriteLine("Invalid Input!");
            }
            

            Console.ReadLine();
        }
    }
}
