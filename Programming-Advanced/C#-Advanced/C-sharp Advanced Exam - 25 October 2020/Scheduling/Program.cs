using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] threadsArr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> tasks = new Stack<int>(tasksArr);

            Queue<int> threads = new Queue<int>(threadsArr);

            int taskToBeKilled = int.Parse(Console.ReadLine());

            int taskValue = 0;
            int threadValue = 0;

            while (tasks.Contains(taskToBeKilled))
            {
                taskValue = tasks.Pop();
                threadValue = threads.Peek();

                if (taskValue == taskToBeKilled)
                {
                    continue;
                }

                threads.Dequeue();
                if (threadValue < taskValue)
                {
                    tasks.Push(taskValue);
                }
            }


            Console.WriteLine($"Thread with value {threadValue} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
