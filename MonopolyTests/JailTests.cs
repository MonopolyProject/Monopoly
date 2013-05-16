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
            List<int> roll = new List<int>();
            roll.Add(3);
            roll.Add(3);
            board.setDiceRoll(roll);
            board.movePlayer(true);
            board.movePlayer(true);
            board.movePlayer(true);
            board.updatePlayerPosition();
            Assert.AreEqual(10, tester.getLocation());
        }
        [Test]
        public void TestLeaveJailAfterFine()
        {
            Board board = new WindowsFormsApplication2.Board();
            Player tester = board.getPlayer();
            List<int> roll = new List<int>();
            roll.Add(4);
            roll.Add(6);
            board.setDiceRoll(roll);
            board.movePlayer(true);
            int initialMoney = tester.getMoney();
            board.movePlayer(true);
            board.movePlayer(true);
            board.movePlayer(true);
            Assert.AreEqual(initialMoney - 50, tester.getMoney());
            tester.move(5);
            Assert.False(tester.inJail());
            Assert.AreEqual(15, tester.getLocation());
        }
        [Test]
        public void TestLeaveJailAfterDouble()
        {
            Board board = new WindowsFormsApplication2.Board();
            Player tester = board.getPlayer();
            List<int> roll = new List<int>();
            roll.Add(4);
            roll.Add(6);
            board.setDiceRoll(roll);
            board.movePlayer(true);
            roll.Clear();
            roll.Add(1);
            roll.Add(1);
            board.setDiceRoll(roll);
            board.movePlayer(true);
            Assert.False(tester.inJail());
            Assert.AreEqual(12, tester.getLocation());
        }
    }
}
