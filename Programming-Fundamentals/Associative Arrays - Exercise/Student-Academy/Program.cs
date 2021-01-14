using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double> markbook = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (markbook.ContainsKey(student))
                {
                    markbook[student] = (markbook[student] + grade) / 2;
                }
                else
                {
                    markbook.Add(student, grade);   
                }
            }

            foreach (var student in markbook)
            {
                if (student.Value < 4.5)
                {
                    markbook.Remove(student.Key);
                }
            }

            foreach (var student in markbook.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
