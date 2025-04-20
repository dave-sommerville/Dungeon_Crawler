namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // All templates will be moved to classes 
        // Flags on Program (IsCursed, PrisonerFreed, )
        // Events manage p[layer movement and rest, everything else can be object based 
        // Move triggers weighted randomness trees, first between models then between offering of models
        // With the exception of certain triggers that require a certain room
        // Special event, trap, attack, empty 
        // Special events: Merchant, NPC(special(prisoner, mini-bosses) and generic), Rust monsters, Slimes
        // Monsters: Monster attack must adjust based on player xp, traps must scale damage based on xp or hp 
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
            Dungeon dungeon = new Dungeon();
            Console.WriteLine("Welcome to my Dungeon");
            Console.WriteLine("Enter your name to begin");
            Console.WriteLine("");

            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            player.OnBattle += MonsterBattle;
            player.OnBlast += MonsterBlast;
            player.OnFlee += FleeMonster;
            player.OnTrigger += TriggerTrap;
            player.OnSearch += SearchForRelics;
            player.OnSearch += SearchForGold;
            player.OnSearch += SearchForPotions;
            Console.WriteLine("Follow the instructions to move through the dungeon");
            Console.WriteLine("Walls are invisible currently, so you may not be able to go every direction");
            Console.WriteLine("You can always flee an enemy, but they'll attack as you go. Use your mana blast's wisely, as they bring certain death but you only have so many");
            bool IsRunning = true;
            while(IsRunning && player.Health > 0)
            {
                Console.WriteLine("\nYou are in room " + player.LocationId);
                dungeon.StartingPoint.DisplayDescription();
                Console.WriteLine("n) Move North");
                Console.WriteLine("s) Move South");
                Console.WriteLine("e) Move East");
                Console.WriteLine("w) Move West");
                Console.WriteLine("p) Display Player Details");
                Console.WriteLine("x) Exit Game");
                string decision = Console.ReadLine()?.ToLower();
                switch (decision)
                {
                    case "n":
                    case "s":
                    case "e":
                    case "w":
                        player.MovePlayer(decision, dungeon);
                        break;
                    case "p":
                        player.PrintPlayerDetails();
                        break;
                    case "x":
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
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
        }

        public static void TriggerTrap(Player player)
        {
            int randIndex = GetRandomIndex(1,3);
            if (randIndex == 1)
            {
                int arrInd = GetRandomIndex(0, DamagingTraps.Count());
                string trapDescription = DamagingTraps[arrInd];
                Console.WriteLine($"{trapDescription}");
                int damage = GetRandomIndex(5,25);
                player.Health -= damage;
                Console.WriteLine($"{player.Name}'s health reduced by {damage}");
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
                Console.WriteLine("No items of note");
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
                player.Health += hp;//Should have a max hp
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