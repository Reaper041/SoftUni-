using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strudentInf = Console.ReadLine()
                .Split()
                .ToList();


            List<Student> studentList = new List<Student>(); 
            while (strudentInf[0] != "end")
            {
                string firstName = strudentInf[0];
                string lastName = strudentInf[1];
                int age = int.Parse(strudentInf[2]);
                string hometown = strudentInf[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = hometown;
                studentList.Add(student);

                strudentInf = Console.ReadLine()
                    .Split()
                    .ToList();
            }

            string town = Console.ReadLine();

            foreach (var stud in studentList)
            {
                if (town == stud.Hometown)
                {
                    Console.WriteLine($"{stud.FirstName} {stud.LastName} is {stud.Age} years old.");
                }
            }
        }
    }
}
