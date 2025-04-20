namespace Dungeon_Crawler
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public Weapon(string name, string description, int durability, int damage, int range) : base()
        {
            Name = name;
            Description = description;
            Durability = durability;
            Damage = damage;
            Range = range;
        }
        public void Attack() // Need to adjust 
        {
            Console.WriteLine($"Attacking with {Name} for {Damage} damage.");
        }
    }
}
