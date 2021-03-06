﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Railroad: Property
    {
        private readonly int[] RENTS = { 25, 50, 100, 200 };
        public Railroad() { }

        public Railroad(String name, int position, Player owner, int cost, int mortgage)
        {
            this.buy = cost;
            this.owner = owner;
            this.owner.addDeed(this);
            this.mortgage = mortgage;
            this.name = name;
            this.position = position;
        }

        public override int getRent()
        {
            int rrCount = this.owner.countType(typeof(Railroad)) - 1;
            return RENTS[rrCount];
        }


        public override int addHouse() { return -1; }
    }
}
