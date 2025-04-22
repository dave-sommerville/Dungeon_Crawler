namespace Dungeon_Crawler
{
    public class Chamber
    {
        public Random random = new Random();

        private readonly string[] dungeonPassages = new string[]
        {
            "A narrow stone archway leads into the next chamber.",
            "A heavy wooden door reinforced with iron bands blocks the passage.",
            "An open corridor stretches ahead, framed by crumbling pillars.",
            "A worn staircase descends into shadow beneath a low ceiling.",
            "A rusted iron gate stands slightly ajar, groaning when moved.",
            "A plain stone door rests flush with the wall, almost hidden.",
            "A rough-cut tunnel branches off, barely tall enough to stand in.",
            "A heavy portcullis looms above, its chains thick with rust.",
            "A short, sloping passage disappears into the gloom ahead.",
            "A curved hallway twists sharply to the right, just past a low arch.",
            "A set of stone steps leads up to a carved doorway.",
            "A crumbling archway reveals a narrow exit to the south.",
            "A thick curtain of old leather hangs where a door once stood.",
            "A broken wooden door slumps off its hinges to the side.",
            "A long hallway disappears into darkness, lined with rough-cut stone.",
            "A jagged opening gapes in the wall, like it was torn out recently.",
            "An ornate metal door stands silently, locked or just stubborn.",
            "A low crawlspace forces you to duck beneath jagged stone.",
            "A sealed stone slab bears faint runes along its edge.",
            "A hidden panel in the wall slides open to reveal a secret tunnel.",
            "A tunnel curves away into blackness, carved hastily and unevenly.",
            "A creaking hatch leads downward by iron ladder.",
            "A door of blackened wood bears scorch marks and claw scratches.",
            "A carved arch bears no door, only thick darkness beyond.",
            "A rotting tapestry hangs over an open doorway.",
            "A heavy stone frame surrounds a narrow slit of a passage.",
            "A trapdoor lies at your feet, surrounded by dust and cobwebs.",
            "A narrow bridge crosses a gap and leads to a heavy stone door.",
            "A simple rope ladder descends through a hole in the floor.",
            "A corridor lined with faint torch sconces bends out of view."
        };


        public string ChamberId { get; set; }
        public string Description { get; set; }
        public bool NorthPassage { get; set; }
        public bool SouthPassage { get; set; }
        public bool EastPassage { get; set; }
        public bool WestPassage { get; set; }
        public NPC? NPC { get; set; }
        public Trap? Trap { get; set; }
        public Monster? Monster { get; set; }
        public Chamber(string id, string description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
        }
        public void DisplayDescription()
        {
            Console.WriteLine(Description);
            DisplayPassages();
        }
        public bool FiftyFifty()
        {
            return new Random().NextDouble() < 0.5;
        }
        public void RandomizePassages()
        {
            NorthPassage = FiftyFifty();
            SouthPassage= FiftyFifty();
            EastPassage= FiftyFifty();
            WestPassage= FiftyFifty();
        }
        public void DisplayPassages()
        {
            if (NorthPassage)
            {
                Console.WriteLine("To the North " + dungeonPassages[random.Next(dungeonPassages.Length)]);
            }
            if (SouthPassage)
            {
                Console.WriteLine("To the South " + dungeonPassages[random.Next(dungeonPassages.Length)]);
            }
            if (EastPassage)
            {
                Console.WriteLine("To the East " + dungeonPassages[random.Next(dungeonPassages.Length)]);
            }
            if (WestPassage)
            {
                Console.WriteLine("To the West " + dungeonPassages[random.Next(dungeonPassages.Length)]);
            }
        }
        public static int GetRandomIndex(int min, int max)
        {
            Random random = new Random();
            int randomInt = random.Next(min, max);
            return randomInt;
        }
        public void MasterEventsTree(Player player)
        {
            int randomEvent = GetRandomIndex(1, 10);
            if (randomEvent <= 1)
            {
                // Trigger a special event
                Console.WriteLine("A special event has occurred!");
            }
            else if (randomEvent <= 3)
            {
                Trap chamberTrap = TrapEvent(player);
                chamberTrap.TrapCheck(player);
            }
            else if (randomEvent <= 6)
            {
                Monster chamberMonster = MonsterEvent(player);
                player.MonsterFight(chamberMonster);
            }
            else
            {
                // No event
                Console.WriteLine("Nothing happens.");
            }
        }
        public Trap TrapEvent(Player player)
        {
            Trap trap = new Trap();
            Trap = trap;
            return trap;
        }
        public Monster MonsterEvent(Player player)
        {
            Monster monster = new Monster("Goblin", "A small, green-skinned creature with a nasty disposition.");
            return monster;
        }
        public static void SpecialEventsTree(Player player)
        {
            int specialEventSelector = GetRandomIndex(1, 10);
            switch(specialEventSelector)
            {
                case 1:
                    RustMonsterEvent(player);
                    break;
                case 2:
                    SlimeEvent();
                    break;
                case 3:                         //Can build this out more elsewhere, but this'll do for now
                    NPC merchant = new NPC("Merchant Frank", "A shady figure with a glint in their eye.");
                    merchant.MarketPlace(player);
                    break;
            }
        }
        public static void RustMonsterEvent(Player player)
        {
            Console.WriteLine("Oh no, Rust Monsters!!\nThese disgusting critters couldn't care less about hurting you");
            Console.WriteLine("Unfortunately, they have a ravenous appetite for your weapons and armor.");
            Console.WriteLine();
            Console.WriteLine("**You are swarmed by these creatures and your weapon and shield dissolve in front of your eyes**");
            player.Weapon = null;
            player.Armor = null;
        }
        public static void SlimeEvent()
        {

        }

        public static List<Item> GetLoot()
        {
            List<Item> loot = new List<Item>();
            return loot;
        }
        public void PrisonerDilemma(Player player, Dungeon dungeon)
        {
            if (player.PlayerLevel >= 5 && random.Next(1,5) > 2) 
            {
                player.PrisonerReleased = true;
                NPC prisoner = new NPC("Prisoner", "A desperate figure bound in chains.");
                NPC = prisoner;
            }
        }
    }
}
