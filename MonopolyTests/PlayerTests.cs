using System;
using Monopoly;
using NUnit.Framework;
using System.Collections.Generic;

namespace MonopolyTests
{
    [TestFixture()]
    public class PlayerTests
    {
        [Test()]
        public void TestThatPlayerInitializes()
        {
            var player1 = new Player("Ed");
            Assert.IsNotNull(player1);
        }
        [Test()]
        public void TestPlayerStartPosition()
        {
            var player1 = new Player("Ed");
            Assert.AreEqual(0, player1.getLocation());
        }
        [Test()]
        public void TestPlayerMoves()
        {
            var player1 = new Player("Ed");
            int correctPosition = 0;
            for (int distance = 2; distance <= 12; distance++)
            {
                correctPosition += distance;
                correctPosition = correctPosition % 40;
                player1.move(distance);
                Assert.AreEqual(correctPosition, player1.getLocation());
            }
        }

        [Test()]
        public void TestPlayerDeedsIndividual()
        {
            var p = new Player("Ed");
            Property prop1 = new Property("Board Walk", 39, p, 500, 200, new int[] { 100 }, 3);
            Property prop2 = new Property("Park Place", 37, p, 450, 150, new int[] { 75 }, 2);
            Property prop3 = new Property("Short Line", 35, p, 200, 100, new int[] { 25 }, 1);
            p.addDeed(prop1);
            p.addDeed(prop2);
            p.addDeed(prop3);
            Assert.True(p.hasDeed(prop1));
            Assert.True(p.hasDeed(prop2));
            Assert.True(p.hasDeed(prop3));


        }

        [Test()]
        public void TestPlayerDeedsLists()
        {
            var p = new Player("Ed");
            var t = new Player("p sucks");
            Property prop1 = new Property("Board Walk", 39, p, 500, 200, new int[] { 100 }, 3);
            Property prop2 = new Property("Park Place", 37, p, 450, 150, new int[] { 75 }, 2);
            Property prop3 = new Property("Short Line", 35, p, 200, 100, new int[] { 25 }, 1);

            List<Property> testProps = new List<Property>();
            testProps.Add(prop1);
            testProps.Add(prop2);
            testProps.Add(prop3);
            CollectionAssert.AreEqual(testProps, p.getDeeds());
            Assert.True(p.hasDeeds(testProps));

            Property badProp = new Property("Done Messed Up", 1, t, 2, 3, new int[] { 4 }, 5);
            testProps.Add(badProp);
            Assert.False(p.hasDeeds(testProps));

        }

        [Test()]
        public void TestCountingTypesRailroads()
        {
            Player playah = new Player("Ben");
            Type t = typeof(Railroad);
            Assert.AreEqual(0, playah.countType(t));


            Railroad readingRR = new Railroad("Reading Railroad", 5, playah, 200, 100);
            Assert.AreEqual(1, playah.countType(t));

            Railroad pennRR = new Railroad("Pennsylvania Railroad", 15, playah, 200, 100);
            Assert.AreEqual(2, playah.countType(t));

            Railroad boRR = new Railroad("B&O Railroad", 25, playah, 200, 100);
            Assert.AreEqual(3, playah.countType(t));

            Railroad shortRR = new Railroad("Short Line", 35, playah, 200, 100);
            Assert.AreEqual(4, playah.countType(t));
        }

            

        [Test()]
        public void TestPassGoFromAverageDistance()
        {
            var p = new Player("Ed");
            p.move(35);
            p.move(10);
            Assert.AreEqual(1700, p.getMoney());
        }

        [Test()]
        public void TestPassGoFromAdjacent()
        {
            var p = new Player("Ed");
            p.move(39);
            p.move(2);
            Assert.AreEqual(1700, p.getMoney());
        }

        [Test()]
        public void TestPassLandOnGo()
        {
            var p = new Player("Ed");
            p.move(40);
            Assert.AreEqual(1500, p.getMoney());
            p.move(1);
            Assert.AreEqual(1700, p.getMoney());
        }

        [Test()]
        public void TestPassWithFlagTrue()
        {
            var p = new Player("Ed");
            p.move(38);
            p.move(5, true);
            Assert.AreEqual(1700, p.getMoney());
        }

        [Test()]
        public void TestPassWithFlagFalse()
        {
            var p = new Player("Ed");
            p.move(38);
            p.move(5, false);
            Assert.AreEqual(1500, p.getMoney());
        }

        [Test()]
        public void TestCalculateTotalWorthNoProp()
        {
            var p = new Player("Eddy");
            Assert.AreEqual(1300, p.calculateTotalWorth());
        }


        [Test()]
        public void TestCalculateTotalWorthProp()
        {
            var p = new Player("Eddy");
            Property prop = new Property("TEST", 0, p, 100, 200, new int[] { 0, 0 }, 50);
            Assert.AreEqual(1300 + 100 + 0*50, p.calculateTotalWorth());
        }

        [Test()]
        public void TestCalculateTotalWorthMultProp()
        {
            var p = new Player("Eddy");
            Property prop1 = new Property("TEST1", 0, p, 100, 200, new int[] { 0, 0 }, 50);
            int worth1 = 100 + 0 * 50;
            Property prop2 = new Property("TEST2", 0, p, 200, 300, new int[] { 0, 0 }, 100);
            int worth2 = 200 + 0 * 100;
            Property prop3 = new Property("TEST3", 0, p, 300, 400, new int[] { 0, 0 }, 150);
            int worth3 = 300 + 0 * 150;
            Assert.AreEqual(1300 + worth1 + worth2 + worth3, p.calculateTotalWorth());
        }

        [Test()]
        public void TestCalculateTotalWorthRailroad()
        {
            Player p = new Player("Eddy");
            Railroad rr = new Railroad("TEST", 0, p, 100, 200);


            Assert.Contains(rr, p.getDeeds());
            Assert.AreEqual(1300 + 100, p.calculateTotalWorth());
        }

        [Test()]
        public void TestCalculateTotalWorthUtility()
        {
            Player p = new Player("Eddy");
            Utility u = new Utility("TEST", 0, p, 100, 200);

            Assert.AreEqual(1300 + 100, p.calculateTotalWorth());
        }

        [Test()]
        public void TestCalculateTotalWorthHouses()
        {
            Player p = new Player("Eddy");
            Property prop = new Property("TEST", 0, p, 100, 200, new int[] { 0, 0 }, 50);
            prop.setColorGroup(new Property[] { });

            prop.addHouse();
            Assert.AreEqual(1300 + 100 + 50 * 1, p.calculateTotalWorth());

            prop.addHouse();
            Assert.AreEqual(1300 + 100 + 50 * 2, p.calculateTotalWorth());

            prop.addHouse();
            prop.addHouse();
            prop.addHouse();
            Assert.AreEqual(1300 + 100 + 50 * 5, p.calculateTotalWorth());//1 hotel
        }
    }
}