using Dungeon_Crawler;

namespace Dungeon_Crawler
{
    public class Boss : Monster
    {
        public int NumberOfAttacks { get; set; }
        public string[]? AttackDescriptions { get; set; }
        public int TurnCounter { get; set; } = 0;
        public NPC? MonologueEngine { get; set; }
        public Spell Spell { get; set; } = new Spell();
        public Boss(string name, string description, int numberOfAttacks, string[] attackDescriptions, int playerLvl) : base(playerLvl)
        {
            Name = name;
            Description = description;
            NumberOfAttacks = numberOfAttacks;
            AttackDescriptions = attackDescriptions;
        }
        public override void Attack(Character targetCharacter)
        {
            if (TurnCounter == 2)
            {
                // Trigger Terrain effect
                // 
            } else if (TurnCounter == 4)
            {
                // Cast Spell
            } else {
                for (int i = 0; i < NumberOfAttacks; i++)
                {

                    base.Attack(targetCharacter);
                    if (AttackDescriptions != null) { Console.WriteLine(AttackDescriptions[i]); }
                }
                TurnCounter += 1;
                if (TurnCounter == 6) { TurnCounter = 0; }
            }
        }
        public void BossDeathCheck()
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
                Console.WriteLine("Would you like to add a description of your victory blow?\nEnter x to skip");
                string? victoryBlow = Console.ReadLine();
                if (victoryBlow != null && victoryBlow != "x")
                {
                    Console.WriteLine(victoryBlow);
                }
                else
                {
                    Console.WriteLine($"You have defeated {Name}");
                }
            }

        }
    }
}