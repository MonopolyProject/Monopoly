using System;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture()]
    public class PlayerTests
    {
        [Test()]
        public void TestThatPlayerInitializes()
        {
            var player1 = new Player();
            Assert.IsNotNull(player1);
        }
        [Test()]
        public void TestPlayerStartPosition()
        {
            var player1 = new Player();
            Assert.AreEqual(0, player1.getLocation());
        }
        [Test()]
        public void TestPlayerMoves()
        {
            var player1 = new Player();
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
        public void TestPlayerDeeds()
        {
            var p = new Player();
            Property prop1 = new Property("Board Walk", 39, p, 500, 200, new int[] { 100 });
            Property prop2 = new Property("Park Place", 37, p, 450, 150, new int[] { 75 });
            Property prop3 = new Property("Short Line", 35, p, 200, 100, new int[] { 25 });
            p.addDeed(prop1);
            p.addDeed(prop2);
            p.addDeed(prop3);
            Assert.True(p.hasDeed(prop1));
            Assert.True(p.hasDeed(prop2));
            Assert.True(p.hasDeed(prop3));
            

        }
    }
}