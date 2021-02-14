using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Employees = new List<Employee>();
            Name = name;
            Capicity = capacity;
        }

        public List<Employee> Employees { get; set; }
        public string Name { get; set; }
        public int Capicity { get; set; }

        public void Add(Employee employee)
        {
            if (Capicity + 1 <= Employees.Count)
            {
                Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (Employees.Exists(x => x.Name == name))
            {
                Employees.Remove(Employees.Find(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            int maxAge = int.MinValue;
            Employee oldest = null;

            foreach (Employee employee in Employees)
            {
                if (employee.Age > maxAge)
                {
                    oldest = employee;
                }
            }

            return oldest;
        }

        public Employee GetEmployee(string name)
        {
            return Employees.Find(x => x.Name == name);
        }

        public int Count()
        {
            return Employees.Count;
        }

        public void Report()
        {
            Console.WriteLine("Employees working at Bakery {bakeryName}:");
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
