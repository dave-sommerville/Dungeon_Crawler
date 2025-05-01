using System.Runtime.Intrinsics.X86;

namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // Add typing and text effects to gameplay 
        // Add color
        // Add end of game sequence 
            // Add a way to save the game
        // Structure relationship between health and max health
        // Map
        // More potion classes

        // Marketplace throwing an error
        // Gold given for every search(Issue with double menu int vs string)
        // Use item menu not accepting use item to return
        // Inventory empty message needed
        // Says it's giving a boon, but I see no boon
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
                Utility.Print("n) Move North");
                Utility.Print("s) Move South");
                Utility.Print("e) Move East");
                Utility.Print("w) Move West");
                Utility.Print("p) Display Player Details");
                Utility.Print("l) Look more closely around the chamber");
                Utility.Print("i) View inventory");
                // Later - show map
                // Where possible interact with NPC
                Utility.Print("x) Exit Game");
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
            Utility.Print("Welcome Adventurer,\nBefore we begin, please tell me some things about yourself");
            Utility.Print("What is your name?");
            Utility.Print("");
            string playerName = Console.ReadLine().Trim();
            Utility.Print("Very well,\nDo you care to describe yourself?");
            Utility.Print("You may enter 'x' to skip this step");
            Console.WriteLine(); 
            string playerDesc = Console.ReadLine().Trim();
            if(playerDesc.ToLower() == "x")
            {
                playerDesc = "";
            }
            Player player = new Player(playerName, playerDesc);
            Utility.Print("You have three  skills that you will be tested on,\non top of maintaining your health and sanity");

            Utility.Print("You have the keys to your own destiny. You have two skills points you can spend now.");
            Utility.Print("You may spend them on Athletics, Perception, or Dexterity");
            Utility.Print("Please enter which skill you choose first");
            player.ApplySkillPoint();
            Utility.Print("Please enter which skill you choose second");
            player.ApplySkillPoint();
            Utility.Print("You have chosen your skills wisely, now find all the bravery your heart has to muster and proceed");
            return player;
        }
        public static void PrintIntro()
        {
            Utility.PrintLines();
            Utility.Print("WELCOME TO\nTHE DUNGEON OF BLEEPBLORPP");
            for (int i = 0; i < Utility.EntranceArt.Length; i++)
            {
                Utility.Print(Utility.EntranceArt[i]);
            }
            Utility.PrintLines();
        }
    }
}