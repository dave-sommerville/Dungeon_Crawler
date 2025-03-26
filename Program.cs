namespace Dungeon_Crawler
{
    internal class Program
    {
        public static Random Random = new Random();
        public static string[] Inventory { get; private set; }
        public static List<string> Relics { get; private set; } = new List<string>
        {
            "Big",
            "Small"
        };
        public static List<Monster> Monsters { get; set; }
        static void Main(string[] args)
        {
            userInterface();
        }
        public static void userInterface()
        {
            Player player = new Player("Player");
            player.OnBattle += MonsterBattle;
            player.OnBlast += MonsterBlast;
            player.OnFlee += FleeMonster;
            player.OnTrigger += TriggerTrap;
            player.OnSearch += SearchForRelics;
            player.OnSearch += SearchForGold;
            player.OnSearch += SearchForPotions;


            bool IsRunning = true;
            while(IsRunning && player.Health > 0)
            {
                Console.WriteLine("Please select option\n1) Explore Dungeon\n2) Display Player details\n3) Show instructions\n4) Exit Game");
                int decision = PrintMenu(4);
                switch(decision)
                {
                    case 1:
                        ExploreDungeon(player);
                        break;
                    case 2:
                        player.PrintPlayerDetails();
                        break;
                    case 3:
                        Console.WriteLine("Instructions");
                        break;
                    case 4:
                        Console.WriteLine("Exiting game");
                        IsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }

        }
        private static int PrintMenu(int options)
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
        public static void ExploreDungeon(Player player)
        {
            Random random = new Random();
            Console.WriteLine("You proceed to the next room");
            //Console.WriteLine($"{descriptions[random.Next(0, descriptions.Count)]}");
            int randIndex = random.Next(1, 4);
            if (randIndex <= 2)
            {
                MonsterMenu(player);
            } else if (randIndex == 3)
            {
                player.Trigger(player);
            } else
            {
                Console.WriteLine("Choose an action:\n1) Search the room\n2)Continue exploring");
                int decision = PrintMenu(2);
                if (decision == 1)
                {
                    player.Search(player);
                }
            }
        }
        public static void MonsterMenu(Player player)
        {
            Monster newMonster = new Monster();
            Console.WriteLine($"A {newMonster.Species} appears in front of you. What do you do?");
            Console.WriteLine("1) Battle Monster\n2) Use a Mana blast against monster\n3) Flee Monster");
            //while (newMonster.Health > 0) {
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
            //}
        }

        //  Delegate subscriptions 
        public static void MonsterBattle(Player player, Monster monster)
        {
            bool battleRunning = true;
            while(battleRunning)
            {
               if(monster.Health > 0)
                {
                    monster.MonsterAttack(player);
                } else if(monster.Health <= 0)
                {
                    battleRunning = false;
                }
                if (player.Health > 0)
                {
                    player.PlayerAttack(monster);
                }
                else if (player.Health <= 0)
                {
                    battleRunning = false;
                }
            }
        }
        public static void MonsterBlast(Player player, Monster monster)
        {
            if (player.Mana >= 1)
            {
                monster.Health = 0;
                player.Mana -= 1;
            } else if (player.Mana <= 0)
            {
                Console.WriteLine($"{player.Name} doesn't have enough Mana");
            }
        }
        public static void FleeMonster(Player player, Monster monster)
        {
            monster.MonsterAttack(player);
            ExploreDungeon(player);
        }

        public static void TriggerTrap(Player player)
        {
        }
        public static void SearchForRelics(Player player)
        {
            Random random = new Random();
            if(random.Next(0,6) > 2)
            {
                string foundRelic = Relics[random.Next(0,Relics.Count())];
                player.Inventory.Add(foundRelic);
                Console.WriteLine($"{player.Name} has added {foundRelic} to their inventory");
            } else
            {
                Console.WriteLine("Nothing found");
            }
        }
        public static void SearchForPotions(Player player)
        {
            int randSelect = Random.Next(1,10);
            if(randSelect == 10)
            {
                Console.WriteLine($"{player.Name} found a glowing blue potion. Upon drinking it, they gained 1 mana");
                Console.WriteLine($"{player.Name} Mana Currently: {player.Mana}");
            } else if(randSelect <= 9 && randSelect > 7)
            {
                int hp = Random.Next(1, 3);
                player.Health += hp;
                Console.WriteLine($"{player.Name} found a dark green potion. Upon drinking it, they gained {hp} Health");
            } else
            {
                Console.WriteLine("There are no potions in this room");
            }
        }
        public static void SearchForGold(Player player)
        {
            if (Random.Next(1,10) > 5) 
            {
                int gold = Random.Next(1, 300) * 10;
                Console.WriteLine($"{player.Name} discovered {gold} Gold Pieces in this room");
                player.Gold += gold;
            } else
            {
                Console.WriteLine("No gold found");
            }
        }
    }
}