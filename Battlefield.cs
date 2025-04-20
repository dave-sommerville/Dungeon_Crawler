using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Battlefield : Chamber
    {
        public Boss LevelBoss { get; set; }
        public Battlefield(string id, string description) : base(id, description)
        {
            ChamberId = id;
            Description = description;

        }
        public void DisplayBattlefield()
        {
            Console.WriteLine(Description);
        }
    }
}
