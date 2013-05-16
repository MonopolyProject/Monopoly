using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly;
using System.Threading;
using System.Globalization;

namespace Monopoly
{
    public class IncomeTaxWindow : Form
    {

        private Player landedOn;
        private IncomeTax tax;
        private WindowsFormsApplication2.Board b;

        public IncomeTaxWindow(Player landedOn, IncomeTax tax, WindowsFormsApplication2.Board b)
        {
            this.landedOn = landedOn;
            this.tax = tax;
            this.b = b;
        }


        public void initialize()
        {
            Button b1 = new Button();
            b1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            b1.Location = new Point(21, 50);
            b1.Size = new Size(82, 31);
            b1.Text = "$200";
            b1.UseVisualStyleBackColor = true;
            b1.Click += new EventHandler(incomeTaxDefault);


            Button b2 = new Button();
            b2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            b2.Location = new Point(306, 50);
            b2.Size = new Size(82, 31);
            b2.Text = "10%";
            b2.Click += new EventHandler(incomeTaxTenPercent);

            Label l = new Label();
            l.AutoSize = true;
            l.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            l.Location = new Point(17, 19);
            l.Size = new Size(381, 20);
            l.Text = "Do you want to pay $200 or 10% of your total worth ($"+ (int)this.landedOn.calculateTotalWorth()/10+")?";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 93);
            this.Controls.Add(l);
            this.Controls.Add(b2);
            this.Controls.Add(b1);
            this.Text = "Income Tax";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;

        }




        private void incomeTaxTenPercent(object sender, EventArgs e)
        {
            this.tax.effect(landedOn, false);
            b.updatePlayerLabels();
            this.Dispose();
        }

        private void incomeTaxDefault(object sender, EventArgs e)
        {
            this.tax.effect(landedOn, true);
            b.updatePlayerLabels();
            this.Dispose();
        }

    }
}
