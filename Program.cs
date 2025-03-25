namespace Dungeon_Crawler
{
    internal class Program
    {
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
            player.OnSearch += SearchRoom;


            bool IsRunning = true;
            while(IsRunning && player.Health > 0)
            {
                Console.WriteLine("Please select an option");
                int decision = PrintMenu(4);
                switch(decision)
                {
                    case 1:
                        ExploreDungeon(Relics, player, Monsters);
                        break;
                    case 2:
                        Console.WriteLine($"Player Name: {player.Name}\nPlayer Health: {player.Health}");
                        break;
                    case 3:
                        //Game Instructions
                        Console.WriteLine("Instructions");
                        break;
                    case 4:
                        //Exit
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
        public static void ExploreDungeon(List<string> descriptions, Player player, List<Monster> monsters)
        {
            Random random = new Random();
            Console.WriteLine("You proceed to the next room");
            Console.WriteLine($"{descriptions[random.Next(0, descriptions.Count)]}");
            int randIndex = random.Next(1, 4);
            if (randIndex <= 2)
            {
                MonsterMenu(player, monsters);
            } else if (randIndex == 3)
            {
                player.Trigger(player);
            } else
            {
                Console.WriteLine("Nothing else of note");//Need to search room or break to previous menu
            }
        }

        public static void MonsterMenu(Player player, List<Monster> monsters)
        {
            Monster newMonster = new Monster();
            Console.WriteLine($"A {newMonster.Name} appears in front of you. What do you do?");
            Console.WriteLine("1) Battle Monster\n2) Use a Mana blast against monster\n3) Flee Monster");
            int decision = PrintMenu(3);
            switch(decision)
            {
                case 1:
                    player.Battle(player, newMonster);
                    break;
                case 2:
                    player.Flee(player, newMonster);
                    break;
                case 3:
                    player.Blast(player, newMonster);
                    break;
            }
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
        public static void FleeMonster(Player player, Monster monster)
        {//Console player through process
            monster.MonsterAttack(player);
        }
        public static void MonsterBlast(Player player, Monster monster)
        {//Console player through process
            if (player.Mana >= 1)
            {
                monster.Health = 0;
                player.Mana -= 1;
            }
        }
        public static void TriggerTrap(Player player)
        {
        }
        public static void SearchRoom(Player player, string[] relics)
        {
            Random random = new Random();
            if(random.Next(0,6) > 2)
            {
                string foundRelic = relics[random.Next(0,relics.Count())];
                player.Inventory.Add(foundRelic);
                Console.WriteLine($"Player has added {foundRelic} to their inventory");
            } else
            {
                Console.WriteLine("Nothing found");
            }
        }
    }
}