
namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        private readonly string[] MonsterNames = { "Goblin", "Orc", "Troll", "Dragon" };
        public string Species { get; set; }
        public Monster() : base()
        {
            Species = MonsterNames[random.Next(0,3)];
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
