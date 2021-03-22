using PersonInfo;

namespace PersonInfo
{
    public class Pet : IBirthable, INameable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}