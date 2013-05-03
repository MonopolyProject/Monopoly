using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class NearestRailroadCardTests
    {
        [Test()]
        public void testCardProperties()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Assert.AreEqual(c.getName(), "Nearest Railroad Card");
        }

        [Test()]
        public void testCardEffectNoOwner()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, b);
            Assert.AreEqual(5, ed.getLocation());
            Assert.AreEqual(initialMoney + 200, ed.getMoney());
        }

        [Test()]
        public void testCardEffectOwner()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            Player hex = new Player("Hex");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            Railroad r = (Railroad)b.getCellAt(5);
            r.changeOwner(hex);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, b);
            Assert.AreEqual(5, ed.getLocation());
            Assert.AreEqual(initialMoney +200 - r.getRent(), ed.getMoney());
        }
    }
}
