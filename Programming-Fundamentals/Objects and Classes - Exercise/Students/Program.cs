using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Grade = grade;

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
