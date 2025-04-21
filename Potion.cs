using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Potion : Item 
    {
        public Random random = new Random();
        public int Potency { get; set; }
        public Potion() : base()
        {
            Name = "Potion of Healing"; //I think I will need to add classes to add more potion effects, but this'll do for now
            Description = "Healing potion";
            Durability = 1;
            Potency = 10; // Default potency
        }
        public override void DisplayItem()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Worth {Potency} healing points");
        }
        public override void EquipItem(Player player)
        {
            player.Health += Potency;
            Console.WriteLine($"You drink the {Name} and heal {Potency} health points.");
        }
    }
}
