﻿using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;
namespace Dungeon_Crawler.Items.Potions
{
    public class PotionOfKnowledge : Potion
    {
        public PotionOfKnowledge() : base()
        {
            Name = "Potion of Knowledge";
            Description = "A potion that grants you knowledge.";
            Potency = 5;
        }
        public override void EquipItem(Player player)
        {
            Utility.Print("You feel a surge of ability well up in you. You can spend one skill point on a skill of your choice");
            player.IncreaseModifier();
        }
    }
}
