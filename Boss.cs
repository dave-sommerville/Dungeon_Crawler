using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Boss : Monster
    {
        public Boss(string name, string description, int numberOfAttacks) : base(name, description, numberOfAttacks)
        {
        }
    }
}
