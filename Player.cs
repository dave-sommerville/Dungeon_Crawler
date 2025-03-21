
namespace Dungeon_Crawler
{
    public class Player
    {
        public string Name { get; set; }
        // Player position
        public int PlayerX { get; set; } = 0;
        public int PlayerY { get; set; } = 0;
        public List<Room> ExploredRooms { get; set; } = new List<Room>();
        public int ArmorClass { get; set; } = 10;
        public int Health { get; set; } = 100;
        public int XP { get; set; } = 0;
        public int Mana { get; set; } = 3;
        public int Attack { get; set; } = 10;
        public int Modifiers { get; set; } = 0;
        public string[] Inventory { get; set; } = new string[5];
        public Player(string name)
        {
            Name = name;
        }

        //  Flee
        //  Mana Blast 
        //  Menu to print all three

        //  Move
        //  Dodge

    }
}
