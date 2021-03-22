using System;
using System.Collections.Generic;
using System.Linq;
using PersonInfo;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<IBirthable> birthable = new List<IBirthable>();

            while (input[0] != "End")
            {
                if (input[0] == "Robot")
                {
                    
                }
                else if (input[0] == "Citizen")
                {
                    IBirthable citizen = new Citizen(input[1], int.Parse(input[2]), 
                        input[3], input[4]);

                    birthable.Add(citizen);
                }
                else
                {
                    IBirthable pet = new Pet(input[1],input[2]);
                    birthable.Add(pet);
                }

                input = Console.ReadLine().Split();
            }

            string year = Console.ReadLine();

            foreach (var birthableObject in birthable.Where(x => x.Birthdate.TrimEnd().EndsWith(year)))
            {
                Console.WriteLine(birthableObject.Birthdate);
            }
        }
    }
}
