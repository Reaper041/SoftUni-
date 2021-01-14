using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();


            List<Student> students = new List<Student>();
            while (input[0] != "end")
            {
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string hometown = input[3];




                if (IsStudentExisting(firstName, lastName, students))
                {
                    Student student = GetStudent(firstName, lastName, students);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;
                }
                else
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;

                    students.Add(student);
                }

                input = Console.ReadLine()
                    .Split();
            }

            string town = Console.ReadLine();

            foreach (Student stud in students)
            {
                if (stud.Hometown == town)
                {
                    Console.WriteLine($"{stud.FirstName} {stud.LastName} is {stud.Age} years old.");
                }
            }
        }

        static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
        {
            foreach (Student stud in students)
            {
                if (stud.FirstName == firstName && stud.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
        static Student GetStudent(string firstName, string lastName, List<Student> students)
        {
            Student existingStudent = null;
            foreach (Student stud in students)
            {
                if (stud.FirstName == firstName && stud.LastName == lastName)
                {
                    existingStudent = stud;
                }
            }

            return existingStudent;
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

    }
}
