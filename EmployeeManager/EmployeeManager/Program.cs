using System;

namespace EmployeeManager
{
    class Program
    {
        public const double hourlyRate = 9.50;

        static void Main(string[] args)
        {
            Console.Write("Hours Worked: ");
            int hours = int.Parse(Console.ReadLine());
            Console.WriteLine("The weekly wage is {0:C2}", (hours * hourlyRate));
        }
    }
}
