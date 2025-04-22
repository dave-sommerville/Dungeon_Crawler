using Dungeon_Crawlerx;

namespace Dungeon_Crawler
{
    public class Battlefield : Chamber
    {
        public Boss LevelBoss { get; set; }
        public Battlefield(string id, string description) : base(id, description)
        {
            ChamberId = id;
            Description = description;

        }
        public void DisplayBattlefield()
        {
            Console.WriteLine(Description);
        }
    }
}
