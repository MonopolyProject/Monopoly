using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class MoneyCardTests
    {
        [Test()]
        public void testNotNull()
        {
            Assert.NotNull(new MoneyCard());
            Assert.NotNull(new MoneyCard("Dis Card", 200));
        }


        [Test()]
        public void testMoneyCardInitializes()
        {
            MoneyCard c = new MoneyCard("Get 200", 200);
            Assert.NotNull(c);
        }

        [Test()]
        public void testMoneyCardProperties()
        {
            MoneyCard c = new MoneyCard("Get 200", 200);
            Assert.AreEqual(c.getName(), "Get 200");
            Assert.AreEqual(c.getAmount(), 200);
        }

        [Test()]
        public void testMoneyCardEffect()
        {
            MoneyCard c = new MoneyCard("Get 200", 200);
            Player ed = new Player("Ed");
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, null);
            Assert.AreEqual(initialMoney + 200, ed.getMoney());
        }

        [Test()]
        public void testNegativeMoneyCardEffect()
        {
            MoneyCard c = new MoneyCard("Lose 200", -200);
            Player ed = new Player("Ed");
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, null);
            Assert.AreEqual(initialMoney - 200, ed.getMoney());
        }
    }
}
