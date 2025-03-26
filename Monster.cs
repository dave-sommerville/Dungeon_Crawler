
namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        private readonly List<string> MonsterNames = new List<string>
{
    "Goblin",
    "Orc",
    "Troll",
    "Kobold",
    "Giant Rat",
    "Skeleton",
    "Zombie",
    "Ghoul",
    "Wraith",
    "Mimic",
    "Gargoyle",
    "Ogre",
    "Basilisk",
    "Minotaur",
    "Lich",
    "Hobgoblin",
    "Giant Spider",
    "Wyvern",
    "Dark Elf",
    "Slime"
};

        public string Species { get; set; }
        public Monster() : base()
        {
            Species = MonsterNames[random.Next(0,MonsterNames.Count())];
            Health = random.Next(0,5) + 10;
            Attack = random.Next(0, 5) + 7;
            ArmorClass = random.Next(0, 5) + 2;
        }
        public void MonsterAttack(Player player)
        {
            Random random = new Random();
            if(Attack >= player.ArmorClass)
            {
                int damage = random.Next(5, 20);
                player.Health -= damage;
                Console.WriteLine($"Player hit! Player's health reduced by {damage}");
            } else
            {
                Console.WriteLine("Monster Attack missed");
            }
        }
    }
}
