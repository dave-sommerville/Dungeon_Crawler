

namespace Dungeon_Crawler
{
    public class NPC : Character
    {
        // Needs a list of the base NPCs as well as dialogue options for them. Probably store prisoner here too
        public string[] Dialogues { get; set; }
        public int[] Items { get; set; }
        public int[] Locations { get; set; }
        public NPC(string name, string description) : base(name, description)
        {
            Description = "A mysterious figure.";
            Dialogues = new string[] { "Hello, traveler!", "What brings you here?", "I have a quest for you." };
        }
    }
}
