using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double hoursPerDay;
            DateTime finishedDate = DateTime.Today;
            TimeSpan timeSpan;

            Console.WriteLine("How many hours per day can you practise?");
            string answer = Console.ReadLine();

            while (!double.TryParse(answer, out hoursPerDay) && hoursPerDay <= 0.0)
            {
                Console.WriteLine("Invalid input, try again!");
                answer = Console.ReadLine();
            }

            finishedDate = finishedDate.AddDays(10000/ hoursPerDay);
            timeSpan = finishedDate - DateTime.Today;
            int years = timeSpan.Days / 365;

            Console.Clear();
            Console.WriteLine("Practising {0} hours per day if starting today, you would be finished in\n{1}",
                hoursPerDay, finishedDate.ToShortDateString());

            Console.WriteLine("You would be practising for\n{0} years and {1} days.",
                years, (finishedDate.AddYears(-years) - DateTime.Today).Days);
            Console.ReadKey();
        }

    }
}
