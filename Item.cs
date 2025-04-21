namespace Dungeon_Crawler
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public Item()
        {
            Name = "Item"; // Kinda silly default values 
            Description = "This is an item.";
            Durability = 1;
        }
        public virtual void DisplayItem()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
        }
        public virtual void EquipItem(Player player)
        {
            Console.WriteLine("This item can't be used this way");
        }
    }
}
