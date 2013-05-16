namespace Monopoly
{
    partial class GetOutOfJailDialog
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dialog = new System.Windows.Forms.Label();
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dialog
            // 
            this.dialog.AutoSize = true;
            this.dialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog.Location = new System.Drawing.Point(12, 32);
            this.dialog.Name = "dialog";
            this.dialog.Size = new System.Drawing.Size(303, 44);
            this.dialog.TabIndex = 0;
            this.dialog.Text = "You have a Get Out of Jail Free card\r\nWould you like to use it?";
            this.dialog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // yes
            // 
            this.yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yes.Location = new System.Drawing.Point(16, 114);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(82, 34);
            this.yes.TabIndex = 1;
            this.yes.Text = "Yes";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // no
            // 
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(205, 114);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(110, 34);
            this.no.TabIndex = 2;
            this.no.Text = "No way, José";
            this.no.UseVisualStyleBackColor = true;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // GetOutOfJailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 160);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.dialog);
            this.Name = "GetOutOfJailDialog";
            this.Text = "Get Out of Jail Free!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dialog;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
    }
}