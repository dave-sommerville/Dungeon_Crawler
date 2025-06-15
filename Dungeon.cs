using System;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler
{
    public class Dungeon
    {
        private static Dungeon _dungeonInstance;
        private static readonly object _lock = new object();
        
        public  Dictionary<string, Chamber> ExploredChambers { get; set; }
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
            "A solemn chamber with scorched stone and faint red markings that defy comprehension. A dry wind occasionally stirs from nowhere, shifting small fragments of debris. Though entirely still, the space resonates with dormant tension, like the aftermath of a powerful force.",
            "A bell-shaped vault encrusted with salt crystals that crunch underfoot. Strange geometric symbols cover the walls, some glowing faintly. There’s a low thrumming in the stone itself, as though the chamber is humming an old, forgotten song only the walls remember.",
            "A collapsed stairwell filled with dry, whispering vines that shift when unwatched. The temperature plummets the deeper one goes, and a vague scent of ash hangs in the air. Whispers and footsteps seem to loop endlessly, as if trapped echoes play on repeat.",
            "A domed observatory sealed underground, where a shattered lens still points at a ceiling of solid rock. Ancient constellations are painted above, but they do not match any known sky. Something scratches faintly at the walls — soft, deliberate, and patient.",
            "A winding tunnel with walls so narrow they seem to breathe. Every few steps, the air tightens, and the echo of movement behind you grows louder. Occasionally, a distant chime rings out, though its source is never found.",
            "A sacrificial chamber carved from a single slab of black stone. The floor dips in the center, stained with something too dark to reflect light. The walls are silent, but the room exudes the expectation of ritual — incomplete or soon to resume.",
            "A forgotten garden overtaken by glowing fungus and brittle vines. Stone benches crumble under invisible weight, and no insects stir. The air tastes sweet but artificial, like a memory of something that never truly existed.",
            "A circular oubliette accessible only from above, with claw marks scoring the walls and no visible exit. The quiet here is oppressive, yet feels constantly violated by unseen movement. Even sound falls wrong, arriving slightly after its source.",
            "A room whose floor is composed of thick glass panes revealing swirling black liquid underneath. The glass fogs at random, obscuring your view just as vague shapes begin to appear. At times, it feels as if you're the one being observed.",
            "A vast hall of cracked mirrors, each reflecting slightly incorrect versions of reality. Some show movements you haven't made yet. One mirror near the center is perfectly black and reflects nothing — not even light.",
            "A sunken archive submerged in murky water, with scrolls and tomes sealed in rusted cages. The water is unnaturally cold and emits soft vibrations, as if the past itself resents being disturbed. Occasionally, bubbles rise in patterns resembling runes.",
            "A throne room reduced to rubble, where a stone seat still stands untouched amid the destruction. Every path leading to it is blocked, as if the space resists approach. The silence here is reverent, the kind reserved for ancient failure or buried kings.",
            "A hexagonal vault whose walls are etched with constellations, slowly shifting like a clockwork sky. Time feels fluid here — moments drag or vanish. At the center, a pedestal holds nothing, yet demands attention as though it were never truly empty."
        };

        public Chamber StartingPoint { get; set; }
        private Dungeon() 
        {
            StartingPoint = new Chamber("00", "Welcome to the Dungeon of Draegmor. This is the first chamber.");
            StartingPoint.NorthPassage = true;
            StartingPoint.EastPassage = true;
            StartingPoint.WestPassage = true;
            StartingPoint.SouthPassage = false;
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
