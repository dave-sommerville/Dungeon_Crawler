using Dungeon_Crawler;

namespace Dungeon_Crawlerx
{
    public class Boss : Monster
    {
        public int NumberOfAttacks { get; set; }
        public string[]? AttackDescriptions { get; set; }
        public int TurnCounter { get; set; } = 0;
        public NPC? MonologueEngine { get; set; }
        // Should have a turn counter, trigger a terrain event or dialogue
        public Boss(string name, string description, int numberOfAttacks, string[] attackDescriptions, int playerLvl) : base(playerLvl)
        {
            Name = name;
            Description = description;
            NumberOfAttacks = numberOfAttacks;
            AttackDescriptions = attackDescriptions;
        }
        public override void Attack(Character targetCharacter)
        {
            for(int i = 0; i < NumberOfAttacks; i++)
            {
                base.Attack(targetCharacter);
                if (AttackDescriptions != null) { Console.WriteLine(AttackDescriptions[i]); }
            }
            TurnCounter += 1;
        }
    }
}