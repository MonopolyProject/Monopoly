using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class MoveCardTests
    {

        [Test()]
        public void testNotNull()
        {
            Assert.NotNull(new MoveCard());
            Assert.NotNull(new MoveCard("Dis Card", 2, true));
        }

        [Test()]
        public void testMoveCardProperties()
        {
            MoveCard c = new MoveCard("Go to 2", 2, true);
            Assert.AreEqual(c.getName(), "Go to 2");
        }

        [Test()]
        public void testMoveCardEffect()
        {
            MoveCard c = new MoveCard("Go to 2", 2, true);
            Player ed = new Player("Ed");
            ed.move(30);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, null);
            Assert.AreEqual(2, ed.getLocation());
            Assert.AreEqual(initialMoney + 200, ed.getMoney());
        }

        [Test()]
        public void testMoveCardEffectNoCollect()
        {
            MoveCard c = new MoveCard("Go to 2", 2, false);
            Player ed = new Player("Ed");
            ed.move(30);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, null);
            Assert.AreEqual(2, ed.getLocation());
            Assert.AreEqual(initialMoney, ed.getMoney());
        }
    }
}
