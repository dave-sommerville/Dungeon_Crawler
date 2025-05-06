using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Spells;
    
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




        public static string SnakeOneStatement = "Ah, look, our master will be pleased to find fresh meat. Wait, what is that gem?";
        public static string[] SnakeOneOptions = new string[]
        {
            "Say 'Why don't you come within my blades reach to find out?",
            "Say 'I want no trouble.'"
        };
        public static DialogueNode[] SnakeOneResponseOne = new DialogueNode[]
        {
            new DialogueNode("As you say.", null, null),
            new DialogueNode("We know what that is, we shall retrieve it.", null, null)
        };
        public static DialogueNode[] SnakeOneResponseTwo = new DialogueNode[]
        {
            new DialogueNode("And yet, it seems trouble wants you.", null, null),
            new DialogueNode("Your wishes are no concern of mine.", null, null)
        };
        public static DialogueNode[][] SnakeOneResponses = new DialogueNode[][]
        {
            SnakeOneResponseOne,
            SnakeOneResponseTwo
        };
        public static DialogueNode SnakeOneText = new DialogueNode(SnakeOneStatement, SnakeOneOptions, SnakeOneResponses);

        public static string SnakeTwoStatement = "We sensed your presence and heard those weaklings' screams. You will now give us what belongs to our master.";
        public static string[] SnakeTwoOptions = new string[]
        {
            "Say 'It would seem the stone has chosen to belong to me.'",
            "Say 'Tell me more about this master of yours'"
        };
        public static DialogueNode[] SnakeTwoResponseOne = new DialogueNode[]
        {
            new DialogueNode("As a pawn, perhaps. But the stone longs for Master as much as They long for It.", null, null),
            new DialogueNode("Then it is you we shall have to take.", null, null)
        };
        public static DialogueNode[] SnakeTwoResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Surrender now and survive long enough to meet Them.", null, null),
            new DialogueNode("That stone is all that stands between Master and Their ascension.", null, null)
        };
        public static DialogueNode[][] SnakeTwoResponses = new DialogueNode[][]
        {
            SnakeTwoResponseOne,
            SnakeTwoResponseTwo
        };
        public static DialogueNode SnakeTwoText = new DialogueNode(SnakeOneStatement, SnakeOneOptions, SnakeOneResponses);

        public static string SnakeThreeStatementOne = "There you are, little one. Your smell of your blood has been tickling my tongue. How do you wish to die?";
        public static string SnakeThreeStatementTwo = "";
        public static string[] SnakeThreeOptionsOne = new string[]
        {
            "Say 'Peacefully on a mountain of gold.'",
            ""
        };
        public static string[] SnakeThreeOptionsTwo = new string[]
        {
            "There will be no peace to be found in the land once I have that gemstone.",
            "Hmmm, I guess tearing you limb from limb will do."
        };
        public static DialogueNode[] SnakeThreeResponseOne = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[] SnakeThreeResponseTwo = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[][] SnakeResponses = new DialogueNode[][]
        {
            SnakeThreeResponseOne,
            SnakeThreeResponseTwo
        };
        public static DialogueNode[][] SnakeMonologue = new DialogueNode[][] {

            [new DialogueNode("Monologue", null, null)]
        };
        public static DialogueNode SnakeThreeTextOne = new DialogueNode(SnakeThreeStatementOne, SnakeThreeOptionsOne, SnakeResponses);
        public static DialogueNode SnakeThreeTextTwo = new DialogueNode(SnakeThreeStatementTwo, SnakeThreeOptionsTwo, SnakeMonologue);




        public static string NecroOneStatement = "Wow, what a rarity. Don't see Predead creatures like you around much.";
        public static string[] NecroOneOptions = new string[]
        {
            "",
            ""
        };
        public static DialogueNode[] NecroOneResponseOne = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[] NecroOneResponseTwo = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[][] NecroOneResponses = new DialogueNode[][]
        {
            DrowOneResponseOne,
            DrowOneResponseTwo
        };
        public static DialogueNode NecroOneText = new DialogueNode(DrowOneStatement, DrowOneOptions, DrowOneResponses);

        public static string NecroTwoStatement = "I could hear your breathing throughout these tunnels. Imagine relying on air to survive.";
        public static string[] NecroTwoOptions = new string[]
        {
            "Say 'What kind of evil are you?'",
            "Predead?"
        };
        public static DialogueNode[] NecroTwoResponseOne = new DialogueNode[]
        {
            new DialogueNode("You know, on breath support, blood filled adventurers.", null, null),
            new DialogueNode("Don't worry, we will help you on your way to starting your postdeath era.", null, null)
        };
        public static DialogueNode[] NecroTwoResponseTwo = new DialogueNode[]
        {
            new DialogueNode("A lot of people would call my Master and I necromancers. I think of it more like recycling.", null, null),
            new DialogueNode("Run of the mill dark magic, just making a living in these tunnels.", null, null)
        };
        public static DialogueNode[][] NecroTwoResponses = new DialogueNode[][]
        {
            DrowTwoResponseOne,
            DrowTwoResponseTwo
        };
        public static DialogueNode NecroTwoText = new DialogueNode(DrowTwoStatement, DrowTwoOptions, DrowTwoResponses);

        public static string NecroThreeStatementOne = "";
        public static string NecroThreeStatementTwo = "";
        public static string[] NecroThreeOptionsOne = new string[]
        {
            "",
            ""
        };
        public static string[] NecroThreeOptionsTwo = new string[]
        {
            "",
            ""
        };
        public static DialogueNode[] NecroThreeResponseOne = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[] NecroThreeResponseTwo = new DialogueNode[]
        {
            new DialogueNode("", null, null),
            new DialogueNode("", null, null)
        };
        public static DialogueNode[][] NecroThreeResponses = new DialogueNode[][]
        {
            DrowThreeResponseOne,
            DrowThreeResponseTwo
        };
        public static DialogueNode[][] NecroMonologue = new DialogueNode[][] {

            [new DialogueNode("Monologue", null, null)]
        };
        public static DialogueNode NecroThreeTextOne = new DialogueNode(DrowThreeStatementOne, DrowThreeOptionsOne, DrowThreeResponses);
        public static DialogueNode NecroThreeTextTwo = new DialogueNode(DrowThreeStatementTwo, DrowThreeOptionsTwo, DrowMonologue);

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