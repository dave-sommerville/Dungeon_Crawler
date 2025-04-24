namespace Dungeon_Crawler
{
    public class Armor : Item
    {
        public int AC { get; set; } 
        public Armor() : base()
        {
            Name = "Armor"; // Kinda silly default values 
            Description = "This is an armor.";
            Durability = 100;
            AC = 0;
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
