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
        public void testNotNull()
        {
            Assert.NotNull(new NearestRailroadCard());
            Assert.NotNull(new NearestRailroadCard("Dis Card"));
        }
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

        [Test()]
        public void TestMovingToReadingRailroad()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();

            ed.move(35);//on shortline
            c.drawCard(ed, null, b);
            Assert.AreEqual(5, ed.getLocation());

            ed.move(39);//cell right before reading
            Assert.AreEqual(4, ed.getLocation());
            c.drawCard(ed, null, b);
            Assert.AreEqual(5, ed.getLocation());
        }


        [Test()]
        public void TestMovingToPennsylvaniaRailroad()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            ed.move(5);//on reading railroad
            c.drawCard(ed, null, b);
            Assert.AreEqual(15, ed.getLocation());

            ed.move(39);//cell right before pennsylvania
            Assert.AreEqual(14, ed.getLocation());
            c.drawCard(ed, null, b);
            Assert.AreEqual(15, ed.getLocation());        
        }

        [Test()]
        public void TestMovingToBORailroad()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            ed.move(15);//on pennsylvania
            c.drawCard(ed, null, b);
            Assert.AreEqual(25, ed.getLocation());

            ed.move(39);//cell right before bo
            Assert.AreEqual(24, ed.getLocation());
            c.drawCard(ed, null, b);
            Assert.AreEqual(25, ed.getLocation());
        }

        [Test()]
        public void TestMovingToShortLine()
        {
            NearestRailroadCard c = new NearestRailroadCard("Nearest Railroad Card");
            Player ed = new Player("Ed");
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            ed.move(25);//on bo railroad
            c.drawCard(ed, null, b);
            Assert.AreEqual(35, ed.getLocation());

            ed.move(39);//cell right before short line
            Assert.AreEqual(34, ed.getLocation());
            c.drawCard(ed, null, b);
            Assert.AreEqual(35, ed.getLocation());
        }
    }
}
