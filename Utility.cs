namespace Dungeon_Crawler
{
    public class Utility
    {
        public Random random = new Random();
        public static string[] EntranceArt = new string[]
{
            "          ____    ___    ____           ",
            "         /    \\__/   \\__/    \\         ",
            "        /      /       \\      \\        ",
            "       /      /         \\      \\       ",
            "      |      |           |      |      ",
            "  ____|      |   ____    |      |____  ",
            " /    |      |  /    \\   |      |    \\ ",
            "/     |      | |      |  |      |     \\",
            "\\     |      | |      |  |      |     /",
            " \\____|______|_|______|__|______|____/ "
};

        public static int Delay = 120;
        public static int GetRandomIndex(int min, int max)
        {
            Random random = new Random();
            int randomInt = random.Next(min, max);
            return randomInt;
        }
        public static bool FiftyFifty()
        {
            int randomInt = GetRandomIndex(0, 1);
            if (randomInt == 0)
            {
                return true;
            }
            else
            {
                return false;
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
        public static void PrintLines()
        {
            int lines = 10;
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
