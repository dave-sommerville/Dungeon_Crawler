
using System;

namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        private readonly List<string> MonsterNames = new List<string>
    {
        "Orc",
        "Troll",
        "Kobold",
        "Giant Rat",
        "Skeleton",
        "Wraith",
        "Gargoyle",
        "Ogre",
        "Minotaur",
        "Hobgoblin",
        "Giant Spider",
        "Wyvern",
        "Wight",
        "Mummy",
        "Otyugh",
        "Roper",
        "Chimera",
        "Yuan-Ti",
        "Minotaur",
        "Purple Worm",
        "Troglodyte"
    };
        public int Attack { get; set; }
        public int NumberOfAttacks { get; set; }
        public Monster(string name, string description) : base(name, description)
        {
            Health = random.Next(0,5) + 10;
            Attack = random.Next(0, 5) + 7;
            ArmorClass = random.Next(0, 5) + 2;
            NumberOfAttacks = 1;
        }
        // Probably override this from character 
        public void MonsterAttack(Player player)
        {
            Random random = new Random();
            if(Attack >= player.ArmorClass)
            {
                int damage = random.Next(5, 20);
                player.Health -= damage;
                Console.WriteLine($"Player hit! Player's health reduced by {damage}");
            } else
            {
                Console.WriteLine("Monster Attack missed");
            }
        }
        // Offer three special abilities to monsters, one to target each of the stat properties 
    }
}
