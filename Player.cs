
using System.Diagnostics;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public Random random = new Random();
        private int _nextId = 1;
        public string Name { get; set; }
        public int Mana { get; set; } = 3;
        public List<string> Inventory { get; set; } = new List<string>();
        public int Gold { get; set; } 
        public int Y { get; set; }
        public int X { get; set; }
        public string LocationId { get; set; }
        public Player(string name) : base()
        {
            Name = name;
            ArmorClass = 8;
            Health = 100;
            Attack = 10;
            Gold = 10;
            Y = 0;
            X = 0;
            LocationId = "00";
            Mana = 3;
        }
        public delegate void MonsterActions(Player player, Monster monster);
        public event MonsterActions OnBattle;
        public event MonsterActions OnBlast;
        public event MonsterActions OnFlee;
        public delegate void TrapActions(Player player); 
        public event TrapActions OnTrigger;
        public delegate void SearchActions(Player player); 
        public event SearchActions OnSearch;

        public void Battle(Player player, Monster monster)
        {
            BattleMonster(player, monster);
        }
        protected virtual void BattleMonster(Player player, Monster monster)
        {
            if(OnBattle != null)
            {
                OnBattle(player, monster);
            }
        }
        public void Blast(Player player, Monster monster)
        {
            BlastMonster(player, monster);
        }
        protected virtual void BlastMonster(Player player, Monster monster)
        {
            if (OnBlast != null)
            {
                OnBlast(player, monster);
            }
        }
        public void Flee(Player player, Monster monster)
        {
            FleeMonster(player, monster);
        }
        protected virtual void FleeMonster(Player player, Monster monster)
        {
            if (OnFlee != null)
            {
                OnFlee(player, monster);
            }
        }
        public void Trigger(Player player)
        {
            TriggerTrap(player);
        }
        protected virtual void TriggerTrap(Player player)
        {
            if (OnTrigger != null)
            {
                OnTrigger(player);
            }
        }
        public void Search(Player player)
        {
            SearchRoom(player);
        }
        protected virtual void SearchRoom(Player player)
        {
            if(OnSearch != null)
            {
                OnSearch(player);
            }
        }
        //  Other player methods
        public void PrintPlayerDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"AC: {ArmorClass}\nHP: {Health}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Mana: {Mana}");
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.Write(Inventory[i].ToString());
            }
        }
        public void MovePlayer(string decision, Dungeon dungeon)
        {
            Chamber currentChamber = dungeon.ExploredChambers[LocationId];
            string locationRef = LocationId;
            switch (decision)
            {
                case "n":
                    if (currentChamber.NorthPassage)
                    {
                        Y += 1;
                        break;
                    } else
                    {
                        Console.Write("You can't go this way");
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
                        Console.Write("You can't go this way");
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
                        Console.Write("You can't go this way");
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
                        Console.Write("You can't go this way");
                        break;
                    }
                default:
                            break;
                        }
            LocationId = $"{Y}{X}";

            if(dungeon.ExploredChambers.ContainsKey(LocationId))
            {
               Console.WriteLine("You've already explored this room");
               currentChamber.DisplayDescription();
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
                ClearChamber(newChamber);
            }
        }
        public void PlayerAttack(Monster monster)
        {
            Random random = new Random();
            if (Attack >= monster.ArmorClass)
            {
                int damage = random.Next(5, 20);
                monster.Health -= damage;
                Console.WriteLine($"The {monster.Species} is hit! Its health is reduced by {damage}.");
                if(monster.Health <= 0)
                {
                    Console.WriteLine("The monster has been killed");
                } else
                {
                    Console.WriteLine($"It still has {monster.Health}");
                }
            }
            else
            {
                Console.WriteLine("Player Attack missed");
            }
        }
        public static void MonsterMenu(Player player)
        {
            Monster newMonster = new Monster();
            Console.WriteLine($"A {newMonster.Species} appears in front of you. What do you do?");
            Console.WriteLine("1) Battle Monster\n2) Use a Mana blast against monster\n3) Flee Monster");
            int decision = PrintMenu(3);
            switch (decision)
            {
                case 1:
                    player.Battle(player, newMonster);
                    break;
                case 2:
                    player.Blast(player, newMonster);
                    break;
                case 3:
                    player.Flee(player, newMonster);
                    break;
            }
        }
        public void ClearChamber(Chamber chamber)
        {
            int rand = random.Next(1, 4);
            if (rand == 1)
            {
                MonsterMenu(this);
            }
            else if (rand == 2)
            {
                Console.WriteLine("Trap triggered!");
                Trigger(this);
            }
                Console.WriteLine("Room is clear");
                Console.WriteLine("Choose an action:\n1) Search the room\n2) Continue exploring");
                int decision = PrintMenu(2);
                if (decision == 1)
                {
                    Search(this);
                }
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
    }
}
