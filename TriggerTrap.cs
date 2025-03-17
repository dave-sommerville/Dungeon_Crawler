
namespace Dungeon_Crawler
{
    public class TriggerTrap
    {
        public delegate void TrapHandler(Player player);
        public event TrapHandler Trap;
        public void TrapTrigger(Player player)
        {   // Logic and activity here 
            OnTrapTrigger(player);
        }
        protected virtual void OnTrapTrigger(Player player)
        {
            Trap?.Invoke(player);
        }
    }
}
