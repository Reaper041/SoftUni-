using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int tab = 1; tab <= numberOfTabs; tab++)
            {
                string title = Console.ReadLine();

                if (title == "Facebook")
                {
                    salary -= 150;
                }
                else if (title == "Instagram")
                {
                    salary -= 100;
                }
                else if (title == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                        
                }
            }
            if (salary > 0) Console.WriteLine(salary);
        }
    }
}
