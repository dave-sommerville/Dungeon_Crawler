

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
        public NPC MushroomMan()
        {
            NPC temuToad = new NPC("Toad", "Little guy");
            return temuToad;
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
    }
}
