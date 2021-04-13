using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using WarCroft.Constants;
using WarCroft.Entities;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private List<Character> characterParty;
        private List<Item> itemPool;

		public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new List<Item>();
        }

		public string JoinParty(string[] args)
		{
            if (args[0] == "Priest")
            {
                Character priest = new Priest(args[1]);
				characterParty.Add(priest);
            }
			else if (args[0] == "Warrior")
            {
                Character warrior = new Warrior(args[1]);
				characterParty.Add(warrior);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{args[0]}\"!");
            }

            return $"{args[1]} joined the party!";
        }

		public string AddItemToPool(string[] args)
        {
            Item item = null;

            if (args[0] == "HealthPotion")
            {
                item = new HealthPotion();
            }
			else if (args[0] == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{ args[0] }\"!");
            }

			itemPool.Add(item);
            return $"{args[0]} added to pool.";
        }

		public string PickUpItem(string[] args)
        {

            if (!characterParty.Exists(x=> x.Name == args[0]))
            {
                throw new ArgumentException($"Character {args[0]} not found!");
            }

            if (!itemPool.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Character character = characterParty.First(c => c.Name == args[0]);

            Item item = itemPool[^1];

            character.Bag.AddItem(item);

            itemPool.Remove(item);

            return $"{args[0]} picked up {item.GetType().Name}!";
        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!characterParty.Exists(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }


            Character character = characterParty.First(x => x.Name == characterName);

            character.UseItem(character.Bag.GetItem(itemName));

            return $"{character.Name} used {itemName}.";
        }

		public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine( $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (!characterParty.Exists(x => x.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            else if (!characterParty.Exists(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }


            if (characterParty.First(x => x.Name == attackerName).GetType().Name == "Priest")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior attacker = (Warrior)characterParty.First(x => x.Name == attackerName);
            var receiver = characterParty.First(x => x.Name == receiverName);

            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine( $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!characterParty.Exists(x => x.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            else if (!characterParty.Exists(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (characterParty.First(x => x.Name == healerName).GetType().Name == "Warrior")
            {
                throw new ArgumentException($"{healerName} cannot attack!");
            }

            Priest healer = (Priest)characterParty.First(x => x.Name == healerName);
            var receiver = characterParty.First(x => x.Name == healingReceiverName);

            healer.Heal(receiver);

            return
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
