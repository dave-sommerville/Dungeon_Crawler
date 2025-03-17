
namespace Dungeon_Crawler
{
    public class Monster
    {
        private readonly int _nextId;
        private readonly Random random = new Random();
        private readonly string[] MonsterNames = { "Goblin", "Orc", "Troll", "Dragon" };
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int ArmorClass { get; set; }
        public Monster()
        {
            MonsterId = _nextId++;
            Name = MonsterNames[random.Next(0,3)];
            Health = random.Next(0,5) + 10;
            Attack = random.Next(0, 5) + 7;
            ArmorClass = random.Next(0, 5) + 10;
        }
        public void AttackPlayer(Player player)
        {
            int damage = Attack - player.ArmorClass;
            if (damage > 0)
            {
                player.Health -= damage;
            }
        }
        // Add XP
        // Opportunity attack
        // Mana blast
    }
}
