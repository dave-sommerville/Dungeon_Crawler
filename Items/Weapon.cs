﻿using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Items
{
    public class Weapon : Item
    {
        private readonly string[] midMeleeWeapons = new string[]
        {
            "Iron Club",
            "Worn Shortsword",
            "Cracked Mace",
            "Rusty Hatchet",
            "Dull Saber",
            "Stone Axe",
            "Bent Spear",
            "Jagged Blade",
            "Splintered Staff",
            "Basic Cutlass"
        };

        private readonly string[] goodMeleeWeapons = new string[]
        {
            "Stormforged Blade",
            "Voidfang Saber",
            "Crimson Reaver",
            "Runesteel Axe",
            "Obsidian Halberd",
            "Echofang Katana",
            "Titan's Maul",
            "Soulpiercer Spear",
            "Frostbrand Sword",
            "Nightshade Scythe"
        };

        public int Boost { get; set; }
        public Weapon() : base()
        {
            bool IsGood = Utility.FiftyFifty();
            if(IsGood) { 
                Name = goodMeleeWeapons[Utility.GetRandomIndex(0, goodMeleeWeapons.Length)];
                Boost = 3;
                Value = 30;
                Durability = 20;
            }
            else
            {
                Name = midMeleeWeapons[Utility.GetRandomIndex(0, midMeleeWeapons.Length)];
                Boost = 1;
                Value = 10;
                Durability = 10;
            }

        }
        public override void EquipItem(Player player)
        {
            if (Durability <= 0)
            {
                Console.WriteLine($"{Name} is broken and cannot be equipped.");
                return;
            }
            Console.WriteLine("Are you sure you want to equip this weapon? Anything there will be replaced?");
            Console.WriteLine("1) Equip item 2) Cancel");
            int decision = Utility.PrintMenu(2);
            if (decision == 1)
            {
                player.Weapon = this;
                Console.WriteLine(player.Weapon.Name);
            }
            else
            {
                Console.WriteLine("Item not equipped.");
            }
        }
    }
}
