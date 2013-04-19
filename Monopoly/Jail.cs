using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Jail:Special
    {
        public Jail(string name, int position)
        {
            this.name = name;
            this.position = position;
        }
        public override void effect(Player landedOn)
        {

        }
    }
}
