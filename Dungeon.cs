using System;

namespace Dungeon_Crawler
{
    public class Dungeon
    {
        private static Dungeon _dungeonInstance;
        private static readonly object _lock = new object();
        
        public  Dictionary<string, Chamber> ExploredChambers { get; set; }
        // List of monsters by challenge rating, monsters by storyline, battlefields, 
        private readonly int _nextId = 1; // Descriptions belong in the chambers class, should be generated at creation (as well as passageway descriptions)
        public static string[] DungeonChambers = {
            "A damp stone chamber where flickering torchlight casts elongated shadows that dance across ancient walls. The air is thick with humidity and the faint scent of mildew. Echoes of long-forgotten movements seem to linger in the stillness, pressing against the silence like unseen memories.",
            "A musty library with shelves that stretch endlessly into darkness, their wooden frames warped by time. Layers of dust coat every surface, muting even the faintest colors. The oppressive quiet hangs heavy, as if the room itself is waiting for something to stir from the void.",
            "A circular room sunk in shadow, where a subtle draft spirals upward as if drawn by unseen forces. The stone underfoot feels strangely warm in places, almost pulsing faintly. Barely audible whispers drift through the air like wind through a keyhole, evading clear direction or origin.",
            "A flooded chamber where brackish water reaches high up the walls, cloaking everything below in obscurity. The occasional ripple betrays hidden movements beneath the surface. The ceiling looms with cracked masonry, and the smell of stagnant decay clings to every breath.",
            "A long, crypt-like hall shrouded in gloom, where rows of ancient engravings fade into obscurity. Dust motes hang unmoving in the air, and the walls seem to press in subtly the longer one lingers. A pervasive sense of presence pervades the space, though nothing ever appears.",
            "A cavernous hollow where the ceiling disappears into a black canopy, lit only by the dim shimmer of bioluminescent growths. The pale light seems to shift subtly, never quite constant. Cold drafts rise from below, carrying sounds that resemble breathing but never repeat exactly.",
            "An abandoned forge buried deep underground, where the air is stale with metallic residue. The walls are scorched with long-cooled firemarks, and soot covers much of the floor. A faint clanging sound, perhaps from settling stone or memory itself, rings out at uneven intervals.",
            "A narrow room lined with looming figures carved from obsidian, their features worn by time. Their eyeless gazes align as though orchestrated, each angled toward the same unknown point. The room is cold and unmoving, save for a slight tremor that occasionally pulses underfoot.",
            "A ruined hall with collapsed pillars and torn tapestries hanging in tatters from ancient brackets. The silence here is oppressive, broken only by the distant sound of dripping water. Cracks in the floor expose faint glimmers of something deeper, unreachable and undefined.",
            "A desolate chamber whose walls are etched with faded murals, now indecipherable from erosion. The atmosphere is stagnant, almost timeless, as if air has not moved in centuries. There is no clear purpose to the room, only a vague feeling of judgment embedded in the stone.",
            "A twisting corridor where the walls subtly shimmer as if alive, distorting shapes and sounds. At times, the path ahead seems longer or shorter than before. Footsteps echo oddly, never quite matching the rhythm of the walker, as though something unseen is following.",
            "A solemn chamber with scorched stone and faint red markings that defy comprehension. A dry wind occasionally stirs from nowhere, shifting small fragments of debris. Though entirely still, the space resonates with dormant tension, like the aftermath of a powerful force."
        };


        public Chamber StartingPoint { get; set; }
        private Dungeon() 
        {
            StartingPoint = new Chamber("00", "Welcome to the Dungeon of Draegmor. This is the first chamber.");
            ExploredChambers = new Dictionary<string, Chamber>
    {
        { "00", StartingPoint }
    };
        }

        public static Dungeon GetInstance()
        {
            if (_dungeonInstance == null)
            {
                lock (_lock)
                {
                    if (_dungeonInstance == null)
                    {
                        _dungeonInstance = new Dungeon();
                    }
                }
            }
            return _dungeonInstance;
        }
        public Chamber GenerateChamber(string newRoomId)
        {
            string description = DungeonChambers[Utility.GetRandomIndex(0, DungeonChambers.Length)];
            Chamber newChamber = new Chamber(newRoomId, description);
            //newChamber.RandomizePassages();

            newChamber.AddChamberLoot();
            return newChamber;
        }
    }
}
