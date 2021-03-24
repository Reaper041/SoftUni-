
namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public string Id { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}