using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Items.Potions
{
    public class Potion : Item 
    {
        public int Potency { get; set; }
        public Potion() : base()
        {
            Name = "Dud Potion"; 
            Description = "Bottle of Water";
            Durability = 1;
            Potency = 10;
            Value = Utility.GetRandomIndex(5, 15); // Random value between 5 and 15
        }
        public override void DisplayItem()
        {
            Utility.Print($"Name: {Name}");
            Utility.Print($"Worth {Potency} healing points");
        }
        public override void EquipItem(Player player)
        {
            Utility.Print($"You drink the {Name}. As far as you can tell, nothing happens");
        }
    }
}
