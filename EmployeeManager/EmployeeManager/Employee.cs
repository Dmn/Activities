using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EmployeeManager
{
    public class Employee
    {
        private string name;
        private string id;
        private int hours;
        private double rate;

        public Employee(string name, string id, int hours, double rate = 9.50)
        {
            this.name = name;
            this.id = id;
            this.hours = hours;
            this.rate = rate;
        }

        public static bool isValidName(string input)
        {
            return input.Length > 0 && input.Length <= 50;
        }

        public static bool isValidID(string input)
        {
            string regex = @"^[A-Z]\d{2}$";
            return Regex.IsMatch(input, regex) ? true : false;
        }

        public static bool isValidHours(int input)
        {
            return input > 0 && input <= 100;
        }

        public double calcWage()
        {
            return (hours > 40) ? (rate * 40 + 14.25 * (hours - 40)) : (rate * hours);
        }

        public string ToString()
        {
            return name + " (" + id + "). Wage: " + calcWage();
        }
    }
}
