using System;

namespace VetClinic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet("Gogi", 32, "Timi");
            Pet pet2 = new Pet("Stefan", 512, "Dea");
            Pet pet3 = new Pet("Selen", 32, "Emo");

            Console.WriteLine(pet3);

            Clinic clinic = new Clinic(5);

            clinic.Add(pet3);

            clinic.Remove("Selen");
            clinic.Remove("Gogi");

            clinic.Add(pet3);
            clinic.GetPet("Selen", "Emo");

            Console.WriteLine(clinic.GetOldestPet());

            Console.WriteLine(clinic.Count);

            Console.WriteLine(clinic.GetStatistics());
        }
    }
}