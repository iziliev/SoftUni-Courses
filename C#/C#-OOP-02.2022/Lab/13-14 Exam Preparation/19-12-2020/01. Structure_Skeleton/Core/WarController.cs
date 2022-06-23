using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characterParty;
		private Stack<Item> itemPool;

		public WarController()
		{
			this.characterParty = new List<Character>();
			this.itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			var characterType = args[0];
			var name = args[1];

			Character character;
            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
			else if (characterType == "Priest")
            {
				character = new Priest(name);
            }
            else
            {
				throw new ArgumentException($@"Invalid character type ""{characterType}""!");
            }

			this.characterParty.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			var itemName = args[0];

			Item item;
			if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
			}
            else
            {
				throw new ArgumentException($@"Invalid item ""{itemName}""!");
            }

			this.itemPool.Push(item);
			
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			var characterName = args[0];

			var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
			}

            if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
			}

			var item = this.itemPool.Pop();

			character.Bag.AddItem(item);

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			var characterName = args[0];
			var itemName = args[1];

			var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			var item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return $"{characterName} used {itemName}.";
		}

		public string GetStats()
		{
			var sb = new StringBuilder();

            foreach (var character in this.characterParty.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
				sb.AppendLine(character.ToString());
            }

			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var receiverName = args[1];

			var attacker = this.characterParty.FirstOrDefault(x => x.Name == attackerName);

			var receiver = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

			if (attacker == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
			}

			if (receiver == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

            if (attacker.GetType().Name != "Warrior")
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

			var warrior = attacker as Warrior;

			warrior.Attack(receiver);

			var sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }

			return sb.ToString().Trim();
		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var healingReceiverName = args[1];

			var healer = this.characterParty.FirstOrDefault(x => x.Name == healerName);

			var receiver = this.characterParty.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			if (receiver == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			var healerCharacter = healer as Priest;

			healerCharacter.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
