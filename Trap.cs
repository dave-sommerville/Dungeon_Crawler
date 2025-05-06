using Dungeon_Crawler.Character;

namespace Dungeon_Crawler
{//Mimic
    public class Trap
    {
        private readonly string[] dexterityTraps = {
            "A narrow pit suddenly opens beneath your feet, requiring a quick jump to avoid falling.",
            "A series of swinging blades cross the hallway, needing precise timing to dodge.",
            "A rope-triggered dart trap fires projectiles aimed at your vital organs, requiring quick reflexes to duck.",
            "Pressure plates release spikes from the walls, demanding swift side-stepping to avoid injury.",
            "A hidden crossbow fires bolts towards you, needing a quick roll or dive to avoid the deadly projectiles.",
            "A set of tumbling stones falls from above, requiring fast reflexes to duck or sidestep.",
            "A cloud of poisonous gas is released by an unseen mechanism, needing rapid movement to get out of range.",
            "A tripwire triggers an explosive charge, requiring a nimble dive to avoid the blast radius.",
            "Invisible ropes suddenly pull tight across your path, requiring quick movements to avoid entanglement.",
            "A wall of fire erupts in front of you, requiring a rapid dash to avoid being scorched."
        };
        private readonly string[] strengthTraps = {
            "A large boulder rolls toward you, requiring you to push or hold it back with all your might.",
            "A heavy door slams shut, needing strength to force it open before it crushes you.",
            "A stone block slowly descends from above, needing brute force to stop its descent or escape.",
            "A collapsing bridge requires you to hold onto the edge and pull yourself to safety with sheer strength.",
            "A massive cage falls around you, needing strength to break the bars and escape.",
            "Giant jaws snap shut in front of you, requiring strength to pry them apart or avoid getting trapped.",
            "A rope bridge begins to snap under your weight, needing a powerful leap to escape before it breaks completely.",
            "A trapdoor opens beneath you, and you must push against the falling weight to avoid being crushed.",
            "A powerful spring mechanism launches a heavy net to entangle you, needing strength to break free.",
            "A large stone slab blocks your path, requiring you to lift or roll it away to continue forward."
        };

        public int HiddenDifficulty { get; set; }
        public int TrapDifficulty { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }
        public bool Athletics { get; set; }
        public bool Dexterity { get; set; }
        
        public Trap(int trapLvl)
        {
            Athletics = Utility.FiftyFifty();
            Dexterity = !Athletics;
            Description = DescribeTrap();
            HiddenDifficulty = 12;
            Damage = trapLvl * 10;
        }
        public string DescribeTrap()
        {
            string description = "";
            if(Athletics)
            {
                description = strengthTraps[Utility.GetRandomIndex(0, strengthTraps.Length)];
            } else if(Dexterity)
            {
                description = dexterityTraps[Utility.GetRandomIndex(0, dexterityTraps.Length)];
            }
            return description;
        }
        public void TrapCheck(Player player)
        {
            int modifer = 8;
            if(player.Perception >= HiddenDifficulty)
            {
                Utility.Print("You see a trap.");
                modifer = 4;
            }
            int trapCheck = Utility.GetRandomIndex(1, modifer);
            if(trapCheck == 1)
            {
                return;
            } else
            {
                Utility.Print("The trap triggers before you can avoid it.");
                TriggerTrap(player);
            }
        }
        public void TriggerTrap(Player player)
        {
            Utility.Print(Description);
            if(Athletics)
            {
                if(player.Athletics >= TrapDifficulty)
                {
                    Utility.Print("Using your strength you manage to reduce some of the damage");
                    Damage = Damage / 2;
                }
            }
            if (Dexterity)
            {
                if (player.Dexterity >= TrapDifficulty)
                {
                    Utility.Print("Thanks to your quick reflexes, you avoid some of the damage");
                    Damage = Damage / 2;
                }
            }
            player.Health -= Damage;
            Utility.Print($"The trap deals {Damage}");
            player.PlayerDeathCheck();
        }
    }
}
