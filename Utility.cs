namespace Dungeon_Crawler
{
    public class Utility
    {
        public Random random = new Random();

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

    }
}
