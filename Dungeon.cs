using System;

namespace Dungeon_Crawler
{
    public class Dungeon
    {
        public  Dictionary<string, Chamber> ExploredChambers { get; set; }
        // List of monsters by challenge rating, monsters by storyline, battlefields, 
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
            ExploredChambers.Add("00", StartingPoint);
        }
        public Chamber GenerateChamber(string newRoomId)
        {
            string description = DungeonChambers[Utility.GetRandomIndex(0, DungeonChambers.Length)];
            Chamber newChamber = new Chamber(newRoomId, description);
            newChamber.RandomizePassages();
            return newChamber;
        }
    }
}
