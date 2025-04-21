
using System;

namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();

        private readonly string[] encounterGroups = new string[]
        {
            "Three Giant Rats",
            "Two Kobolds and One Giant Rat",
            "Four Kobolds and One Skeleton",
            "An Orc with Two Skeletons",
            "Two Hobgoblins",
            "A Giant Spider with One Skeleton and One Kobold",
            "Two Orcs and One Ogre",
            "A Minotaur",
            "One Wight with One Skeleton and One Hobgoblin",
            "An Otyugh",
            "One Troll",
            "One Mummy and One Hobgoblin",
            "One Yuan-Ti",
            "One Ogre with Two Orcs and Two Skeletons",
            "Two Minotaurs",
            "A Wraith with Two Skeletons",
            "A Chimera",
            "A Roper",
            "A Wyvern and One Giant Spider",
            "Two Trolls",
            "A Wight with One Mummy and Two Skeletons",
            "Two Wraiths",
            "A Chimera with One Hobgoblin and One Orc",
            "A Roper and Two Troglodytes",
            "Two Wyverns",
            "A Yuan-Ti with One Mummy and One Wight",
            "Two Chimeras",
            "A Purple Worm",
            "A Purple Worm and One Wight",
            "A Purple Worm with One Chimera and One Yuan-Ti"
        };
        private readonly string[] goblinArmyEncounters = new string[]
        {
            "Two Goblins and One Worg",
            "Three Goblins and Two Goblin Bombers",
            "Two Hobgoblins with One Worg and One Bugbear",
            "One Bugbear and One Goblin Shaman with Three Goblins",
            "One Hobgoblin with One Bugbear and Three Goblins",
            "Two Worg Riders and One Hobgoblin Blademaster",
        };
        string[] drowEncounters = new string[]
        {
            "Two Drow Scouts and One Drow Priestess",
            "Two Drow Warriors with One Giant Spider",
            "Two Drow Warriors and One Drow Elite Guard",
            "Three Drow with One Shadow Mastiff",
            "Two Drow Archers with One Giant Spider and One Drow Warrior",
            "One Drow Assassin with Two Drow Warriors"
        };
        private readonly string[] illithidEncounters = new string[]
        {
            "Three Enslaved Quagoth",
            "Two Thrall Acolytes and One Duergar",
            "One Enslaved Orog with Three Thrall Cult Fanatics",
            "Two Enslaved Duergar and Two Grimlocks",
            "One Mind Flayer with One Thrall Mage and Two Grimlocks",
            "One Mind Flayer with One Enslaved Quaggoth and Two Duergar"
        }; // This is good for control, but they are hard wired for monsters. Either they need to be set by method
        // or they need to be set by the constructor ooooor I add a public modifer property
        private readonly int minAttack = 0;
        private readonly int maxAttack = 0;
        private readonly int minDamage = 0;
        private readonly int maxDamage = 0;
        private readonly int minHealth = 0;
        private readonly int maxHealth = 0;
        private readonly int minArmorClass = 0;
        private readonly int maxArmorClass = 0;

        public int NumberOfAttacks { get; set; }
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
