

namespace Dungeon_Crawler
{
    public class NPC : Character
    {
        // Needs a list of the base NPCs as well as dialogue options for them. Probably store prisoner here too
        public string[] Dialogues { get; set; }
        public List<Item> Items { get; set; }
        public NPC() : base()
        {
            Description = "A mysterious figure.";
            Dialogues = new string[] { "Hello, traveler, What brings you here?", "I have a quest for you." };
        }

        public NPC Prisoner()
        {
            NPC prisoner = new NPC();
            return prisoner;
        }
        public void MarketPlace(Player player) // Expand to allow for descriptions/reconsiderations
        {
            Console.WriteLine($"Hello adventurer, how brave to come this far.");
            Console.WriteLine($"I am the humble {Name}, and I have a few items for sale. Do you want to see them?");
            Console.WriteLine("1) Yes 2) Talk to merchant");
            int decision = Player.PrintMenu(2);
            if (decision == 1)
            {
                bool TransactionInProgress = true;
                do
                {
                    foreach (Item item in Items)
                    {
                        Console.WriteLine($"{item.Name}: {item.Value} Gold Pieces");
                    }
                    Console.WriteLine("What would you like to buy?\nSelect an item");
                    Console.WriteLine("Be careful what you choose, I don't ask twice");
                    int selectedItem = Player.PrintMenu(Items.Count) - 1;
                    if (selectedItem == -1) TransactionInProgress = false;
                    if (player.Gold >= Items[selectedItem].Value)
                    {
                        player.AddToInventory(Items[selectedItem]);
                        player.Gold -= Items[selectedItem].Value;
                    } else
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                } while (TransactionInProgress);
            } else
            {
                Console.WriteLine("So what's shakin, bacon?");
            }
        }
        public void Interact()
        {

        }
    }
}
