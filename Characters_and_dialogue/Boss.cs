using Dungeon_Crawler.Spells;

namespace Dungeon_Crawler;
using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Spells;

// Drow
// Drider and 2 guards 
// Spider Demon
// Priestess and 2 Driders 
// Yuan-Ti
// Assassin and two cultists
// Naga and Two Snake Headed Guards
// Gorgon
// Necromancer
// Apprentice and an Ogre Zombie
// Death Knights and three skeletons
// Necromancer and undead dragon
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
                if (AttackDescriptions != null) { Utility.Print(AttackDescriptions[i]); }
            }
            TurnCounter += 1;
            if (TurnCounter == 6) { TurnCounter = 0; }
        }
    }
    public void BossDeathCheck()
    {
        if (Health <= 0)
        {
            Utility.Print($"{Name} has been defeated!");
            Utility.Print("Would you like to add a description of your victory blow?\nEnter x to skip");
            string? victoryBlow = Utility.Read();
            if (victoryBlow != null && victoryBlow != "x")
            {
                Utility.Print(victoryBlow);
            }
            else
            {
                Utility.Print($"You have defeated {Name}");
            }
        }

    }
}