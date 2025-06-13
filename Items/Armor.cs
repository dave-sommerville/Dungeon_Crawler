using System;
using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Items
{
    public class Armor : Item
    {
        private readonly string[] goodArmorMaterials = new string[]
        {
            "Cured Leather",
            "Forged Chainmail",
            "Polished Bronzeplate",
            "Tempered Ironmail",
            "Hardened Studded Leather",
            "Scaled Hide Vest",
            "Wrought Iron Lamellar",
            "Beaten Copper Guard"
        };


        private readonly string[] midArmorMaterials = new string[]
        {
            "Thin Leather",
            "Rusty Chainmail",
            "Dull Bronzeplate",
            "Brittle Ironmail",
            "Scuffed Studded Leather",
            "Faded Hide Vest",
            "Light Wrought Iron Lamellar",
            "Bent Copper Guard"
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
                Value = 15;
            }
            else
            {
                Name = midArmorMaterials[Utility.GetRandomIndex(0, midArmorMaterials.Length)];
                AC = 1;
                Value = 5;
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
