using System;
using Monopoly;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApplication2;

namespace MonopolyTests
{
    [TestFixture()]
    public class BoardTests
    {
        [Test()]
        public void TestThatBoardInitializes()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board);
        }
        [Test()]
        public void TestBoardInitializePlayer()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board.getPlayer());

        }
        [Test()]
        public void TestBoardPopulateLocations()
        {
            Board board = new WindowsFormsApplication2.Board();
            Assert.IsNotNull(board.locations);
            Assert.AreEqual(40, board.locations.Count);
        }
        [Test()]
        public void TestRollingDie()
        {
            Board board = new WindowsFormsApplication2.Board();
            List<int> die = board.roll();
            Assert.Less(die[0],6);
            Assert.Greater(die[0],0);
            Assert.Less(die[1], 6);
            Assert.Greater(die[1], 0);
        }

        [Test()]
        public void TestMovePlayer()
        {
            Board board = new WindowsFormsApplication2.Board();
            int position = board.movePlayer();
            Assert.AreEqual(position, board.getPlayer().getLocation());
        }

        [Test()]
        public void TestPlayerShapePosition()
        {
            Board board = new WindowsFormsApplication2.Board();
            for (int i = 0; i < 12; i++)
            {
                int position = board.movePlayer();
                Assert.AreEqual(board.getPlayerShape().Location, board.locations[board.getPlayer().getLocation()]);
            }
        }

        [Test()]
        public void TestBuyDisplay()
        {
            Board board = new WindowsFormsApplication2.Board();
            board.buyDisplay();
            Assert.True(board.getBuy().Enabled);
            Assert.True(board.getEndTurn().Enabled);
            Assert.False(board.getRollDie().Enabled);
        }

        [Test()]
        public void TestEndTurn()
        {
            Board board = new WindowsFormsApplication2.Board();
            int active = board.getActivePlayer();
            board.endTurn();
            Assert.AreEqual(active + 1, board.getActivePlayer());
            board.endTurn();
            Assert.AreEqual(0, board.getActivePlayer());
            Assert.False(board.getBuy().Enabled);
            Assert.False(board.getEndTurn().Enabled);
            Assert.True(board.getRollDie().Enabled);
        }
        
        [Test()]
        public void TestBuyProperty()
        {
            Board board = new WindowsFormsApplication2.Board();
            var p = board.getPlayer();
            p.move(6);
            Assert.AreEqual(6, p.getLocation());
            Property prop = (Property) board.getCellAt(p.getLocation());

            Assert.False(p.getDeeds().Contains(prop));
            int houseCost = prop.getBuy();
            board.buyProperty();
            Assert.True(p.getDeeds().Contains(prop));
            int newMoney = 1500 - houseCost;
            Assert.AreEqual(newMoney, p.getMoney());
            Assert.AreEqual(0, prop.getNumHouses());

            houseCost = prop.getHouseCost();
            board.buyProperty();
            Assert.AreEqual(newMoney - houseCost, p.getMoney());
            Assert.AreEqual(1, prop.getNumHouses());

            p.addMoney(-p.getMoney());
            board.buyProperty();
            Assert.AreEqual(0, p.getMoney());
            Assert.AreEqual(1, prop.getNumHouses());
        }

        [Test()]
        public void TestTradeOneProperty()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");
            Property prop = (Property) board.getCellAt(6);
            Tomato.addDeed(prop);
            List<Property> toTrade = new List<Property>();
            toTrade.Add(prop);
            board.trade(Tomato, MPU, toTrade, 0);
            Assert.True(Tomato.deeds.Count == 0);
            Assert.True(MPU.deeds.Contains(prop));
            }

        [Test()]
        public void TestTradeTwoProperties()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");
            Property prop = (Property)board.getCellAt(6);
            Property prop2 = (Property)board.getCellAt(11);
            Tomato.addDeed(prop);
            Tomato.addDeed(prop2);
            List<Property> toTrade = new List<Property>();
            toTrade.Add(prop);
            toTrade.Add(prop2);
            board.trade(Tomato, MPU, toTrade, 0);
            Assert.True(Tomato.deeds.Count == 0);
            Assert.True(MPU.deeds.Contains(prop) && MPU.deeds.Contains(prop2));
        }

        [Test()]
        public void TestTradeUnownedProperty()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");
            Property prop = (Property)board.getCellAt(6);
            Property prop2 = (Property)board.getCellAt(11);
            Tomato.addDeed(prop);
            List<Property> toTrade = new List<Property>();
            toTrade.Add(prop);
            toTrade.Add(prop2);
            board.trade(Tomato, MPU, toTrade, 0);
            Assert.True(Tomato.getDeeds().Count == 1 && Tomato.getDeeds().Contains(prop));
            Assert.True(MPU.getDeeds().Count==0);
        }

        [Test()]
        public void TestTradeEmptyPropertyList()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");
            List<Property> toTrade = new List<Property>();
            board.trade(Tomato, MPU, toTrade, 0);
            Assert.True(Tomato.getDeeds().Count == 0);
            Assert.True(MPU.getDeeds().Count == 0);
        }

        [Test()]
        public void TestTrade1()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");

            int TomatoInitialMoney = Tomato.getMoney();
            int MPUInitialMoney = MPU.getMoney();
            int moneyToTrade = 1;

            List<Property> toTrade = new List<Property>();

            board.trade(Tomato, MPU, toTrade, moneyToTrade);
            Assert.AreEqual(Tomato.getMoney(), TomatoInitialMoney - moneyToTrade);
            Assert.AreEqual(MPU.getMoney(), MPUInitialMoney + moneyToTrade);
        }

        [Test()]
        public void TestTradeAllMoney()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");

            int TomatoInitialMoney = Tomato.getMoney();
            int MPUInitialMoney = MPU.getMoney();
            int moneyToTrade = Tomato.getMoney();

            List<Property> toTrade = new List<Property>();

            board.trade(Tomato, MPU, toTrade, moneyToTrade);
            Assert.AreEqual(Tomato.getMoney(), TomatoInitialMoney - moneyToTrade);
            Assert.AreEqual(MPU.getMoney(), MPUInitialMoney + moneyToTrade);
        }

        [Test()]
        public void TestTradeNegativeMoneyDoesNotTrade()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");

            int TomatoInitialMoney = Tomato.getMoney();
            int MPUInitialMoney = MPU.getMoney();
            int moneyToTrade = -1;

            List<Property> toTrade = new List<Property>();

            board.trade(Tomato, MPU, toTrade, moneyToTrade);
            Assert.AreEqual(Tomato.getMoney(), TomatoInitialMoney);
            Assert.AreEqual(MPU.getMoney(), MPUInitialMoney);
        }

        [Test()]
        public void TestTradeExcessiveMoneyDoesNotTrade()
        {
            Board board = new WindowsFormsApplication2.Board();
            var Tomato = board.getPlayer();
            var MPU = new Player("MPU");

            int TomatoInitialMoney = Tomato.getMoney();
            int MPUInitialMoney = MPU.getMoney();
            int moneyToTrade = Tomato.getMoney()+1;

            List<Property> toTrade = new List<Property>();

            board.trade(Tomato, MPU, toTrade, moneyToTrade);
            Assert.AreEqual(Tomato.getMoney(), TomatoInitialMoney);
            Assert.AreEqual(MPU.getMoney(), MPUInitialMoney);
        }

        [Test()]
        public void TestOneMortgagePropertiesMoneyChanges()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var haute = new Property("Terre Haute", 0, Tomato, 100, 50, new int[] {1, 2, 3, 4, 5, 6}, 10);
            Tomato.addDeed(haute);

            List<Property> props = new List<Property>();
            props.Add(haute);

            Assert.AreEqual(1300, Tomato.getMoney());
            b.mortgageProperties(Tomato, props);
            Assert.AreEqual(1350, Tomato.getMoney());

        }


        [Test()]
        public void TestMultipleMortgagePropertiesMoneyChanges()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var haute = new Property("Terre Haute", 0, Tomato, 100, 50, new int[] { 1, 2, 3, 4, 5, 6 }, 10);
            var chitown = new Property("Chi Town", 0, Tomato, 100, 100, new int[] { 1, 2, 3, 4, 5, 6 }, 10);
            var norleans = new Property("Norleans", 0, Tomato, 100, 50, new int[] { 1, 2, 3, 4, 5, 6 }, 10);
            Tomato.addDeed(haute);
            Tomato.addDeed(chitown);
            Tomato.addDeed(norleans);

            List<Property> props = new List<Property>();
            props.Add(haute);
            props.Add(chitown);
            props.Add(norleans);

            Assert.AreEqual(1300, Tomato.getMoney());
            b.mortgageProperties(Tomato, props);
            Assert.AreEqual(1500, Tomato.getMoney());

        }

        [Test()]
        public void TestMortgageThrowsNoHousesErrors()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var haute = new Property("Terre Haute", 0, Tomato, 100, 50, new int[] { 1, 2, 3, 4, 5, 6 }, 10);
            haute.addHouse();
            Tomato.addDeed(haute);
            

            List<Property> props = new List<Property>();
            props.Add(haute);

            String result = b.mortgageProperties(Tomato,props);
            Assert.AreEqual("ERROR: You have too many houses on " + haute.getName() + ", sell them off before mortgaging", result);
        }

        [Test()]
        public void TestMortgageThrowsAlreadyMortgagedErrors()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var haute = new Property("Terre Haute", 0, Tomato, 100, 50, new int[] { 1, 2, 3, 4, 5, 6 }, 10);
            haute.mortgageProperty();
            Tomato.addDeed(haute);

            List<Property> props = new List<Property>();
            props.Add(haute);

            String result = b.mortgageProperties(Tomato, props);
            Assert.AreEqual("ERROR: You have already mortgaged " + haute.getName(), result);
        }

        [Test()]
        public void TestMortgageThrowsNoneSelectedErrors()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();

            List<Property> props = new List<Property>();

            String result = b.mortgageProperties(Tomato, props);
            Assert.AreEqual("ERROR: You did not select any properties", result);
        }

        [Test()]
        public void TestHasMonopolyWorks()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var banker = b.getBanker();
            Property p1 = (Property)b.getCellAt(1);
            Property p3 = (Property)b.getCellAt(3);
            Property p8 = (Property)b.getCellAt(8);
            Property p9 = (Property)b.getCellAt(9);
            p1.changeOwner(Tomato);
            p3.changeOwner(Tomato);
            p8.changeOwner(Tomato);
            Assert.True(b.hasMonopoly((Property)b.getCellAt(1)));
            Assert.False(b.hasMonopoly((Property)b.getCellAt(8)));
            Assert.False(b.hasMonopoly((Property)b.getCellAt(9)));
        }

        [Test()]
        public void TestRentWorks()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop = (Property)b.getCellAt(1);
            prop.changeOwner(Hex);
            Tomato.move(1);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - prop.getRent(), Tomato.getMoney());
        }

        [Test()]
        public void TestNoRentOnMortgagedProperty()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop = (Property)b.getCellAt(1);
            prop.changeOwner(Hex);
            Tomato.move(1);
            int startMoney = Tomato.getMoney();
            prop.mortgageProperty();
            b.rent();
            Assert.AreEqual(startMoney, Tomato.getMoney());
            prop.liftMortgage();
            b.rent();
            Assert.AreEqual(startMoney - prop.getRent(), Tomato.getMoney());
        }

        [Test()]
        public void TestRentWith2Houses()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop = (Property)b.getCellAt(1);
            prop.changeOwner(Hex);
            prop.addHouse();
            prop.addHouse();
            Tomato.move(1);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - prop.getRent(), Tomato.getMoney());
        }

        [Test()]
        public void TestRentMonopolyNoHouses()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop0 = (Property)b.getCellAt(1);
            prop0.changeOwner(Hex);
            int initialRent = prop0.getRent();
            Property prop1 = (Property)b.getCellAt(3);
            prop1.changeOwner(Hex);
            Tomato.move(1);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - initialRent*2, Tomato.getMoney());
        }

        [Test()]
        public void TestRentMonopoly3Houses()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop0 = (Property)b.getCellAt(1);
            prop0.changeOwner(Hex);
            Property prop1 = (Property)b.getCellAt(3);
            prop1.changeOwner(Hex);
            prop0.addHouse();
            prop0.addHouse();
            prop0.addHouse();
            Tomato.move(1);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - prop0.getRent(), Tomato.getMoney());
        }

        [Test()]
        public void TestRentRailroad()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop0 = (Property)b.getCellAt(5);
            prop0.changeOwner(Hex);
            Tomato.move(5);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - prop0.getRent(), Tomato.getMoney());
        }

        [Test()]
        public void TestRentUtility()
        {
            Board b = new WindowsFormsApplication2.Board();
            var Tomato = b.getPlayer();
            var Hex = new Player("Hex");

            Property prop0 = (Property)b.getCellAt(12);
            prop0.changeOwner(Hex);
            Tomato.move(12);
            List<int> roll = new List<int>();
            roll.Add(6);
            roll.Add(6);
            b.setDiceRoll(roll);
            int startMoney = Tomato.getMoney();
            b.rent();
            Assert.AreEqual(startMoney - 12*prop0.getRent(), Tomato.getMoney());
        }
    }
}
