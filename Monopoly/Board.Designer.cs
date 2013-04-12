using Monopoly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication2
{
    public partial class Board
    {
        private static Player banker = new Player("banker");
        public List<Point> locations = populateLocations();
        private List<Player> players = populatePlayers();
        private List<Cell> cells = populateCells(banker);
        private List<System.Windows.Forms.TextBox> houseNumbers;
        private int activePlayer;
        CheckedListBox properties;
        Form propertyList;
        TextBox tradePrice = new TextBox();
        Property propertyToAdd;
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public Player getPlayer()
        {
            return this.players[this.activePlayer];
        }

        public Microsoft.VisualBasic.PowerPacks.OvalShape getPlayerShape()
        {
            if(this.getPlayer().Equals(players[0]))
            return this.ovalShape2;
            else
            return this.ovalShape1;
        }

        private static List<Player> populatePlayers()
        {
            Player player0 = new Player("Ed");
            Player player1 = new Player("Tomato");
            List<Player> players = new List<Player>();
            players.Add(player0);
            players.Add(player1);
            return players;
        }

        private static List<Point> populateLocations() {
            List<Point> locationSet = new List<Point>();
            int x = 58;
            int y = 848;
            int i;
            locationSet.Add(new Point(x, y));
            for(i = 0; i<10; i++) {
                if (i %10 ==  0)
                {
                    y -= 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    y -= 70;
                    locationSet.Add(new Point(x, y));
                    
                }
            }
            x = 120;
            y = 50;
            for (i = 10; i < 20; i++)
            {
                if (i % 10 == 0)
                {
                    x += 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    x += 70;
                    locationSet.Add(new Point(x, y));

                }
            }
            x = 910;
            y = 120;
            for (i = 20; i < 30; i++)
            {
                if (i % 10 == 0)
                {
                    y += 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    y += 70;
                    locationSet.Add(new Point(x, y));

                }
            }

            x = 840;
            y = 910;
            for (i = 10; i < 19; i++)
            {
                if (i % 10 == 0)
                {
                    x -= 80;
                    locationSet.Add(new Point(x, y));
                }
                else
                {
                    x -= 70;
                    locationSet.Add(new Point(x, y));

                }
            }

            for (i = 0; i < locationSet.Count; i++)
            {
                Console.WriteLine("(" + locationSet[i].X + "," + locationSet[i].Y+")");
            }
            return locationSet;
        }

        private static List<Cell> populateCells(Player banker)
        {
            List<Cell> cells = new List<Cell>();
            List<Cell> orderedCells = new List<Cell>();

            Property mediterr = new Property("Mediterranean Avenue", 1, banker, 60, 30, new int[] { 2, 10, 30, 90, 160, 250 }, 50);
            Property baltic = new Property("Baltic Avenue", 3, banker, 60, 30, new int[] { 4, 20, 60, 180, 320, 450 }, 50);

            Property oriental = new Property("Oriental Avenue", 6, banker, 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, 50);
            Property vermont = new Property("Vermont Avenue", 8, banker, 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, 50);
            Property connecticut = new Property("Connecticut Avenue", 9, banker, 120, 60, new int[] { 8, 40, 100, 300, 450, 600 }, 50);

            Property charles = new Property("St. Charles Place", 11, banker, 140, 70, new int[] { 10, 50, 150, 250, 625, 750 }, 100);
            Property states = new Property("States Avenue", 13, banker, 140, 70, new int[] { 10, 50, 150, 250, 625, 750 }, 100);
            Property virginia = new Property("Virginia Avenue", 14, banker, 160, 80, new int[] { 12, 60, 180, 500, 700, 900 }, 100);

            Property james = new Property("St. James Place", 16, banker, 180, 90, new int[] { 14, 70, 200, 550, 750, 950 }, 100);
            Property tennessee = new Property("Tennessee Avenue", 18, banker, 180, 90, new int[] { 14, 70, 200, 550, 750, 950 }, 100);
            Property newyork = new Property("New York Avenue", 19, banker, 200, 100, new int[] { 16, 80, 220, 600, 800, 1000 }, 100);

            Property kentucky = new Property("Kentucky Avenue", 21, banker, 220, 110, new int[] { 18, 90, 250, 700, 875, 1050 }, 150);
            Property indiana = new Property("Indiana Avenue", 23, banker, 220, 110, new int[] { 18, 90, 250, 700, 875, 1050 }, 150);
            Property illinois = new Property("Illinois Avenue", 24, banker, 240, 120, new int[] { 20, 100, 300, 750, 925, 1100 }, 150);


            Property atlantic = new Property("Atlantic Avenue", 26, banker, 260, 130, new int[] { 22, 110, 330, 800, 975, 1150 }, 150);
            Property ventnor = new Property("Ventnor Avenue", 27, banker, 260, 130, new int[] { 22, 110, 330, 800, 975, 1150 }, 150);
            Property marvin = new Property("Marvin Gardens", 29, banker, 280, 140, new int[] { 24, 120, 360, 850, 1025, 1200 }, 150);

            Property pacific = new Property("Pacific Avenue", 31, banker, 300, 150, new int[] { 26, 130, 390, 900, 1100, 1275 }, 200);
            Property carolina = new Property("North Carolina Avenue", 32, banker, 300, 150, new int[] { 26, 130, 390, 900, 1100, 1275 }, 200);
            Property penn = new Property("Pennsylvania Avenue", 34, banker, 320, 160, new int[] { 28, 150, 450, 1000, 1200, 1400 }, 200);

            Property park = new Property("Park Place", 37, banker, 350, 175, new int[] { 35, 175, 500, 1100, 1300, 1500 }, 200);
            Property boardwalk = new Property("Boardwalk", 39, banker, 400, 200, new int[] { 50, 200, 600, 1400, 1700, 2000 }, 200);

            Railroad readingRR = new Railroad("Reading Railroad", 5, banker, 200, 100, new int[] { 25, 50, 100, 200 });
            Railroad pennRR = new Railroad("Pennsylvania Railroad", 15, banker, 200, 100, new int[] { 25, 50, 100, 200 });
            Railroad boRR = new Railroad("B&O Railroad", 25, banker, 200, 100, new int[] { 25, 50, 100, 200 });
            Railroad shortRR = new Railroad("Short Line", 35, banker, 200, 100, new int[] { 25, 50, 100, 200 });

            Utility electric = new Utility("Electric Company", 12, banker, 150, 75);
            Utility water = new Utility("Water Works", 28, banker, 150, 75);

            Property temp0 = new Property("Placeholder", 0, banker, 0, 0, new int[] { 0,0,0,0,0}, 0);
            Property temp2 = new Property("Placeholder", 2, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp4 = new Property("Placeholder", 4, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp7 = new Property("Placeholder", 7, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp10 = new Property("Placeholder", 10, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp17 = new Property("Placeholder", 17, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp20 = new Property("Placeholder", 20, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp22 = new Property("Placeholder", 22, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp30 = new Property("Placeholder", 30, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp33 = new Property("Placeholder", 33, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp36 = new Property("Placeholder", 36, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);
            Property temp38 = new Property("Placeholder", 38, banker, 0, 0, new int[] { 0, 0, 0, 0, 0 }, 0);

            cells.Add(temp0); cells.Add(mediterr); cells.Add(temp2); cells.Add(baltic); cells.Add(temp4); cells.Add(readingRR); cells.Add(oriental); cells.Add(temp7); cells.Add(vermont);
            cells.Add(connecticut); cells.Add(temp10); cells.Add(charles); cells.Add(electric); cells.Add(states); cells.Add(virginia); cells.Add(pennRR); cells.Add(james); cells.Add(temp17);
            cells.Add(tennessee); cells.Add(newyork); cells.Add(temp20); cells.Add(kentucky); cells.Add(temp22); cells.Add(indiana); cells.Add(illinois); cells.Add(boRR); cells.Add(atlantic);
            cells.Add(ventnor); cells.Add(water); cells.Add(marvin); cells.Add(temp30); cells.Add(pacific); cells.Add(carolina); cells.Add(temp33); cells.Add(penn); cells.Add(shortRR);
            cells.Add(temp36); cells.Add(park); cells.Add(temp38); cells.Add(boardwalk); 
                        
            return cells;
        }

        private void updateHouseNumbers()
        {
        }

        public List<int> roll()
        {
            List<int> dice = new List<int>();
            Random die = new Random();
            dice.Add(die.Next(5) + 1);
            dice.Add(die.Next(5) + 1);
            return dice;
        }

        public int movePlayer()
        {
            List<int> die = this.roll();
            int newPosition = this.getPlayer().move(die[0] + die[1]);
            System.Diagnostics.Debug.Write("Die 1: " + die[0] + " Die 2: " + die[1] + " New Location: " + newPosition + "\n");
            this.updatePlayerPosition();
            this.cellEffect(newPosition);
            return newPosition;
        }

        public void cellEffect(int position)
        {
            Cell cell = this.cells[position];
            if (cell is Property)
            {

                this.buyDisplay();
            }else{
                this.endTurn();
                }
        }

        public void buyProperty()
        {
            propertyToAdd = (Property)this.cells[this.getPlayer().getLocation()];
            if (propertyToAdd.getOwner().getName() == "banker" && this.getPlayer().getMoney() >= propertyToAdd.getBuy())
            {
                propertyToAdd.addHouse();
                propertyToAdd.changeOwner(this.getPlayer());
                this.getPlayer().addMoney(-propertyToAdd.getBuy());
                
            }
            else if (this.getPlayer().getMoney() >= propertyToAdd.getHouseCost()&&this.getPlayer().hasDeed(propertyToAdd))
            {
                int newHouseNum = propertyToAdd.addHouse();
                if (newHouseNum > 0)
                {
                    this.getPlayer().addMoney(-propertyToAdd.getHouseCost());
                    //this.houseNumbers[this.getPlayer().getLocation()].Text = newHouseNum.ToString();
                }
            }
            else if (this.getPlayer().getMoney() >= propertyToAdd.getHouseCost())
            {
                System.Diagnostics.Debug.Write(this.getPlayer().getName() + " doesnt have enough money\n");
            }
            if (this.getPlayer().deeds.Count > 0)
            {
                System.Diagnostics.Debug.Write(this.getPlayer().getName() + " has " + this.getPlayer().deeds[this.getPlayer().deeds.Count - 1].getName() + "\n");
            }
            System.Diagnostics.Debug.Write(this.getPlayer().getName() + " has " + this.getPlayer().getMoney() + "dollars\n");
            System.Diagnostics.Debug.Write(propertyToAdd +" has " + propertyToAdd.getNumHouses() + "houses\n");
        }

        public void endTurn()
        {
            this.activePlayer++;
            this.activePlayer = this.activePlayer % (this.players.Count);
            this.rollDie.Enabled = true;
            this.BuyProper.Enabled = false;
            this.TurnEnds.Enabled = false;
        }

        public void updatePlayerPosition()
        {
                            
            if (this.getPlayer().getName() == "Ed")
            {
                this.ovalShape2.Location = this.locations[this.getPlayer().getLocation()];
            }
            else
            {
                this.ovalShape1.Location = this.locations[this.getPlayer().getLocation()];
            }

        }

        public void tradeProperties()
        {
            propertyList = new Form();
            propertyList.Width = 300;
            propertyList.Height = 600;
            propertyList.Text = "Select Properties.";
            List<Property> initialList = this.players[this.activePlayer].deeds;
            properties = new CheckedListBox();
            properties.Width = 300;
            properties.Height = 300;
            for (int i = 0; i < initialList.Count; i++)
            { 
                properties.Items.Add(initialList[i].getName());
            }
            propertyList.Controls.Add(properties);
            tradePrice.Text = "Enter the price you offer.";
            tradePrice.Location = new System.Drawing.Point(5,305);
            tradePrice.Size = new System.Drawing.Size(290, 350);
            Button confirm = new Button();
            confirm.Text = "Confirm";
            confirm.Location = new System.Drawing.Point(5, 450);
            
            confirm.Click += new System.EventHandler(confirm_Click_1);
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Location = new System.Drawing.Point(150, 450);
            cancel.Click += new System.EventHandler(cancel_Click_1);
            Label player1Money = new Label();
            Label player2Money = new Label();
            player1Money.Text = "Player1: " + this.players[0].getMoney();
            player2Money.Text = "Player2: " + this.players[1].getMoney();
            player1Money.Location = new System.Drawing.Point(50, 370);
            player2Money.Location = new System.Drawing.Point(50, 400);

            propertyList.Controls.Add(tradePrice);
            propertyList.Controls.Add(confirm);
            propertyList.Controls.Add(cancel);
            propertyList.Controls.Add(player1Money);
            propertyList.Controls.Add(player2Money);
            propertyList.ShowDialog();

        }


        public void buyDisplay()
        {
            this.rollDie.Enabled = false;
            this.BuyProper.Enabled = true;
            this.TurnEnds.Enabled = true;
            propertyToAdd = (Property)this.cells[this.getPlayer().getLocation()];
            System.Diagnostics.Debug.Write(banker.hasDeed(propertyToAdd));
            if (!banker.hasDeed(propertyToAdd))
            {
                this.BuyProper.Enabled = false;
            }
           
        }

        public System.Windows.Forms.Button getRollDie()
        {
            return this.rollDie;
        }

        public System.Windows.Forms.Button getBuy()
        {
            return this.BuyProper;
        }

        public System.Windows.Forms.Button getEndTurn()
        {
            return this.BuyProper;
        }

        public int getActivePlayer()
        {
            return this.activePlayer;
        }

        public Cell getCellAt(int location)
        {
            return this.cells[location];
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape2 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.marvinGardens = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ventnorAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.illinoisAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.indianaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.newYorkAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.tennesseeAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.virginiaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.statesAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.orientalAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.vermontAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.balticAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.waterWorks = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.atlanticAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.boRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape24 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.readingRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.incomeTax = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.mediteraneanAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.connecticutAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.goYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.gotoJailYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.boardwalk = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shortLine = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chance3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.parkPlace = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.luxuryTax = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pacificAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.northCarolinaAvenue = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectanglepennsylvaniaAvenueShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape15 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.communityChest2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.electricCompany = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.PennsylvaniaRailroad = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.stCharlesPlace = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.freeParkingYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.jailYOLO = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.goLabel = new System.Windows.Forms.Label();
            this.parkingLabel = new System.Windows.Forms.Label();
            this.chestLabel1 = new System.Windows.Forms.Label();
            this.chestLabel2 = new System.Windows.Forms.Label();
            this.chestLabel3 = new System.Windows.Forms.Label();
            this.waterWorksLabel = new System.Windows.Forms.Label();
            this.chanceLabel1 = new System.Windows.Forms.Label();
            this.railReadLabel = new System.Windows.Forms.Label();
            this.taxLabel1 = new System.Windows.Forms.Label();
            this.jailLabel = new System.Windows.Forms.Label();
            this.chanceLabel2 = new System.Windows.Forms.Label();
            this.eCompanyLabel = new System.Windows.Forms.Label();
            this.railPennLabel = new System.Windows.Forms.Label();
            this.railBOLabel = new System.Windows.Forms.Label();
            this.goToJailLabel = new System.Windows.Forms.Label();
            this.railShortLabel = new System.Windows.Forms.Label();
            this.chanceLabel3 = new System.Windows.Forms.Label();
            this.taxLabel2 = new System.Windows.Forms.Label();
            this.rollDie = new System.Windows.Forms.Button();
            this.buy = new System.Windows.Forms.Button();
            this.endTurnButton = new System.Windows.Forms.Button();
            this.payText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BuyProper = new System.Windows.Forms.Button();
            this.TurnEnds = new System.Windows.Forms.Button();
            this.Trade = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.MagProper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShape1,
            this.ovalShape2,
            this.marvinGardens,
            this.ventnorAvenue,
            this.illinoisAvenue,
            this.indianaAvenue,
            this.newYorkAvenue,
            this.tennesseeAvenue,
            this.virginiaAvenue,
            this.statesAvenue,
            this.orientalAvenue,
            this.vermontAvenue,
            this.balticAvenue,
            this.waterWorks,
            this.atlanticAvenue,
            this.boRailroad,
            this.chance2,
            this.rectangleShape24,
            this.chance1,
            this.readingRailroad,
            this.incomeTax,
            this.communityChest1,
            this.mediteraneanAvenue,
            this.connecticutAvenue,
            this.goYOLO,
            this.gotoJailYOLO,
            this.boardwalk,
            this.shortLine,
            this.chance3,
            this.parkPlace,
            this.luxuryTax,
            this.pacificAvenue,
            this.northCarolinaAvenue,
            this.communityChest3,
            this.rectanglepennsylvaniaAvenueShape2,
            this.rectangleShape15,
            this.communityChest2,
            this.electricCompany,
            this.PennsylvaniaRailroad,
            this.stCharlesPlace,
            this.freeParkingYOLO,
            this.jailYOLO});
            this.shapeContainer1.Size = new System.Drawing.Size(984, 962);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // ovalShape1
            // 
            this.ovalShape1.AccessibleDescription = "Player";
            this.ovalShape1.AccessibleName = "Player";
            this.ovalShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape1.FillColor = System.Drawing.Color.DarkViolet;
            this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent60;
            this.ovalShape1.Location = new System.Drawing.Point(58, 848);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(22, 22);
            // 
            // ovalShape2
            // 
            this.ovalShape2.AccessibleDescription = "Player";
            this.ovalShape2.AccessibleName = "Player";
            this.ovalShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShape2.FillColor = System.Drawing.Color.Blue;
            this.ovalShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent90;
            this.ovalShape2.Location = new System.Drawing.Point(58, 848);
            this.ovalShape2.Name = "ovalShape2";
            this.ovalShape2.Size = new System.Drawing.Size(22, 22);
            // 
            // marvinGardens
            // 
            this.marvinGardens.BackColor = System.Drawing.Color.Yellow;
            this.marvinGardens.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.marvinGardens.Location = new System.Drawing.Point(810, 740);
            this.marvinGardens.Name = "marvinGardens";
            this.marvinGardens.Size = new System.Drawing.Size(90, 70);
            this.marvinGardens.Click += new System.EventHandler(this.rectangleShape37_Click);
            // 
            // ventnorAvenue
            // 
            this.ventnorAvenue.BackColor = System.Drawing.Color.Yellow;
            this.ventnorAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ventnorAvenue.Location = new System.Drawing.Point(810, 600);
            this.ventnorAvenue.Name = "ventnorAvenue";
            this.ventnorAvenue.Size = new System.Drawing.Size(90, 70);
            this.ventnorAvenue.Click += new System.EventHandler(this.rectangleShape37_Click);
            // 
            // illinoisAvenue
            // 
            this.illinoisAvenue.BackColor = System.Drawing.Color.Red;
            this.illinoisAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.illinoisAvenue.Location = new System.Drawing.Point(810, 390);
            this.illinoisAvenue.Name = "illinoisAvenue";
            this.illinoisAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // indianaAvenue
            // 
            this.indianaAvenue.BackColor = System.Drawing.Color.Red;
            this.indianaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.indianaAvenue.Location = new System.Drawing.Point(810, 320);
            this.indianaAvenue.Name = "indianaAvenue";
            this.indianaAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // newYorkAvenue
            // 
            this.newYorkAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newYorkAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.newYorkAvenue.Location = new System.Drawing.Point(740, 90);
            this.newYorkAvenue.Name = "newYorkAvenue";
            this.newYorkAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // tennesseeAvenue
            // 
            this.tennesseeAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tennesseeAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.tennesseeAvenue.Location = new System.Drawing.Point(670, 90);
            this.tennesseeAvenue.Name = "tennesseeAvenue";
            this.tennesseeAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // virginiaAvenue
            // 
            this.virginiaAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.virginiaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.virginiaAvenue.Location = new System.Drawing.Point(391, 90);
            this.virginiaAvenue.Name = "virginiaAvenue";
            this.virginiaAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // statesAvenue
            // 
            this.statesAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.statesAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.statesAvenue.Location = new System.Drawing.Point(321, 90);
            this.statesAvenue.Name = "statesAvenue";
            this.statesAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // orientalAvenue
            // 
            this.orientalAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.orientalAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.orientalAvenue.Location = new System.Drawing.Point(90, 390);
            this.orientalAvenue.Name = "orientalAvenue";
            this.orientalAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // vermontAvenue
            // 
            this.vermontAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.vermontAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.vermontAvenue.Location = new System.Drawing.Point(90, 250);
            this.vermontAvenue.Name = "vermontAvenue";
            this.vermontAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // balticAvenue
            // 
            this.balticAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.balticAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.balticAvenue.Location = new System.Drawing.Point(90, 600);
            this.balticAvenue.Name = "balticAvenue";
            this.balticAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // waterWorks
            // 
            this.waterWorks.Location = new System.Drawing.Point(810, 670);
            this.waterWorks.Name = "waterWorks";
            this.waterWorks.Size = new System.Drawing.Size(90, 70);
            // 
            // atlanticAvenue
            // 
            this.atlanticAvenue.BackColor = System.Drawing.Color.Yellow;
            this.atlanticAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.atlanticAvenue.Location = new System.Drawing.Point(810, 530);
            this.atlanticAvenue.Name = "atlanticAvenue";
            this.atlanticAvenue.Size = new System.Drawing.Size(90, 70);
            this.atlanticAvenue.Click += new System.EventHandler(this.rectangleShape37_Click);
            // 
            // boRailroad
            // 
            this.boRailroad.Location = new System.Drawing.Point(810, 460);
            this.boRailroad.Name = "boRailroad";
            this.boRailroad.Size = new System.Drawing.Size(90, 70);
            // 
            // chance2
            // 
            this.chance2.Location = new System.Drawing.Point(810, 250);
            this.chance2.Name = "chance2";
            this.chance2.Size = new System.Drawing.Size(90, 70);
            // 
            // rectangleShape24
            // 
            this.rectangleShape24.BackColor = System.Drawing.Color.Red;
            this.rectangleShape24.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape24.Location = new System.Drawing.Point(810, 180);
            this.rectangleShape24.Name = "rectangleShape24";
            this.rectangleShape24.Size = new System.Drawing.Size(90, 70);
            // 
            // chance1
            // 
            this.chance1.Location = new System.Drawing.Point(90, 320);
            this.chance1.Name = "chance1";
            this.chance1.Size = new System.Drawing.Size(90, 70);
            // 
            // readingRailroad
            // 
            this.readingRailroad.Location = new System.Drawing.Point(90, 460);
            this.readingRailroad.Name = "readingRailroad";
            this.readingRailroad.Size = new System.Drawing.Size(90, 70);
            // 
            // incomeTax
            // 
            this.incomeTax.Location = new System.Drawing.Point(90, 530);
            this.incomeTax.Name = "incomeTax";
            this.incomeTax.Size = new System.Drawing.Size(90, 70);
            // 
            // communityChest1
            // 
            this.communityChest1.Location = new System.Drawing.Point(90, 670);
            this.communityChest1.Name = "communityChest1";
            this.communityChest1.Size = new System.Drawing.Size(90, 70);
            this.communityChest1.Tag = "";
            this.communityChest1.Click += new System.EventHandler(this.rectangleShape27_Click);
            // 
            // mediteraneanAvenue
            // 
            this.mediteraneanAvenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mediteraneanAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.mediteraneanAvenue.Location = new System.Drawing.Point(90, 740);
            this.mediteraneanAvenue.Name = "mediteraneanAvenue";
            this.mediteraneanAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // connecticutAvenue
            // 
            this.connecticutAvenue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.connecticutAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.connecticutAvenue.Location = new System.Drawing.Point(90, 180);
            this.connecticutAvenue.Name = "connecticutAvenue";
            this.connecticutAvenue.Size = new System.Drawing.Size(90, 70);
            // 
            // goYOLO
            // 
            this.goYOLO.Location = new System.Drawing.Point(90, 810);
            this.goYOLO.Name = "goYOLO";
            this.goYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // gotoJailYOLO
            // 
            this.gotoJailYOLO.Location = new System.Drawing.Point(810, 810);
            this.gotoJailYOLO.Name = "gotoJailYOLO";
            this.gotoJailYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // boardwalk
            // 
            this.boardwalk.BackColor = System.Drawing.Color.Blue;
            this.boardwalk.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.boardwalk.Location = new System.Drawing.Point(180, 810);
            this.boardwalk.Name = "boardwalk";
            this.boardwalk.Size = new System.Drawing.Size(70, 90);
            // 
            // shortLine
            // 
            this.shortLine.Location = new System.Drawing.Point(460, 810);
            this.shortLine.Name = "shortLine";
            this.shortLine.Size = new System.Drawing.Size(70, 90);
            // 
            // chance3
            // 
            this.chance3.Location = new System.Drawing.Point(390, 810);
            this.chance3.Name = "chance3";
            this.chance3.Size = new System.Drawing.Size(70, 90);
            // 
            // parkPlace
            // 
            this.parkPlace.BackColor = System.Drawing.Color.Blue;
            this.parkPlace.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.parkPlace.Location = new System.Drawing.Point(320, 810);
            this.parkPlace.Name = "parkPlace";
            this.parkPlace.Size = new System.Drawing.Size(70, 90);
            // 
            // luxuryTax
            // 
            this.luxuryTax.Location = new System.Drawing.Point(250, 810);
            this.luxuryTax.Name = "luxuryTax";
            this.luxuryTax.Size = new System.Drawing.Size(70, 90);
            // 
            // pacificAvenue
            // 
            this.pacificAvenue.BackColor = System.Drawing.Color.Green;
            this.pacificAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.pacificAvenue.Location = new System.Drawing.Point(740, 810);
            this.pacificAvenue.Name = "pacificAvenue";
            this.pacificAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // northCarolinaAvenue
            // 
            this.northCarolinaAvenue.BackColor = System.Drawing.Color.Green;
            this.northCarolinaAvenue.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.northCarolinaAvenue.Location = new System.Drawing.Point(670, 810);
            this.northCarolinaAvenue.Name = "northCarolinaAvenue";
            this.northCarolinaAvenue.Size = new System.Drawing.Size(70, 90);
            // 
            // communityChest3
            // 
            this.communityChest3.Location = new System.Drawing.Point(600, 810);
            this.communityChest3.Name = "communityChest3";
            this.communityChest3.Size = new System.Drawing.Size(70, 90);
            // 
            // rectanglepennsylvaniaAvenueShape2
            // 
            this.rectanglepennsylvaniaAvenueShape2.BackColor = System.Drawing.Color.Green;
            this.rectanglepennsylvaniaAvenueShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectanglepennsylvaniaAvenueShape2.Location = new System.Drawing.Point(530, 810);
            this.rectanglepennsylvaniaAvenueShape2.Name = "rectanglepennsylvaniaAvenueShape2";
            this.rectanglepennsylvaniaAvenueShape2.Size = new System.Drawing.Size(70, 90);
            // 
            // rectangleShape15
            // 
            this.rectangleShape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rectangleShape15.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape15.Location = new System.Drawing.Point(530, 90);
            this.rectangleShape15.Name = "rectangleShape15";
            this.rectangleShape15.Size = new System.Drawing.Size(70, 90);
            // 
            // communityChest2
            // 
            this.communityChest2.Location = new System.Drawing.Point(600, 90);
            this.communityChest2.Name = "communityChest2";
            this.communityChest2.Size = new System.Drawing.Size(70, 90);
            // 
            // electricCompany
            // 
            this.electricCompany.Location = new System.Drawing.Point(250, 90);
            this.electricCompany.Name = "electricCompany";
            this.electricCompany.Size = new System.Drawing.Size(70, 90);
            // 
            // PennsylvaniaRailroad
            // 
            this.PennsylvaniaRailroad.Location = new System.Drawing.Point(460, 90);
            this.PennsylvaniaRailroad.Name = "PennsylvaniaRailroad";
            this.PennsylvaniaRailroad.Size = new System.Drawing.Size(70, 90);
            // 
            // stCharlesPlace
            // 
            this.stCharlesPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stCharlesPlace.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.stCharlesPlace.Location = new System.Drawing.Point(180, 90);
            this.stCharlesPlace.Name = "stCharlesPlace";
            this.stCharlesPlace.Size = new System.Drawing.Size(70, 90);
            // 
            // freeParkingYOLO
            // 
            this.freeParkingYOLO.Location = new System.Drawing.Point(810, 90);
            this.freeParkingYOLO.Name = "freeParkingYOLO";
            this.freeParkingYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // jailYOLO
            // 
            this.jailYOLO.Location = new System.Drawing.Point(90, 90);
            this.jailYOLO.Name = "jailYOLO";
            this.jailYOLO.Size = new System.Drawing.Size(90, 90);
            // 
            // goLabel
            // 
            this.goLabel.AutoSize = true;
            this.goLabel.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.goLabel.Location = new System.Drawing.Point(104, 845);
            this.goLabel.Name = "goLabel";
            this.goLabel.Size = new System.Drawing.Size(57, 38);
            this.goLabel.TabIndex = 1;
            this.goLabel.Text = "GO";
            // 
            // parkingLabel
            // 
            this.parkingLabel.AutoSize = true;
            this.parkingLabel.Font = new System.Drawing.Font("Comic Sans MS", 16F);
            this.parkingLabel.Location = new System.Drawing.Point(812, 99);
            this.parkingLabel.Name = "parkingLabel";
            this.parkingLabel.Size = new System.Drawing.Size(88, 60);
            this.parkingLabel.TabIndex = 2;
            this.parkingLabel.Text = "Free\r\nParking\r\n";
            this.parkingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chestLabel1
            // 
            this.chestLabel1.AutoSize = true;
            this.chestLabel1.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel1.Location = new System.Drawing.Point(103, 684);
            this.chestLabel1.Name = "chestLabel1";
            this.chestLabel1.Size = new System.Drawing.Size(78, 38);
            this.chestLabel1.TabIndex = 3;
            this.chestLabel1.Text = "Community\r\n    Chest";
            this.chestLabel1.Click += new System.EventHandler(this.chest1_Click);
            // 
            // chestLabel2
            // 
            this.chestLabel2.AutoSize = true;
            this.chestLabel2.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel2.Location = new System.Drawing.Point(596, 110);
            this.chestLabel2.Name = "chestLabel2";
            this.chestLabel2.Size = new System.Drawing.Size(78, 38);
            this.chestLabel2.TabIndex = 4;
            this.chestLabel2.Text = "Community\r\nChest";
            this.chestLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chestLabel3
            // 
            this.chestLabel3.AutoSize = true;
            this.chestLabel3.BackColor = System.Drawing.Color.Transparent;
            this.chestLabel3.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chestLabel3.Location = new System.Drawing.Point(593, 835);
            this.chestLabel3.Name = "chestLabel3";
            this.chestLabel3.Size = new System.Drawing.Size(78, 38);
            this.chestLabel3.TabIndex = 5;
            this.chestLabel3.Text = "Community\r\nChest";
            this.chestLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // waterWorksLabel
            // 
            this.waterWorksLabel.AutoSize = true;
            this.waterWorksLabel.BackColor = System.Drawing.Color.Transparent;
            this.waterWorksLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.waterWorksLabel.Location = new System.Drawing.Point(829, 684);
            this.waterWorksLabel.Name = "waterWorksLabel";
            this.waterWorksLabel.Size = new System.Drawing.Size(52, 38);
            this.waterWorksLabel.TabIndex = 6;
            this.waterWorksLabel.Text = "Water\r\nWorks";
            this.waterWorksLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel1
            // 
            this.chanceLabel1.AutoSize = true;
            this.chanceLabel1.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel1.Location = new System.Drawing.Point(111, 350);
            this.chanceLabel1.Name = "chanceLabel1";
            this.chanceLabel1.Size = new System.Drawing.Size(53, 19);
            this.chanceLabel1.TabIndex = 7;
            this.chanceLabel1.Text = "Chance";
            this.chanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railReadLabel
            // 
            this.railReadLabel.AutoSize = true;
            this.railReadLabel.BackColor = System.Drawing.Color.Transparent;
            this.railReadLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railReadLabel.Location = new System.Drawing.Point(106, 471);
            this.railReadLabel.Name = "railReadLabel";
            this.railReadLabel.Size = new System.Drawing.Size(62, 38);
            this.railReadLabel.TabIndex = 8;
            this.railReadLabel.Text = "Reading\r\nRailroad";
            this.railReadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taxLabel1
            // 
            this.taxLabel1.AutoSize = true;
            this.taxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.taxLabel1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.taxLabel1.Location = new System.Drawing.Point(107, 547);
            this.taxLabel1.Name = "taxLabel1";
            this.taxLabel1.Size = new System.Drawing.Size(57, 38);
            this.taxLabel1.TabIndex = 9;
            this.taxLabel1.Text = "Income\r\nTax";
            this.taxLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // jailLabel
            // 
            this.jailLabel.AutoSize = true;
            this.jailLabel.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.jailLabel.Location = new System.Drawing.Point(105, 102);
            this.jailLabel.Name = "jailLabel";
            this.jailLabel.Size = new System.Drawing.Size(63, 38);
            this.jailLabel.TabIndex = 10;
            this.jailLabel.Text = "Jail";
            this.jailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel2
            // 
            this.chanceLabel2.AutoSize = true;
            this.chanceLabel2.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel2.Location = new System.Drawing.Point(828, 271);
            this.chanceLabel2.Name = "chanceLabel2";
            this.chanceLabel2.Size = new System.Drawing.Size(53, 19);
            this.chanceLabel2.TabIndex = 11;
            this.chanceLabel2.Text = "Chance";
            this.chanceLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // eCompanyLabel
            // 
            this.eCompanyLabel.AutoSize = true;
            this.eCompanyLabel.BackColor = System.Drawing.Color.Transparent;
            this.eCompanyLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.eCompanyLabel.Location = new System.Drawing.Point(253, 109);
            this.eCompanyLabel.Name = "eCompanyLabel";
            this.eCompanyLabel.Size = new System.Drawing.Size(63, 38);
            this.eCompanyLabel.TabIndex = 12;
            this.eCompanyLabel.Text = "Electric\r\nCompany";
            this.eCompanyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railPennLabel
            // 
            this.railPennLabel.AutoSize = true;
            this.railPennLabel.BackColor = System.Drawing.Color.Transparent;
            this.railPennLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railPennLabel.Location = new System.Drawing.Point(453, 107);
            this.railPennLabel.Name = "railPennLabel";
            this.railPennLabel.Size = new System.Drawing.Size(88, 38);
            this.railPennLabel.TabIndex = 13;
            this.railPennLabel.Text = "Pennsylvania\r\nRailroad";
            this.railPennLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railBOLabel
            // 
            this.railBOLabel.AutoSize = true;
            this.railBOLabel.BackColor = System.Drawing.Color.Transparent;
            this.railBOLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railBOLabel.Location = new System.Drawing.Point(827, 471);
            this.railBOLabel.Name = "railBOLabel";
            this.railBOLabel.Size = new System.Drawing.Size(62, 38);
            this.railBOLabel.TabIndex = 14;
            this.railBOLabel.Text = "B&&O\r\nRailroad";
            this.railBOLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goToJailLabel
            // 
            this.goToJailLabel.AutoSize = true;
            this.goToJailLabel.BackColor = System.Drawing.Color.Transparent;
            this.goToJailLabel.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.goToJailLabel.Location = new System.Drawing.Point(826, 827);
            this.goToJailLabel.Name = "goToJailLabel";
            this.goToJailLabel.Size = new System.Drawing.Size(62, 56);
            this.goToJailLabel.TabIndex = 15;
            this.goToJailLabel.Text = "Go to\r\nJail";
            this.goToJailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // railShortLabel
            // 
            this.railShortLabel.AutoSize = true;
            this.railShortLabel.BackColor = System.Drawing.Color.Transparent;
            this.railShortLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.railShortLabel.Location = new System.Drawing.Point(475, 835);
            this.railShortLabel.Name = "railShortLabel";
            this.railShortLabel.Size = new System.Drawing.Size(47, 38);
            this.railShortLabel.TabIndex = 16;
            this.railShortLabel.Text = "Short\r\nLine";
            this.railShortLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chanceLabel3
            // 
            this.chanceLabel3.AutoSize = true;
            this.chanceLabel3.BackColor = System.Drawing.Color.Transparent;
            this.chanceLabel3.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.chanceLabel3.Location = new System.Drawing.Point(399, 848);
            this.chanceLabel3.Name = "chanceLabel3";
            this.chanceLabel3.Size = new System.Drawing.Size(53, 19);
            this.chanceLabel3.TabIndex = 17;
            this.chanceLabel3.Text = "Chance";
            this.chanceLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // taxLabel2
            // 
            this.taxLabel2.AutoSize = true;
            this.taxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.taxLabel2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.taxLabel2.Location = new System.Drawing.Point(259, 833);
            this.taxLabel2.Name = "taxLabel2";
            this.taxLabel2.Size = new System.Drawing.Size(57, 38);
            this.taxLabel2.TabIndex = 18;
            this.taxLabel2.Text = "Income\r\nTax";
            this.taxLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rollDie
            // 
            this.rollDie.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollDie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rollDie.Location = new System.Drawing.Point(240, 220);
            this.rollDie.Name = "rollDie";
            this.rollDie.Size = new System.Drawing.Size(220, 70);
            this.rollDie.TabIndex = 19;
            this.rollDie.Text = "Roll";
            this.rollDie.UseVisualStyleBackColor = true;
            this.rollDie.Click += new System.EventHandler(this.rollDie_Click_1);
            // 
            // buy
            // 
            this.buy.Location = new System.Drawing.Point(0, 0);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(75, 21);
            this.buy.TabIndex = 20;
            // 
            // endTurnButton
            // 
            this.endTurnButton.Location = new System.Drawing.Point(0, 0);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(75, 21);
            this.endTurnButton.TabIndex = 21;
            // 
            // payText
            // 
            this.payText.Location = new System.Drawing.Point(0, 0);
            this.payText.Name = "payText";
            this.payText.Size = new System.Drawing.Size(100, 21);
            this.payText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BuyProper
            // 
            this.BuyProper.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyProper.Location = new System.Drawing.Point(530, 220);
            this.BuyProper.Name = "BuyProper";
            this.BuyProper.Size = new System.Drawing.Size(220, 70);
            this.BuyProper.TabIndex = 23;
            this.BuyProper.Text = "Buy";
            this.BuyProper.UseVisualStyleBackColor = true;
            this.BuyProper.Click += new System.EventHandler(this.buy_Click_1);
            // 
            // TurnEnds
            // 
            this.TurnEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnEnds.Location = new System.Drawing.Point(309, 659);
            this.TurnEnds.Name = "TurnEnds";
            this.TurnEnds.Size = new System.Drawing.Size(395, 88);
            this.TurnEnds.TabIndex = 24;
            this.TurnEnds.Text = "End Turn";
            this.TurnEnds.UseVisualStyleBackColor = true;
            this.TurnEnds.Click += new System.EventHandler(this.endTurn_Click_1);
            // 
            // Trade
            // 
            this.Trade.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trade.Location = new System.Drawing.Point(240, 347);
            this.Trade.Name = "Trade";
            this.Trade.Size = new System.Drawing.Size(220, 70);
            this.Trade.TabIndex = 25;
            this.Trade.Text = "Trade";
            this.Trade.UseVisualStyleBackColor = true;
            this.Trade.Click += new System.EventHandler(this.trade_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MagProper
            // 
            this.MagProper.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MagProper.Location = new System.Drawing.Point(530, 347);
            this.MagProper.Name = "MagProper";
            this.MagProper.Size = new System.Drawing.Size(220, 70);
            this.MagProper.TabIndex = 27;
            this.MagProper.Text = "Manage";
            this.MagProper.UseVisualStyleBackColor = true;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 962);
            this.Controls.Add(this.MagProper);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Trade);
            this.Controls.Add(this.TurnEnds);
            this.Controls.Add(this.BuyProper);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rollDie);
            this.Controls.Add(this.buy);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.taxLabel2);
            this.Controls.Add(this.chanceLabel3);
            this.Controls.Add(this.railShortLabel);
            this.Controls.Add(this.goToJailLabel);
            this.Controls.Add(this.railBOLabel);
            this.Controls.Add(this.railPennLabel);
            this.Controls.Add(this.eCompanyLabel);
            this.Controls.Add(this.chanceLabel2);
            this.Controls.Add(this.jailLabel);
            this.Controls.Add(this.taxLabel1);
            this.Controls.Add(this.railReadLabel);
            this.Controls.Add(this.chanceLabel1);
            this.Controls.Add(this.waterWorksLabel);
            this.Controls.Add(this.chestLabel3);
            this.Controls.Add(this.chestLabel2);
            this.Controls.Add(this.chestLabel1);
            this.Controls.Add(this.parkingLabel);
            this.Controls.Add(this.goLabel);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Board";
            this.Text = "GameBoard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void rollDie_Click(object sender, EventArgs e)
        {
            List<int> die = this.roll();
            int steps = die[0] + die[1];
            this.getPlayer().move(steps);
        }


        #endregion

        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape illinoisAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape indianaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape newYorkAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape tennesseeAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape virginiaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape statesAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape orientalAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape vermontAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape balticAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape waterWorks;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape atlanticAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape boRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape24;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape readingRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape incomeTax;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape mediteraneanAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape connecticutAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape goYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape gotoJailYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape boardwalk;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape shortLine;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape chance3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape parkPlace;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape luxuryTax;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape pacificAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape northCarolinaAvenue;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectanglepennsylvaniaAvenueShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape15;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape communityChest2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape electricCompany;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape PennsylvaniaRailroad;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape stCharlesPlace;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape freeParkingYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape jailYOLO;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape marvinGardens;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape ventnorAvenue;
        private System.Windows.Forms.Label goLabel;
        private System.Windows.Forms.Label parkingLabel;
        private System.Windows.Forms.Label chestLabel1;
        private System.Windows.Forms.Label chestLabel2;
        private System.Windows.Forms.Label chestLabel3;
        private System.Windows.Forms.Label waterWorksLabel;
        private System.Windows.Forms.Label chanceLabel1;
        private System.Windows.Forms.Label railReadLabel;
        private System.Windows.Forms.Label taxLabel1;
        private System.Windows.Forms.Label jailLabel;
        private System.Windows.Forms.Label chanceLabel2;
        private System.Windows.Forms.Label eCompanyLabel;
        private System.Windows.Forms.Label railPennLabel;
        private System.Windows.Forms.Label railBOLabel;
        private System.Windows.Forms.Label goToJailLabel;
        private System.Windows.Forms.Label railShortLabel;
        private System.Windows.Forms.Label chanceLabel3;
        private System.Windows.Forms.Label taxLabel2;
        private System.Windows.Forms.Button rollDie;
        private System.Windows.Forms.Button buy;
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.TextBox payText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BuyProper;
        private System.Windows.Forms.Button TurnEnds;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private System.Windows.Forms.Button Trade;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button MagProper;
    }

}

