using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class CardCellTests
    {
        [Test()]
        public void testCardCellProperties()
        {
            CardCell c = new CardCell("CC", 2);
            Assert.AreEqual(c.getName(), "CC");
            Assert.AreEqual(c.getPos(), 2);
        }

        [Test()]
        public void testCardCellEffect()
        {
            CardCell c = new CardCell("CC", 2);
            MoneyCard mc = new MoneyCard("", 200);
            Player ed = new Player("Ed");
            int initialMoney = ed.getMoney();
            c.effect(ed, mc, null, null);
            Assert.AreEqual(initialMoney + 200, ed.getMoney());
        }
    }
}
