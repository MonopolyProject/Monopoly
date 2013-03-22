using System;
using Monopoly;
using NUnit.Framework;

namespace PlayerTests
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
                correctPosition = correctPosition % 39;
                player1.move(distance);
                Assert.AreEqual(correctPosition, player1.getLocation());
            }
        }
    }
}