using Dungeon_Crawler.Characters_and_dialogue;

namespace Dungeon_Crawler.Items.Potions
{
    public class PotionOfMana : Potion
    {
        public PotionOfMana() : base() 
        {
            Name = "Potion of Mana";
            Description = "A potion that grants you mana.";
            Potency = 3;
        }
        public override void EquipItem(Player player)
        {
            player.Mana += Potency;
            Utility.Print($"You drink the {Name} and gain {Potency} mana.");
        }
    }
}
