using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class GiveMoneyCardTests
    {
        [Test()]
        public void testMoneyCardProperties()
        {
            GiveMoneyCard c = new GiveMoneyCard("Get 200", 200);
            Assert.AreEqual(c.getName(), "Get 200");
        }

        [Test()]
        public void testGiveMoneyCardEffect()
        {
            GiveMoneyCard c = new GiveMoneyCard("Get 200", 200);
            Player ed = new Player("Ed");
            List<Player> ps = new List<Player>();
            Player ein = new Player("Ein");
            Player hex = new Player("Hex");
            ps.Add(ein); ps.Add(hex);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, ps, null);
            Assert.AreEqual(initialMoney + 400, ed.getMoney());
            Assert.AreEqual(initialMoney - 200, ein.getMoney());
            Assert.AreEqual(initialMoney - 200, hex.getMoney());
        }

        [Test()]
        public void testNegativeGiveMoneyCardEffect()
        {
            GiveMoneyCard c = new GiveMoneyCard("Get 200", -200);
            Player ed = new Player("Ed");
            List<Player> ps = new List<Player>();
            Player ein = new Player("Ein");
            Player hex = new Player("Hex");
            ps.Add(ein); ps.Add(hex);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, ps, null);
            Assert.AreEqual(initialMoney - 400, ed.getMoney());
            Assert.AreEqual(initialMoney + 200, ein.getMoney());
            Assert.AreEqual(initialMoney + 200, hex.getMoney());
        }
    }
}
