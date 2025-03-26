using System;

namespace Dungeon_Crawler
{
    public class Dungeon
    {
        private  Dictionary<int, Chamber> Chambers { get; set; }
        private Random Random { get; set; }
        private readonly int _nextId;
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
        public static string[] Directions =
        {
            "north", "south", "east", "west"
        };
        public Dungeon()
        {
            Chambers = new Dictionary<int, Chamber>();
            Random = new Random();
            Chamber startingRoom = new Chamber("And so we begin");
        }


        public int GenerateChamber(int fromRoomId, string direction)
        {
            Chamber newChamber = new Chamber(DungeonChambers[Random.Next(DungeonChambers.Length)]);
            newChamber.AddExit(OppositeDirection(direction), fromRoomId);
            int chamberRef = newChamber.ChamberId;
            Chambers[chamberRef] = newChamber;
            Chambers[fromRoomId].AddExit(direction, chamberRef);

            return chamberRef;
        }
        public Chamber GetChamber(int id)
        {
            return Chambers.ContainsKey(id) ? Chambers[id] : null;
        }
        private string OppositeDirection(string direction)
        {
            return direction switch
            {
                "north" => "south",
                "south" => "north",
                "east" => "west",
                "west" => "east",
                _ => ""
            };
        }
    }
}
