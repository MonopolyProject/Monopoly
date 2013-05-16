using System.Windows.Forms;

namespace Monopoly
{
 
    partial class GiveCardWindow
    {
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

        #region Windows Form Designer generated code





        private void setUp()
        {
            for (int i = 0; i < b.getPlayers().Count; i++)
            {
                RadioButton pradio = new RadioButton();
                pradio.AutoSize = true;
                pradio.Location = new System.Drawing.Point(38, 60 + 23 * i);
                pradio.Name = "pradio";
                pradio.Size = new System.Drawing.Size(63, 17);
                pradio.TabIndex = 0;
                pradio.TabStop = true;
                pradio.Text = b.getPlayers()[i].getName(); ;
                pradio.UseVisualStyleBackColor = true;
                pradio.ForeColor = b.getPlayerShape(i).FillColor;
                this.splitContainer1.Panel1.Controls.Add(pradio);
                this.playerButtons.Add(pradio);
            }

            for (int i = 0; i < b.getChance().Count; i++)
            {
                RadioButton chanceRadio = new RadioButton();
                chanceRadio.AutoSize = true;
                chanceRadio.Location = new System.Drawing.Point(12, 60 + 23 * i);
                chanceRadio.Name = "chanceRadio";
                chanceRadio.Size = new System.Drawing.Size(62, 17);
                chanceRadio.TabIndex = 6;
                chanceRadio.TabStop = true;
                chanceRadio.Text = b.getChance()[i].getName();
                if (chanceRadio.Text.Length > 100) chanceRadio.Text = chanceRadio.Text.Substring(0, 50);
                chanceRadio.UseVisualStyleBackColor = true;
                this.splitContainer1.Panel2.Controls.Add(chanceRadio);
                this.chanceButtons.Add(chanceRadio);
            }
            for (int i = 0; i < b.getCommunity().Count; i++)
            {
                RadioButton commRadio = new RadioButton();
                commRadio.AutoSize = true;
                commRadio.Location = new System.Drawing.Point(516, 60 + 23 * i);
                commRadio.Name = "commRadio";
                commRadio.Size = new System.Drawing.Size(62, 17);
                commRadio.TabIndex = 6;
                commRadio.TabStop = true;
                commRadio.Text = b.getCommunity()[i].getName();
                commRadio.UseVisualStyleBackColor = true;
                this.splitContainer1.Panel2.Controls.Add(commRadio);
                this.commButtons.Add(commRadio);
            }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.select = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Chance = new System.Windows.Forms.Label();
            this.choose = new System.Windows.Forms.Label();
            this.give = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.give);
            this.splitContainer1.Panel1.Controls.Add(this.select);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.Chance);
            this.splitContainer1.Panel2.Controls.Add(this.choose);
            this.splitContainer1.Size = new System.Drawing.Size(1104, 262);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 5;
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select.Location = new System.Drawing.Point(12, 9);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(119, 24);
            this.select.TabIndex = 1;
            this.select.Text = "Select Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Community";
            // 
            // Chance
            // 
            this.Chance.AutoSize = true;
            this.Chance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chance.Location = new System.Drawing.Point(8, 33);
            this.Chance.Name = "Chance";
            this.Chance.Size = new System.Drawing.Size(64, 20);
            this.Chance.TabIndex = 7;
            this.Chance.Text = "Chance";
            // 
            // choose
            // 
            this.choose.AutoSize = true;
            this.choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choose.Location = new System.Drawing.Point(278, 9);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(121, 24);
            this.choose.TabIndex = 6;
            this.choose.Text = "Choose Card";
            // 
            // give
            // 
            this.give.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.give.Location = new System.Drawing.Point(16, 223);
            this.give.Name = "give";
            this.give.Size = new System.Drawing.Size(97, 27);
            this.give.TabIndex = 2;
            this.give.Text = "Give Card!";
            this.give.UseVisualStyleBackColor = true;
            this.give.Click += new System.EventHandler(this.give_Click);
            // 
            // GiveCardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GiveCardWindow";
            this.Text = "Give a Card to a Player";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Chance;
        private System.Windows.Forms.Label choose;
        private Button give;


    }
}