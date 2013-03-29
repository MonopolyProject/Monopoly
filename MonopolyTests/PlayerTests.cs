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
    }
}