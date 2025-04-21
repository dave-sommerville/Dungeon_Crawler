using System;

namespace Dungeon_Crawler
{
    public class Dungeon
    {
        public  Dictionary<string, Chamber> ExploredChambers { get; set; }
        // List of monsters by challenge rating, monsters by storyline, battlefields, 
        private Random Random { get; set; }
        private readonly int _nextId = 1; // Descriptions belong in the chambers class, should be generated at creation (as well as passageway descriptions)
        public static string[] DungeonChambers =
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
        
        public Chamber StartingPoint { get; set; }
        public Dungeon()
        {                                       //Needs to be an actual description 
            StartingPoint = new Chamber("00", "And so we begin");
            ExploredChambers = new Dictionary<string, Chamber>();
            Random = new Random();
            ExploredChambers.Add("00", StartingPoint);
        }
        public Chamber GenerateChamber(string newRoomId)
        {
            string description = DungeonChambers[Random.Next(DungeonChambers.Length)];
            Chamber newChamber = new Chamber(newRoomId, description);
            ExploredChambers[newRoomId] = newChamber;
            newChamber.RandomizePassages();

            return newChamber;
        }
        public static int GetRandomIndex(int min, int max)
        {
            Random random = new Random();
            int randomInt = random.Next(min, max);
            return randomInt;
        }
        public static void MasterEventsTree()
        {
            int randomEvent = GetRandomIndex(1, 10);
            if (randomEvent <= 1)
            {
                // Trigger a special event
                Console.WriteLine("A special event has occurred!");
            }
            else if (randomEvent <= 3)
            {
                // Trigger a trap
                Console.WriteLine("You have triggered a trap!");
            }
            else if (randomEvent <= 6)
            {
                // Trigger a monster encounter
                Console.WriteLine("A monster has appeared!");
            }
            else
            {
                // No event
                Console.WriteLine("Nothing happens.");
            }
        }
        public Trap TrapEvent()
        {
            Trap trap = new Trap();
            return trap;
        }
        public Monster MonsterAttack()
        {
            Monster monster = new Monster("Goblin", "A small, green-skinned creature with a nasty disposition.", 1);
            return monster;
        }
        public static void SpecialEventsTree()
        {

        }
        // Special Event Functions
        public static void RustMonsterEvent()
        {

        }
        public static void SlimeEvent()
        {

        }

        public Battlefield BossBattle()
        { // Will actually insert the battle field in place of the generated chamber
            Battlefield battlefield = new Battlefield("BossBattle", "A dark chamber filled with the echoes of past battles.");
            return battlefield;
        }
        public NPC Merchant()
        { // Can populate inventory from items list in dungeon 
            NPC merchant = new NPC("Merchant", "A shady figure with a glint in their eye.");
            merchant.Items = new int[] { 1, 2, 3 }; // Placeholder for item IDs
            merchant.Locations = new int[] { 1, 2, 3 }; // Placeholder for location IDs
            return merchant;
        }
        public NPC Prisoner()
        {
            NPC prisoner = new NPC("Prisoner", "A desperate figure bound in chains.");
            prisoner.Items = new int[] { 1, 2, 3 }; // Placeholder for item IDs
            prisoner.Locations = new int[] { 1, 2, 3 }; // Placeholder for location IDs
            return prisoner;
        }
        public NPC NpcGeneric()
        {
            NPC npc = new NPC("NPC", "A mysterious figure.");
            npc.Items = new int[] { 1, 2, 3 }; // Placeholder for item IDs
            npc.Locations = new int[] { 1, 2, 3 }; // Placeholder for location IDs
            return npc;
        }
        // Choose opponents by CR

        //int GetBaseEnemyRangeStart(int xp)
        //{
        //    int chunkSize = 5;
        //    int index = Math.Min(xp / 10, (baseEnemies.Length / chunkSize) - 1); // Clamp max
        //    return index * chunkSize;
        //}
        //Enemy GetRandomEnemy(Player player)
        //{
        //    List<Enemy> encounterPool = new List<Enemy>();

        //    // Add base enemies based on XP tier
        //    int start = GetBaseEnemyRangeStart(player.XP);
        //    for (int i = start; i < start + 5; i++)
        //        encounterPool.Add(baseEnemies[i]);

        //    // Check for special region
        //    if (IsInSpecialRegion(player))
        //    {
        //        // Weight logic: add some from special array
        //        int weight = Math.Min((player.X - 50) / 5, specialEnemies.Length); // Scale weight

        //        for (int i = 0; i < weight; i++)
        //        {
        //            // Clamp to array bounds
        //            int index = i % specialEnemies.Length;
        //            encounterPool.Add(specialEnemies[index]);
        //        }
        //    }

        //    // Return random enemy from pool
        //    Random rand = new Random();
        //    return encounterPool[rand.Next(encounterPool.Count)];

    }
    }
