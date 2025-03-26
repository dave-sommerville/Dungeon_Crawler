namespace Dungeon_Crawler
{
    public class Chamber
    {
        private readonly int _nextId;
        public int ChamberId { get; set; }
        public string Description { get; set; }
        public bool IsCleared { get; set; }
        public Dictionary<string, int> Exits { get; set; } = new Dictionary<string, int>();

        public Chamber(string description)
        {
            ChamberId = _nextId++;
            Description = description;
            IsCleared = false;
        }
        public void AddExit(string direction, int id)
        {
            Exits[direction] = id;
        }
    }
}
