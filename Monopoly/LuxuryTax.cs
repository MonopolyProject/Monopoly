using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class LuxuryTax : Special
    {
        private readonly int LUXURY_TAX = 75;

        public LuxuryTax(string name, int pos)
        {
            this.name = name;
            this.position = pos;
        }

        public override void effect(Player landedOn)
        {
            landedOn.addMoney(-this.LUXURY_TAX);
        }
    }
}
