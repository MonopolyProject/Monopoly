using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class LuxaryTax : Special
    {
        private readonly int LUXARY_TAX = 75;

        public LuxaryTax(string name, int pos)
        {
            this.name = name;
            this.position = pos;
        }

        public override void effect(Player landedOn)
        {
            landedOn.addMoney(-LUXARY_TAX);
        }
    }
}
