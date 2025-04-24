
using System;

namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        // This is good for control, but they are hard wired for monsters. Either they need to be set by method
        // or they need to be set by the constructor ooooor I add a public modifer property
        private readonly int minAttack = 8;
        private readonly int maxAttack = 12;
        private readonly int minDamage = 8;
        private readonly int maxDamage = 12;
        private readonly int minHealth = 20;
        private readonly int maxHealth = 40;
        private readonly int minArmorClass = 7;
        private readonly int maxArmorClass = 10;

        
        public Monster(string name, string description) : base(name, description)
        {
            Health = random.Next(minHealth,maxHealth);
            ArmorClass = random.Next(minArmorClass, maxArmorClass);
        }
        public override void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = random.Next(minAttack, maxAttack);
                int damage = random.Next(minDamage, maxDamage);
                if (attack > targetCharacter.ArmorClass)
                {
                    Console.WriteLine($"{Name} attacked {targetCharacter.Name} and hit for {damage} damage");
                    targetCharacter.Health -= damage;
                }
                else
                {
                    Console.WriteLine($"{Name} attacked but missed");
                }
            }
        }
    }
}
