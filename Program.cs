namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // Add color and typing effects 
        // Structure relationship between health and max health
        // Allow player to describe their boss kills
        // Add use item mechanic to monster fight
        // Print inventory option
        // Map
        // Write Prisoner event
        // Adjust levels a bit so that player starts at 1 and triggers end event at 10 (Good boon at level nine)
        // Bosses
            // More potion classes

        // Later
            // Artifacts
            // Map
            // Possible add ons 
                // Cursed Object
                // Ghosts
                // Spell Books//Libraries


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
                    case "l":
                        dungeon.ExploredChambers[player.LocationId].SearchForLoot(player);
                        break;
                    case "i":
                        player.PrintInventory();
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
            Console.WriteLine("Draegmor's Deep"); // ASCI art 
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
        public void PrintIntro()
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