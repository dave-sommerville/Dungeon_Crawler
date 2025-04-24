
using System;

namespace Dungeon_Crawler
{
    public class Monster : Character
    {
        private readonly Random random = new Random();
        // This is good for control, but they are hard wired for monsters. Either they need to be set by method
        // or they need to be set by the constructor ooooor I add a public modifer property 
        private readonly int attackBase = 8;
        private readonly int minAttack = 8;
        private readonly int maxAttack = 12;
        private readonly int minDamage = 8;
        private readonly int maxDamage = 12;
        private readonly int minHealth = 20;
        private readonly int maxHealth = 40;
        private readonly int minArmorClass = 7;
        private readonly int maxArmorClass = 10;
        public string[] monsters = new string[]
        {
            "Giant Rat",
            "Giant Spider",
            "Skeleton Warrior",
            "Kobold",
            "Deep Gnome",
            "Grimlock",
            "Troglodyte",
            "Goblin Scout",
            "Spectre",
            "Wight",
            "Ogre",
            "Cave Troll",
            "Stone Golem",
            "Mummy",
            "Pit Crawler",
            "Bone Naga",
            "Land Shark",
            "Death Knight",
            "Drake",
            "Hydra",
            "Chimera",
            "Wyvern",
            "Purple Worm"
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

        public int ChallengeRating = 0;
        public Monster(int playerLvl) : base()
        {
            ChallengeRating = playerLvl - 1;
            int challengeRatingHigh = ChallengeRating + 5;
            int monsterIndex = random.Next(ChallengeRating, Math.Min(challengeRatingHigh, monsters.Length));
            Name = monsters[monsterIndex];
            Description = monsterDescriptions[monsterIndex];
            Health = random.Next(minHealth, maxHealth) + (ChallengeRating * 2);
            ArmorClass = random.Next(minArmorClass, maxArmorClass) + (ChallengeRating * 2);
        }
        public override void Attack(Character targetCharacter)
        {
            int max = Math.Min((ChallengeRating * 2), 12);
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = random.Next(max) + 5;
                int damage = random.Next(max) + 5;
                if (attack > targetCharacter.ArmorClass)
                {
                    Console.WriteLine($"{Name} attacked {targetCharacter.Name} and hit for {damage} damage");
                    targetCharacter.Health -= damage;
                }
                else
                {
                    Console.WriteLine($"{Name} attacked but missed");
                }
            }
        }
    }
}
