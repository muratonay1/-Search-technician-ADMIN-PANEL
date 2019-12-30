namespace HelpAsCompanyApp
{
    partial class HizmetSaglaForm
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
            this.button_HizmetVer = new System.Windows.Forms.Button();
            this.listBox_Musait_Ustalar = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Bilgiler = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Usta_Ismi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_HizmetVer
            // 
            this.button_HizmetVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_HizmetVer.Font = new System.Drawing.Font("Rajdhani", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_HizmetVer.ForeColor = System.Drawing.Color.DarkKhaki;
            this.button_HizmetVer.Location = new System.Drawing.Point(52, 276);
            this.button_HizmetVer.Name = "button_HizmetVer";
            this.button_HizmetVer.Size = new System.Drawing.Size(448, 69);
            this.button_HizmetVer.TabIndex = 1;
            this.button_HizmetVer.Text = "Hizmeti Ver";
            this.button_HizmetVer.UseVisualStyleBackColor = true;
            this.button_HizmetVer.Click += new System.EventHandler(this.button_HizmetVer_Click);
            // 
            // listBox_Musait_Ustalar
            // 
            this.listBox_Musait_Ustalar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.listBox_Musait_Ustalar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Musait_Ustalar.Font = new System.Drawing.Font("Rajdhani", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox_Musait_Ustalar.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox_Musait_Ustalar.FormattingEnabled = true;
            this.listBox_Musait_Ustalar.ItemHeight = 28;
            this.listBox_Musait_Ustalar.Location = new System.Drawing.Point(590, 91);
            this.listBox_Musait_Ustalar.Name = "listBox_Musait_Ustalar";
            this.listBox_Musait_Ustalar.Size = new System.Drawing.Size(183, 254);
            this.listBox_Musait_Ustalar.TabIndex = 2;
            this.listBox_Musait_Ustalar.SelectedIndexChanged += new System.EventHandler(this.listBox_Musait_Ustalar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rajdhani", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(561, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hizmet Verebilecek Ustalar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rajdhani", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(593, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ustayı atamak için üzerine tıklayın";
            // 
            // label_Bilgiler
            // 
            this.label_Bilgiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.label_Bilgiler.Font = new System.Drawing.Font("Rajdhani", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Bilgiler.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_Bilgiler.Location = new System.Drawing.Point(12, 9);
            this.label_Bilgiler.Name = "label_Bilgiler";
            this.label_Bilgiler.Size = new System.Drawing.Size(547, 234);
            this.label_Bilgiler.TabIndex = 5;
            this.label_Bilgiler.Text = "Hizmet Verebilecek Ustalar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rajdhani", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(72, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "SEÇİLEN USTA: ";
            // 
            // label_Usta_Ismi
            // 
            this.label_Usta_Ismi.AutoSize = true;
            this.label_Usta_Ismi.Font = new System.Drawing.Font("Rajdhani", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Usta_Ismi.ForeColor = System.Drawing.Color.LightYellow;
            this.label_Usta_Ismi.Location = new System.Drawing.Point(164, 250);
            this.label_Usta_Ismi.Name = "label_Usta_Ismi";
            this.label_Usta_Ismi.Size = new System.Drawing.Size(0, 20);
            this.label_Usta_Ismi.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Aqua;
            this.button1.Location = new System.Drawing.Point(766, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HizmetSaglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Usta_Ismi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Bilgiler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Musait_Ustalar);
            this.Controls.Add(this.button_HizmetVer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HizmetSaglaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HizmetSaglaForm";
            this.Load += new System.EventHandler(this.HizmetSaglaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_HizmetVer;
        private System.Windows.Forms.ListBox listBox_Musait_Ustalar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Bilgiler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Usta_Ismi;
        private System.Windows.Forms.Button button1;
    }
}