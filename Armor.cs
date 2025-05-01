using Dungeon_Crawler;
using System;

namespace Dungeon_Crawler
{
    public class Armor : Item
    {
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
            bool IsGood = Utility.FiftyFifty();
            if (IsGood)
            {
                Name = goodArmorMaterials[Utility.GetRandomIndex(0, goodArmorMaterials.Length)];
                AC = 3;
            }
            else
            {
                Name = midArmorMaterials[Utility.GetRandomIndex(0, midArmorMaterials.Length)];
                AC = 1;
            }

        }
        public override void EquipItem(Player player)
        {
            if (Durability <= 0)
            {
                Utility.Print($"{Name} is broken and cannot be equipped.");
                return;
            }
            Utility.Print("Are you sure you want to equip this armor? Anything there will be replaced?");
            Utility.Print("1) Equip item 2) Cancel");
            int decision = Utility.PrintMenu(2);
            if (decision == 1)
            {
                player.Armor = this;
                player.ArmorClass += AC;
            }
            else
            {
                Utility.Print("Item not equipped.");
            }
        }
    }
}
