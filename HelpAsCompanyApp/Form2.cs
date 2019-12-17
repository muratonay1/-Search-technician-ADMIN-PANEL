﻿using System;
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
        public dynamic Response_Alan_Usta;
        public dynamic Response_AltAlan_Usta;
        public dynamic Response_Sehirler_Usta;
        public dynamic Response_Ilceler_Usta;
        public dynamic Response_String_Result;
        //UstaListeleme Degiskenleri
        public dynamic Response_Usta_Listele;
        public int alanId;
        public int altalanId;
        public int sehirId;
        public int ilceId;



        public int denemeint;

        public int _alanId;
        public int _altalanId;
        public int _sehirId;
        public int _ilceId;
        public string sehir_ismi;
        public string ilce_ismi;
        public string alan_ismi;
        public string altalan_ismi;
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
            //Yorum_Listele();
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
            Alan_Listele_Usta_Function();
            Sehir_Listele_Usta_Function();
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
        private void button7_Click(object sender, EventArgs e)//Kullanıcılar buton click
        {
            kullanıcılar_panel.BringToFront();
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
        //NAVBAR SEKME RESİMLERİ İÇİN TASARIMSAL EVENTLER
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


        #region Ustalar

            //comboBox'tan alan seçimi yapoıldığında otomatik alt alan combosunu kendi alt alanlarıyla doldurması
        private void comboBox_Usta_Alan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aln = comboBox_Usta_Alan.SelectedItem.ToString();

            //aln[0] yani alanın string olarak gelen id değerini public tanımladığımız değişken tipine benzetiyoruz.
            Int32.TryParse(aln[0].ToString(), out alanId);            
            comboBox_AltAlan_Usta.Items.Clear();
            comboBox_AltAlan_Usta.Text = "";
            //1- Ev Aletleri Örneğini verelim= 1,-, , simgelerini kaldırıp 3. indexten sonrasını yazdırıyoruz.
            //Çünkü Servisten alt alanları isteyebilmek için sadece db'deki alan ismini yazmamız gerekli.            
            string alan_secimi = comboBox_Usta_Alan.SelectedItem.ToString().Substring(3);
            //MessageBox.Show(alan_secimi);
            var response = service.AltAlanListesi(alan_secimi);
            if (response == null || response == "")
            {
                comboBox_AltAlan_Usta.Items.Clear();
                comboBox_AltAlan_Usta.Items.Add("0");               

            }
            else
            {
                Response_AltAlan_Usta = JsonConvert.DeserializeObject(response);
                int altalan_id;
                string altalan_adi;
                string altalan_alan_id;
                foreach (var item in Response_AltAlan_Usta)
                {
                    altalan_id = item.Dal_Id;
                    altalan_adi = item.Dal_Isim;
                    altalan_alan_id = item.Alan_Isim;
                    comboBox_AltAlan_Usta.Items.Add(altalan_id + "- " + altalan_adi);

                }
            }
        }
        //usta ekleme/arama/güncelleme combo box eventi
        private void comboBox_Alanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aln = comboBox_Alanlar.SelectedItem.ToString();

            //aln[0] yani alanın string olarak gelen id değerini public tanımladığımız değişken tipine benzetiyoruz.
            Int32.TryParse(aln[0].ToString(), out alanId);
            comboBox_Brans.Items.Clear();
            comboBox_Brans.Text = "";
            //1- Ev Aletleri Örneğini verelim= 1,-, , simgelerini kaldırıp 3. indexten sonrasını yazdırıyoruz.
            //Çünkü Servisten alt alanları isteyebilmek için sadece db'deki alan ismini yazmamız gerekli.            
            string alan_secimi = comboBox_Alanlar.SelectedItem.ToString().Substring(3);
            //MessageBox.Show(alan_secimi);
            var response = service.AltAlanListesi(alan_secimi);
            if (response == null || response == "")
            {
                comboBox_Brans.Items.Clear();

            }
            else
            {
                Response_AltAlan_Usta = JsonConvert.DeserializeObject(response);
                int altalan_id;
                string altalan_adi;
                string altalan_alan_id;
                foreach (var item in Response_AltAlan_Usta)
                {
                    altalan_id = item.Dal_Id;
                    altalan_adi = item.Dal_Isim;
                    altalan_alan_id = item.Alan_Isim;
                    comboBox_Brans.Items.Add(altalan_id + "- " + altalan_adi);

                }
            }
        }
        //Ustalar alanların comboBox'a gömülmesi
        public void Alan_Listele_Usta_Function()
        {
            var response = service.AlanListesi();
            Response_Alan_Usta = JsonConvert.DeserializeObject(response);
            int alan_id;
            string alan_adi;
            foreach (var item in Response_Alan_Usta)
            {
                alan_id = item.Alan_Id;
                alan_adi = item.Alan_Isim;
                comboBox_Usta_Alan.Items.Add(alan_id+"- "+alan_adi);
                comboBox_Alanlar.Items.Add(alan_id + "- " + alan_adi);
            }
        }       
        //Ustalar şehirleri comboBox'a gömme
        public void Sehir_Listele_Usta_Function()
        {
            var response = service.SehirListesi();
            Response_Sehirler_Usta = JsonConvert.DeserializeObject(response);
            int sehir_id;
            string sehir_name;
            foreach (var item in Response_Sehirler_Usta)
            {
                sehir_id = item.Id;
                sehir_name = item.Name;
                comboBox_Sehirler_Usta.Items.Add(sehir_id+"- "+sehir_name);
                comboBox_Sehirler.Items.Add(sehir_id + "- " + sehir_name);
            }
        }
        //şehir comboBox seçilince otomatik şehrin ilçelerinin getirilmesi
        private void comboBox_Sehirler_Usta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shr = comboBox_Sehirler_Usta.SelectedItem.ToString().Split('-').First();            
            Int32.TryParse(shr.ToString(), out sehirId);
            comboBox_Ilceler_Usta.Items.Clear();
            comboBox_Ilceler_Usta.Text = "";
            string sehir_secimi = comboBox_Sehirler_Usta.SelectedItem.ToString().Substring(3);
            
            
            var response = service.IlceListesi(sehir_secimi.Trim());         
            Response_Ilceler_Usta = JsonConvert.DeserializeObject(response);
            int ilce_no;
            string isim;
            foreach (var item in Response_Ilceler_Usta)
            {
                ilce_no = item.ilce_no;
                isim = item.isim;
                comboBox_Ilceler_Usta.Items.Add(ilce_no+"- "+isim);
            }
        }
        private void comboBox_Sehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shr = comboBox_Sehirler.SelectedItem.ToString().Split('-').First();
            Int32.TryParse(shr.ToString(), out sehirId);
            comboBox_Ilceler.Items.Clear();
            comboBox_Ilceler.Text = "";
            string sehir_secimi = comboBox_Sehirler.SelectedItem.ToString().Substring(3);


            var response = service.IlceListesi(sehir_secimi.Trim());
            Response_Ilceler_Usta = JsonConvert.DeserializeObject(response);
            int ilce_no;
            string isim;
            foreach (var item in Response_Ilceler_Usta)
            {
                ilce_no = item.ilce_no;
                isim = item.isim;
                comboBox_Ilceler.Items.Add(ilce_no + "- " + isim);
            }
        }
        //USTA BULMA BUTONU
        private void button12_Click_1(object sender, EventArgs e)
        {
            //AlanId parse
            flowpanel_USTA_MAIN.Controls.Clear();
            button_UstaEkle.Enabled = true;
            button_UstaKaydet.Enabled = true;
            button_UstaSil.Enabled = true;
            textBox_isim.Clear();
            textBox_soyisim.Clear();
            comboBox_Alanlar.Text = "";
            comboBox_Brans.Text="";
            comboBox_Sehirler.Text="";
            comboBox_Ilceler.Text = "";
            textBox_telefon.Clear();
            textBox_mail.Clear();
            textBox_puan.Clear();
            textBox_musaitlik.Clear();
            if (comboBox_AltAlan_Usta.Text=="0")
            {               
                
                    string altaln = "0";
                    Int32.TryParse(altaln.ToString(), out altalanId);
                    //IlceId parse
                    string ilcem = comboBox_Ilceler_Usta.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(ilcem.ToString(), out ilceId);
                    var response = service.Usta_Listele(alanId, altalanId, sehirId, ilceId);
                    Response_Usta_Listele = JsonConvert.DeserializeObject(response);
                    int Usta_Id;
                    string _Alan_Ismi;
                    string _Sehir_Ismi;
                    string _Ilce_Ismi;
                    string Usta_Isim;
                    string Usta_SoyIsim;
                    string Usta_Telefon;
                    string Usta_Email;
                    float Usta_Puan;
                    int Usta_Musaitlik;
                    string _AltAlan_Ismi;
                    foreach (var item in Response_Usta_Listele)
                    {
                        Usta_Id = item.Usta_Id;
                        _Alan_Ismi = Alan__Ismi(Convert.ToInt32(item.Alan_Id));
                        _Sehir_Ismi = Sehir_Ismi(Convert.ToInt32(item.Sehir_Id));
                        _Ilce_Ismi = Ilce_Ismi(Convert.ToInt32(item.Ilce_Id));
                        Usta_Isim = item.Usta_Isim;
                        Usta_SoyIsim = item.Usta_SoyIsim;
                        Usta_Email = item.Usta_Email;
                        Usta_Telefon = item.Usta_Telefon;
                        Usta_Puan = item.Usta_Puan;
                        Usta_Musaitlik = item.Usta_Musaitlik;
                        _AltAlan_Ismi = "0";
                        Usta_Listele_for_FlowPanel(Usta_Id, _Alan_Ismi, _Sehir_Ismi, _Ilce_Ismi, Usta_Isim, Usta_SoyIsim, Usta_Telefon, Usta_Email, Usta_Puan, Usta_Musaitlik, _AltAlan_Ismi);
                    }
                             
            }
            else
            {
                try
                {
                    var response = service.Usta_Listele(alanId, altalanId, sehirId, ilceId);
                    string altaln = comboBox_AltAlan_Usta.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(altaln.ToString(), out altalanId);
                    //IlceId parse
                    string ilcem = comboBox_Ilceler_Usta.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(ilcem.ToString(), out ilceId);
                    response = service.Usta_Listele(alanId, altalanId, sehirId, ilceId);
                    Response_Usta_Listele = JsonConvert.DeserializeObject(response);
                    int Usta_Id;
                    string _Alan_Ismi;
                    string _Sehir_Ismi;
                    string _Ilce_Ismi;
                    string Usta_Isim;
                    string Usta_SoyIsim;
                    string Usta_Telefon;
                    string Usta_Email;
                    float Usta_Puan;
                    int Usta_Musaitlik;
                    string _AltAlan_Ismi;
                    foreach (var item in Response_Usta_Listele)
                    {
                        Usta_Id = item.Usta_Id;
                        _Alan_Ismi = Alan__Ismi(Convert.ToInt32(item.Alan_Id));
                        _Sehir_Ismi = Sehir_Ismi(Convert.ToInt32(item.Sehir_Id));
                        _Ilce_Ismi = Ilce_Ismi(Convert.ToInt32(item.Ilce_Id));
                        Usta_Isim = item.Usta_Isim;
                        Usta_SoyIsim = item.Usta_SoyIsim;
                        Usta_Email = item.Usta_Email;
                        Usta_Telefon = item.Usta_Telefon;
                        Usta_Puan = item.Usta_Puan;
                        Usta_Musaitlik = item.Usta_Musaitlik;
                        Int32.TryParse(item.AltAlan_Id.ToString(), out denemeint);
                        _AltAlan_Ismi = AltAlan__Ismi(denemeint);
                        Usta_Listele_for_FlowPanel(Usta_Id, _Alan_Ismi, _Sehir_Ismi, _Ilce_Ismi, Usta_Isim, Usta_SoyIsim, Usta_Telefon, Usta_Email, Usta_Puan, Usta_Musaitlik, _AltAlan_Ismi);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Bu kriterlerde usta bulunmamaktadır.");
                }           
            }           
        }       
        //BURALARI GÖRMEZDEN GELELİM FACİA :)
        //TEK BİR SEHİR İSMİ VS ÇEKMEK İÇİN SERVİS YAZDIM ve fonk isimlerini çekmek için :)
        public dynamic Sehir_Ismi(int sehir_id)
        {            
            dynamic cevap;
            var response = service.SehirIsmiDonder(sehir_id);
            cevap = JsonConvert.DeserializeObject(response);
            foreach (var item in cevap)
            {
                sehir_ismi = item.Name;
             
            }
            return sehir_ismi;
        }
        public dynamic Ilce_Ismi(int ilce_id)
        {
            dynamic cevap;
            var response = service.IlceIsmiDonder(ilce_id);
            cevap = JsonConvert.DeserializeObject(response);
            foreach (var item in cevap)
            {
                ilce_ismi = item.isim;

            }
            return ilce_ismi;
        }
        public dynamic Alan__Ismi(int alan_id)
        {
            dynamic cevap;
            var response = service.AlanIsmiDonder(alan_id);
            cevap = JsonConvert.DeserializeObject(response);
            foreach (var item in cevap)
            {
                alan_ismi = item.Alan_Isim;
            }
            return alan_ismi;
        }
        public dynamic AltAlan__Ismi(int altalan_id)
        {
            dynamic cevap;
            var response = service.AltAlanIsmiDonder(altalan_id);
            cevap = JsonConvert.DeserializeObject(response);
            foreach (var item in cevap)
            {
                altalan_ismi = item.Dal_Isim;
            }
            return altalan_ismi;
        }
        public void Usta_Listele_for_FlowPanel(int usta_id, string alan_ismi,string sehir_ismi, string ilce_ismi,string usta_ismi,string usta_soyad,string usta_tel,string usta_mail,float usta_puan,int usta_müs,string alt_isim)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.FromArgb(39, 60, 117);
            flp.Size = new System.Drawing.Size(410, 217);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = usta_id;
            //click eventi ekle
            flp.Click += new EventHandler(this.Usta_click);
            //USTA İSİM
            Font usta_isim_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_ustaisim = new Label();
            label_ustaisim.AutoSize = true;
            label_ustaisim.AutoEllipsis = true;
            label_ustaisim.UseCompatibleTextRendering = true;
            label_ustaisim.Text = "Usta İsmi:  "+usta_ismi;
            label_ustaisim.ForeColor = Color.Gold;
            label_ustaisim.Font = usta_isim_font;
            label_ustaisim.Padding = new Padding(5);


            //USTA SOYİSİM
            Font usta_soyad_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_soyad = new Label();
            label_usta_soyad.AutoSize = true;
            label_usta_soyad.AutoEllipsis = true;
            label_usta_soyad.UseCompatibleTextRendering = true;
            label_usta_soyad.Text = "Soyadı:  "+usta_soyad;
            label_usta_soyad.ForeColor = Color.Gold;
            label_usta_soyad.Font = usta_soyad_font;
            label_usta_soyad.Padding = new Padding(5);



            //USTA ŞEHİR
            Font usta_sehir_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_sehir = new Label();
            label_usta_sehir.AutoSize = true;
            label_usta_sehir.AutoEllipsis = true;
            label_usta_sehir.UseCompatibleTextRendering = true;
            label_usta_sehir.Text = "Şehir:  "+sehir_ismi;
            label_usta_sehir.ForeColor = Color.Gold;
            label_usta_sehir.Font = usta_sehir_font;
            label_usta_sehir.Padding = new Padding(5);



            //USTA İLÇE
            Font usta_ilce_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_ilce = new Label();
            label_usta_ilce.AutoSize = true;
            label_usta_ilce.AutoEllipsis = true;
            label_usta_ilce.UseCompatibleTextRendering = true;
            label_usta_ilce.Text = "İlçe:  "+ilce_ismi;
            label_usta_ilce.ForeColor = Color.Gold;
            label_usta_ilce.Font = usta_ilce_font;
            label_usta_ilce.Padding = new Padding(5);



            //USTA ALAN
            Font usta_alan_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_alan = new Label();
            label_usta_alan.AutoSize = true;
            label_usta_alan.AutoEllipsis = true;
            label_usta_alan.UseCompatibleTextRendering = true;
            label_usta_alan.Text = "Alanı:  "+alan_ismi;
            label_usta_alan.ForeColor = Color.Gold;
            label_usta_alan.Font = usta_alan_font;
            label_usta_alan.Padding = new Padding(5);


            //USTA ALT ALAN
            Font usta_altalan_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_altalan = new Label();
            label_usta_altalan.AutoSize = true;
            label_usta_altalan.AutoEllipsis = true;
            label_usta_altalan.UseCompatibleTextRendering = true;
            label_usta_altalan.Text = "Branşı:  "+altalan_ismi;
            label_usta_altalan.ForeColor = Color.Gold;
            label_usta_altalan.Font = usta_altalan_font;
            label_usta_altalan.Padding = new Padding(5);



            //USTA TELEFON
            Font usta_tel_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_tel = new Label();
            label_usta_tel.AutoSize = true;
            label_usta_tel.AutoEllipsis = true;
            label_usta_tel.UseCompatibleTextRendering = true;
            label_usta_tel.Text = "Telefon:  "+usta_tel;
            label_usta_tel.ForeColor = Color.Gold;
            label_usta_tel.Font = usta_tel_font;
            label_usta_tel.Padding = new Padding(5);


            //USTA MAİL
            Font usta_mail_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_mail = new Label();
            label_usta_mail.AutoSize = true;
            label_usta_mail.AutoEllipsis = true;
            label_usta_mail.UseCompatibleTextRendering = true;
            label_usta_mail.Text = "    E-mail:  "+usta_mail;
            label_usta_mail.ForeColor = Color.Gold;
            label_usta_mail.Font = usta_mail_font;
            label_usta_mail.Padding = new Padding(5);


            //USTA PUAN
            Font usta_puan_font = new Font("Rajdhani", 8, FontStyle.Bold);
            Label label_usta_puan = new Label();
            label_usta_puan.AutoSize = true;
            label_usta_puan.AutoEllipsis = true;
            label_usta_puan.UseCompatibleTextRendering = true;
            label_usta_puan.Text = "    Puanı:  "+usta_puan.ToString();
            label_usta_puan.ForeColor = Color.Gold;
            label_usta_puan.Font = usta_puan_font;
            label_usta_puan.Padding = new Padding(5);

            //USTA MUSAIT
            Font usta_musait_font = new Font("Rajdhani", 9, FontStyle.Bold);
            Label label_ustamusait = new Label();
            if (usta_müs==0)
            {
                
                label_ustamusait.AutoSize = true;
                label_ustamusait.AutoEllipsis = true;
                label_ustamusait.UseCompatibleTextRendering = true;
                label_ustamusait.Text = "   Durumu:  " + usta_müs.ToString()+" MEŞGUL";
                label_ustamusait.ForeColor = Color.Red;
                label_ustamusait.Font = usta_musait_font;
                label_ustamusait.Padding = new Padding(5);
            }
            else if(usta_müs==1)
            {
                
                label_ustamusait.AutoSize = true;
                label_ustamusait.AutoEllipsis = true;
                label_ustamusait.UseCompatibleTextRendering = true;
                label_ustamusait.Text = "   Durumu:  " + usta_müs.ToString()+" MUSAIT";
                label_ustamusait.ForeColor = Color.Green;
                label_ustamusait.Font = usta_musait_font;
                label_ustamusait.Padding = new Padding(5);
            }            
            flp.Controls.Add(label_ustaisim);
            flp.Controls.Add(label_usta_soyad);
            flp.Controls.Add(label_usta_sehir);
            flp.Controls.Add(label_usta_ilce);
            flp.Controls.Add(label_usta_alan);
            flp.Controls.Add(label_usta_altalan);
            flp.Controls.Add(label_usta_tel);
            flp.Controls.Add(label_usta_mail);
            flp.Controls.Add(label_usta_puan);
            flp.Controls.Add(label_ustamusait);
            flowpanel_USTA_MAIN.Controls.Add(flp);
        }
        //Flow habere tıklama işlemi
        public void Usta_click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
            FlowLayoutPanel usta_paneli = sender as FlowLayoutPanel;
            string _usta_id = usta_paneli.Tag.ToString();
            foreach (var item in Response_Usta_Listele)
            {
                if (Convert.ToInt32(item.Usta_Id) == Convert.ToInt32(_usta_id))
                {
                    if(item.Usta_Musaitlik == 0)
                    {
                        button_UstaEkle.Enabled = false;
                        button_UstaKaydet.Enabled = false;
                        button_UstaSil.Enabled = false;
                        textBox_isim.Text = item.Usta_Isim;
                        textBox_soyisim.Text = item.Usta_SoyIsim;
                        comboBox_Alanlar.Text = Alan__Ismi(Convert.ToInt32(item.Alan_Id));
                        comboBox_Brans.Text = item.AltAlan_Id;
                        comboBox_Sehirler.Text = Sehir_Ismi(Convert.ToInt32(item.Sehir_Id));
                        comboBox_Ilceler.Text = Ilce_Ismi(Convert.ToInt32(item.Ilce_Id));
                        textBox_telefon.Text = item.Usta_Telefon;
                        textBox_mail.Text = item.Usta_Email;
                        textBox_puan.Text = item.Usta_Puan;
                        textBox_musaitlik.Text = item.Usta_Musaitlik;
                        MessageBox.Show("Usta şuan msait olmadığı için bilgileri değiştiremezsiniz.");
                    }
                    else
                    {
                        button_UstaEkle.Enabled = true;
                        button_UstaKaydet.Enabled = true;
                        button_UstaSil.Enabled = true;
                        textBox_isim.Text = item.Usta_Isim;
                        textBox_soyisim.Text = item.Usta_SoyIsim;
                        comboBox_Alanlar.Text = Alan__Ismi(Convert.ToInt32(item.Alan_Id));
                        comboBox_Brans.Text = item.AltAlan_Id;
                        comboBox_Sehirler.Text = Sehir_Ismi(Convert.ToInt32(item.Sehir_Id));
                        comboBox_Ilceler.Text = Ilce_Ismi(Convert.ToInt32(item.Ilce_Id));
                        textBox_telefon.Text = item.Usta_Telefon;
                        textBox_mail.Text = item.Usta_Email;
                        textBox_puan.Text = item.Usta_Puan;
                        textBox_musaitlik.Text = item.Usta_Musaitlik;
                    }                    
                }
            }
        }

        private void button_UstaTemizle_Click(object sender, EventArgs e)
        {
            button_UstaEkle.Enabled = true;
            button_UstaKaydet.Enabled = true;
            button_UstaSil.Enabled = true;
            textBox_isim.Clear();
            textBox_soyisim.Clear();
            comboBox_Alanlar.Text = "";
            comboBox_Brans.Text = "";
            comboBox_Sehirler.Text = "";
            comboBox_Ilceler.Text = "";
            textBox_telefon.Clear();
            textBox_mail.Clear();
            textBox_puan.Clear();
            textBox_musaitlik.Clear();
        }

        private void button_UstaEkle_Click(object sender, EventArgs e)
        {
            button_UstaEkle.Enabled = true;
            button_UstaKaydet.Enabled = true;
            button_UstaSil.Enabled = true;
            textBox_isim.Clear();
            textBox_soyisim.Clear();
            comboBox_Alanlar.Text = "";
            comboBox_Brans.Text = "";
            comboBox_Sehirler.Text = "";
            comboBox_Ilceler.Text = "";
            textBox_telefon.Clear();
            textBox_mail.Clear();
            textBox_puan.Clear();
            textBox_musaitlik.Clear();
            groupBox9.Visible = true;
            button_UstaEkle.Enabled = false;
            //başlangıç puanı 0 ve müsait olarak ayarlandı.
            textBox_puan.Text = "0";
            textBox_musaitlik.Text = "1";
            textBox_puan.Enabled = false;
            textBox_musaitlik.Enabled = false;
        }

        private void button_iptal_Click(object sender, EventArgs e)
        {
            DialogResult ds;
            ds = MessageBox.Show("İptali onaylıyor musunuz?", "Kayıt İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (ds == DialogResult.Yes)
            {
                textBox_puan.Clear();
                textBox_musaitlik.Clear();
                textBox_puan.Enabled = true;
                textBox_musaitlik.Enabled = true;
                button_UstaEkle.Enabled = true;
                groupBox9.Visible = false;
            }

        }

        private void button_tamamla_Click(object sender, EventArgs e)
        {
            if (
                textBox_isim.Text == "" ||
                textBox_soyisim.Text == "" ||
                textBox_telefon.Text == "" ||
                comboBox_Alanlar.Text == "" ||
                comboBox_Ilceler.Text == "" ||
                comboBox_Sehirler.Text == ""
                )
            {
                MessageBox.Show("Boş alanlar mevcut, boş alanları doldurduğunuza emin olun.");
            }

            else
            {
                int i;
                for (i = 0; i < comboBox_Brans.Items.Count; i++)
                {
                    //comboBox'ta item varmı yokmu kontrolü altalan (televinyon tamirinde yok, eklerken çıkan problemi ortadan kaldırmak için sayıyı bilmeliyiz.)
                }
                if (i == 0)
                {
                    string shr = comboBox_Sehirler.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(shr.ToString(), out _sehirId);

                    string ilc = comboBox_Ilceler.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(ilc.ToString(), out _ilceId);

                    string aln_id = comboBox_Alanlar.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(aln_id.ToString(), out _alanId);
                    int puan;
                    int musait;

                    int _altalan_id = 0;
                    Int32.TryParse(textBox_puan.Text, out puan);

                    Int32.TryParse(textBox_musaitlik.Text, out musait);
                   
                    var response = service.Usta_Ekle(
                        _alanId,
                        _sehirId,
                        _ilceId,
                        textBox_isim.Text,
                        textBox_soyisim.Text,
                        textBox_telefon.Text,
                        textBox_mail.Text,
                        puan,
                        musait,
                        _altalan_id
                        );
                   
                    MessageBox.Show(response);
                    if(response=="ok")
                    {
                        groupBox9.Visible = false;
                        button_UstaEkle.Enabled = true;
                        button_UstaSil.Enabled = true;
                        button_UstaKaydet.Enabled = true;
                    }                    
                   
                }
                else if (i != 0)
                {
                    string shr = comboBox_Sehirler.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(shr.ToString(), out _sehirId);

                    string ilc = comboBox_Ilceler.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(ilc.ToString(), out _ilceId);

                    string aln_id = comboBox_Alanlar.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(aln_id.ToString(), out _alanId);
                    int puan;
                    int musait;
                 
                    Int32.TryParse(textBox_puan.Text, out puan);

                    Int32.TryParse(textBox_musaitlik.Text, out musait);
                    
                    string _altalan_id = comboBox_Brans.SelectedItem.ToString().Split('-').First();
                    Int32.TryParse(_altalan_id.ToString(), out _altalanId);
                    
                    var response = service.Usta_Ekle(
                        _alanId,
                        _sehirId,
                        _ilceId,
                        textBox_isim.Text,
                        textBox_soyisim.Text,
                        textBox_telefon.Text,
                        textBox_mail.Text,
                        puan,
                        musait,
                        _altalanId
                        );

                    MessageBox.Show(response);
                    if (response == "ok")
                    {
                        groupBox9.Visible = false;
                        button_UstaEkle.Enabled = true;
                        button_UstaSil.Enabled = true;
                        button_UstaKaydet.Enabled = true;
                    }

                }
            }
        }
        #endregion


    }
}
