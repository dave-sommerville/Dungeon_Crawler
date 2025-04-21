namespace Dungeon_Crawler
{//Mimic
    public class Trap
    {
        public Random random = new Random();
        public int HiddenDifficulty { get; set; }
        public int TrapDifficulty { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }
        public bool Athletics { get; set; }
        public bool Dexterity { get; set; }
        
        public Trap(string description, int difficulty, int damage, bool athletics, bool dexterity)
        {
            Description = description;
            HiddenDifficulty = difficulty;
            Damage = damage;
            Athletics = athletics;
            Dexterity = dexterity;
        }
        public void TrapCheck(Player player)
        {
            int modifer = 8;
            if(player.Perception >= HiddenDifficulty)
            {
                Console.WriteLine("You see a trap.");
                modifer = 4;
            }
            int trapCheck = random.Next(1, modifer);
            if(trapCheck == 1)
            {
                return;
            } else
            {
                Console.WriteLine("The trap triggers before you can avoid it.");
                TriggerTrap(player);
            }
        }
        public void TriggerTrap(Player player)
        {
            Console.WriteLine(Description);
            if(Athletics)
            {
                if(player.Athletics >= TrapDifficulty)
                {
                    Console.WriteLine("Using your strength you manage to reduce some of the damage");
                    Damage = Damage / 2;
                }
            }
            if (Dexterity)
            {
                if (player.Dexterity >= TrapDifficulty)
                {
                    Console.WriteLine("Thanks to your quick reflexes, you avoid some of the damage");
                    Damage = Damage / 2;
                }
            }
            player.Health -= Damage;
            Console.WriteLine($"The trap deals {Damage}");
        }
    }
}
