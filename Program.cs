namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // All templates will be moved to classes 
        // Character creation actions at beginning of game
        // Flags on Program (IsCursed, PrisonerFreed, IsInRegion)
        // Events manage player movement, levelling, and rest, everything else can be object based 
        // Move triggers weighted randomness trees, first between models then between offering of models
        // With the exception of certain triggers that require a certain room
        // Special event, trap, attack, empty 
        // Merchant, NPC(special(prisoner, mini-bosses) and generic), Rust monsters, Slimes, Bosses
        // Monsters: Monster attack must adjust based on player xp, traps must scale damage based on xp or hp 

        @* Retrieving the  chunk of the base enemy array 
        int GetBaseEnemyRangeStart(int xp)
            {
                int chunkSize = 5;
                int index = Math.Min(xp / 10, (baseEnemies.Length / chunkSize) - 1); // Clamp max
                return index * chunkSize;
            }
        Enemy GetRandomEnemy(Player player)
{
    List<Enemy> encounterPool = new List<Enemy>();
    
    // Add base enemies based on XP tier
    int start = GetBaseEnemyRangeStart(player.XP);
    for (int i = start; i < start + 5; i++)
        encounterPool.Add(baseEnemies[i]);

    // Check for special region
    if (IsInSpecialRegion(player))
    {
        // Weight logic: add some from special array
        int weight = Math.Min((player.X - 50) / 5, specialEnemies.Length); // Scale weight

        for (int i = 0; i < weight; i++)
        {
            // Clamp to array bounds
            int index = i % specialEnemies.Length;
            encounterPool.Add(specialEnemies[index]);
        }
    }

    // Return random enemy from pool
    Random rand = new Random();
    return encounterPool[rand.Next(encounterPool.Count)];
}

         *@
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
            GameLaunch(CreatePlayer());

        }
        public static void GameLaunch(Player player)
        {
            Dungeon dungeon = new Dungeon();
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
        public static Player CreatePlayer()
        {
            Console.WriteLine("Draegmor's Deep"); // ASCI art 
            Console.WriteLine("Welcome Adventurer,\nBefore we begin, please tell me some things about yourself");
            Console.WriteLine("What is your name?");
            Console.WriteLine();
            string playerName = Console.ReadLine().Trim();
            Console.WriteLine("Very well,\nDo you care to describe yourself?");
            Console.WriteLine("You may enter 'x' to skip this step");
            Console.WriteLine(); 
            string playerDesc = Console.ReadLine().Trim();
            if(playerDesc.ToLower() == "x")
            {
                playerDesc = "";
            }
            Player player = new Player(playerName, playerDesc);
            Console.WriteLine("You have three  skills that you will be tested on,\non top of maintaining your health and sanity");

            Console.WriteLine("You have the keys to your own destiny. You have two skills points you can spend now.");
            Console.WriteLine("You may spend them on Athletics, Perception, or Dexterity");
            Console.WriteLine("Please enter which skill you choose first");
            ApplySkillPoint(player);
            Console.WriteLine("Please enter which skill you choose second");
            ApplySkillPoint(player);
            Console.WriteLine("You have chosen your skills wisely, now find all the bravery your heart has to muster and proceed");
            return player;
        }
        public static void ApplySkillPoint(Player player)
        {
            string skill = Console.ReadLine().Trim().ToLower();
            switch(skill)
            {
                case "athletics":
                case "ath":
                    player.Athletics += 1;
                    break;
                case "perception":
                case "per":
                    player.Perception += 1;
                    break;
                case "dexterity":
                case "dex":
                    player.Dexterity += 1;
                    break;
                default:
                    Console.WriteLine("Invalid skill");
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