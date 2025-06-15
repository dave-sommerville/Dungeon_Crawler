using System.Numerics;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Items.Potions;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Characters_and_dialogue
{
    public class NPC : Character
    {

        public static string[] Colors = { "red", "blue", "green", "yellow", "purple", "orange" };
        public static string[] myconidFeatures = new string[]
        {
            "a mushroom cap shaped like a wizard hat, complete with natural frills.",
            "eyeballs that peek out from under the gills of their cap.",
            "tiny toadstools growing symmetrically down each arm.",
            "a beard made of soft, dangling moss and miniature fungi.",
            "legs resembling twisted mushroom stalks with polka dots.",
            "fingers constantly sprouting and shedding glittery spores.",
            "one shoulder hosting a sleepy snail frozen upon it.",
            "a patch of turf where tiny insects host parties on its back.",
            "a belly glowing faintly with shifting colors like a lava lamp.",
            "a belt made of woven roots and acorn buttons."
        };



        // Generic Dialogue arrays 
        public static string[] Hellos = new string[]
        {
            "Greetings traveler",
            "Howdy mate",
            "Hello there",
            "Ahoy my friend",
            "Fair travels"
        };
        public static string[] YesNo = new string[] {
            "Say 'Yes'",
            "Say 'No'"
        };
        public static DialogueNode[] Goodbyes = new DialogueNode[]
        {
            new DialogueNode("'OK bye friend'\nThe creature walks away from you gloomily", null, null),
            new DialogueNode("Smell ya later", null, null),
            new DialogueNode("Peace be with you", null, null),
            new DialogueNode("Farewell and good luck", null, null)
        };
        public static DialogueNode[] IgnoreStatements= new DialogueNode[]
        {
            new DialogueNode("OK bye friend", null, null),
            new DialogueNode("Smell ya later", null, null),
            new DialogueNode("Peace be with you", null, null),
            new DialogueNode("Farewell and good luck", null, null)
        };
        //  Secrets 
        public static DialogueNode[] Secrets = new DialogueNode[]
        {
            new DialogueNode("I keep a pet pebble named Sir Crunch — everyone laughs, but he’s the only one who listens.", null, null),
            new DialogueNode("There's a moss spirit that flirts with me... but only when she's bored.", null, null),
            new DialogueNode("I once tried to grow wings like the fireflies... glued leaves to my back and jumped off a stump. Broke my favorite cap.", null, null)
        };
        public static DialogueNode[][] SecretResponses = new DialogueNode[][]
        {
            Secrets,
            Goodbyes
        };
        public DialogueNode SecretText = new DialogueNode("Do you wanna know a secret?", YesNo, SecretResponses);
        // Jokes
        public static DialogueNode[] Jokes = new DialogueNode[]
        {
            new DialogueNode("Why do paladins wear chain mail?\r\n\r\nBecause it’s holy armor.", null, null),
            new DialogueNode("What do you call a mushroom that makes music?\r\n\r\nA de-composer.", null, null),
            new DialogueNode("What’s nine feet long, has six legs, and flies?\r\n\r\nThree dead halflings!", null, null),
            new DialogueNode("Why did the mushroom hate going to school?\r\n\r\nHe was always spored.", null, null)
        };
        public static DialogueNode[][] JokeResponses = new DialogueNode[][]
        {
            Jokes,
            Goodbyes
        };
        public DialogueNode JokeText = new DialogueNode("Do you want to hear a joke?", YesNo, JokeResponses);
        // Facts 
        public static DialogueNode[] Facts = new DialogueNode[]
        {
            new DialogueNode("If you hum at just the right frequency, snails will start to dance in sync", null, null),
            new DialogueNode("Mushrooms can hear compliments. That's why some grow bigger after you tell them they're handsome.", null, null),
            new DialogueNode("Ants invented the first maps, but nobody could read the handwriting.", null, null)
        };
        public static DialogueNode[][] FactResponses = new DialogueNode[][]
        {
            Facts,
            Goodbyes
        };
        public static DialogueNode FactText = new DialogueNode("Any chance you want to know a fun science fact?", YesNo, FactResponses);
        // Merchant
        public static string MerchantStatement = "Absolutely, what would you like to ask me?";
        public static string[] MerchantOptions = new string[]
        {
            "Say 'How do you even light all these torches? Someone’s gotta be replacing them constantly, right?'",
            "Say 'Do you actually live down here, or is this just your shift?'",
            "Say 'What are you doing with all this gold?'"
        };
        public static DialogueNode[] MerchantResponseOne = new DialogueNode[]
        {
            new DialogueNode("A very small dragon does it", null, null),
            new DialogueNode("Magma sprite with a debt to a wizard. Funny thing is, wizard died a long time ago.", null, null),
            new DialogueNode("Those are actually just inferno tree roots", null, null)
        };
        public static DialogueNode[] MerchantResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Actually I eat the gold and I don't want to set off the traps", null, null),
            new DialogueNode("I'm actually a figment of my imagination", null, null),
            new DialogueNode("It's just me, that's what happens when you ask a rock to be your union leader", null, null)
        };
        public static DialogueNode[] MerchantResponseThree = new DialogueNode[]
        {
            new DialogueNode("I just like how shiny it is.", null, null),
            new DialogueNode("I'm making a statue of my partner, and, let's just say, I like em big", null, null)
        };
        public static DialogueNode[][] MerchantResponses = new DialogueNode[][]
        {
            MerchantResponseOne,
            MerchantResponseTwo,
            MerchantResponseThree
        };
        public static DialogueNode MerchantText = new DialogueNode(MerchantStatement, MerchantOptions,MerchantResponses);

        public bool HasBag { get; set; } = false; // Will be used to track if the player has received a bag from the NPC
        public bool HasMap { get; set; } = false; // Will be used to track if the player has received a map from the NPC
        public Item Item { get; set; }
        public bool InteractionInProgress { get; set; }
        public NPC() : base()
        {
            Description = "A mysterious figure.";
        }
        public void InitialInteraction(Player player)
        {
            Utility.Print("'Hello there', a small and slightly shrill voice calls out to you");
            Utility.Print(Description);

            bool InteractionInProgress = true;
            do
            {
                Thread.Sleep(Utility.Delay);
                Console.WriteLine("What do you do?");
                Thread.Sleep(Utility.Delay);
                Console.WriteLine($"1) Nod towards the creature with a stern but calm expression'");
                Thread.Sleep(Utility.Delay);
                Console.WriteLine("2) Say 'Why hello there, what might your name be?");
                Thread.Sleep(Utility.Delay);
                Console.WriteLine("3) Ignore the creature and continue on your way");
                Thread.Sleep(Utility.Delay);
                int decision = Utility.PrintMenu(3);
                switch (decision)
                {
                    case 1:
                        Utility.Print("You nod towards the creature with a stern but calm expression");
                        AdventureQuestion(player);
                        InteractionInProgress = false;
                        break;
                    case 2:
                        Utility.Print("'Why hello there, what might your name be?' you say to the creature");
                        Utility.Print("'What's a name?' it says, 'Can you give me a name?'");
                        Thread.Sleep(Utility.Delay);
                        Console.WriteLine("Enter a name below");
                        NameNpc();
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
        public void NameNpc()
        {
            string name = "Toad";
            name = Console.ReadLine().Trim();
            Utility.Print($"'Oh, I like that name! {name} it is!'");
            Name = name;
        }
        public void AdventureQuestion(Player player)
        {
            Utility.Print("It says to you 'What kind of adventure are you on?'");
            Utility.Print("");
            Utility.Print("");
            Utility.Print("");
            Thread.Sleep(Utility.Delay);
            Console.WriteLine("What do you say?");
            Thread.Sleep(Utility.Delay);
            Console.WriteLine("1) Seeking treasure and fortune");
            Thread.Sleep(Utility.Delay);
            Console.WriteLine("2) Seeking acknowledgement and renown");
            Thread.Sleep(Utility.Delay);
            Console.WriteLine("3) Seeking knowledge and relics");
            Thread.Sleep(Utility.Delay);
            Console.WriteLine("4) Why don't you mind your own business!");

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
                        Utility.Print($"You reply '{endResult}'");

                        Utility.Print($"'Cool cool cool. I just sort of hang out.' {Name} says. 'I found this neat rock you can have.'");
                        EquipGreyStoneSpire(player);
                        onQuestion = false; 
                        break;
                    case 2:
                        player.Charisma += 1;
                        endResult = "Seeking acknowledgement and renown";
                        Utility.Print($"You reply '{endResult}'");
                        Utility.Print($"Cool cool cool. I just sort of hang out. {Name} says.I found this neat rock you can have.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false;
                        break;
                    case 3:
                        player.Charisma += 1;
                        endResult = "Seeking knowledge and relics";
                        Utility.Print($"You reply '{endResult}'");
                        Utility.Print($"Cool cool cool. I just sort of hang out. {Name} says. I found this neat rock you can have.");
                        EquipGreyStoneSpire(player);
                        onQuestion = false;

                        break;
                    case 4:
                        Utility.Print($"You reply 'Why don't you mind your own business!'");
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
        public void RandomizeAttributes()
        {
            string color = Colors[Utility.GetRandomIndex(0, Colors.Length)];
            string feature = myconidFeatures[Utility.GetRandomIndex(0, myconidFeatures.Length)];
            this.Description = $"A foot tall {color} mushroom; with {feature}";
        }
        public void InteractWithNpc(Player player)
        {
            Utility.Print("You encounter a familiar creature in this room.");
            Utility.Print($"'{Hellos[Utility.GetRandomIndex(0, Hellos.Length)]}' {Name} says");
            Utility.Print(Description);
            int interactionIndex = Utility.GetRandomIndex(1, 3);
            switch (interactionIndex)
            {
                case 1:
                    SecretText.Node(this);
                    EquipBagOfCarrying(player);
                    break;
                case 2:
                    JokeText.Node(this);
                    EquipBagOfCarrying(player);
                    break;
                case 3:
                    FactText.Node(this);
                    EquipBagOfCarrying(player);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            Utility.Print($"{Name} shuffles away from you, quickly blending into the shadows and ruins.");

        }
        public bool BagChecker(Player player)
        {
            if(player.Charisma > 5 && !HasBag && player.PlayerLevel >= 3)
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
        public void EquipGreyStoneSpire(Player player)
        {
            Utility.Print("The stone, about the size of your thumb, given to you is grey and rough, but looks like a crystal.");
            Utility.Print("It's warm to the touch and you feel like it's trying to communicate with you.");
            Utility.Print("SUDDENLY, it begins shining a bright light throughout the room.");
            Program.PrintASCII(ASCII.Magic);
            Utility.Print("The crystal levitates out of your hand. It then hovers in front of you briefly, still glowing with an intense white.");
            Utility.Print("It rockets towards your head, embedding itself inside your forehead.");
            Utility.Print("Although a violent act, you feel no pain nor do you take any damage.");
            Utility.Print("In fact, you feel more powerful than before in a strange way. Nothing else seems to happen.");
            Item greyStoneSpire = new Item();
            greyStoneSpire.Name = "Greystone Crystal";
            greyStoneSpire.Description = "A small dull, grey crystal, stuck into your forehead.";
            greyStoneSpire.Durability = 1000;
            greyStoneSpire.Value = 1000;
            player.GreyStoneSpire = greyStoneSpire;
            player.MaxHP += 10;
            player.Health += 10;
        }
        public void EquipBagOfCarrying(Player player)
        {
            if (BagChecker(player))
            {
                Item[] bagOfCarrying = new Item[20];
                for (int i = 0; i < player.Inventory.Length; i++)
                {
                    bagOfCarrying[i] = player.Inventory[i];
                }
                player.Inventory = bagOfCarrying;
                HasBag = true; // Mark as given
                Utility.Print("Y'know what, I rather like you. Here, take this magical loot bag!");
            }
        }

        //public void EquipMap(Player player)
        //{
        //    Utility.Print("Map is now equipped");
        //}
        public void MarketPlace(Player player) 
        {
            StockMarketPlace();
            Utility.Print($"'Hello adventurer, how brave to come this far.' a strange character who seems to blend into the shadows.");
            Utility.Print($"'I am {Name}, the humble merchant, and I have a few items for sale. Do you want to see them?'");
            Utility.Print("1) Yes 2) Talk to merchant");
            int decision = Utility.PrintMenu(2);
            if (decision == 1)
            {
                PrintMerchantShop(player);
            } else
            {
                Utility.Print("You say to the merchant");
                Utility.Print("'Can I ask you a question?'");
                MerchantText.Node(this);
                Utility.Print("");
                Utility.Print("So, would you like to take a look at my shop? (y/n)");
                string choice = Utility.Read();
                if(choice == "y")
                {
                    PrintMerchantShop(player);
                }
                Utility.Print("Very well, we shall meet again perhaps.");
            }
        }
        public void PrintMerchantShop(Player player)
        {
            bool TransactionInProgress = true;
            do
            {
                for (int i = 0; i < Inventory.Length; i++)
                {
                    if (Inventory[i] == null) continue;
                    Utility.Print($"{i + 1}) {Inventory[i].Name}: {Inventory[i].Value} Gold Pieces");
                }
                Utility.Print($"You currently have {player.Gold} gold pieces.");
                Utility.Print("What would you like to buy?\nSelect an item");
                Utility.Print("Be careful what you choose, I don't ask twice");
                Utility.Print("0) To Exit");
                int selectedItem = Utility.PrintMenu(Inventory.Length);
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
        }
        public void StockMarketPlace()
        {
            int stockCycles = Utility.GetRandomIndex(1, 5);
            for (int i = 0; i < stockCycles; i++) {
                int weaponIndex = Utility.GetRandomIndex(0, 12);
                int armorIndex = Utility.GetRandomIndex(0, 12);
                int potionIndex = Utility.GetRandomIndex(0, 18);
                if (weaponIndex > 5)
                {
                    for (int j = 0; j < Inventory.Length; j++)
                    {
                        if (Inventory[j] == null)
                        {
                            Inventory[j] = new Weapon();
                            return;
                        }
                    }
                }
                if (armorIndex > 5)
                {
                    for (int j = 0; j < Inventory.Length; i++)
                    {
                        if (Inventory[j] == null)
                        {
                            Inventory[j] = new Armor();
                            return;
                        }
                    }
                }
                if (potionIndex > 5)
                {
                    for (int j = 0; j < Inventory.Length; i++)
                    {
                        if (Inventory[j] == null)
                        {
                            Inventory[j] = new Potion();
                            return;
                        }
                    }
                }
                if (potionIndex > 10)
                {
                    for (int j = 0; j < Inventory.Length; i++)
                    {
                        if (Inventory[j] == null)
                        {
                            Inventory[j] = new Potion();
                            return;
                        }
                    }
                }
            }
        }
    }
}
