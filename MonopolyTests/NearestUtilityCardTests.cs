using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class NearestUtilityCardTests
    {

        [Test()]
        public void testNotNull()
        {
            Assert.NotNull(new NearestUtilityCard());
            Assert.NotNull(new NearestRailroadCard("Dis Card"));
        }

        [Test()]
        public void testCardProperties()
        {
            NearestUtilityCard c = new NearestUtilityCard("Nearest Utility Card");
            Assert.AreEqual(c.getName(), "Nearest Utility Card");
        }

        [Test()]
        public void testCardEffectNoOwner()
        {
            NearestUtilityCard c = new NearestUtilityCard("Nearest Utility Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, b);
            Assert.AreEqual(12, ed.getLocation());
            Assert.AreEqual(initialMoney + 200, ed.getMoney());
        }

        [Test()]
        public void testCardEffectOwner()
        {
            NearestUtilityCard c = new NearestUtilityCard("Nearest Utility Card");
            Player ed = new Player("Ed");
            Player hex = new Player("Hex");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            Utility r = (Utility)b.getCellAt(12);
            r.changeOwner(hex);
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, b);
            Assert.AreEqual(12, ed.getLocation());
            Assert.True(r.getOwner() == hex);
            Assert.True(initialMoney + 200 > ed.getMoney());
        }

        [Test()]
        public void testMovingToWaterWorks()
        {
            NearestUtilityCard c = new NearestUtilityCard("Sup homie");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            ed.move(12);//player at electric company
            c.drawCard(ed, null, b);
            Assert.AreEqual(28, ed.getLocation());

            ed.move(39);//right before water works
            c.drawCard(ed, null, b);
            Assert.AreEqual(28, ed.getLocation());
        }

        [Test()]
        public void testMovingToElectric()
        {
            NearestUtilityCard c = new NearestUtilityCard("Sup homie");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            ed.move(28);//player at water works
            c.drawCard(ed, null, b);
            Assert.AreEqual(12, ed.getLocation());

            ed.move(39);//right before electric company
            c.drawCard(ed, null, b);
            Assert.AreEqual(12, ed.getLocation());
        }
    }
}
