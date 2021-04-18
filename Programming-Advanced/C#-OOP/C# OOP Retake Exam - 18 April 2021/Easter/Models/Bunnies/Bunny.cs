using System;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }

                name = value;
            }
        }


        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes => dyes;

        public abstract void Work();

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }
    }
}