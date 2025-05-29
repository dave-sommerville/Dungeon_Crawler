using System.Runtime.Intrinsics.X86;
using Dungeon_Crawler.Characters_and_dialogue;

namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        // Figure out spells

        static void Main(string[] args)
        {
            GameLaunch(CreatePlayer());
        }
        public static void GameLaunch(Player player)
        {
            Dungeon dungeon = new Dungeon();
            player.IsPlaying = true;

            while (player.IsPlaying && player.Health > 0)
            {
                Chamber chamber = dungeon.ExploredChambers[player.LocationId];
                if (chamber.NorthPassage)
                {
                    Thread.Sleep(Utility.Delay);
                    Console.WriteLine("n) Move North");
                }
                if (chamber.SouthPassage)
                {
                    Thread.Sleep(Utility.Delay);
                    Console.WriteLine("s) Move South");
                }
                if (chamber.EastPassage)
                {
                    Thread.Sleep(Utility.Delay);
                    Console.WriteLine("e) Move East");
                }
                if (chamber.WestPassage)
                {
                    Thread.Sleep(Utility.Delay);
                    Console.WriteLine("w) Move West");
                }
                Thread.Sleep(Utility.Delay);
                Console.WriteLine("p) Display Player Details");
                Thread.Sleep(Utility.Delay);
                Console.WriteLine("i) View inventory");
                Thread.Sleep(Utility.Delay);
                // Later - show map
                Console.WriteLine("x) Exit Game");
                string decision = Utility.Read();
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
                        player.GameOver();
                        player.IsPlaying = false;
                        break;
                    default:
                        Thread.Sleep(Utility.Delay);
                        Utility.Print("Invalid selection");
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
            string playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Adventurer";
            }
            Utility.Print($"Very well,\nDo you care to describe yourself?");
            Utility.Print("You may enter 'x' to skip this step");
            Console.WriteLine();
            string playerDesc = Console.ReadLine();
            if (playerDesc.ToLower().Trim() == "x")
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
            Utility.Print("WELCOME TO\nTHE DUNGEON OF DRAEGMOR ");
            for (int i = 0; i < Utility.EntranceArt.Length; i++)
            {
                Utility.Print(Utility.EntranceArt[i]);
            }
            Utility.PrintLines();
        }

    }
}