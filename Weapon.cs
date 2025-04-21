namespace Dungeon_Crawler
{
    public class Weapon : Item
    {
        public int Boost { get; set; }
        public Weapon(string name, string description, int durability, int boost) : base()
        {
            Name = name;
            Description = description;
            Durability = durability;
            Boost = boost;
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
            int decision = Player.PrintMenu(2);
            if (decision == 1)
            {
                player.Weapon = this;
            }
            else
            {
                Console.WriteLine("Item not equipped.");
            }
        }
    }
}
