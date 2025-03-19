namespace Dungeon_Crawler
{
    public class Trap
    {
        public int TrapId { get; set; }
        public string Description { get; set; }
        public Trap(int trapId)
        {
            TrapId = trapId;
            Description = "You have triggered a trap!";
        }
        public delegate void TrapHandler(Player player);
        public event TrapHandler OnTrapTriggered;

    }
}
