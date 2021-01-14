using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];
                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                input = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            courses = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in courses)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{course.Key}: {course.Value.Count}");
                foreach (var user in courses[course.Key].OrderBy(x => x))
                {
                    sb.AppendLine($"-- {user}");
                }

                Console.Write(sb.ToString());
            }
        }
    }
}
