using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (data.Exists(x => x.Name == name))
            {
                data.Remove(data.FirstOrDefault(x => x.Name == name));
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if (data.Exists(x => x.Name == name && x.Owner == owner))
            {
                return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
