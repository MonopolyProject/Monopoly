using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class FreeParking : Special
    {
        public FreeParking(string name, int position)
        {
            this.name = name;
            this.position = position;
        }

        public override void effect(Player landedOn)
        {

        }
    }
}
