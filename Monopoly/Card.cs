﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Card
    {
        protected String name;

        public String getName() { return this.name; }

        public abstract void drawCard(Player p);
    }
}
