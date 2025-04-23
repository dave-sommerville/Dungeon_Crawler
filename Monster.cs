
using System;

namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        // This is good for control, but they are hard wired for monsters. Either they need to be set by method
        // or they need to be set by the constructor ooooor I add a public modifer property
        private readonly int minAttack = 0;
        private readonly int maxAttack = 0;
        private readonly int minDamage = 0;
        private readonly int maxDamage = 0;
        private readonly int minHealth = 0;
        private readonly int maxHealth = 0;
        private readonly int minArmorClass = 0;
        private readonly int maxArmorClass = 0;

        
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
                    Console.WriteLine($"{Name} attacked {targetCharacter.Name} and hit for {attack} damage");
                    targetCharacter.Health -= attack;
                }
                else
                {
                    Console.WriteLine($"{Name} attacked but missed");
                }
            }
        }
        // Offer three special abilities to monsters, one to target each of the stat properties 
    }
}
