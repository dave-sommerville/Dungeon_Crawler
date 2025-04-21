using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Potion : Item 
    {
        // Potion ideas (Healing (max, extra), mana, ac(for a while), skill point(super rare),
        // Rest, Damage??)
        public Random random = new Random();
        public int Potency { get; set; }
        public Potion() : base()
        {
            Name = "Potion"; // Need to change the naming of the potions to be controller by the method
            Description = "A healing potion.";
            Durability = 1;
            Potency = 10; // Default potency
        }
        public override void UseItem(Player player)
        {
            if (Durability > 0)
            {
                player.Health += Potency;
                Durability--; // Remove from inventory after use
                Console.WriteLine($"{player.Name} used a {Name}. Health increased by {Potency}. Remaining durability: {Durability}");
            }
            else
            {
                Console.WriteLine($"{Name} is empty and cannot be used.");
            }
        }
    }
}
