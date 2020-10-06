using System;
using System.Collections.Generic;

namespace EmployeeManager
{
    class Program
    {
        public static Dictionary<int,Employee> employees = new Dictionary<int, Employee>();

        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("1.Add Employee\n2.List Employees (with the positon number inthe list)\n3.Remove Employee (based on a positon number provided by the user)");
                int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        addEmployee();
                        break;
                    case 2:
                        Console.Clear();
                        listEmployee();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        removeEmployee();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    default:
                        run = false;
                        break;
                }
            }

            //double price = (hours > 40) ? (rate * 40 + 14.25 * (hours - 40)) : (rate * hours);
            //Console.WriteLine("The weekly wage is {0:C2}.", price);
        }

        public static void addEmployee()
        {
            Console.Write("Input Employee name: ");
            string name = Console.ReadLine();
            while (!Employee.isValidName(name))
            {
                Console.Write("Invalid name, try again: ");
                name = Console.ReadLine();
            }
            Console.Write("Input Employee id: ");
            string id = Console.ReadLine();
            while (!Employee.isValidID(id))
            {
                Console.Write("Invalid id, try again: ");
                id = Console.ReadLine();
            }
            Console.Write("Input Hours worked: ");
            int hours = int.Parse(Console.ReadLine());
            while (!Employee.isValidHours(hours))
            {
                Console.Write("Invalid name, try again: ");
                hours = int.Parse(Console.ReadLine());
            }
            Employee emp = new Employee(name, id, hours);
            employees.Add(employees.Count + 1, emp);
        }

        public static void listEmployee()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees.");
                return;
            }
            for (int i = 1; i <= employees.Count; i++)
            {
                Employee test = null;
                employees.TryGetValue(i, out test);
                Console.WriteLine(i + ". " + test.ToString());
            }
        }

        public static void removeEmployee()
        {
            listEmployee();
            if (employees.Count == 0)
            {
                return;
            }
            Console.Write("Number of employee to remove: ");
            int id = int.Parse(Console.ReadLine());
            if (employees.ContainsKey(id))
            {
                employees.Remove(id);
            }
            else
            {
                Console.WriteLine("Invalid Employee.");
                return;
            }
        }
    }
}
