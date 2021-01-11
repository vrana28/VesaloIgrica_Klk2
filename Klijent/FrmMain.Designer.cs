
namespace Klijent
{
    partial class FrmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlovo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPojam = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPogadnjanaSlova = new System.Windows.Forms.Label();
            this.lblPokusaji = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unesi slovo:";
            // 
            // txtSlovo
            // 
            this.txtSlovo.Location = new System.Drawing.Point(30, 42);
            this.txtSlovo.Name = "txtSlovo";
            this.txtSlovo.Size = new System.Drawing.Size(100, 20);
            this.txtSlovo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Posalji";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPojam
            // 
            this.lblPojam.AutoSize = true;
            this.lblPojam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPojam.Location = new System.Drawing.Point(27, 102);
            this.lblPojam.Name = "lblPojam";
            this.lblPojam.Size = new System.Drawing.Size(0, 16);
            this.lblPojam.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prestali broj puta:";
            // 
            // lblPogadnjanaSlova
            // 
            this.lblPogadnjanaSlova.AutoSize = true;
            this.lblPogadnjanaSlova.Location = new System.Drawing.Point(27, 174);
            this.lblPogadnjanaSlova.Name = "lblPogadnjanaSlova";
            this.lblPogadnjanaSlova.Size = new System.Drawing.Size(0, 13);
            this.lblPogadnjanaSlova.TabIndex = 5;
            // 
            // lblPokusaji
            // 
            this.lblPokusaji.AutoSize = true;
            this.lblPokusaji.Location = new System.Drawing.Point(157, 215);
            this.lblPokusaji.Name = "lblPokusaji";
            this.lblPokusaji.Size = new System.Drawing.Size(0, 13);
            this.lblPokusaji.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 303);
            this.Controls.Add(this.lblPokusaji);
            this.Controls.Add(this.lblPogadnjanaSlova);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPojam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSlovo);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSlovo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPojam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPogadnjanaSlova;
        private System.Windows.Forms.Label lblPokusaji;
    }
}