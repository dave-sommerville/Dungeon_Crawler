namespace Dungeon_Crawler
{
    public class Character
    {
        private readonly int _nextId;
        public int Id { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public Character()
        {
            Id = _nextId++;
            ArmorClass = 0;
            Health = 0;
            Attack = 0;
        }
    }
}
