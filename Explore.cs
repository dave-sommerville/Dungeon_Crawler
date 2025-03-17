
namespace Dungeon_Crawler
{
    public class Explore
    {
        public delegate void ExplorationHandler(Player player);
        public event ExplorationHandler Exploration;
        private  readonly Random random = new Random();
        public void ExploreRoom(Player player)
        {   // Logic and activity here
            // Needs method for location parameters 
            Room newRoom = new Room(0, 0);
            int r = random.Next(0, 2);
            if (r == 0)
            {
                // Trigger monster event 
            } else if (r == 1)
            {
                // Trigger trap event
            }
            player.ExploredRooms.Add(newRoom);
            OnExploreRoom(player);
        }
        protected virtual void OnExploreRoom(Player player)
        {
            Exploration?.Invoke(player);
        }
    }
}
