namespace HelpAsCompanyApp
{
    partial class Kullanici_Engelle_Form
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
            this.label_Bilgiler = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Engelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Bilgiler
            // 
            this.label_Bilgiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label_Bilgiler.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Bilgiler.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_Bilgiler.Location = new System.Drawing.Point(12, 76);
            this.label_Bilgiler.Name = "label_Bilgiler";
            this.label_Bilgiler.Size = new System.Drawing.Size(531, 289);
            this.label_Bilgiler.TabIndex = 0;
            this.label_Bilgiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.textBox1.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(18, 416);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(525, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(202, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Engellenme Sebebi";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.LightSalmon;
            this.button1.Location = new System.Drawing.Point(499, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(1, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(557, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Engellenen kullanıcı, engeli kalkana kadar hesabına giriş yapamayacak";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(187, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "KULLANICI ENGELLEME";
            // 
            // Btn_Engelle
            // 
            this.Btn_Engelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Engelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_Engelle.ForeColor = System.Drawing.Color.GreenYellow;
            this.Btn_Engelle.Location = new System.Drawing.Point(216, 476);
            this.Btn_Engelle.Name = "Btn_Engelle";
            this.Btn_Engelle.Size = new System.Drawing.Size(126, 46);
            this.Btn_Engelle.TabIndex = 7;
            this.Btn_Engelle.Text = "Engelle";
            this.Btn_Engelle.UseVisualStyleBackColor = true;
            this.Btn_Engelle.Click += new System.EventHandler(this.Btn_Engelle_Click);
            // 
            // Kullanici_Engelle_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(555, 534);
            this.Controls.Add(this.Btn_Engelle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Bilgiler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kullanici_Engelle_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanici_Engelle_Form";
            this.Load += new System.EventHandler(this.Kullanici_Engelle_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Bilgiler;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Engelle;
    }
}