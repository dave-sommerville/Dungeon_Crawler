

namespace Dungeon_Crawler
{
    public class NPC : Character
    {
        private readonly string[][] _npcDialogue = new string[][]
        {
            new string[] { "Greetings traveler", "Howdy mate", "Hello there", "Ahoy my friend", "Fair travels" }, // Initial statement [0][Rand]
            new string[] { "Hello", "Mhmm" }, // Only piece of user dialogue, two way to respond(potentially more) [1][0,1]
                                 // No effect on the next
            new string[] { "Do you want to hear a joke?", "Do you wanna know a secret?", "Any chance you want to know a science fact?"}, // Three dialogue themes, 1 at random for user menu (y/n) [0][Rand]
            // The index here has to be referenced by the three next indices 
            new string[] { "Why did the mushroom hate going to school?\r\n\r\nHe was always spored.", "What’s nine feet long, has six legs, and flies?\r\n\r\nThree dead halflings!", "What do you call a mushroom that makes music?\r\n\r\nA de-composer.", "Why do paladins wear chain mail?\r\n\r\nBecause it’s holy armor." }, // Dialogue Theme One [Output][Rand]
            new string[] { "", "I keep a pet pebble named Sir Crunch — everyone laughs, but he’s the only one who listens.", "There's a moss spirit that flirts with me... but only when she's bored.", "I once tried to grow wings like the fireflies... glued leaves to my back and jumped off a stump. Broke my favorite cap.",  }, // Dialogue Theme Two [Output][Rand]
            new string[] { "If you hum at just the right frequency, snails will start to dance in sync", "Mushrooms can hear compliments. That's why some grow bigger after you tell them they're handsome.", "Ants invented the first maps, but nobody could read the handwriting." }, // Dialogue Theme Three [Output][Rand]
            new string[] { "OK bye friend", "Smell ya later", "Peace be with you", "Farewell and good luck" }, // Friendly goodbye 
            new string[] { "Woooooooowwwww, ok. Kinda rude.\\nI mean, like, how many things have tried to kill you\\nand here I am just looking to chat a little but\\nnooooooo, you're all high and mighty. OK, that's fine.", "It's ok if you ignore me, my mother always did.", "Hmmm, someone doesn't have very good manners" }, // Being ignored text
        };
        public int ArtifactTracker { get; set; } = 0; // Will be used to track if the player has received an item from the NPC
        public bool HasBag { get; set; } = false; // Will be used to track if the player has received a bag from the NPC
        public bool HasMap { get; set; } = false; // Will be used to track if the player has received a map from the NPC
        public Item Item { get; set; }
        public NPC() : base()
        {
            Description = "A mysterious figure.";
        }
        public void InitialInteraction(Player player)
        {
            Utility.Print(Description);
            Utility.Print("'Hello there', a small and slightly shrill voice calls out to you");

            bool InteractionInProgress = true;
            do
            {
                Utility.Print("What do you do?");
                Utility.Print($"1) Nod towards the creature with a stern but calm expression'");
                Utility.Print("2) Say 'Why hello there, what might your name be?");
                Utility.Print("3) Ignore the creature and continue on your way");
                int decision = Utility.PrintMenu(3);
                switch (decision)
                {
                    case 1:
                        AdventureQuestion(player);
                        InteractionInProgress = false;
                        break;
                    case 2:
                        Utility.Print("What's a name? Can you give me a name?");
                        AdventureQuestion(player);
                        InteractionInProgress = false;
                        break;
                    case 3:
                        Utility.Print("'Woooooooowwwww, ok. Kinda rude.\nI mean, like, how many things have tried to kill you\nand here I am just looking to chat a little but\nnooooooo, you're all high and mighty. OK, that's fine.' the creature says passive aggressively");
                        break;

                    default:
                        Utility.Print("Invalid choice, please try again.");
                        break;
                }
            } while (InteractionInProgress);
        }
        public void AdventureQuestion(Player player)
        {
            Utility.Print("What kind of adventure are you on?");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Utility.Print("What do you say?");
            Utility.Print("1) Seeking treasure and fortune");
            Utility.Print("2) Seeking acknowledgement and renown");
            Utility.Print("3) Seeking knowledge and relics");
            Utility.Print("4) Why don't you mind your own business");
            string endResult = "";
            bool onQuestion = true;
            do
            {
                int choice = Utility.PrintMenu(4);
                switch (choice)
                {
                    case 1:
                        player.Charisma += 1;
                        endResult = "Seeking treasure and fortune";
                        Utility.Print("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false; 
                        break;
                    case 2:
                        player.Charisma += 1;

                        endResult = "Seeking acknowledgement and renown";
                        Utility.Print("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false;
                        break;
                    case 3:
                        player.Charisma += 1;

                        endResult = "Seeking knowledge and relics";
                        Utility.Print("Cool cool cool. I just sort of hang out. I found this neat rock you can have.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false;

                        break;
                    case 4:
                        Utility.Print("Well, kinda rude. I just have this cool rock that I was gonna give you.");
                        Utility.Print("Ah, whatever! Here you go.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false;
                        player.Charisma -= 1;
                        break;
                    default:
                        Utility.Print("Invalid choice, please try again.");
                        break;
                }
            } while (onQuestion);
        }
        public void InteractWithNpc(Player player)
        {
            Utility.Print("You encounter a familiar creature in this room.");
            Utility.Print(Description);
            Utility.Print(_npcDialogue[0][Utility.GetRandomIndex(0, _npcDialogue[0].Length)]);
            ArtifactTracker++;
            bool interactionInProgress = true;
            do
            {
                Utility.Print($"What do you?\n1) Say '{_npcDialogue[1][0]}'\n2) Say'{_npcDialogue[1][1]}'");
                Utility.Print("3) Ignore\n4) Attack");
                int choice = Utility.PrintMenu(4);
                switch (choice)
                {
                    case 1:
                        Utility.Print(_npcDialogue[1][0]);
                        DialogueNode(player);
                        interactionInProgress = false;
                        player.Charisma += 1;
                        break;
                    case 2:
                        Utility.Print(_npcDialogue[1][1]);
                        DialogueNode(player);
                        interactionInProgress = false;
                        break;
                    case 3:
                        Utility.Print(_npcDialogue[7][Utility.GetRandomIndex(0, _npcDialogue[7].Length)]);
                        player.Charisma -= 1;
                        interactionInProgress = false;
                        break;
                    case 4:
                        Utility.Print("You kill him instantly, you monster");
                        player.Charisma = -5;
                        interactionInProgress = false;
                        break;
                    default:
                        Utility.Print("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
            } while (interactionInProgress);
        }
        public bool BagChecker(Player player)
        {
            Console.WriteLine("Checking charisma");
            if(player.Charisma > 2 && !HasBag && player.PlayerLevel >= 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool MapChecker(Player player)
        {
            Console.WriteLine("Checking charisma");
            if (player.Charisma > 2 && !HasMap && player.PlayerLevel >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DialogueNode(Player player)
        {
            int dialogueQuestionIndex = Utility.GetRandomIndex(0, _npcDialogue[2].Length);
            int userChoice = dialogueQuestionIndex + 3;
            int dialogueIndex = Utility.GetRandomIndex(0, _npcDialogue[userChoice].Length);
            Utility.Print(_npcDialogue[2][dialogueQuestionIndex]);
            Utility.Print("1) Yes\n2) No");
            int decision = Utility.PrintMenu(2);
            if (decision == 1)
            {
                player.Charisma += 1;
                Utility.Print(_npcDialogue[userChoice][dialogueIndex]);
                if(BagChecker(player))
                {
                    Console.WriteLine("Equipping bag");
                    EquipBagOfCarrying(player);
                    HasBag = true;
                } else if(MapChecker(player))
                {
                    EquipMap(player);
                }
            }
            else
            {
                player.Charisma -= 1;
                Utility.Print(_npcDialogue[4][dialogueIndex]);
            }
        }
        public void EquipGreyStoneSpire(Player player)
        {
            Item greyStoneSpire = new Item();
            greyStoneSpire.Name = "Grey Stone Spire";
            greyStoneSpire.Description = "A small stone spire, it is grey and has a small hole in the top";
            greyStoneSpire.Durability = 1000;
            greyStoneSpire.Value = 1000;
            player.GreyStoneSpire = greyStoneSpire;
        }
        public void EquipBagOfCarrying(Player player)
        {
            Item[] bagOfCarrying = new Item[20];
            for(int i = 0; i < Inventory.Length; i++)
            {
                bagOfCarrying[i] = Inventory[i];
            }
            player.Inventory = bagOfCarrying;
        }
        public void EquipMap(Player player)
        {
            Utility.Print("Map is now equipped");
        }
        public NPC Prisoner()
        {
            NPC prisoner = new NPC();
            return prisoner;
        }
        public void MarketPlace(Player player) // Expand to allow for descriptions/reconsiderations
        {
            StockMarketPlace();
            Utility.Print($"Hello adventurer, how brave to come this far.");
            Utility.Print($"I am the humble {Name}, and I have a few items for sale. Do you want to see them?");
            Utility.Print("1) Yes 2) Talk to merchant");
            int decision = Utility.PrintMenu(2);
            if (decision == 1)
            {
                bool TransactionInProgress = true;
                do
                {
                    for (int i = 0; i < Inventory.Length; i++)
                    {
                        if (Inventory[i] == null) continue;
                        Utility.Print($"{i + 1}) {Inventory[i].Name}: {Inventory[i].Value} Gold Pieces");
                    }
                    Utility.Print("What would you like to buy?\nSelect an item");
                    Utility.Print("Be careful what you choose, I don't ask twice");
                    Utility.Print("0) To Exit");
                    int selectedItem = Utility.PrintMenu(Inventory.Length) ;
                    selectedItem--;
                    if (selectedItem == -1)
                    {
                        TransactionInProgress = false;
                    }
                    else
                    {
                        if (player.Gold >= Inventory[selectedItem].Value)
                        {
                            player.AddToInventory(Inventory[selectedItem]);
                            player.Gold -= Inventory[selectedItem].Value;
                            Inventory[selectedItem] = null;
                        }
                        else
                        {
                            Utility.Print("You don't have enough gold");
                        }
                    }
                } while (TransactionInProgress);
            } else
            {
                Utility.Print("So what's shakin, bacon?");
            }
        }
        public void StockMarketPlace()
        {
            int weaponIndex = Utility.GetRandomIndex(0, 10);
            int armorIndex = Utility.GetRandomIndex(0, 10);
            int potionIndex = Utility.GetRandomIndex(0, 10);
            if (weaponIndex > 5)
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if (Inventory[i] == null)
                    {
                        Inventory[i] = new Weapon();
                        return;
                    }
                }
            }
            if (armorIndex > 5)
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if (Inventory[i] == null)
                    {
                        Inventory[i] = new Armor();
                        return;
                    }
                }
            }
            if (potionIndex > 5)
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if (Inventory[i] == null)
                    {
                        Inventory[i] = new Potion();
                        return;
                    }
                }
            }
        }
    }
}
