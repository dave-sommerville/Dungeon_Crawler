namespace Dungeon_Crawler.Utilities
{
    public class Utility
    {
        public Random random = new Random();

        public static int Delay = 120;
        public static List<string> GameHistory = new List<string>();
        public static int GetRandomIndex(int min, int max)
        {
            Random random = new Random();
            int randomInt = random.Next(min, max);
            return randomInt;
        }
        public static bool FiftyFifty()
        {
            int randomInt = GetRandomIndex(0, 2);
            if (randomInt == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Print(string printing)
        {
            GameHistory.Add(printing);
            Thread.Sleep(Delay);
            Console.WriteLine(printing);
        }
        public static int PrintMenu(int options)
        {
            int intDecision;
            bool isValid;
            do
            {
                string decision = Console.ReadLine();
                isValid = int.TryParse(decision, out intDecision) && intDecision >= 0 && intDecision <= options;
                if (!isValid)
                {
                    Thread.Sleep(Delay);
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!isValid);
            return intDecision;
        }
        public static string Read()
        {
            string decision;
            bool isValid;
            do
            {
                decision = Console.ReadLine().Trim().ToLower();
                if (decision == "" || decision == null)
                {
                    break;
                }
                else
                {
                    isValid = decision.Length > 0 && decision.Length < 2;
                    isValid = new[] { 's', 'e', 'n', 'w', '1', '2', 'x', 'i', 'p', 'y' }.Contains(decision[0]);
                    if (!isValid)
                    {
                        Thread.Sleep(Delay);
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
            } while (!isValid);
            return decision;
        }
        public static void PrintLines()
        {
            int lines = 10;
            for (int i = 0; i < lines; i++)
            {
                Thread.Sleep(Delay);
                Console.WriteLine();
            }
        }
        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static bool ChanceBool(int chanceIndex)
        {
            int chance = GetRandomNumber(1, 101);
            if (chance <= chanceIndex) 
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        public static void SaveGameHistory()
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folderPath = Path.Combine(documentsPath, "GameSaves");
                Directory.CreateDirectory(folderPath);
                string fileName = $"game-history-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
                string fullPath = Path.Combine(folderPath, fileName);
                File.WriteAllLines(fullPath, GameHistory);
                Console.WriteLine($"Your progress has been saved to file '{fullPath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save game: {ex.Message}");
            }
            
        }
    }
}
