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
        public abstract void effect(Player landedOn);
    }
}
