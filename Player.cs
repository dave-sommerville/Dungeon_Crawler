
using System.Diagnostics;

namespace Dungeon_Crawler
{
    public class Player
    {
        private readonly int _nextId;
        public string Name { get; set; }
        public int RoomId { get; set; }
        // Player position
        //public int PlayerX { get; set; } = 0;
        //public int PlayerY { get; set; } = 0;
        //public List<Room> ExploredRooms { get; set; } = new List<Room>();
        public int ArmorClass { get; set; } = 10;
        public int Health { get; set; } = 100;
        //public int XP { get; set; } = 0;
        public int Mana { get; set; } = 3;
        public int Attack { get; set; } = 10;
        //public int Modifiers { get; set; } = 0;
        public string[] Inventory { get; set; } = new string[5];
        public Player(string name)
        {
            RoomId = _nextId++;
            Name = name;
        }
        public delegate void MonsterActions(Player player, Monster monster);
        public event MonsterActions OnBattle;
        public event MonsterActions OnBlast;
        public event MonsterActions OnFlee;
        public delegate void TrapActions(Player player); // Will likely need a string array or dictionary to hold descriptions 
        public event TrapActions OnTrigger;
        public delegate void SearchActions(Player player); // Will likely need a string array or dictionary to hold descriptions 
        public event SearchActions OnSearch;

        public void Battle(Player player, Monster monster)
        {
            // Line optional
            BattleMonster(player, monster);
        }
        protected virtual void BattleMonster(Player player, Monster monster)
        {
            if(OnBattle != null)
            {
                OnBattle(player, monster);
            }
        }
        public void Blast(Player player, Monster monster)
        {
            // Line optional
            BlastMonster(player, monster);
        }
        protected virtual void BlastMonster(Player player, Monster monster)
        {
            if (OnBlast != null)
            {
                OnBlast(player, monster);
            }
        }
        public void Flee(Player player, Monster monster)
        {
            // Line optional
            FleeMonster(player, monster);
        }
        protected virtual void FleeMonster(Player player, Monster monster)
        {
            if (OnFlee != null)
            {
                OnFlee(player, monster);
            }
        }

        public void Trigger(Player player)
        {
            TriggerTrap(player);
        }
        protected virtual void TriggerTrap(Player player)
        {
            if (OnTrigger != null)
            {
                OnTrigger(player);
            }
        } 
        //  OnExplore
            //  OnTrap
            //  OnSearch
    }
}
