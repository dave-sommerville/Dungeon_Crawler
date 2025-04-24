

namespace Dungeon_Crawler
{
    public class NPC : Character
    {
        // Needs a list of the base NPCs as well as dialogue options for them. Probably store prisoner here too
        public string[] Dialogues { get; set; }
        public List<Item> Items { get; set; }
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
            return merchant;
        }
        public NPC Prisoner()
        {
            NPC prisoner = new NPC("Prisoner", "A desperate figure bound in chains.");
            return prisoner;
        }
        public void MarketPlace(Player player) // Expand to allow for descriptions/reconsiderations
        {
            bool TransactionInProgress = true;
            do
            {
                foreach (Item item in Items)
                {
                    Console.WriteLine($"{item.Name}: {item.Value} Gold Pieces");
                }
                Console.WriteLine("What would you like to buy?\nSelect an item");
                int selectedItem = Player.PrintMenu(Items.Count) - 1;
                if( selectedItem == -1) TransactionInProgress = false;
                if (player.Gold >= Items[selectedItem].Value)
                {
                    player.AddToInventory(Items[selectedItem]);
                    player.Gold -= Items[selectedItem].Value;
                } else
                {
                    Console.WriteLine("You don't have enough gold");
                }
            } while (TransactionInProgress);
        }
    }
}
