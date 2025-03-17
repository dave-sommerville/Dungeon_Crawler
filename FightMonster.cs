
namespace Dungeon_Crawler
{
    public class FightMonster
    {
        public delegate void FightHandler(Player player);
        public event FightHandler Fight;
        public void MonsterFight(Player player, Room room)
        {
            // Logic and activity here
            bool battleRunning = true;
            while(battleRunning)
            {
                if (room.Monster.Health > 0)
                {
                    room.Monster.AttackPlayer(player);
                } else if (room.Monster.Health <= 0)
                {
                    // Add xp to player
                    // Write message
                    battleRunning = false;
                }
                if (player.Health > 0)
                {
                    //  Three battle actions

                } 
            }
            OnMonsterFight(player);
        }
        protected virtual void OnMonsterFight(Player player)
        {
            Fight?.Invoke(player);
        }
    }
}
