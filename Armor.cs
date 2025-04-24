using Dungeon_Crawlerx;
using System;

namespace Dungeon_Crawler
{
    public class Armor : Item
    {
        Random random = new Random();
        private readonly string[] midArmorMaterials = new string[]
        {
            "Leather",
            "Chainmail",
            "Bronze",
            "Iron"
        };

        private readonly string[] goodArmorMaterials = new string[]
        {
            "Mythril",
            "Dragonhide",
            "Adamantite",
            "Runesteel"
        };

        public int AC { get; set; } 

        public Armor() : base()
        {
            Durability = 10;
            bool IsGood = FiftyFifty();
            if (IsGood)
            {
                Name = goodArmorMaterials[random.Next(goodArmorMaterials.Length)];
                AC = 3;
            }
            else
            {
                Name = midArmorMaterials[random.Next(midArmorMaterials.Length)];
                AC = 1;
            }

        }
        public bool FiftyFifty()
        {
            return new Random().NextDouble() < 0.5;
        }
        public override void EquipItem(Player player)
        {
            if (Durability <= 0)
            {
                Console.WriteLine($"{Name} is broken and cannot be equipped.");
                return;
            }
            Console.WriteLine("Are you sure you want to equip this armor? Anything there will be replaced?");
            Console.WriteLine("1) Equip item 2) Cancel");
            int decision = Player.PrintMenu(2);
            if (decision == 1)
            {
                player.Armor = this;
                player.ArmorClass += AC;
            }
            else
            {
                Console.WriteLine("Item not equipped.");
            }
        }
    }
}
