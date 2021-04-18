using System;
using Easter.Models.Eggs.Contracts;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            EnergyRequired -= 10;

            if (EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (EnergyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}