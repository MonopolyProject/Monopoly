using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Special : Cell
    {
        public Special() { }
        public Special(String name, int pos)
        {
            this.name = name;
            this.position = pos;
        }
        public abstract void effect(Player landedOn);
    }
}
