
using System.Diagnostics;

namespace Dungeon_Crawler
{
    public class Player
    {
        private readonly int _nextId;
        public string Name { get; set; }
        public int RoomId { get; set; }

        public int ArmorClass { get; set; } = 2;
        public int Health { get; set; } = 100;
        public int Mana { get; set; } = 3;
        public int Attack { get; set; } = 10;
        public List<string> Inventory { get; set; } = new List<string>();
        //public int Modifiers { get; set; } = 0;
        //public int XP { get; set; } = 0;
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
        public delegate void SearchActions(Player player, string[] relics); // Will likely need a string array or dictionary to hold descriptions 
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

        public void Search(Player player, string[] relics)
        {
            SearchRoom(player, relics);
        }
        protected virtual void SearchRoom(Player player, string[] relics)
        {
            if(OnSearch != null)
            {
                OnSearch(player, relics);
            }
        }
        //Print player
        public void PlayerAttack(Monster monster)
        {
            Random random = new Random();
            if (Attack >= monster.ArmorClass)
            {
                int damage = random.Next(5, 20);
                monster.Health -= damage;
                Console.WriteLine($"The {monster.Name} is hit! Its health is reduced by {damage}, it still has {monster.Health}");
                if(monster.Health <= 0)
                {
                    Console.WriteLine("The monster has been killed");
                }
            }
            else
            {
                Console.WriteLine("Player Attack missed");
            }
        }
    }
}
