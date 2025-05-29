using System.Diagnostics;
using Dungeon_Crawler.Characters_and_dialogue;
using Dungeon_Crawler.Spells;
    
namespace Dungeon_Crawler {
    public class Boss : Monster
    {
        /// DROW BOSSES
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
            new DialogueNode("I am your mortality coming to meet you.", null, null)
        };
        public static DialogueNode[] DrowTwoResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Many blades have whispered in my presence, yet all silent now.", null, null),
            new DialogueNode("What is a blade to a demon.", null, null)
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



        // YUAN TI BOSSES
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
        public static string SnakeThreeStatementTwo = "That gemstone on your head is my key to godhood. You are not prepared for how desperately I desire it.";
        public static string[] SnakeThreeOptionsOne = new string[]
        {
            "Say 'Peacefully on a mountain of gold.'",
            "Say 'I fear not death nor shall it be mine today'"
        };
        public static string[] SnakeThreeOptionsTwo = new string[]
        {
            "Then today shall be the day you almost became a god.",
            "Why would you belive such a thing?"
        };
        public static DialogueNode[] SnakeThreeResponseOne = new DialogueNode[]
{
            new DialogueNode("Peace will be forgotten throughout the land once I have that gemstone.", null, null),
            new DialogueNode("Hmmm, how about tearing you limb from limb?", null, null)
};
        public static DialogueNode[] SnakeThreeResponseTwo = new DialogueNode[]
        {
            new DialogueNode("I respect that. I do. But I often respect my food.", null, null),
            new DialogueNode("Perhaps just a slow bleed for the day then.", null, null)
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



        //  NECROMANCER BOSSES
        public static string NecroOneStatement = "Wow, what a rarity. Don't see Predead creatures like you around much.";
        public static string[] NecroOneOptions = new string[]
        {
            "Say 'What kind of evil are you?'",
            "Predead?"
        };
        public static DialogueNode[] NecroOneResponseOne = new DialogueNode[]
        {
            new DialogueNode("We have been called evil, but we think of it as more of recycling than anything.", null, null),
            new DialogueNode("We may look evil to you. You look useable to us. Especially that gemstone.", null, null)
        };
        public static DialogueNode[] NecroOneResponseTwo = new DialogueNode[]
        {
            new DialogueNode("You know, on breath support, blood filled adventurers.", null, null),
            new DialogueNode("Don't worry, we will help you on your way to starting your postdeath transition as seamless as possible.", null, null)
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
            "Say 'I'd like to not be breathing, I wouldn't have to smell you.'",
            "Say 'Here you are relying on my grace to survive.'"
        };
        public static DialogueNode[] NecroTwoResponseOne = new DialogueNode[]
        {
            new DialogueNode("You're funny. I hope you keep that sense of humor postdeath.", null, null),
            new DialogueNode("No worries, we'll remedy that for you.", null, null)
        };
        public static DialogueNode[] NecroTwoResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Let's test that steel to steel.", null, null),
            new DialogueNode("You're funny. I hope you keep that sense of humor postdeath.", null, null)
        };
        public static DialogueNode[][] NecroTwoResponses = new DialogueNode[][]
        {
            DrowTwoResponseOne,
            DrowTwoResponseTwo
        };
        public static DialogueNode NecroTwoText = new DialogueNode(DrowTwoStatement, DrowTwoOptions, DrowTwoResponses);

        public static string NecroThreeStatementOne = "Have I finally found the trouble maker who has been eliminating my troops. Now I see why they coveted you so.";
        public static string NecroThreeStatementTwo = "Death will come unto the world, but in it a new world will be reborn.";
        public static string[] NecroThreeOptionsOne = new string[]
        {
            "Say 'My charming personality, was it?'",
            "Say 'Soon you will see how they were eliminated.'"
        };
        public static string[] NecroThreeOptionsTwo = new string[]
        {
            "Sounds like a rotten idea to me.",
            "What's so special about the gemstone anyway?"
        };
        public static DialogueNode[] NecroThreeResponseOne = new DialogueNode[]
        {
            new DialogueNode("Would you like to keep that smile in the next life? That can be arranged/.", null, null),
            new DialogueNode("I'm unconcerned about your perceived abilities.", null, null)
        };
        public static DialogueNode[] NecroThreeResponseTwo = new DialogueNode[]
        {
            new DialogueNode("Place holder", null, null),
            new DialogueNode("Place holder", null, null)
        };
        public static DialogueNode[][] NecroThreeResponses = new DialogueNode[][]
        {
            DrowThreeResponseOne,
            DrowThreeResponseTwo
        };
        public static DialogueNode[][] NecroMonologue = new DialogueNode[][] {

            [new DialogueNode("Monologue", null, null)]
        };
        public static DialogueNode NecroThreeTextOne = new DialogueNode(NecroThreeStatementOne, NecroThreeOptionsOne, NecroThreeResponses);
        public static DialogueNode NecroThreeTextTwo = new DialogueNode(NecroThreeStatementTwo, NecroThreeOptionsTwo, NecroMonologue);

        public int NumberOfAttacks { get; set; }
        public string[]? AttackDescriptions { get; set; }
        public int TurnCounter { get; set; } = 0;
        public Spell Spell { get; set; } = new Spell();
        public DialogueNode? Dialogue { get; set; }
        public bool InteractionInProgress { get; set; } = false;

        public Boss(string name, string description, int numberOfAttacks, string[] attackDescriptions, DialogueNode dialogue, int playerLvl) : base(playerLvl)
        {
            Name = name;
            Description = description;
            NumberOfAttacks = numberOfAttacks;
            AttackDescriptions = attackDescriptions;
            Dialogue = dialogue;
        }
        private static Boss _drowOne = new Boss("Drider and two Drow Warriors", "A monstrous being, half human and half giant spider, followed by two swarthy guards.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, DrowOneText, 1);
        private static Boss _drowTwo = new Boss("Drow Sorceress", "A tall, slender figure with dark skin and white hair, her eyes glowing with arcane power.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, DrowTwoText, 1);
        private static Boss _drowThree = new Boss("Drow Priestess", "A tall, slender figure with dark skin and white hair, her eyes glowing with arcane power.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, DrowThreeTextOne, 1);
        private static Boss _snakeOne = new Boss("Yuan-ti Abomination", "A massive serpent-like creature with a humanoid torso, its scales glistening in the dim light.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, SnakeOneText, 1);
        private static Boss _snakeTwo = new Boss("Yuan-ti Sorcerer", "A humanoid figure with snake-like features, its eyes glowing with dark magic.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, SnakeTwoText, 1);
        private static Boss _snakeThree = new Boss("Yuan-ti High Priest", "A tall, serpentine figure with a crown of snakes, its voice echoing with power.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, SnakeThreeTextOne, 1);
        private static Boss _necroOne = new Boss("Necromancer", "A hooded figure surrounded by a swirling mist, its eyes glowing with dark energy.", 2, new string[] { "The drow lunges at you with her dagger, but you dodge out ", "The blade slices your skin" }, NecroOneText, 1);
        private static Boss _necroTwo = new Boss("Necromancer", "Huh", 2, new string[] { "Blade slices", "Point pierces"}, NecroTwoText, 2);
        private static Boss _necroThree = new Boss("Necromancer", "Huh", 2, new string[] { "Blade slices", "Point pierces" }, NecroThreeTextOne, 2);
        private static Boss[] _dungeonbosses = new Boss[]
        {
            _drowOne,
            _drowTwo,
            _drowThree,
            _snakeOne,
            _snakeTwo,
            _snakeThree,
            _necroOne,
            _necroTwo,
            _necroThree
        };
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
                for (int i = 0; i < NumberOfAttacks; i++)
                {

                    base.Attack(targetCharacter);
                }
                TurnCounter += 1;
                if (TurnCounter == 6) { TurnCounter = 0; }
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
        public static Boss GetPlotBoss(int plotIndex)
        {
            int bossNum = plotIndex - 1;
            Boss boss = _dungeonbosses[bossNum];
            return boss;
        }
    }
}