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
    public class CardWindow : Form
    {
        private Card c;
        private WindowsFormsApplication2.Board b;

        public CardWindow(Card c, WindowsFormsApplication2.Board b)
        {
            this.c = c;
            this.b = b;
        }


        public void initialize()
        {
            Button b1 = new Button();
            b1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            b1.Location = new Point(21, 50);
            b1.Size = new Size(82, 31);
            b1.Text = "Okay";
            b1.UseVisualStyleBackColor = true;
            b1.Click += new EventHandler(cardWindowClose);
            
            Label l = new Label();
            l.AutoSize = true;
            l.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            l.Location = new Point(17, 19);
            l.Size = new Size(381, 20);
            l.Text = c.getName();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 93);
            this.Controls.Add(l);
            this.Controls.Add(b1);
            this.Text = "You Drew a Card!";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;

        }

        private void cardWindowClose(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
