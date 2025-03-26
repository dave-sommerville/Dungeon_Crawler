
using System.Diagnostics;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public string Name { get; set; }
        public int Mana { get; set; } = 3;
        public List<string> Inventory { get; set; } = new List<string>();
        public int Gold { get; set; }
        //public int Modifiers { get; set; } = 0;
        //public int XP { get; set; } = 0;
        //Explored room tracker  
        public Player(string name) : base()
        {
            Name = name;
            ArmorClass = 8;
            Health = 100;
            Attack = 10;
            Gold = 10;
            Mana = 3;
        }
        public delegate void MonsterActions(Player player, Monster monster);
        public event MonsterActions OnBattle;
        public event MonsterActions OnBlast;
        public event MonsterActions OnFlee;
        public delegate void TrapActions(Player player); 
        public event TrapActions OnTrigger;
        public delegate void SearchActions(Player player); 
        public event SearchActions OnSearch;

        public void Battle(Player player, Monster monster)
        {
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

        public void Search(Player player)
        {
            SearchRoom(player);
        }
        protected virtual void SearchRoom(Player player)
        {
            if(OnSearch != null)
            {
                OnSearch(player);
            }
        }
        //  Other player methods
        public void PrintPlayerDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"AC: {ArmorClass}\nHP: {Health}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Mana: {Mana}");
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.Write(Inventory[i].ToString());
            }
        }
        public void PlayerAttack(Monster monster)
        {
            Random random = new Random();
            if (Attack >= monster.ArmorClass)
            {
                int damage = random.Next(5, 20);
                monster.Health -= damage;
                Console.WriteLine($"The {monster.Species} is hit! Its health is reduced by {damage}, it still has {monster.Health}");
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
