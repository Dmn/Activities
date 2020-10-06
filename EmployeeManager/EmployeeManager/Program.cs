using System;

namespace EmployeeManager
{
    class Program
    {
        public const double rate = 9.50;

        static void Main(string[] args)
        {
            Console.Write("Hours Worked: ");
            int hours = int.Parse(Console.ReadLine());
            double price = (hours > 40) ? (rate * 40 + 14.25 * (hours - 40)) : (rate * hours);
            Console.WriteLine("The weekly wage is {0:C2}.", price);
        }
    }
}
