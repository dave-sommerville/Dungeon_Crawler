
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public Random random = new Random();
        public int Y { get; set; }
        public int X { get; set; }
        public string LocationId { get; set; }
        public int Modifer { get; set; } = 0;
        public int Sanity { get; set; } = 100;
        public int Dexterity { get; set; } = 0;
        public int Athletics { get; set; } = 0;
        public int Perception { get; set; } = 0;
        public int XP { get; set; } = 0;
        public int Mana { get; set; } = 3;
        public int Gold { get; set; }
        public Item[] Inventory { get; set; } = new Item[10];
        public Player(string name, string description) : base(name, description)
        {
            ArmorClass = 8;
            Health = 100;
            Gold = 10;
            Dexterity = 0;
            Athletics = 0;
            Perception = 0;
            Y = 0;
            X = 0;
            LocationId = "00";
            Mana = 3;
        }

        public static int PrintMenu(int options)
        {
            int intDecision;
            bool isValid;
            do
            {
                string decision = Console.ReadLine();
                isValid = int.TryParse(decision, out intDecision) && intDecision >= 1 && intDecision <= options;
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!isValid);
            return intDecision;
        }
        public void PrintPlayerDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"AC: {ArmorClass}\nHP: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine("Inventory:");

        }
        public void NavCase(string decision, Chamber currentChamber)
        {
            switch (decision) {
                case "n":
                    if (currentChamber.NorthPassage)
                    {
                        Y += 1;
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "s":
                    if (currentChamber.SouthPassage)
                    {
                        Y -= 1;
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "w":
                    if (currentChamber.WestPassage)
                    {
                        X -= 1;
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "e":
                    if (currentChamber.EastPassage)
                    {
                        X += 1;
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                default:
                    break;
            }

        }
        public void MovePlayer(string decision, Dungeon dungeon)
        {
            Chamber currentChamber = dungeon.ExploredChambers[LocationId];
            string locationRef = LocationId;
            NavCase(decision, currentChamber);
            LocationId = $"{Y}{X}";

            if(dungeon.ExploredChambers.ContainsKey(LocationId))
            {
                Console.WriteLine("You've already explored this room");
                Console.WriteLine("Would you like to view the description again?\n1) Yes\n2) No");
                int viewDesicion = PrintMenu(2);
                if(viewDesicion == 1)
                {
                    currentChamber.DisplayDescription();
                } else
                {
                    return;
                }
            } else
            {
                Chamber newChamber = dungeon.GenerateChamber(LocationId);
                switch(decision)
                {
                    case "n":
                        dungeon.ExploredChambers[locationRef].SouthPassage = true;
                        break;
                    case "s":
                        dungeon.ExploredChambers[locationRef].NorthPassage = true; 
                        break;
                    case "e":
                        dungeon.ExploredChambers[locationRef].WestPassage = true;
                        break;
                    case "w":
                        dungeon.ExploredChambers[locationRef].EastPassage = true;
                        break;
                }
                newChamber.DisplayDescription();
            }
        }

        public static void AddToInventory()
        {

        }

    }
}
