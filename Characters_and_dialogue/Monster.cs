
using System;

namespace Dungeon_Crawler.Characters_and_dialogue
{
    public class Monster : Character
    {
        private readonly int minAttack = 8;
        private readonly int maxAttack = 12;
        private readonly int minDamage = 8;
        private readonly int maxDamage = 12;
        private readonly int minHealth = 20;
        private readonly int maxHealth = 40;
        private readonly int minArmorClass = 2;
        private readonly int maxArmorClass = 5;
        public string[] monsters = new string[]
        {
            "a Giant Rat",
            "a Giant Spider",
            "a Skeleton Warrior",
            "a Kobold",
            "a Deep Gnome",
            "a Grimlock",
            "a Troglodyte",
            "a Goblin Scout",
            "an Animated Suit of Armor",
            "a Spectre",
            "a  Wight",
            "an Ogre",
            "a Cave Troll",
            "a Stone Golem",
            "a Mummy",
            "a Pit Crawler",
            "a Bone Naga",
            "a Land Shark",
            "a Drake",
            "a Hydra",
            "a Chimera",
            "a Wyvern",
            "a Purple Worm"
        };

        public string[] monsterDescriptions = new string[]
        {
            "Vermin the size of dogs, often swarming and spreading disease.",
            "Web-weaving predator with venomous fangs and cunning ambush tactics.",
            "Reanimated bones clad in rusted armor, driven by dark will.",
            "Small reptilian humanoid with a knack for traps and cowardly tactics.",
            "Clever subterranean dweller skilled in stealth and illusion magic.",
            "Blind, brutish humanoid with an acute sense of smell and aggression.",
            "Primitive reptilian humanoid, reeks of musk and savagery.",
            "Fast and elusive scout, often the eyes and ears of larger goblin warbands.",
            "Ghostly apparition that drains warmth and life from nearby souls.",
            "Undead warrior with cursed strength and a hunger for the living.",
            "Massive, dim-witted brute with a club that can shatter stone.",
            "Thick-skinned giant dwelling in caves, extremely strong and territorial.",
            "Magical construct of immense weight and force, nearly impervious to blades.",
            "Wrapped in ancient linens, cursed to protect tombs with dark magic.",
            "Sinister, skittering horror that burrows through walls and flesh alike.",
            "Serpentine undead with spellcasting power and a gaze that chills the spine.",
            "Massive beast with armored hide and a hunger for anything that moves underground.",
            "Fallen champion clad in blackened armor, wielding unholy powers and blades.",
            "Wingless draconic creature with elemental breath and raw fury.",
            "Many-headed serpent beast; cut one head off, two may take its place.",
            "Three-headed monstrosity that breathes fire, roars thunder, and strikes with venom.",
            "Flying reptile with a venomous stinger and a taste for meat.",
            "Titanic worm with a gaping maw, capable of devouring adventurers whole."
        };

        public int ChallengeRating = 1;
        public int TurnCounter { get; set; } = 0;
        public Monster(int playerLvl) : base()
        {
            int crFactor = playerLvl;
            ChallengeRating = crFactor;
            int challengeRatingHigh = ChallengeRating + 5; // The challengeRatingHigh establishes which character is displayed so the stronger they are, the more vicious sounding the monster. 
            int monsterIndex = Utility.GetRandomIndex(ChallengeRating, Math.Min(challengeRatingHigh, monsters.Length));
            Name = monsters[monsterIndex];
            Description = monsterDescriptions[monsterIndex];
            Health = Utility.GetRandomIndex(minHealth, maxHealth) + (ChallengeRating * 2);
            ArmorClass = Utility.GetRandomIndex(minArmorClass, maxArmorClass) + (ChallengeRating * 2);
            XP = ChallengeRating * 20;
        }
        public override void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int max = Math.Max(5, ChallengeRating * 4);
                int attack = Utility.GetRandomIndex(minAttack, maxAttack) + (ChallengeRating * 2);
                int damage = Utility.GetRandomIndex(minDamage, maxDamage) + (ChallengeRating * 2);
                if (targetCharacter.IsDodging)
                {
                    attack = attack / 2;
                    targetCharacter.IsDodging = false;
                }
                if (attack > targetCharacter.ArmorClass)
                {
                    Utility.Print($"{Name} attacked {targetCharacter.Name} and hit for {damage} damage");
                    targetCharacter.Health -= damage;
                }
                else
                {
                    Utility.Print($"{Name} attacked but missed");
                }
            }
        }
    }
}
