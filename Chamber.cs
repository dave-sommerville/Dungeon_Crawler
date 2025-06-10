using System.Numerics;
using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Items.Potions;

namespace Dungeon_Crawler
{
    public class Chamber
    {
        private readonly string[] dungeonPassages = new string[]
        {
            "a narrow stone archway leads into the next chamber.",
            "a heavy wooden door reinforced with iron bands blocks the passage.",
            "an open corridor stretches ahead, framed by crumbling pillars.",
            "a worn staircase descends into shadow beneath a low ceiling.",
            "a rusted iron gate stands slightly ajar, groaning when moved.",
            "a plain stone door rests flush with the wall, almost hidden.",
            "a rough-cut tunnel branches off, barely tall enough to stand in.",
            "a heavy portcullis looms above, its chains thick with rust.",
            "a short, sloping passage disappears into the gloom ahead.",
            "a curved hallway twists sharply to the right, just past a low arch.",
            "a set of stone steps leads up to a carved doorway.",
            "a crumbling archway reveals a narrow exit to the south.",
            "a thick curtain of old leather hangs where a door once stood.",
            "a broken wooden door slumps off its hinges to the side.",
            "a long hallway disappears into darkness, lined with rough-cut stone.",
            "a jagged opening gapes in the wall, like it was torn out recently.",
            "an ornate metal door stands silently, locked or just stubborn.",
            "a low crawlspace forces you to duck beneath jagged stone.",
            "a sealed stone slab bears faint runes along its edge.",
            "a hidden panel in the wall slides open to reveal a secret tunnel.",
            "a tunnel curves away into blackness, carved hastily and unevenly.",
            "a creaking hatch leads downward by iron ladder.",
            "a door of blackened wood bears scorch marks and claw scratches.",
            "a carved arch bears no door, only thick darkness beyond.",
            "a rotting tapestry hangs over an open doorway.",
            "a heavy stone frame surrounds a narrow slit of a passage.",
            "a trapdoor lies at your feet, surrounded by dust and cobwebs.",
            "a narrow bridge crosses a gap and leads to a heavy stone door.",
            "a simple rope ladder descends through a hole in the floor.",
            "a corridor lined with faint torch sconces bends out of view."
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
        public int ChamberGold { get; set; } = 0;
        // Event master control
        private readonly int TierOne = 2;
        private readonly int TierTwo = 4;
        private readonly int TierThree = 94;
        private readonly int TierFour = 96;
        private readonly int TierFive = 98;
        private readonly int MasterIndex = 100;
        public Chamber(string id, string description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
            ChamberLoot = new List<Item>();
            if (Utility.FiftyFifty())
            {
                ChamberGold = Utility.GetRandomIndex(2, 20);
            }
        }
        public void DisplayDescription()
        {
            Utility.Print("");
            Utility.Print(Description);
            DisplayPassages();
            Utility.Print("");
        }
        public void RandomizePassages()
        {
            NorthPassage = Utility.FiftyFifty();
            SouthPassage= Utility.FiftyFifty();
            EastPassage= Utility.FiftyFifty();
            WestPassage= Utility.FiftyFifty();
        }
        public void ReturnPassages(string choice)
        {
            switch (choice)
            {
                case "n":
                    SouthPassage = true;
                    break;
                case "s":
                    NorthPassage = true;
                    break;
                case "e":
                    WestPassage = true;
                    break;
                case "w":
                    EastPassage = true;
                    break;
            }
        }
        public void DisplayPassages()
        {
            Utility.Print("");
            if (NorthPassage)
            {
                Utility.Print("To the North " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (SouthPassage)
            {
                Utility.Print("To the South " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (EastPassage)
            {
                Utility.Print("To the East " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            if (WestPassage)
            {
                Utility.Print("To the West " + dungeonPassages[Utility.GetRandomIndex(0, dungeonPassages.Length)]);
            }
            Utility.Print("");
            Utility.Print("");
        }
        public void MasterEventsTree(Player player)
        {
            int randomEvent = Utility.GetRandomIndex(1, MasterIndex);
            if (randomEvent >= 1 && randomEvent <= TierOne)
            {
                Utility.Print("You encounter a hazard in the chamber.");
                HazardEvent(player);
            }
            else if (randomEvent > TierOne && randomEvent <= TierTwo)
            {
                Utility.Print("You trigger a trap in the chamber.");
                Trap chamberTrap = TrapEvent(player);
                chamberTrap.TrapCheck(player);
            }
            else if (randomEvent > TierTwo && randomEvent <= TierThree)
            {
                Utility.Print("You encounter a monster in the chamber.");
                Monster chamberMonster = MonsterEvent(player);
                player.MonsterFight(chamberMonster);
            }
            else if(randomEvent > TierThree && randomEvent <= TierFour)
            {
                NpcEvent(player);
            } else if (randomEvent > TierFour && randomEvent <= TierFive)
            {
                Utility.Print("You encounter a merchant in the chamber.");
                NPC chamberMerchant = MerchantEvent(player);
                chamberMerchant.MarketPlace(player);
            }
            else 
                {
                Utility.Print("Nothing happens.");
            }
        }
        public Trap TrapEvent(Player player)
        {
            Trap trap = new Trap(player.PlayerLevel);
            Trap = trap;
            return trap;
        }
        public Monster MonsterEvent(Player player)
        {
            Monster monster = new Monster(player.PlayerLevel);
            return monster;
        }
        public void Rest(Player player)
        {
            Utility.Print("You prepare the room to sleep for the night");
            int restEncounter = Utility.GetRandomIndex(1, 10);
            if (restEncounter <= 3)
            {
                Utility.Print("You are ambushed while you sleep! You get no rest and the monster is attacking.");
                Monster chamberMonster = MonsterEvent(player);
                player.MonsterFight(chamberMonster);
            } else
            {
                Utility.Print("You have a peaceful sleep. You feel fully rested.");
                player.RestCounter = 0;
            }
        }
        public void NpcEvent(Player player)
        {
            if (player.MushroomMan == null)
            {
                NPC mushroomMan = new NPC();
                mushroomMan.RandomizeAttributes();
                mushroomMan.Name = "The creature";
                player.MushroomMan = mushroomMan;
                mushroomMan.InitialInteraction(player);
            } else
            {
                player.MushroomMan.RandomizeAttributes();
                player.MushroomMan.InteractWithNpc(player);
            }
            player.ProcessCharisma();
            player.MushroomMan.EquipBagOfCarrying(player);
        }
        public NPC MerchantEvent(Player player)
        {
            NPC merchant = new NPC();
            merchant.Name = "Jeff";
            return merchant;
        }
        public void HazardEvent(Player player)//
        {
            if (player.PrisonerStatus == 0)
            {
                Utility.Print("Inside this chamber is a cage with a prisoner inside.");

                Utility.Print("He is in a bad state and begs for help.");
                Utility.Print("He is an Orc standing around six and a half feet tall.");
                Utility.Print("Do you want to free the prisoner? (y/n)");
                string choice = Utility.Read();
                if(choice == "y")
                {
                    Utility.Print("You free the prisoner. He looms over you for a moment");
                    Utility.Print("Then he thanks you briefly and runs through an entrance and disappears into the dungeon");
                    player.PrisonerStatus = 1;
                }
                else
                {
                    Utility.Print("You leave the prisoner in the cage.");
                    player.PrisonerStatus = 2;
                }
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
            Utility.Print("You are caught in a cloud of spores. You feel dizzy and disoriented.");
            Utility.Print("Strange visions in the shadows plague you and off");
            Utility.Print("After an indeterminate amount of time the effects wear off but your sanity doesn't full recover");
            Utility.Print($"You lose {madnessLvl} sanity points.");
            player.Sanity -= madnessLvl;
        }
        public void PoisonGasEvent(Player player)
        {
            int poisonLvl = 5;
            Utility.Print("You are caught in a cloud of poison gas. You fall to your knees coughing.");
            Utility.Print("You feel your lungs burning but you push through and you can eventually breathe clearly again");
            Utility.Print($"You do take some permanent damage however and lose {poisonLvl} maximum health points");
            player.MaxHP -= poisonLvl;
        }
        public void RustMonsterEvent(Player player)
        {
            Utility.Print("Oh no, Rust Monsters!!\nThese disgusting critters couldn't care less about hurting you");
            Utility.Print("Unfortunately, they have a ravenous appetite for your weapons and armor.");
            Console.WriteLine();
            Utility.Print("**You are swarmed by these creatures and your weapon and shield dissolve in front of your eyes**");
            player.Weapon = null;
            player.Armor = null;
        }
        public void SlimeEvent(Player player)
        {
            Utility.Print("You are caught in a pool of slime. You feel your skin crawling.");
            Utility.Print("Disgusting but harmless, the sludge is difficult to get through and takes twice as much energy");
            player.RestCounter += 1;
        }
        public void AddChamberLoot()
        {
            int weaponIndex = Utility.GetRandomIndex(0,10);
            int armorIndex = Utility.GetRandomIndex(0,10);
            int potionIndex = Utility.GetRandomIndex(0,10);
            if (weaponIndex > 5)
            {
                Weapon weapon = new Weapon();
                ChamberLoot.Add(weapon);
            }
            if (armorIndex > 5)
            {
                Armor armor = new Armor();
                ChamberLoot.Add(armor);
            }
            if (potionIndex > 4)
            {
                int potionType = Utility.GetRandomIndex(0, 700);
                Potion chamberPotion = null;
                if (potionType < 20)
                {
                    chamberPotion = new PotionOfKnowledge();
                    ChamberLoot.Add(chamberPotion);
                } else if (potionType < 900)
                {
                    chamberPotion = new PotionOfRestoration();
                    ChamberLoot.Add(chamberPotion);
                } else if (potionType < 280)
                {
                    chamberPotion = new PotionOfMana();
                    ChamberLoot.Add(chamberPotion);
                } else
                {
                    chamberPotion = new PotionOfHealing();
                    ChamberLoot.Add(chamberPotion);
                }
            }
        }
        public void SearchForLoot(Player player)
        {
            int trapTrigger = Utility.GetRandomIndex(1, 10);
            if (trapTrigger < 3)
            {
                TrapEvent(player);
            }
            if ((player.Perception + Utility.GetRandomIndex(7,10)) > 5)
            {
                Utility.Print("You search around the chamber.");
                if (ChamberLoot == null)
                {
                    Utility.Print("No items are found.");
                }
                else
                {
                    foreach (Item item in ChamberLoot)
                    {
                        Utility.Print($"You find a {item.Name}.");
                        player.AddToInventory(item);
                    }
                }
                if (ChamberGold > 0)
                {
                    Utility.Print($"You find {ChamberGold} gold coins.");
                    player.Gold += ChamberGold;
                }
            }

        }
    }
}
