namespace Dungeon_Crawler
{
    internal class Program
    {
        public static string[] Inventory { get; private set; }
        public static string[] Traps { get; private set; }
        public static List<Room> Rooms { get; set; }
        static void Main(string[] args)
        {

        }
        public static void userInterface()
        {
            Player player = new Player("Player");
            player.OnBattle += BattleMonster;
            player.OnBlast += BlastMonster;
            player.OnFlee += FleeMonster;

            bool IsRunning = true;
            while(IsRunning)
            {
                Console.WriteLine("Please select an option");
                int decision = PrintMenu();
                switch(decision)
                {
                    case 1:
                        //Explore
                        break;
                    case 2:
                        Console.WriteLine($"Player Name: {player.Name}\nPlayer Health: {player.Health}");
                        break;
                    case 3:
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
        public static int PrintMenu()
        {
            return 0;
        }
        public static void RoomEvents(Player player)
        {
            Room newRoom = new Room();
            DisplayRoom(newRoom);
            Random random = new Random();
            int r = random.Next(0, 2);
            if (r == 0)
            {
                // Trigger monster event 
            }
            else if (r == 1)
            {
                // Trigger trap event
            } else
            {
                
            }
        }
        public static void DisplayRoom(Room room)
        {
            // Display room information
            // Print menu choices 
        }

        public static void MonsterMenu()
        {
            // Battle
            // Flee
            // Blast
        }

        //  Delegate subscriptions 
        public static void BattleMonster(Player player, Monster monster)
        {
            bool battleRunning = true;
            while(battleRunning)
            {
               //Player and monster should have attack methods 
               if(monster.Health > 0)
                {
                    battleRunning = false;
                }
                //Player and monster should have attack methods 
                if (player.Health > 0)
                {
                    // Player should also have a death method to end game
                    battleRunning = false;
                }
            }
        }
        public static void FleeMonster(Player player, Monster monster)
        {
            //Monster attack
            //Explore room trigger
        }
        public static void BlastMonster(Player player, Monster monster)
        {//Console player through process
            if (player.Mana >= 1)
            {
                monster.Health = 0;
                player.Mana -= 1;
            }
        }
        public static void TriggerTrap()
        {
        }
        public static void SearchRoom(Player player)
        {
            Random random = new Random();
            if(random.Next(0,4) > 2)
            {
                Relic foundRelic = new Relic();
                player.Inventory.Add(foundRelic);
                Console.WriteLine($"Player has added {foundRelic} to their inventory");
            }
        }
    }
}