using System.Runtime.CompilerServices;

namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        public static List<string> Relics = new List<string>
        {
            "Rusty Iron Sword",
            "Moldy Leather Pouch of Copper Coins",
            "Silver Goblet with Ruby Inlay",
            "Broken Wooden Shield",
            "Ancient Bronze Helmet",
            "Cracked Crystal Orb",
            "Tarnished Silver Dagger",
            "Gold Necklace with a Missing Gem",
            "Bundle of Old Arrows",
            "Ornate Key with Strange Markings",
            "Small Pouch of Bone Dice",
            "Steel Warhammer with Dwarven Runes",
            "Jeweled Ring of Unknown Origin",
            "Set of Rusted Lockpicks",
            "Bloodstained Bandages",
            "Carved Wooden Idol of a Forgotten Deity",
            "Chipped Sapphire Pendant",
            "Bronze Bell with an Eerie Chime",
            "Obsidian Dagger with a Serpentine Handle",
            "Scroll Case Containing Illegible Writings",
            "Silver Chainmail Shirt, Slightly Damaged",
            "Tattered Map Marking a Lost Crypt",
            "A Jar of Preserved Eyeballs",
            "Glowing Blue Crystal Shard",
            "Ancient Coin Stamped with an Unknown Emperor",
            "Black Iron Gauntlets, Warm to the Touch",
            "Bundle of Moth-Eaten Spellbooks",
            "A Locked Music Box Playing a Haunting Melody",
            "Dragon Bone Dice Set",
            "Golden Arrow with No Fletching",
            "A Flask of Ever-Chilled Water",
            "Pair of Silent Iron Boots",
            "Engraved Copper Bracelet",
            "A Severed Hand Clutching a Gemstone",
            "Rusted Lantern that Still Burns with Green Flame",
            "A Box of Teeth, Each Carved with Symbols",
            "Mummified Finger in a Small Silk Pouch",
            "An Unfinished Stone Chess Set",
            "A Cloak Stitched with Moving Constellations",
            "An Empty Book that Absorbs Ink",
            "A Wooden Mask That Whispers When Worn",
            "A Dagger That Drips Blood, Even When Cleaned",
            "An Hourglass That Reverses Time Slightly When Flipped",
            "A Blackened Crown that Feels Heavy with Regret",
            "A Set of Bone Flutes That Play Themselves",
            "An Unfired Clay Figurine That Warms in Your Hands",
            "A Candle That Burns Without Melting",
            "A Set of Silver Coins That Always Total 13",
            "A Helm That Echoes the Voices of the Dead",
            "A Glove That Writes on Walls When Worn"
        };

        public static List<string> DungeonChambers = new List<string>
        {
            "A damp stone chamber with flickering torchlight and ancient carvings on the walls.",
            "A musty library filled with rotting scrolls and a single intact tome on a pedestal.",
            "A circular room with a pit in the center, from which strange whispers echo.",
            "A flooded chamber where only the tops of broken pillars emerge from the dark water.",
            "A crypt-like hall lined with sarcophagi, some of which are slightly ajar.",
            "A cavernous space where glowing mushrooms cling to the ceiling, casting eerie light.",
            "A blacksmith's forge, long abandoned, with rusted weapons scattered across the floor.",
            "A small chamber filled with ominous statues, their hollow eyes seeming to watch you.",
            "A throne room in ruins, with a tattered banner hanging above a cracked stone seat.",
            "A treasury looted long ago, save for a single, locked chest in the corner.",
            "A corridor with shifting walls, revealing hidden doors and long-forgotten passageways.",
            "A ritual chamber with a bloodstained altar and a lingering scent of incense."
        };
        public static List<string> CloseCallTraps = new List<string>
        {
            "A pressure plate clicks underfoot, but you leap away just in time.",
            "A hidden arrow whizzes past your ear, embedding itself in the wall.",
            "A floor panel tilts beneath you, nearly sending you into a pit of spikes.",
            "A pendulum blade swings down, stopping inches from your face.",
            "A ceiling panel shifts, releasing a shower of sand instead of expected boulders.",
            "You step back just as the ground splits open, revealing a pit beneath.",
            "A burst of flame erupts from a nearby statue, but you dodge behind cover.",
            "An iron cage drops from above, narrowly missing you as it slams shut.",
            "A swarm of mechanical saw blades whirs to life but halts before striking.",
            "A poisonous gas fills the chamber, but a hidden vent clears the air just in time."
        };
        public static List<string> DamagingTraps = new List<string>
        {
            "A row of spears shoots up from the floor, piercing anything above them.",
            "A jet of green flame bursts from the wall, searing everything in its path.",
            "A massive spiked log swings down from the ceiling, smashing into you.",
            "Barbed chains lash out from the walls, wrapping around you with cruel force.",
            "The floor electrifies with a sudden jolt, sending shocks through your body.",
            "A hidden blade slices up from the ground, cutting deep into your legs.",
            "A swarm of venomous darts rains down, leaving painful welts and poison.",
            "The ceiling suddenly collapses, sending jagged stones crashing onto you.",
            "A spinning saw blade erupts from the floor, carving through flesh and bone.",
            "An acidic mist fills the room, burning your skin and making it hard to breathe."
        };

        static void Main(string[] args)
        {
            GameLaunch();
        }
        public static void GameLaunch()
        {
            Player player = new Player("Player");
            player.OnBattle += MonsterBattle;
            player.OnBlast += MonsterBlast;
            player.OnFlee += FleeMonster;
            player.OnTrigger += TriggerTrap;
            player.OnSearch += SearchForRelics;
            player.OnSearch += SearchForGold;
            player.OnSearch += SearchForPotions;


            bool IsRunning = true;
            while(IsRunning && player.Health > 0)
            {
                Console.WriteLine("Please select option\n1) Explore Dungeon\n2) Display Player details\n3) Show instructions\n4) Exit Game");
                int decision = PrintMenu(4);
                switch(decision)
                {
                    case 1:
                        Console.WriteLine("You proceed to the next room");
                        // Describe room
                        ExploreDungeon(player);
                        break;
                    case 2:
                        player.PrintPlayerDetails();
                        break;
                    case 3:
                        Console.WriteLine("Instructions");
                        break;
                    case 4:
                        Console.WriteLine("Exiting game");
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }

        }
        private static int PrintMenu(int options)
        {
            int intDecision;
            bool isValid;
            do
            {
                string decision = Console.ReadLine();
                isValid = int.TryParse(decision, out intDecision) && intDecision >= 1 && intDecision <= options;
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!isValid);
            return intDecision;
        }
        public static void ExploreDungeon(Player player)
        {
            int rand = Random.Next(1,4);
            if (rand == 1)
            {
                MonsterMenu(player);
            } else if (rand == 2)
            {
                Console.WriteLine("Room is clear");
                Console.WriteLine("Choose an action:\n1) Search the room\n2)Continue exploring");
                int decision = PrintMenu(2);
                if (decision == 1)
                {
                    player.Search(player);
                }
            } else if(rand == 3)
            {
                Console.WriteLine("Trap triggered");
                player.Trigger(player);
            }
        }
        public static void MonsterMenu(Player player)
        {
            Monster newMonster = new Monster();
            Console.WriteLine($"A {newMonster.Species} appears in front of you. What do you do?");
            Console.WriteLine("1) Battle Monster\n2) Use a Mana blast against monster\n3) Flee Monster");
            int decision = PrintMenu(3);
            switch (decision)
            {
                case 1:
                    player.Battle(player, newMonster);
                    break;
                case 2:
                    player.Blast(player, newMonster);
                    break;
                case 3:
                    player.Flee(player, newMonster);
                    break;
            }
        }
        public static int GetRandomIndex(int min, int max)
        {
            Random random = new Random();
            int randomInt = random.Next(min, max);
            return randomInt;
        }
        //  Delegate subscriptions 
        public static void MonsterBattle(Player player, Monster monster)
        {
            bool battleRunning = true;
            while(battleRunning)
            {
               if(monster.Health > 0)
                {
                    monster.MonsterAttack(player);
                } else if(monster.Health <= 0)
                {
                    battleRunning = false;
                }
                if (player.Health > 0)
                {
                    player.PlayerAttack(monster);
                }
                else if (player.Health <= 0)
                {
                    battleRunning = false;
                }
            }
        }
        public static void MonsterBlast(Player player, Monster monster)
        {
            if (player.Mana >= 1)
            {
                monster.Health = 0;
                player.Mana -= 1;
            } else if (player.Mana <= 0)
            {
                Console.WriteLine($"{player.Name} doesn't have enough Mana");
            }
        }
        public static void FleeMonster(Player player, Monster monster)
        {
            monster.MonsterAttack(player);
            ExploreDungeon(player);
        }

        public static void TriggerTrap(Player player)
        {
            int randIndex = GetRandomIndex(1,3);
            if (randIndex == 1)
            {
                int arrInd = GetRandomIndex(0, DamagingTraps.Count());
                string trapDescription = DamagingTraps[arrInd];
                Console.WriteLine($"{trapDescription}");
            } else {
                int arrInd = GetRandomIndex(0, CloseCallTraps.Count());
                Console.WriteLine($"{player.Name} narrowly avoids taking damage.");
            } 
        }
        public static void SearchForRelics(Player player)
        {
            Random random = new Random();
            if(random.Next(0,6) > 2)
            {
                string foundRelic = Relics[random.Next(0,Relics.Count())];
                player.Inventory.Add(foundRelic);
                Console.WriteLine($"{player.Name} has added {foundRelic} to their inventory");
            } else
            {
                Console.WriteLine("Nothing found");
            }
        }
        public static void SearchForPotions(Player player)
        {
            int randSelect = Random.Next(1,10);
            if(randSelect == 10)
            {
                Console.WriteLine($"{player.Name} found a glowing blue potion. Upon drinking it, they gained 1 mana");
                Console.WriteLine($"{player.Name} Mana Currently: {player.Mana}");
            } else if(randSelect <= 9 && randSelect > 7)
            {
                int hp = Random.Next(1, 3);
                player.Health += hp;//Should have a max xp 
                Console.WriteLine($"{player.Name} found a dark green potion. Upon drinking it, they gained {hp} Health");
            } else
            {
                Console.WriteLine("There are no potions in this room");
            }
        }
        public static void SearchForGold(Player player)
        {
            if (Random.Next(1,10) > 5) 
            {
                int gold = Random.Next(1, 300) * 10;
                Console.WriteLine($"{player.Name} discovered {gold} Gold Pieces in this room");
                player.Gold += gold;
            } else
            {
                Console.WriteLine("No gold found");
            }
        }
    }
}