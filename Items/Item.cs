using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public int Rarity { get; set; } = 0;
        public int Value { get; set; } = 0;
        public Item()
        {
            Name = "Item"; // Kinda silly default values 
            Description = "This is an item.";
            Durability = 1;
        }
        public virtual void DisplayItem()
        {
            Utility.Print($"Name: {Name}");
            Utility.Print($"Description: {Description}");
        }
        public virtual void EquipItem(Player player)
        {
            Console.WriteLine("This item can't be used this way");
        }
    }
}
