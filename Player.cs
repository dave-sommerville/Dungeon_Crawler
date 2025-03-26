
using System.Diagnostics;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public Random random = new Random();
        public string Name { get; set; }
        public int Mana { get; set; } = 3;
        public List<string> Inventory { get; set; } = new List<string>();
        public int Gold { get; set; } 
        public int LocationId { get; set; }
        public Player(string name) : base()
        {
            Name = name;
            ArmorClass = 8;
            Health = 100;
            Attack = 10;
            Gold = 10;
            Mana = 3;
            LocationId = 0;
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

        public void Move(string direction, Dungeon dungeon)
        {
            if (dungeon.ExploredChambers.ContainsKey(LocationId) &&
                dungeon.ExploredChambers[LocationId].Exits.TryGetValue(direction, out int newLocation))
            {
                LocationId = newLocation;
                Console.WriteLine($"You move {direction} to room {LocationId}.");
                dungeon.DisplayRoomExits(LocationId);
                ClearChamber(this);
            }
            else
            {
                Console.WriteLine("You can't go that way!");
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
        public void ClearChamber(Player player)
        {
            int rand = Program.Random.Next(1, 4);
            if (rand == 1)
            {
                EncounterMonster();
            }
            else if (rand == 2)
            {
                Console.WriteLine("Room is clear");
                Console.WriteLine("Choose an action:\n1) Search the room\n2) Continue exploring");
                int decision = Program.PrintMenu(2);
                if (decision == 1)
                {
                    Search(player);
                }
            }
            else if (rand == 3)
            {
                Console.WriteLine("Trap triggered!");
                Trigger(player);
            }
        }

    }
}
