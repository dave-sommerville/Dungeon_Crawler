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
        
    }
}
