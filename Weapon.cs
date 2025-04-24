namespace Dungeon_Crawler
{
    public class Weapon : Item
    {
        Random random = new Random();
        private readonly string[] midMeleeWeapons = new string[]
        {
            "Iron Club",
            "Worn Shortsword",
            "Cracked Mace",
            "Rusty Hatchet",
            "Dull Saber",
            "Stone Axe",
            "Bent Spear",
            "Jagged Blade",
            "Splintered Staff",
            "Basic Cutlass"
        };

        private readonly string[] goodMeleeWeapons = new string[]
        {
            "Stormforged Blade",
            "Voidfang Saber",
            "Crimson Reaver",
            "Runesteel Axe",
            "Obsidian Halberd",
            "Echofang Katana",
            "Titan's Maul",
            "Soulpiercer Spear",
            "Frostbrand Sword",
            "Nightshade Scythe"
        };

        public int Boost { get; set; }
        public Weapon() : base()
        {
            bool IsGood = FiftyFifty();
            if(IsGood) { 
                Name = goodMeleeWeapons[random.Next(goodMeleeWeapons.Length)];
                Boost = 3;
            }
            else
            {
                Name = midMeleeWeapons[random.Next(midMeleeWeapons.Length)];
                Boost = 1;
            }

        }
        public bool FiftyFifty()
        {
            return new Random().NextDouble() < 0.5;
        }

        public override void EquipItem(Player player)
        {
            if (Durability <= 0)
            {
                Console.WriteLine($"{Name} is broken and cannot be equipped.");
                return;
            }
            Console.WriteLine("Are you sure you want to equip this weapon? Anything there will be replaced?");
            Console.WriteLine("1) Equip item 2) Cancel");
            int decision = Player.PrintMenu(2);
            if (decision == 1)
            {
                player.Weapon = this;
            }
            else
            {
                Console.WriteLine("Item not equipped.");
            }
        }
    }
}
