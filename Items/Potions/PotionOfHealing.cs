using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Items.Potions
{
    public  class PotionOfHealing : Potion
    {
        
        public PotionOfHealing() : base()
        {
            Name = "Potion of Healing"; 
            Description = "Healing potion";

        }
        public override void EquipItem(Player player)
        {
            player.Health += Potency;
            if (player.Health > player.MaxHP) { player.Health = player.MaxHP; }
            Utility.Print($"You drink the {Name} and heal {Potency} health points.");
        }
    }
}
