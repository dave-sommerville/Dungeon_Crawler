

namespace Dungeon_Crawler
{
    public class NPC : Character
    {
        Random random = new Random();
        // Needs a list of the base NPCs as well as dialogue options for them. Probably store prisoner here too
        private readonly string[][] _npcDialogue = new string[][]
        // Oh, I'm sorry, I'm a little chatty sometimes. I try to talk while the people are
        // still alive, their skeletons are much less talkative. I mean, except to the North. 

        {
            // Initial encounter will include constructor and extra, likely hardwritten, dialogue options
            // It is held in an if above the npc event, not with the special events as NPCs should be fairly common? 
            new string[] { "" }, // Initial statement [0][Rand]
            new string[] { "" }, // Only piece of user dialogue, two way to respond(potentially more) [1][0,1]
                                 // No effect on the next
            new string[] { "" }, // Three dialogue themes, 1 at random for user menu (y/n) [0][Rand]
            // The index here has to be referenced by the three next indices 
            new string[] { "" }, // Dialogue Theme One [Output][Rand]
            new string[] { "" }, // Dialogue Theme Two [Output][Rand]
            new string[] { "" }, // Dialogue Theme Three [Output][Rand]
            new string[] { "" }, // Friendly goodbye 
            new string[] { "" }, // Being ignored text
        };
        public void InteractWithNpc(Player player)
        {
            Console.WriteLine("You encounter a familiar creature in this room.");
            Console.WriteLine(Description);
            Console.WriteLine(_npcDialogue[0][random.Next(_npcDialogue[0].Length)]);
            bool interactionInProgress = true;
            do
            {
                Console.WriteLine($"What do you?\n1) Say '{_npcDialogue[1][0]}'\n2) Say'{_npcDialogue[1][1]}'");
                Console.WriteLine("3) Ignore\n4) Attack");
                int choice = Player.PrintMenu(4);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(_npcDialogue[1][0]);
                        interactionInProgress = DialogueNode(player);
                        player.Charisma += 1;
                        break;
                    case 2:
                        Console.WriteLine(_npcDialogue[1][1]);
                        player.Charisma -= 1;
                        break;
                    case 3:
                        Console.WriteLine(_npcDialogue[7][random.Next(_npcDialogue[7].Length)]);
                        break;
                    case 4:
                        Console.WriteLine("You kill him instantly, you monster");
                        player.Charisma = -5;
                        interactionInProgress = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            } while (interactionInProgress);
        }
        public bool DialogueNode(Player player)
        {
            int dialogueIndex = random.Next(0, _npcDialogue[2].Length);
            int userChoice = dialogueIndex + 3;
            Console.WriteLine(_npcDialogue[2][dialogueIndex]);
            Console.WriteLine("1) Yes\n2) No");
            int decision = Player.PrintMenu(2);
            if (decision == 1)
            { 
                player.Charisma += 1;
                Console.WriteLine(_npcDialogue[dialogueIndex][userChoice]);
                // Need to trigger another print menu if there's an object to give (Charisma a recent tracker comparision)
                return true;
            }
            else
            {
                player.Charisma -= 1;
                Console.WriteLine(_npcDialogue[4][dialogueIndex]);
                return false;
            }
        }

        public Item Item { get; set; }
        public NPC() : base()
        {
            Description = "A mysterious figure.";
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
                int decision = Player.PrintMenu(3);
                switch (decision)
                {
                    case 1:
                        AdventureQuestion(player);
                        break;
                    case 2:
                        Console.WriteLine("What's a name? Can you give me a name?");
                        AdventureQuestion(player);
                        break;
                    case 3:
                        Console.WriteLine("'Woooooooowwwww, ok. Kinda rude.\nI mean, like, how many things have tried to kill you\nand here I am just looking to chat a little but\nnooooooo, you're all high and mighty. OK, that's fine.' the creature says passive aggressively");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (InteractionInProgress);
        }
        public Item GivePlayerItem() // Will eventually have to take off a list of items (Will be able to use this for both sets of interaction)
        {
            Item item = new Item();
            item.Name = "A shiny object";
            item.Value = 10;
            return item;
        }
        public void AdventureQuestion(Player player)
        {
            Console.WriteLine("What kind of adventure are you on?");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("What do you say?");
            Console.WriteLine("1) Seeking treasure and fortune");
            Console.WriteLine("2) Seeking acknowledgement and renown");
            Console.WriteLine("3) Seeking knowledge and relics");
            Console.WriteLine("4) Why don't you mind your own business");
            string endResult = "";
            bool onQuestion = true;
            do
            {
                int choice = Player.PrintMenu(4);
                switch(choice) {
                    case 1:
                        player.Charisma += 1;
                        endResult = "Seeking treasure and fortune";
                        Console.WriteLine("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        player.AddToInventory(GivePlayerItem());
                        break;
                    case 2:
                        player.Charisma += 1;

                        endResult = "Seeking acknowledgement and renown";
                        Console.WriteLine("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        player.AddToInventory(GivePlayerItem());
                        break;
                    case 3:
                        player.Charisma += 1;

                        endResult = "Seeking knowledge and relics";
                        Console.WriteLine("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        player.AddToInventory(GivePlayerItem());

                        break;
                    case 4:
                        Console.WriteLine("Well, kinda rude. I just have this cool rock that I was gonna give you.");
                        Console.WriteLine("Ah, whatever! Here you go.");
                        player.AddToInventory(GivePlayerItem());
                        player.Charisma -= 1;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                
            } while (onQuestion);
        }
    }
}
