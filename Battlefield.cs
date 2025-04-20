using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Battlefield : Chamber
    {

        public Battlefield(string id, string description) : base(id, description)
        {
            ChamberId = id;
            Description = description;
            NorthPassage = true;
            SouthPassage = false;
            EastPassage = true;
            WestPassage = true;
        }
        public void DisplayBattlefield()
        {
            Console.WriteLine(Description);
        }
    }
}
