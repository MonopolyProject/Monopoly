using System;
using Monopoly;
using NUnit.Framework;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class JailTests
    {
        [Test()]
        public void TestGoToJailCell()
        {
            Board board = new WindowsFormsApplication2.Board();
            Player tester = board.getPlayer();
            tester.move(30);
            board.updatePlayerPosition();
            Assert.AreEqual(10,tester.getLocation());
            board.endTurn();
            tester = board.getPlayer();
            tester.move(30);
            board.updatePlayerPosition();
            Assert.AreEqual(10, tester.getLocation());
        }
        [Test]
        public void TestJailAfter3Double()
        {
            Board board = new WindowsFormsApplication2.Board();
            Player tester = board.getPlayer();
            tester.doubleCounter = 2;
            tester.move(2);
            board.updatePlayerPosition();
            Assert.AreEqual(10, tester.getLocation());
        }
    }
}
