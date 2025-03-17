namespace Dungeon_Crawler
{
    public class Room
    {
        private readonly Dictionary<string, int> Relics = new Dictionary<string, int>
        {
            { "Sword", 0 },
            { "Shield", 2 },
            { "Potion", 1 },
            { "Gold", 0 }
        };
        private readonly string[] RelicNames = { "Sword", "Shield", "Potion", "Gold" };


        private readonly Random random = new Random();
        public int Y { get; set; } = 0;
        public int X { get; set; } = 0;
        public string Description { get; set; }
        public Monster Monster { get; set; }
        public int TrapId { get; set; }
        public Room(int x, int y)
        {
            X = x;
            Y = y;
            Description = "You are in a room.";// Access from a large random array 
        }
        public void AddLoot(Player player)
        {
            string roomRelic = RelicNames[random.Next(0, RelicNames.Length)];
            for (int i = 0; 1 < player.Inventory.Length; i++)
            {
                if (player.Inventory[i] == null)
                {
                    player.Inventory[i] = roomRelic;
                    break;
                } else
                {
                    Console.WriteLine("You have too much loot. Drop something to pick up more.");
                    // Print inventory with menu
                    // Drop item
                    int itemToDrop = int.Parse(Console.ReadLine());
                    player.Inventory[itemToDrop] = roomRelic;
                }
            }
        }
    }
}
