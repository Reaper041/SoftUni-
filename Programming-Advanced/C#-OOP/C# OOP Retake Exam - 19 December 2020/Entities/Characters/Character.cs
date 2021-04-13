using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Armor = armor;
            Health = health;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get; set; }

        public double Health { get; set; }

        public double BaseArmor { get; set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; set; }

        public Bag Bag { get; set; }

		public bool IsAlive { get; set; } = true;

		public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive(); double damageToAdd = 0;
            Armor -= hitPoints;
            if (Armor < 0)
            {
                damageToAdd = Math.Abs(Armor);
                Armor = 0;
            }

            Health -= damageToAdd;

            if (Health < 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }


    }
}