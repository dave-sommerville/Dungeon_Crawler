using System.Numerics;

namespace Dungeon_Crawler
{
    public class Chamber
    {
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

        private readonly List<Item> PossibleLoot = new List<Item>
        {
            new Armor(),
            new Armor(),
            new Weapon(),
            new Weapon(),
            new Potion(),
            new Potion()
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
        public List<Item>? ChamberLoot { get; set; }
        public Chamber(string id, string description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
            ChamberLoot = new List<Item>();
        }
        public void DisplayDescription()
        {
            Console.WriteLine(Description);
            DisplayPassages();
        }
        public void RandomizePassages()
        {
            NorthPassage = Utility.FiftyFifty();
            SouthPassage= Utility.FiftyFifty();
            EastPassage= Utility.FiftyFifty();
            WestPassage= Utility.FiftyFifty();
        }
        public void DisplayPassages()
        {
            if (NorthPassage)
            {
                Console.WriteLine("To the North " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (SouthPassage)
            {
                Console.WriteLine("To the South " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (EastPassage)
            {
                Console.WriteLine("To the East " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (WestPassage)
            {
                Console.WriteLine("To the West " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
        }
        public List<Item> AddLootToChamber()
        {
            List<Item> chamberLoot = new List<Item>();
            int lootIndex = Utility.GetRandomIndex(0, 3);
            if (lootIndex == 0)
            {
                int lootCount = Utility.GetRandomIndex(1, 3);
                for (int i = 0; i < lootCount; i++)
                {
                    Item lootItem = PossibleLoot[Utility.GetRandomIndex(0, PossibleLoot.Count)];
                    chamberLoot.Add(lootItem);
                }
            }
            return chamberLoot;
        }
        private readonly int TierOne = 3;
        private readonly int TierTwo = 4;
        private readonly int TierThree = 80;
        private readonly int TierFour = 90;
        private readonly int TierFive = 98;
        private readonly int MasterIndex = 100;

        public void MasterEventsTree(Player player)
        {
            int randomEvent = Utility.GetRandomIndex(1, MasterIndex);
            if (randomEvent >= 1 && randomEvent <= TierOne)
            {
                Console.WriteLine("You encounter a hazard in the chamber.");
                HazardEvent(player);
            }
            else if (randomEvent > TierOne && randomEvent <= TierTwo)
            {
                Console.WriteLine("You trigger a trap in the chamber.");
                Trap chamberTrap = TrapEvent(player);
                chamberTrap.TrapCheck(player);
            }
            else if (randomEvent > TierTwo && randomEvent <= TierThree)
            {
                Console.WriteLine("You encounter a monster in the chamber.");
                Monster chamberMonster = MonsterEvent(player);
                player.MonsterFight(chamberMonster);
            }
            else if(randomEvent > TierThree && randomEvent <= TierFour)
            {
                Console.WriteLine("You encounter an NPC in the chamber.");
                NpcEvent(player);
            } else if (randomEvent > TierFour && randomEvent <= TierFive)
            {
                Console.WriteLine("You encounter a merchant in the chamber.");
                NPC chamberMerchant = MerchantEvent(player);
                chamberMerchant.MarketPlace(player);
            }
            else 
                {
                Console.WriteLine("Nothing happens.");
            }
        }
        public Trap TrapEvent(Player player)
        {
            Trap trap = new Trap(player.PlayerLevel);
            Trap = trap;
            return trap;
        }//
        public Monster MonsterEvent(Player player)
        {
            Monster monster = new Monster(player.PlayerLevel);
            return monster;
        }
        public void Rest(Player player)
        {
            Console.WriteLine("You prepare the room to sleep for the night");
            int restEncounter = Utility.GetRandomIndex(1, 10);
            if (restEncounter <= 3)
            {
                Console.WriteLine("You are ambushed while you sleep! You get no rest and the monster is attacking.");
                Monster chamberMonster = MonsterEvent(player);
                player.MonsterFight(chamberMonster);
            } else
            {
                Console.WriteLine("You have a peaceful sleep. You feel fully rested.");
                player.RestCounter = 0;
            }
        }
        public void NpcEvent(Player player)
        {
            if (player.MushroomMan == null)
            {
                NPC mushroomMan = new NPC();
                player.MushroomMan = mushroomMan;
                mushroomMan.InteractWithNpc(player);
            } else
            {
                player.MushroomMan.InteractWithNpc(player);
            }
        }
        public NPC MerchantEvent(Player player)
        {
            NPC merchant = new NPC();
            return merchant;
        }//
        public void HazardEvent(Player player)//
        {
            if (player.PrisonerStatus == 0)
            {
                Console.WriteLine("You encounter a prisoner in the chamber.");
                // This function must change the prisoner status depending on the player's choice
            }
            else {
                int hazardType = Utility.GetRandomIndex(1, 5);
                if (hazardType == 1)
                {
                    RustMonsterEvent(player);
                } else if (hazardType == 2)
                {
                    SlimeEvent(player);
                } else if(hazardType == 3)
                {
                    SporesEvent(player);
                } else
                {
                    PoisonGasEvent(player);
                }
            }
        }
        public void SporesEvent(Player player)
        {
            int madnessLvl = 10;
            Console.WriteLine("You are caught in a cloud of spores. You feel dizzy and disoriented.");
            Console.WriteLine("Strange visions in the shadows plague you and off");
            Console.WriteLine("After an indeterminate amount of time the effects wear off but your sanity doesn't full recover");
            Console.WriteLine($"You lose {madnessLvl} sanity points.");
            player.Sanity -= madnessLvl;
        }
        public void PoisonGasEvent(Player player)
        {
            int poisonLvl = 5;
            Console.WriteLine("You are caught in a cloud of poison gas. You fall to your knees coughing.");
            Console.WriteLine("You feel your lungs burning but you push through and you can eventually breathe clearly again");
            Console.WriteLine($"You do take some permanent damage however and lose {poisonLvl} maximum health points");
            player.MaxHP -= poisonLvl;
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
        public static void SlimeEvent(Player player)
        {
            Console.WriteLine("You are caught in a pool of slime. You feel your skin crawling.");
            Console.WriteLine("Disgusting but harmless, the sludge is difficult to get through and takes twice as much energy");
            player.RestCounter += 1;
        }
        //public void PrisonerDilemma(Player player, Dungeon dungeon)
        //{
        //    if (player.PlayerLevel >= 5 && random.Next(1,5) > 2) 
        //    {
        //        player.PrisonerReleased = true;
        //        NPC prisoner = new NPC("Prisoner", "A desperate figure bound in chains.");
        //        NPC = prisoner;
        //    }
        //}
        public void SearchForLoot(Player player)
        {
            int trapTrigger = Utility.GetRandomIndex(1, 10);
            if (trapTrigger < 3)
            {
                TrapEvent(player);
            }
            if ((player.Perception + Utility.GetRandomIndex(7,10)) > 5)
            {
                Console.WriteLine("You search the chamber and discover the following");
                foreach(Item item in ChamberLoot)
                {
                    Console.WriteLine($"You find a {item.Name}.");
                    player.AddToInventory(item);
                }
                int gold = Utility.GetRandomIndex(1,100);
                Console.WriteLine($"You find {gold} gold coins.");
                player.Gold += gold;
            }

        }
    }
}
