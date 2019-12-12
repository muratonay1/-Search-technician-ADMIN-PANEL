using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace HelpAsCompanyApp
{  
    public partial class Form2 : Form
    {
        #region Service Nesne ve Değişkenler
        SonService.WebService1SoapClient service = new SonService.WebService1SoapClient();
        public dynamic Response_Haber;
        public dynamic Response_Alan;
        public dynamic Response_AltAlan;
        #endregion


        #region CLİCK EVENTLERİ
        public Form2()
        {
            InitializeComponent();
        }
        //NAVBAR BUTTON TOOLTIP FUNCTION
        public void ToolTip_On()
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.BackColor = Color.FromArgb(37, 211, 102);
            Aciklama.ForeColor = Color.Black;
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(pictureBox2, "Yorumlar");
            Aciklama.SetToolTip(pictureBox3, "İstekler");
            Aciklama.SetToolTip(pictureBox4, "Haberler");
            Aciklama.SetToolTip(pictureBox5, "Ustalar");
            Aciklama.SetToolTip(pictureBox6, "Alanlar");
            Aciklama.SetToolTip(pictureBox7, "Geri Bildirimler");
            Aciklama.SetToolTip(pictureBox9, "Kullanıcılar");
        }
        //PROGRAM START PANEL
        public void StartLoadPage()
        {
            yorumlar_panel.BringToFront();
        }
        //GROUPBOX CHANGES POSITION AND DELETE NAVBAR BORDER LINE  
        public void GroupboxSize_NavbarButtonBorder()
        {
            //LEFT MENU BUTTON DELETE BORDER LINE
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.BorderSize = 0;

            //MENU PANEL GROUPBOX SIZE
            groupBox1.Size = new Size(1125, 646);
            groupBox2.Size = new Size(1125, 646);
            groupBox3.Size = new Size(1125, 646);
            groupBox4.Size = new Size(1125, 646);
            groupBox5.Size = new Size(1125, 646);
            groupBox6.Size = new Size(1125, 646);

            //MENU PANEL GROUPBOX LOCATION
            groupBox1.Location = new Point(0, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox3.Location = new Point(0, 0);
            groupBox4.Location = new Point(0, 0);
            groupBox5.Location = new Point(0, 0);
            groupBox6.Location = new Point(0, 0);
        }
        //FORM LOAD 
        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip_On();//NAVBAR TOOLTIP FUNCTION
            StartLoadPage();//PANEL3 BRING TO FORNT FUNCTION 
            GroupboxSize_NavbarButtonBorder();//GROUPBOX CHANGES POSITION AND DELETE NAVBAR BORDER LINE         
        }
        //NAVBAR HIDE SHOW ICON CLICK
        private void pictureBox1_Click_1(object sender, EventArgs e) //NAVBAR İCON
        {
            if (panel1.Size == new Size(300, 646))//Boyu büyükse (açıkken)
            {
                panel1.Size = new Size(73, 646);
                pictureBox1.Location = new Point(15, 46);
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox9.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                //PANELLERİN BOYUTLARI
                yorumlar_panel.Size = new Size(1352, 646);//yorumlar
                yorumlar_panel.Location = new Point(73, 33);//yorumlar
                istekler_panel.Size = new Size(1352, 646);//istekler
                istekler_panel.Location = new Point(73, 33);//istekler
                haberler_panel.Size = new Size(1352, 646);//haberler
                haberler_panel.Location = new Point(73, 33);//haberler
                ustalar_panel.Size = new Size(1352, 646);//ustalar
                ustalar_panel.Location = new Point(73, 33);//ustalar
                alanlar_panel.Size = new Size(1352, 646);//alanlar
                alanlar_panel.Location = new Point(73, 33);//alanlar
                geri_bildirimler_panel.Size = new Size(1352, 646);//geri bildirimler
                geri_bildirimler_panel.Location = new Point(73, 33);//geri bildirimler
                kullanıcılar_panel.Size = new Size(1352, 646);//kullanıcılar
                kullanıcılar_panel.Location = new Point(73, 33);//kullanıcılar
                groupBox1.Location = new Point(110, 0);
                groupBox2.Location = new Point(110, 0);
                groupBox3.Location = new Point(110, 0);
                groupBox4.Location = new Point(110, 0);
                groupBox5.Location = new Point(110, 0);
                groupBox6.Location = new Point(110, 0);
                groupBox7.Location = new Point(110, 0);
            }
            else if (panel1.Size == new Size(73, 646)) //boyu küçükse (kapalıyken)
            {
                panel1.Size = new Size(300, 646);
                pictureBox1.Location = new Point(249, 6);
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox9.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                //PANELLERİN BOYUTLARI
                yorumlar_panel.Size = new Size(1125, 646);
                yorumlar_panel.Location = new Point(300, 33);
                istekler_panel.Size = new Size(1125, 646);
                istekler_panel.Location = new Point(300, 33);
                haberler_panel.Size = new Size(1125, 646);
                haberler_panel.Location = new Point(300, 33);
                ustalar_panel.Size = new Size(1125, 646);
                ustalar_panel.Location = new Point(300, 33);
                alanlar_panel.Size = new Size(1125, 646);
                alanlar_panel.Location = new Point(300, 33);
                geri_bildirimler_panel.Size = new Size(1125, 646);
                geri_bildirimler_panel.Location = new Point(300, 33);
                kullanıcılar_panel.Size = new Size(1125, 646);
                kullanıcılar_panel.Location = new Point(300, 33);
                groupBox1.Location = new Point(0, 0);          
                groupBox2.Location = new Point(0, 0);
                groupBox3.Location = new Point(0, 0);
                groupBox4.Location = new Point(0, 0);
                groupBox5.Location = new Point(0, 0);
                groupBox6.Location = new Point(0, 0);
                groupBox7.Location = new Point(0, 0);
            }
        }
        //Sol Menu Butonların üstüne gelince ve terk edince renk değişme eventleri-------------------------------
        //YORUMLAR BUTONU UZERINE GELINCE
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button1.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button1.Font = new Font("Rajdhani", 22);
                pictureBox2.Visible = true;
            }
            else
            {
                button1.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                pictureBox2.Visible = true;


            }

        }     
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button1.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button1.Font = new Font("Rajdhani", 11);
                pictureBox2.Visible = false;
            }
            else
            {
                button1.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ

            }

        }
        //ISTEKLER BUTONU UZERINE GELINCE
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button2.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button2.Font = new Font("Rajdhani", 22);
                pictureBox3.Visible = true;
            }
            else
            {
                button2.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }

        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button2.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button2.Font = new Font("Rajdhani", 11);
                pictureBox3.Visible = false;
            }
            else
            {
                button2.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
            }

        }
        //HABERLER BUTONU UZERINE GELINCE
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button3.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button3.Font = new Font("Rajdhani", 22);
                pictureBox4.Visible = true;
            }
            else
            {
                button3.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }

        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button3.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button3.Font = new Font("Rajdhani", 11);
                pictureBox4.Visible = false;
            }
            else
            {
                button3.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
            }

        }
        //USTALAR BUTONU UZERINE GELINCE
        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button4.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button4.Font = new Font("Rajdhani", 22);
                pictureBox5.Visible = true;
            }
            else
            {
                button4.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }

        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button4.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button4.Font = new Font("Rajdhani", 11);
                pictureBox5.Visible = false;
            }
            else
            {
                button4.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
            }

        }
        //ALANLAR BUTONU UZERINE GELINCE
        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button5.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button5.Font = new Font("Rajdhani", 22);
                pictureBox6.Visible = true;
            }
            else
            {
                button5.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }

        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button5.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button5.Font = new Font("Rajdhani", 11);
                pictureBox6.Visible = false;
            }
            else
            {
                button5.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
            }

        }
        //GERI BILDIRIMLER BUTONU UZERINE GELINCE
        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button6.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button6.Font = new Font("Rajdhani", 22);
                pictureBox7.Visible = true;
            }
            else
            {
                button6.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }

        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button6.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
                button6.Font = new Font("Rajdhani", 11);
                pictureBox7.Visible = false;
            }
            else
            {
                button6.BackColor = Color.FromArgb(26, 32, 40);//KOYU MAVİ
            }

        }
        //KULLANICILAR BUTONU UZERINE GELINCE
        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button7.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
                button7.Font = new Font("Rajdhani", 22);
                pictureBox9.Visible = true;
            }
            else
            {
                button7.BackColor = Color.FromArgb(0, 102, 204);//AÇIK MAVİ
            }
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.Size == new Size(300, 646))
            {
                button7.BackColor = Color.FromArgb(26, 32, 40);//AÇIK MAVİ
                button7.Font = new Font("Rajdhani", 11);
                pictureBox9.Visible = false;
            }
            else
            {
                button7.BackColor = Color.FromArgb(26, 32, 40);//AÇIK MAVİ
            }
        }
        private void button1_Click(object sender, EventArgs e)//YORUMLAR NAVBAR BUTTON CLICK
        {
            yorumlar_panel.BringToFront();
            flowLayoutPanel1.Controls.Clear();
            Yorum_Listele();
        }
        private void button2_Click(object sender, EventArgs e)//İSTEKLER NAVBAR BUTTON CLICK
        {
            istekler_panel.BringToFront();
        }
        private void button3_Click(object sender, EventArgs e)//Haberler NAVBAR BUTTON CLICK
        {
            HaberListesiFlowPanel.Controls.Clear();
            HaberListele_Function();
            haberler_panel.BringToFront();
        }
        private void button4_Click(object sender, EventArgs e)//Ustalar NAVBAR BUTTON CLICK
        {
            ustalar_panel.BringToFront();
        }
        private void button5_Click(object sender, EventArgs e)//Alanlar navbar button CLICK
        {
            alanlar_panel.BringToFront();
            AlanListele_Function();
            
        }
        private void button6_Click(object sender, EventArgs e)//GERİ BİLDİRİM NAVBAR BUTTON CLICK
        {
            geri_bildirimler_panel.BringToFront();
           
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            yorumlar_panel.BringToFront();
        }//YORUMLAR NAVBAR İCON CLICK
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            istekler_panel.BringToFront();
        }//İSTEKLER NAVBAR İCON CLICK
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            haberler_panel.BringToFront();
        }//HABERLER NAVBAR İCON CLICK
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ustalar_panel.BringToFront();
        }//USTALAR NAVBAR İCON CLICK
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            alanlar_panel.BringToFront();
        }//ALANLAR NAVBAR İCON CLICK
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            geri_bildirimler_panel.BringToFront();
        }//GERİ BİLDİRİMLER NAVBAR İCON CLICK
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            kullanıcılar_panel.BringToFront();
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.Location = new Point(12, 150);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

            pictureBox2.Size = new Size(40, 40);
            pictureBox2.Location = new Point(16, 155);
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.Location = new Point(12, 213);
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.Location = new Point(16, 218);
        }
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.Size = new Size(50, 50);
            pictureBox4.Location = new Point(12, 277);
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.Size = new Size(40, 40);
            pictureBox4.Location = new Point(16, 282);
        }
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Size = new Size(50, 50);
            pictureBox5.Location = new Point(12, 341);
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.Location = new Point(16, 346);
        }
        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.Size = new Size(50, 50);
            pictureBox6.Location = new Point(12, 405);
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox6.Size = new Size(40, 40);
            pictureBox6.Location = new Point(16, 410);
        }
        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox7.Size = new Size(50, 50);
            pictureBox7.Location = new Point(12, 467);
        }
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox7.Size = new Size(40, 40);
            pictureBox7.Location = new Point(16, 472);
        }
        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.Size = new Size(50, 50);
            pictureBox9.Location = new Point(13, 531);
        }
        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox9.Size = new Size(40, 40);
            pictureBox9.Location = new Point(16, 536);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            kullanıcılar_panel.BringToFront();
        }
        
        #endregion
        
       


        #region Alanlar
        //Alanların flowlayout panel tasarımı
        public void AlanListele_for_FlowPanel(int Alan_Id, string Alan_Adi)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.FromArgb(39, 60, 117);
            flp.Size = new System.Drawing.Size(280, 130);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = Alan_Id;
            flp.Click += new EventHandler(this.Alan_click);
            Font header = new Font("Rajdhani", 16, FontStyle.Bold);
            Label lblheader = new Label();
            lblheader.AutoSize = true;
            lblheader.AutoEllipsis = true;
            lblheader.UseCompatibleTextRendering = true;
            lblheader.Text = Alan_Adi;
            lblheader.ForeColor = Color.White;
            lblheader.Font = header;
            lblheader.Padding = new Padding(35);
            flp.Controls.Add(lblheader);     
            flowLayoutPanel2.Controls.Add(flp);
        }
        //Alanların listelenmesi fonksiyonu (Service request)
        public void AlanListele_Function()
        {
            var response = service.AlanListesi();
            Response_Alan = JsonConvert.DeserializeObject(response);
            int alan_id;
            string alan_adi;
            foreach (var item in Response_Alan)
            {
                alan_id = item.Alan_Id;
                alan_adi = item.Alan_Isim;
                AlanListele_for_FlowPanel(alan_id, alan_adi);
            }
        }
        //Alanlara tıklayınca alt alan yordamını çağırma
        public void Alan_click(object sender, EventArgs e)
        {
            FlowLayoutPanel alan_paneli = sender as FlowLayoutPanel;
            string alan_id = alan_paneli.Tag.ToString();
            foreach (var item in Response_Alan)
            {
                if (Convert.ToInt32(item.Alan_Id) == Convert.ToInt32(alan_id))
                {
                    label_AltAlan.Text = "";
                    flowLayoutPanel3.Controls.Clear();
                    //MessageBox.Show(item.Alan_Isim.ToString());
                    AltAlanListele_Function(item.Alan_Isim.ToString());
                }
            }
        }    
        //alt alanların alanlardan gelen alan ismiyle service requesti yapması
        public void AltAlanListele_Function(string Request_AlanAdi)
        {
            var response = service.AltAlanListesi(Request_AlanAdi.ToString());
            if(response == null || response == "")
            {
                AltAlanListele_for_FlowPanel("Boş");
                label_AltAlan.Text = Request_AlanAdi;
            }
            else
            {
                Response_AltAlan = JsonConvert.DeserializeObject(response);
                int altalan_id;
                string altalan_adi;
                string altalan_alan_id;
                foreach (var item in Response_AltAlan)
                {
                    altalan_id = item.Dal_Id;
                    altalan_adi = item.Dal_Isim;
                    altalan_alan_id = item.Alan_Isim;
                    AltAlanListele_for_FlowPanel(altalan_adi);
                    label_AltAlan.Text = Request_AlanAdi;
                }
            }            
        }
        //alt alanların flow layout panel tasarımı
        public void AltAlanListele_for_FlowPanel(string AltAlan_Adi)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.FromArgb(39, 60, 117);
            flp.Size = new System.Drawing.Size(280, 130);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            Font header = new Font("Rajdhani", 16, FontStyle.Bold);
            Label lblheader = new Label();
            lblheader.AutoSize = true;
            lblheader.AutoEllipsis = true;
            lblheader.UseCompatibleTextRendering = true;
            lblheader.Text = AltAlan_Adi;
            lblheader.ForeColor = Color.White;
            lblheader.Font = header;
            lblheader.Padding = new Padding(40);
            flp.Controls.Add(lblheader);
            flowLayoutPanel3.Controls.Add(flp);
        }
        #endregion


        #region Haberler 
        //------------------------------------------------------------------HABERLER vvvvvvvvvvvvv
        // Haber textboxları temizleme
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox2.Clear();
        }

        //haber flowlayout panele gömme
        public void HaberListele_for_FlowPanel(int Haber_Id, string Haber_Baslik, string Haber_Icerik)
        {
            //tek haber için panel boyutları
            int x = 437;
            int y = 200;
            //Tek haber için panel oluşturma
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.FromArgb(39, 60, 117);
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = Haber_Id;
            flp.Click += new EventHandler(this.Haber_click);
            //Haber başlığı oluşturma
            Font header = new Font("Rajdhani", 18, FontStyle.Bold);
            Label lblheader = new Label();
            lblheader.AutoSize = true;
            lblheader.AutoEllipsis = true;
            lblheader.UseCompatibleTextRendering = true;
            lblheader.ForeColor = Color.White;
            lblheader.Font = header;
            lblheader.Margin = new Padding(40, 0, 3, 0);
            lblheader.Text = Haber_Baslik;
            lblheader.Name = Haber_Baslik;
            lblheader.Tag = Haber_Baslik;
            //Haber İçeriği oluşturma
            Font f_icerik = new Font("Rajdhani", 14);
            Label label_icerik = new Label();
            label_icerik.Size = new System.Drawing.Size(426, 104);
            label_icerik.AutoSize = true;
            label_icerik.AutoEllipsis = true;
            label_icerik.UseCompatibleTextRendering = true;
            label_icerik.Margin = new Padding(3, 15, 3, 3);
            label_icerik.ForeColor = Color.FromArgb(46, 204, 113);
            label_icerik.AutoSize = false;
            label_icerik.Font = f_icerik;
            label_icerik.Text = Haber_Icerik;
            label_icerik.Tag = Haber_Icerik;
            //Tek haber için panele yığma
            flp.Controls.Add(lblheader);
            flp.Controls.Add(label_icerik);
            //Oluşturulan Main Panele yığma
            HaberListesiFlowPanel.Controls.Add(flp);
        }
        //haber listeleme fonksiyonu
        public void HaberListele_Function()
        {
            var response = service.HaberListele();
            Response_Haber = JsonConvert.DeserializeObject(response);
            int haber_id;
            string haber_baslik;
            string haber_icerik;
            foreach (var item in Response_Haber)
            {
                haber_id = item.Haber_Id;
                haber_baslik = item.Haber_Baslik;
                haber_icerik = item.Haber_Icerik;
                HaberListele_for_FlowPanel(haber_id, haber_baslik, haber_icerik);
            }
        }

        //Haber Ekleme butonu
        private void button12_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" || textBox1.Text == null) || (richTextBox2.Text == "" || richTextBox2.Text == null))
            {
                MessageBox.Show("Haber başlığı veya haber içeriğini tamamlayın.");
            }
            else
            {
                var response = service.HaberEkle(textBox1.Text, richTextBox2.Text);
                HaberListesiFlowPanel.Controls.Clear();
                HaberListele_Function();
                MessageBox.Show(response);
            }

        }

        //Haber Silme butonu
        private void button11_Click(object sender, EventArgs e)
        {
            var response = service.HaberSil(Convert.ToInt32(textBox1.Tag));
            HaberListesiFlowPanel.Controls.Clear();
            HaberListele_Function();
            MessageBox.Show(response);
        }

        //Haber Güncelleme butonu
        private void button9_Click(object sender, EventArgs e)
        {
            var response = service.HaberGüncelle(Convert.ToInt32(textBox1.Tag), textBox1.Text, richTextBox2.Text);
            HaberListesiFlowPanel.Controls.Clear();
            HaberListele_Function();
            MessageBox.Show(response);
        }

        //Flow habere tıklama işlemi
        public void Haber_click(object sender, EventArgs e)
        {
            FlowLayoutPanel haber_paneli = sender as FlowLayoutPanel;
            string haber_id = haber_paneli.Tag.ToString();
            foreach (var item in Response_Haber)
            {
                if (Convert.ToInt32(item.Haber_Id) == Convert.ToInt32(haber_id))
                {
                    textBox1.Text = item.Haber_Baslik.ToString();
                    richTextBox2.Text = item.Haber_Icerik.ToString();
                    textBox1.Tag = item.Haber_Id;
                }
            }

        }
        //-------------------------------------------------------------HABERLER ^^^^^^^^^^^^^^^^^^
        #endregion


        public void Yorum_Listele()
        {
           
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.BackColor = Color.FromArgb(39, 60, 117);
                flp.Size = new System.Drawing.Size(280, 130);
                flp.Padding = new Padding(10);
                flp.AutoScroll = true;
                flp.FlowDirection = FlowDirection.TopDown;
                

                Font header = new Font("Rajdhani", 14, FontStyle.Bold);
                Label lblheader = new Label();
                //lblheader.Top = 15;
                lblheader.AutoSize = true;
                lblheader.AutoEllipsis = true;
                lblheader.UseCompatibleTextRendering = true;
                
                lblheader.ForeColor = Color.White;
                lblheader.Font = header;

                Font txt = new Font("Rajdhani", 14);
                Label lbltxt = new Label();
                lbltxt.AutoSize = true;
                lbltxt.AutoEllipsis = true;
                lbltxt.UseCompatibleTextRendering = true;
                //lbltxt.Top = 40;
                lbltxt.Text = "Yorum Yapan Kişi";
                lbltxt.ForeColor = Color.FromArgb(46, 204, 113);
                lbltxt.Font = txt;
               

                Font date = new Font("Rajdhani", 10);
                Label lbldate = new Label();
                //lbldate.Top = 80;
                lbldate.AutoSize = true;
                lbldate.AutoEllipsis = true;
                lbldate.UseCompatibleTextRendering = true;
              
                lbldate.ForeColor = Color.FromArgb(251, 197, 49);
                lbldate.Font = date;

                flp.Controls.Add(lblheader);
                flp.Controls.Add(lbldate);
                flp.Controls.Add(lbltxt);
                flp.Click += new EventHandler(this.Yorum_Click);
                this.Controls.Add(flp);
                flowLayoutPanel1.Controls.Add(flp);
                
                
            
        }
        public void Yorum_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel yorum_alanı = sender as FlowLayoutPanel;
            MessageBox.Show(yorum_alanı.Tag.ToString()+"\n"+yorum_alanı.Name.ToString()+"\n");
        }

       
       

       

      


    }
}
