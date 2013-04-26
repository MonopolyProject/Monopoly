using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class IncomeTax : Special
    {
        private readonly int DEFAULT_TAX = 200;


        public IncomeTax(string name, int pos)
        {
            this.name = name;
            this.position = pos;
        }

        public void effect(Player landedOn, bool choseDefault)
        {
            if (choseDefault)
                landedOn.addMoney(-DEFAULT_TAX);
            else
                landedOn.addMoney(-landedOn.calculateTotalWorth() / 10);
        }

        public override void effect(Player landedOn)
        {
            effect(landedOn, true);
        }
    }
}
