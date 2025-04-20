using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Boss : Monster
    {
        // Create miniboss of band of Goblins that activate more Goblin troops
        public Boss(string name, string description) : base(name, description)
        {
        }
    }
}
