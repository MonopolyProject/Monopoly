using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture()]
    class RepairCardTests
    {
        [Test()]
        public void testNotNull()
        {
            Assert.NotNull(new RepairCard());
            Assert.NotNull(new RepairCard("Dis Card", 50, 75));
        }

        [Test()]
        public void testCardProperties()
        {
            RepairCard c = new RepairCard("Repair", 50, 75);
            Assert.AreEqual(c.getName(), "Repair");
        }

        [Test()]
        public void testCardEffect()
        {
            RepairCard c = new RepairCard("Repair", 50, 75);
            Player ed = new Player("Ed");
            int initialMoney = ed.getMoney();
            WindowsFormsApplication2.Board b = new WindowsFormsApplication2.Board();
            Property p0 = (Property)b.getCellAt(1);
            Property p1 = (Property)b.getCellAt(3);
            p0.changeOwner(ed);
            p1.changeOwner(ed);
            for (int i = 0; i < 4; i++) { p0.addHouse(); p1.addHouse(); }
            p0.addHouse();
            c.drawCard(ed, null, null);
            Assert.AreEqual(initialMoney - 4 * 50 - 75, ed.getMoney());
        }

        [Test()]
        public void testCardEffectNoHouses()
        {
            RepairCard c = new RepairCard("Repair", 50, 75);
            Player ed = new Player("Ed");
            int initialMoney = ed.getMoney();
            c.drawCard(ed, null, null);
            Assert.AreEqual(initialMoney, ed.getMoney());
        }
    }
}
