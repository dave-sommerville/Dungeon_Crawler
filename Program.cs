﻿using System.Runtime.Intrinsics.X86;
using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            BetaLaunch();
        }
        public static void BetaLaunch()
        {
            Console.WriteLine("Welcome to the Beta Launch of my Dungeon Crawler Console app!");
            Console.WriteLine("This is a work in progress, so there may be bugs and unfinished features.");
            Console.WriteLine("Have you read the included README?\n1) Yes 2) No");
            Thread.Sleep(Utility.Delay);
            int choice = Utility.PrintMenu(2);
            if(choice == 1)
            {
                Console.WriteLine("Great! Let's get started.");
                Thread.Sleep(1000);
                Console.Clear();
                GameLaunch(CreatePlayer());
            } else
            {
                Console.WriteLine("Please read the README for instructions on how to play.");
                Thread.Sleep(Utility.Delay);
            }
        }
        public static void GameLaunch(Player player)
        {
            Dungeon dungeon = Dungeon.GetInstance();
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
                // Map functionality coming soon
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
            PrintIntro();
            Utility.Print("Hello Adventurer,\nBefore we begin, please tell me some things about yourself");
            Utility.Print("What is your name?");
            Utility.Print("");
            string playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Adventurer";
            }
            Utility.Print($"Nice name\nDo you care to describe yourself?");
            Utility.Print("You may enter 'x' to skip this step");
            Utility.Print("");
            string playerDesc = Console.ReadLine();
            if (playerDesc.ToLower().Trim() == "x")
            {
                playerDesc = "";
            }
            Player player = new Player(playerName, playerDesc);

            Utility.Print($"Welcome {player.Name} to the Dungeon of Draegmor.\nYou are about to embark on a journey that will test your skills, courage, and resolve.");
            Utility.Print("Be mindful of your limitations. Don't forget to use your items well and rest every now and then.");
            Utility.Print("");
            Utility.Print("");
            PrintASCII(ASCII.Door);
            Utility.Print("");
            //Utility.Print("You have three  skills that you will be tested on,\non top of maintaining your health and sanity");

            //Utility.Print("You have the keys to your own destiny. You have two skills points you can spend now.");
            //Utility.Print("You may spend them on Athletics, Perception, or Dexterity");
            //Utility.Print("Please enter which skill you choose first");
            //player.ApplySkillPoint();
            //Utility.Print("Please enter which skill you choose second");
            //player.ApplySkillPoint();
            //Utility.Print("You have chosen your skills wisely, now find all the bravery your heart has to muster and proceed");
            return player;
        }
        public static void PrintIntro()
        {
            Utility.PrintLines();
            Utility.Print("             THE");
            Utility.Print("           DUNGEONS");
            Utility.Print("              OF");
            Utility.Print("           DRAEGMOR");

            PrintASCII(ASCII.Wizard);
        }
        public static void PrintASCII(string[] ascii)
        {
            foreach (string line in ascii)
            {
                Utility.Print(line);
            }
        }
    }
}