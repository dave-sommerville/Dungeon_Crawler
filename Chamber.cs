namespace Dungeon_Crawler
{
    public class Chamber
    {
        public string ChamberId { get; set; }
        public string Description { get; set; }
        public bool NorthPassage { get; set; }
        public bool SouthPassage { get; set; }
        public bool EastPassage { get; set; }
        public bool WestPassage { get; set; }
        public NPC? Merchant { get; set; }
        public Chamber(string id, string description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
        }
        // Needs to also show passageway descriptions
        // Random strings lists belong here (including new ones for the passageway descriptions)
        // I think I could include the monsters, traps, and NPCs here (Character?)
        public void DisplayDescription()
        {
            Console.WriteLine(Description);
        }
        public bool FiftyFifty()
        {
            return new Random().NextDouble() < 0.5;
        }

        public void RandomizePassages()
        {
            NorthPassage = FiftyFifty();
            SouthPassage= FiftyFifty();
            EastPassage= FiftyFifty();
            WestPassage= FiftyFifty();
        }
    }
}
