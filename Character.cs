namespace Dungeon_Crawler
{
    public class Character
    {
        private readonly int _nextId;
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public Character(string name)
        {
            Id = _nextId++;
            Name = name;
            ArmorClass = 0;
            Health = 0;
        }
    }
}
