using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<IIdentifiable> robotsAndCitizens = new List<IIdentifiable>();

             while (input[0] != "End")
            {
                string name = input[0];

                if (input.Length == 2)
                {
                    Robot robot = new Robot(name, input[1]);
                    robotsAndCitizens.Add(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(name, int.Parse(input[1]), input[2]);
                    robotsAndCitizens.Add(citizen);
                }

                input = Console.ReadLine().Split();
            }

            string fakeIdLastNums = Console.ReadLine();

            foreach (var robotsAndCitizen in robotsAndCitizens.Where(x => x.Id.EndsWith(fakeIdLastNums)))
            {
                Console.WriteLine(robotsAndCitizen.Id);
            }
        }
    }
}
