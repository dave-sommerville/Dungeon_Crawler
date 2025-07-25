﻿using System.Runtime.InteropServices.Marshalling;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Characters_and_dialogue
{
    public class Character
    {
        private readonly int _nextId;
        //  STATUS TRACKERS
        public bool IsDodging = false;
        public bool IsStunned = false;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public int XP { get; set; } = 0;
        public Item[] Inventory { get; set; } = new Item[10];

        public Character()
        {
            Id = _nextId++;
            Name = "Blank Character";
            Description = "Generic description";
            ArmorClass = 0;
            Health = 0;
        }
        public virtual void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = 5;
                if (attack > targetCharacter.ArmorClass)
                {
                    Utility.Print($"{Name} attacked {targetCharacter.Name} and hit for {attack} damage");
                    targetCharacter.Health -= attack; 
                }
                else
                {
                    Utility.Print($"{Name} attacked but missed");
                }
            }
        }
        public virtual void PrintInventory()
        {

        }
    }
}
