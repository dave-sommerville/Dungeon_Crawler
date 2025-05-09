using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Characters_and_dialogue;

namespace Dungeon_Crawler.Items.Potions
{
    public class PotionOfRestoration : Potion
    {
        public PotionOfRestoration() : base() 
        {
            Name = "Potion of Restoration";
            Description = "A potion that restores your health and sanity.";
        }
        public override void EquipItem(Player player)
        {
            player.RestCounter = 0;
            player.Health = player.MaxHP;
            player.Mana += 3;
            player.Sanity = 100;
            Utility.Print($"You drink the {Name}. You feel completely rejuvenated.");
        }
    }
}
