﻿namespace Dungeon_Crawler
{
    public class Chamber
    {
        public string ChamberId { get; set; }
        public string Description { get; set; }
        public bool NorthPassage { get; set; }
        public bool SouthPassage { get; set; }
        public bool EastPassage { get; set; }
        public bool WestPassage { get; set; }
        public Chamber(string id, string description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
        }

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
