using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            if (bunnyType == "HappyBunny")
            {
                bunnies.Add(new HappyBunny(bunnyName));
            }
            else
            {
                bunnies.Add(new SleepyBunny(bunnyName));
            }

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);

            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunnies.FindByName(bunnyName).AddDye(dye);

            return $"Successfully added dye with power {dye.Power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunniesToUse = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();
            IEgg egg = eggs.FindByName(eggName);
            Workshop workshop = new Workshop();

            if (!bunniesToUse.Any())
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (var bunny in bunniesToUse)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy <= 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}