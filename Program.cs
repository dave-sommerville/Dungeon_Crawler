using System.Runtime.Intrinsics.X86;

namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // Add typing and text effects to gameplay 
        // Add end of game sequence 
        // Add a way to save the game
        // Add color
        // Structure relationship between health and max health
        // Map
        // More potion classes

        // Marketplace throwing an error
        // Gold given for every search(Issue with double menu int vs string)
        // Use item menu not accepting use item to return
        // Inventory empty message needed
        // Doesn't need to list that you don't have a weapon to use
        // Says it's giving a boon, but I see no boon
        // It's only giving gold
        // Issue with plot index
        // The naming npc function
        // NPC loop not ending
        // Merchant dialogue options?
        // Trap descriptions


        // Full Release
        // Artifacts
        // Cursed Object
        // Ghosts
        // Spell Books//Libraries
        // Shadows of Madness
        // Aboleth Encounter
        // Beholder Encounter
        // Balhannoth encounter 
        // Elder Brain dialogue system


        static void Main(string[] args)
        {
            GameLaunch(CreatePlayer());
        }
        public static void GameLaunch(Player player)
        {
            Dungeon dungeon = new Dungeon();
            bool IsRunning = true;

            while(IsRunning && player.Health > 0)
            {
                Console.WriteLine("n) Move North");
                Console.WriteLine("s) Move South");
                Console.WriteLine("e) Move East");
                Console.WriteLine("w) Move West");
                Console.WriteLine("p) Display Player Details");
                Console.WriteLine("l) Look more closely around the chamber");
                Console.WriteLine("i) View inventory");
                // Later - show map
                // Where possible interact with NPC
                Console.WriteLine("x) Exit Game");
                string decision = Console.ReadLine()?.ToLower();
                switch (decision)
                {
                    case "n":
                    case "s":
                    case "e":
                    case "w":
                        player.MovePlayer(decision, dungeon);
                        break;
                    case "p":
                        player.PrintPlayerDetails();
                        break;
                    case "1":
                        dungeon.ExploredChambers[player.LocationId].SearchForLoot(player);
                        break;
                    case "2":
                        dungeon.ExploredChambers[player.LocationId].Rest(player);
                        break;
                    case "i":
                        player.PrintInventory();
                        player.UseItemOption();
                        break;
                    case "x":
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
        public static Player CreatePlayer()
        {
            PrintIntro();// ASCI art 
            Console.WriteLine("Welcome Adventurer,\nBefore we begin, please tell me some things about yourself");
            Console.WriteLine("What is your name?");
            Console.WriteLine();
            string playerName = Console.ReadLine().Trim();
            Console.WriteLine("Very well,\nDo you care to describe yourself?");
            Console.WriteLine("You may enter 'x' to skip this step");
            Console.WriteLine(); 
            string playerDesc = Console.ReadLine().Trim();
            if(playerDesc.ToLower() == "x")
            {
                playerDesc = "";
            }
            Player player = new Player(playerName, playerDesc);
            Console.WriteLine("You have three  skills that you will be tested on,\non top of maintaining your health and sanity");

            Console.WriteLine("You have the keys to your own destiny. You have two skills points you can spend now.");
            Console.WriteLine("You may spend them on Athletics, Perception, or Dexterity");
            Console.WriteLine("Please enter which skill you choose first");
            player.ApplySkillPoint();
            Console.WriteLine("Please enter which skill you choose second");
            player.ApplySkillPoint();
            Console.WriteLine("You have chosen your skills wisely, now find all the bravery your heart has to muster and proceed");
            return player;
        }
        public static void PrintIntro()
        {
            Utility.PrintLines();
            Console.WriteLine("WELCOME TO\nTHE DUNGEON OF BLEEPBLORPP");
            Utility.PrintLines();
            for (int i = 0; i < Utility.EntranceArt.Length; i++)
            {
                Thread.Sleep(Utility.Delay);
                Console.WriteLine(Utility.EntranceArt[i]);
            }
        }
    }
}