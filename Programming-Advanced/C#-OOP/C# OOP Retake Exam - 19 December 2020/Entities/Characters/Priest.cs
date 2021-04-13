using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();

            character.Health += AbilityPoints;

            if (Health > BaseHealth)
            {
                Health = BaseHealth;
            }
        }
    }
}