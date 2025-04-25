

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
        public void Interact(Player player)
        {
            bool InteractionInProgress = true;
            do
            {
                Console.WriteLine(Description);
                Console.WriteLine("'Hello there', a small and slightly shrill voice calls out to you");
                Console.WriteLine("What do you do?");
                Console.WriteLine($"1) Nod towards the creature with a stern but calm expression'");
                Console.WriteLine("2) Say 'Why hello there, what might your name be?");
                Console.WriteLine("3) Ignore the creature and continue on your way");
                Console.WriteLine("4) Attack the creature");
                int decision = Player.PrintMenu(3);
                // Has to give NPC a way to 
                switch (decision)
                {
                    case 1:
                        Console.WriteLine("What kind of adventure are you on?");
                        //-Seeking treasure and fortune *
                        //-Seeking acknowledgement and renown *
                        //-Seeking knowledge and relics *
                        // Cool cool cool. I just sort of hang out. 
                        // Random question 
                        //-What do you mean by that? -1
                        // Oh, I'm sorry, I'm a little chatty sometimes. I try to talk while the people are
                        // still alive, their skeletons are much less talkative. I mean, except to the North. 
                        //-Why don't you mind your own business? -1
                        break;
                    case 2:
                        Console.WriteLine("What's a name? Can you give me a name?");
                        break;
                    case 3:
                        Console.WriteLine("'Woooooooowwwww, ok. Kinda rude.\nI mean, like, how many things have tried to kill you\nand here I am just looking to chat a little but\nnooooooo, you're all high and mighty. OK, that's fine.' the creature says passive aggressively");
                        player.Charisma -= 1;
                        //Can just keep looping until the player interacts with or attacks the creature
                        break;
                    case 4:
                        Console.WriteLine("You attack the creature, smashing it into a pulp with barely any effort.");
                        player.Charisma = -5;
                        InteractionInProgress = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (InteractionInProgress);
        }
    }
}
