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
    
namespace Dungeon_Crawler {
    public class Boss : Monster
    {
        public static string DrowOneStatement = "Who dares trespass in the Kingdom of Mother Lolth";
        public static string[] DrowOneOptions = new string[]
        {
            "Please have mercy.",
            "It is I"
        };
        public static DialogueNode[] DrowOneResponseOne = new DialogueNode[]
        {
            new DialogueNode("Soon you shall be another set of bones in our glorious land.", null, null),
            new DialogueNode("Ah, well, that means nothing to me. No matter, a fine slave you shall make.", null, null)
        };
        public static DialogueNode[] DrowOneResponseTwo = new DialogueNode[]
        {
            new DialogueNode("These halls weren't forged by mercy.", null, null),
            new DialogueNode("Cowards deserve a truly terrible demise.", null, null)
        };
        public static DialogueNode[][] DrowOneResponses = new DialogueNode[][]
        {
            DrowOneResponseOne,
            DrowOneResponseTwo
        };
        public static DialogueNode DrowOneText = new DialogueNode(DrowOneStatement, DrowOneOptions, DrowOneResponses);

        public static string DrowTwoStatement = "I have heard the stone singing, she calls for Mother.";
        public static string[] DrowTwoOptions = new string[]
        {
            "Say 'What are you, fowl beast?'",
            "Say 'The only singing shall be my blade beast.'"
        };
        public static DialogueNode[] DrowTwoResponseOne = new DialogueNode[]
        {
            new DialogueNode("Before the light, I was. When the light is no longer, still I shall be.", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[] DrowTwoResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Many blades have whispered in my presence, yet all silent now.", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[][] DrowTwoResponses = new DialogueNode[][] 
        { 
            DrowTwoResponseOne, 
            DrowTwoResponseTwo 
        };
        public static DialogueNode DrowTwoText = new DialogueNode(DrowTwoStatement, DrowTwoOptions, DrowTwoResponses);

        public static string DrowThreeStatementOne = "May our Goddess be blessed, she has chosen me to find the pathetic creature bound to the stone.";
        public static string DrowThreeStatementTwo = "The stone has been promised to me, it is my destiny to bring Lolth to her rightful place.";
        public static string[] DrowThreeOptionsOne = new string[]
        {
            "Say 'Your Goddess has already been bested.'",
            "Say 'Come to join the fate of your friends, have we?'"
        };
        public static string[] DrowThreeOptionsTwo = new string[]
        {
            "Say 'What do you mean her rightful place?'",
            "Say 'Enough speaking, it is time for action.'"
        };
        public static DialogueNode[] DrowThreeResponseOne = new DialogueNode[]
        {
            new DialogueNode("Goddess you say? What you killed was hardly a child compared to my Goddess.", null, null),
            new DialogueNode("That was merely a baby you slaughtered. You have no idea what awaits beyond me.", null, null)
        };
        public static DialogueNode[] DrowThreeResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Their lives are small sacrifices for the new Age that is upon us. The Age of the Spider.", null, null),
            new DialogueNode("Only whimpering excuses for creatures believe in friends.", null, null)
        };
        public static DialogueNode[][] DrowThreeResponses = new DialogueNode[][]
        {
            DrowThreeResponseOne,
            DrowThreeResponseTwo
        };
        public static DialogueNode[][] DrowMonologue = new DialogueNode[][] {

            [new DialogueNode("Monologue", null, null)]
        };
        public static DialogueNode DrowThreeTextOne = new DialogueNode(DrowThreeStatementOne, DrowThreeOptionsOne, DrowThreeResponses);
        public static DialogueNode DrowThreeTextTwo = new DialogueNode(DrowThreeStatementTwo, DrowThreeOptionsTwo, DrowMonologue);

        public int NumberOfAttacks { get; set; }
        public string[]? AttackDescriptions { get; set; }
        public int TurnCounter { get; set; } = 0;
        public DialogueNode MonologueEngine { get; set; }
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
            }
            else if (TurnCounter == 4)
            {
                // Cast Spell
            }
            else
            {
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
}