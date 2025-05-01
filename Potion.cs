using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Potion : Item 
    {
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
            Utility.Print($"Name: {Name}");
            Utility.Print($"Worth {Potency} healing points");
        }
        public override void EquipItem(Player player)
        {
            player.Health += Potency;
            if (player.Health > player.MaxHP) { player.Health = player.MaxHP; }
            Utility.Print($"You drink the {Name} and heal {Potency} health points.");
        }
    }
}
