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
        public dynamic Response_Alan_Usta;
        public dynamic Response_AltAlan_Usta;
        public dynamic Response_Sehirler_Usta;
        public dynamic Response_Ilceler_Usta;
        public dynamic Response_String_Result;
        public dynamic Response_Geri_Bildirimler;
        public dynamic Response_Uyeler;
        public dynamic Response_Engelli_Uyeler;
        public dynamic Response_BekleyenIstek_Listele;
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
            TümUstaları_Getir_Function();
            lbl_Panel_Ismi.Text = "YORUMLAR";
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
            groupBox7.Size = new Size(1125, 646);
            //MENU PANEL GROUPBOX LOCATION
            groupBox1.Location = new Point(0, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox3.Location = new Point(0, 0);
            groupBox4.Location = new Point(0, 0);
            groupBox5.Location = new Point(0, 0);
            groupBox6.Location = new Point(0, 0);
            groupBox7.Location = new Point(0, 0);
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
            Gorsellik_Usta_Yorumları_Gizle_Goster(false);
            Gorsellik_Usta_Yorumlar_Ayrıntı_Gizle_Goster(false);
            lbl_Panel_Ismi.Text = "YORUMLAR";
            yorumlar_panel.BringToFront();
            flowLayoutPanel_YorumYapılan_Ustalar.Controls.Clear();
            TümUstaları_Getir_Function();
            //Yorum_Listele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "ISTEKLER";
            istekler_panel.BringToFront();
        }//İSTEKLER NAVBAR BUTTON CLICK
        private void button3_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "HABERLER";
            HaberListesiFlowPanel.Controls.Clear();
            HaberListele_Function();
            haberler_panel.BringToFront();
        }//Haberler NAVBAR BUTTON CLICK
        private void button4_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "USTALAR";
            //panele her girişte şehir,ilçe,alan,branş sıfırlama
            comboBox_Usta_Alan.Items.Clear();
            comboBox_AltAlan_Usta.Items.Clear();
            comboBox_Sehirler_Usta.Items.Clear();
            comboBox_Ilceler_Usta.Items.Clear();
            comboBox_Alanlar.Items.Clear();
            comboBox_Sehirler.Items.Clear();
            comboBox_Brans.Items.Clear();
            comboBox_Ilceler.Items.Clear();
            ustalar_panel.BringToFront();
            Alan_Listele_Usta_Function();
            Sehir_Listele_Usta_Function();
        }//Ustalar NAVBAR BUTTON CLICK
        private void button5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            lbl_Panel_Ismi.Text = "ALANLAR";
            alanlar_panel.BringToFront();
            AlanListele_Function();
        }//Alanlar navbar button CLICK
        private void button6_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "GERI BILDIRIMLER";
            flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Clear();
            geri_bildirimler_panel.BringToFront();
            Geri_Bildirim_Request();
            label_gb_sayisi.Text = flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Count.ToString();
        }//GERİ BİLDİRİM NAVBAR BUTTON CLICK
        private void button7_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "KULLANICILAR";
            kullanıcılar_panel.BringToFront();
        }//KULLANICILAR BUTON CLICK
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Gorsellik_Usta_Yorumları_Gizle_Goster(false);
            Gorsellik_Usta_Yorumlar_Ayrıntı_Gizle_Goster(false);
            lbl_Panel_Ismi.Text = "YORUMLAR";           
            flowLayoutPanel_YorumYapılan_Ustalar.Controls.Clear();
            TümUstaları_Getir_Function();
            yorumlar_panel.BringToFront();
        }//YORUMLAR NAVBAR İCON CLICK
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            istekler_panel.BringToFront();
        }//İSTEKLER NAVBAR İCON CLICK
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "HABERLER";
            HaberListesiFlowPanel.Controls.Clear();
            HaberListele_Function();
            haberler_panel.BringToFront();
        }//HABERLER NAVBAR İCON CLICK
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "USTALAR";
            //panele her girişte şehir,ilçe,alan,branş sıfırlama
            comboBox_Usta_Alan.Items.Clear();
            comboBox_AltAlan_Usta.Items.Clear();
            comboBox_Sehirler_Usta.Items.Clear();
            comboBox_Ilceler_Usta.Items.Clear();
            comboBox_Alanlar.Items.Clear();
            comboBox_Sehirler.Items.Clear();
            comboBox_Brans.Items.Clear();
            comboBox_Ilceler.Items.Clear();
            ustalar_panel.BringToFront();
            Alan_Listele_Usta_Function();
            Sehir_Listele_Usta_Function();
        }//USTALAR NAVBAR İCON CLICK
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            lbl_Panel_Ismi.Text = "ALANLAR";
            alanlar_panel.BringToFront();
            AlanListele_Function();
        }//ALANLAR NAVBAR İCON CLICK
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "GERI BILDIRIMLER";
            flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Clear();
            geri_bildirimler_panel.BringToFront();
            Geri_Bildirim_Request();
            label_gb_sayisi.Text = flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Count.ToString();
        }//GERİ BİLDİRİMLER NAVBAR İCON CLICK
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            lbl_Panel_Ismi.Text = "KULLANICILAR";
            kullanıcılar_panel.BringToFront();
        }//KULLANICILAR NAVBAR ICON
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
            try
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
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı bir hata", "HELPAS");
            }           
        }
        //Alanlara tıklayınca alt alan yordamını çağırma
        public void Alan_click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("hata");
            }
            
        }    
        //alt alanların alanlardan gelen alan ismiyle service requesti yapması
        public void AltAlanListele_Function(string Request_AlanAdi)
        {
            try
            {
                var response = service.AltAlanListesi(Request_AlanAdi.ToString());
                if (response == null || response == "")
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
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
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
            try
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
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
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
                try
                {
                    var response = service.HaberEkle(textBox1.Text, richTextBox2.Text);
                    HaberListesiFlowPanel.Controls.Clear();
                    HaberListele_Function();
                    MessageBox.Show(response);
                }
                catch
                {
                    MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
                }
                
            }
        }
        //Haber Silme butonu
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                var response = service.HaberSil(Convert.ToInt32(textBox1.Tag));
                HaberListesiFlowPanel.Controls.Clear();
                HaberListele_Function();
                MessageBox.Show(response);
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
            }
        }
        //Haber Güncelleme butonu
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var response = service.HaberGüncelle(Convert.ToInt32(textBox1.Tag), textBox1.Text, richTextBox2.Text);
                HaberListesiFlowPanel.Controls.Clear();
                HaberListele_Function();
                MessageBox.Show(response);
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
            }
        }
        //Flow habere tıklama işlemi
        public void Haber_click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Hata Oluştu", "HELPAS");
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
                try
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
                catch
                {
                    MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
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
            try
            {
                var response = service.AlanListesi();
                Response_Alan_Usta = JsonConvert.DeserializeObject(response);
                int alan_id;
                string alan_adi;
                foreach (var item in Response_Alan_Usta)
                {
                    alan_id = item.Alan_Id;
                    alan_adi = item.Alan_Isim;
                    comboBox_Usta_Alan.Items.Add(alan_id + "- " + alan_adi);
                    comboBox_Alanlar.Items.Add(alan_id + "- " + alan_adi);
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı bir hata", "HELPAS");
            }
            
        }       
        //Ustalar şehirleri comboBox'a gömme
        public void Sehir_Listele_Usta_Function()
        {
            try
            {
                var response = service.SehirListesi();
                Response_Sehirler_Usta = JsonConvert.DeserializeObject(response);
                int sehir_id;
                string sehir_name;
                foreach (var item in Response_Sehirler_Usta)
                {
                    sehir_id = item.Id;
                    sehir_name = item.Name;
                    comboBox_Sehirler_Usta.Items.Add(sehir_id + "- " + sehir_name);
                    comboBox_Sehirler.Items.Add(sehir_id + "- " + sehir_name);
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
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
            try
            {
                var response = service.IlceListesi(sehir_secimi.Trim());
                Response_Ilceler_Usta = JsonConvert.DeserializeObject(response);
                int ilce_no;
                string isim;
                foreach (var item in Response_Ilceler_Usta)
                {
                    ilce_no = item.ilce_no;
                    isim = item.isim;
                    comboBox_Ilceler_Usta.Items.Add(ilce_no + "- " + isim);
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis hatası", "HELPAS");
            }         
        }
        private void comboBox_Sehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shr = comboBox_Sehirler.SelectedItem.ToString().Split('-').First();
            Int32.TryParse(shr.ToString(), out sehirId);
            comboBox_Ilceler.Items.Clear();
            comboBox_Ilceler.Text = "";
            string sehir_secimi = comboBox_Sehirler.SelectedItem.ToString().Substring(3);
            try
            {
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
            catch
            {
                MessageBox.Show("Sunucu yada Servis hatası", "HELPAS");
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
                try
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
                catch
                {
                    MessageBox.Show("Bu koşullarda usta bulunamadı");
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
            try
            {
                dynamic cevap;
                var response = service.SehirIsmiDonder(sehir_id);
                cevap = JsonConvert.DeserializeObject(response);
                foreach (var item in cevap)
                {
                    sehir_ismi = item.Name;
                }                
            }
            catch
            {
                MessageBox.Show("Sunucu yada servis hatası","HELPAS");
            }
            return sehir_ismi;
        }
        public dynamic Ilce_Ismi(int ilce_id)
        {
            try
            {
                dynamic cevap;
                var response = service.IlceIsmiDonder(ilce_id);
                cevap = JsonConvert.DeserializeObject(response);
                foreach (var item in cevap)
                {
                    ilce_ismi = item.isim;
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada servis hatası", "HELPAS");
            }            
            return ilce_ismi;
        }
        public dynamic Alan__Ismi(int alan_id)
        {
            try
            {
                dynamic cevap;
                var response = service.AlanIsmiDonder(alan_id);
                cevap = JsonConvert.DeserializeObject(response);
                foreach (var item in cevap)
                {
                    alan_ismi = item.Alan_Isim;
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada servis hatası", "HELPAS");
            }
            return alan_ismi;
        }
        public dynamic AltAlan__Ismi(int altalan_id)
        {
            try
            {
                dynamic cevap;
                var response = service.AltAlanIsmiDonder(altalan_id);
                cevap = JsonConvert.DeserializeObject(response);
                foreach (var item in cevap)
                {
                    altalan_ismi = item.Dal_Isim;
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada servis hatası", "HELPAS");
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
            try
            {
                foreach (var item in Response_Usta_Listele)
                {
                    if (Convert.ToInt32(item.Usta_Id) == Convert.ToInt32(_usta_id))
                    {
                        if (item.Usta_Musaitlik == 0)
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
                            MessageBox.Show("Usta şuan müsait olmadığı için bilgileri değiştiremezsiniz.");
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
            catch
            {
                MessageBox.Show("Sunucu yada Servisle bağlantı kesildi.", "HELPAS");
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
            button_UstaEkle.Enabled = false;
            button_UstaKaydet.Enabled = false;
            button_UstaSil.Enabled = false;
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
                button_UstaKaydet.Enabled = true;
                button_UstaSil.Enabled = true;
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
                    try
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
                        if (response == "ok")
                        {
                            groupBox9.Visible = false;
                            button_UstaEkle.Enabled = true;
                            button_UstaSil.Enabled = true;
                            button_UstaKaydet.Enabled = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
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
        #region GERİ BİLDİRİMLER
        //GERİ BİLDİRİM SERVİS İSTEĞİ
        public void Geri_Bildirim_Request()
        {
            try
            {
                Geri_Bildirimler G_Bildirimler = new Geri_Bildirimler();
                var response = service.Geri_Bildirim_Listele();
                if (response != null)
                {
                    Response_Geri_Bildirimler = JsonConvert.DeserializeObject(response);
                    int _Bildirim_Id;
                    int _Uye_Id;
                    string _Uye_Adi;
                    string _Uye_Soyadi;
                    string _Tarih;
                    string _Aciklama;
                    foreach (var item in Response_Geri_Bildirimler)
                    {
                        _Bildirim_Id = item.Id_Bildirim;
                        _Uye_Id = item.Id_Uye;
                        _Uye_Adi = item.Uye_Ad;
                        _Uye_Soyadi = item.Uye_Soyad;
                        _Tarih = item.Tarih;
                        _Aciklama = item.Aciklama;
                        flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Add(G_Bildirimler.Geri_Bildirim_FlowLayoutDesign(_Bildirim_Id, _Uye_Id, _Uye_Adi, _Uye_Soyadi, _Tarih, _Aciklama));
                    }
                }
                else if (response == null)
                {
                    MessageBox.Show("Hiç bildirim yok");
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı bir hata", "HELPAS");
            }           
        }
        //GERİ BİLDİRİM MAIN FLOW DA GELEN DYNAMİC FLOWLARI LİSTELİYORUZ 
        public async void listele()
        {
            flowLayoutPanel_Geri_Bildirim_MAIN.Controls.Clear();
            Geri_Bildirim_Request();
        }       
        #endregion
        #region KULLANICILAR
        //Tüm kullanıcılar radiobuttonu, engellenmeyen tüm kullanıcıları listeler
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel_UYELER.Controls.Clear();
            if(radioButton1.Checked==true)
            {
                try
                {
                    var response = service.UYE_LİSTELE();
                    if (response != null)
                    {
                        Response_Uyeler = JsonConvert.DeserializeObject(response);
                        int uye_id;
                        string uye_ad;
                        string uye_soyad;
                        string uye_telefon;
                        string uye_mail;
                        string uye_sehir;
                        string uye_ilce;
                        string uye_sifre;
                        foreach (var item in Response_Uyeler)
                        {
                            uye_id = item.Uye_Id;
                            uye_ad = item.Uye_Ad;
                            uye_soyad = item.Uye_Soyad;
                            uye_telefon = item.Uye_Telefon;
                            uye_mail = item.Uye_Email;
                            uye_sehir = Sehir_Ismi(Convert.ToInt32(item.Uye_Sehir_Id));
                            uye_ilce = Ilce_Ismi(Convert.ToInt32(item.Uye_Ilce_Id));
                            uye_sifre = item.Uye_Sifre;
                            Uye_Listele_FlowPanel(uye_id, uye_ad, uye_soyad, uye_telefon, uye_mail, uye_sehir, uye_ilce, uye_sifre);
                        }
                    }
                    else if (response == null)
                    {
                        MessageBox.Show("Hiç bildirim yok");
                    }
                }
                catch
                {
                    MessageBox.Show("Sunucu yada servis kaynaklı hata", "HELPAS");
                }                
            }
            else
            {
                flowLayoutPanel_UYELER.Controls.Clear();
            }            
        }
        //üyeleri flowpanele yerleştirme
        public void Uye_Listele_FlowPanel(int uye_id, string uye_ad, string uye_soyad, string uye_tel, string uye_mail, string sehir, string ilce, string sifre)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 350;
            int y = 175;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.WhiteSmoke;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = uye_id;          
            flp.DoubleClick += new EventHandler(this.Kullanicilar_Direkt_Engel_Click);
            //isim soyisim
            Font f_isim_soyisim = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_isim_soyisim = new Label();
            label_isim_soyisim.Size = new System.Drawing.Size(426, 104);
            label_isim_soyisim.AutoSize = true;
            label_isim_soyisim.AutoEllipsis = true;
            label_isim_soyisim.UseCompatibleTextRendering = true;
            label_isim_soyisim.ForeColor = Color.FromArgb(46, 204, 113);
            label_isim_soyisim.AutoSize = true;
            label_isim_soyisim.Font = f_isim_soyisim;
            label_isim_soyisim.Text = "Ad Soyad: "+uye_ad + " " + uye_soyad;
            //telefon
            Font font_tel = new Font("Rajdhani", 14);
            Label lbl_tel = new Label();
            lbl_tel.AutoSize = true;
            lbl_tel.AutoEllipsis = true;
            lbl_tel.UseCompatibleTextRendering = true;
            lbl_tel.ForeColor = Color.Black;
            lbl_tel.Font = font_tel;
            lbl_tel.Text = "Tel: "+uye_tel;
            //mail
            Font font_mail = new Font("Rajdhani", 14);
            Label lbl_mail = new Label();
            lbl_mail.AutoSize = true;
            lbl_mail.AutoEllipsis = true;
            lbl_mail.UseCompatibleTextRendering = true;
            lbl_mail.ForeColor = Color.DimGray;
            lbl_mail.AutoSize = true;
            lbl_mail.Font = font_mail;
            lbl_mail.Text = "Mail: "+uye_mail;
            //şehir
            Font font_sehir = new Font("Rajdhani", 14);
            Label lbl_sehir = new Label();
            lbl_sehir.AutoSize = true;
            lbl_sehir.AutoEllipsis = true;
            lbl_sehir.UseCompatibleTextRendering = true;
            lbl_sehir.ForeColor = Color.Black;
            lbl_sehir.Font = font_sehir;
            lbl_sehir.Text = "Şehir: "+sehir;
            //ilçe
            Font font_ilce = new Font("Rajdhani", 14);
            Label lbl_ilce = new Label();
            lbl_ilce.AutoSize = true;
            lbl_ilce.AutoEllipsis = true;
            lbl_ilce.UseCompatibleTextRendering = true;
            lbl_ilce.ForeColor = Color.Black;
            lbl_ilce.Font = font_ilce;
            lbl_ilce.Text = "İlçe: "+ilce;
            //şifre
            Font font_sifre = new Font("Rajdhani", 14);
            Label lbl_sifre = new Label();
            lbl_sifre.AutoSize = true;
            lbl_sifre.AutoEllipsis = true;
            lbl_sifre.UseCompatibleTextRendering = true;
            lbl_sifre.ForeColor = Color.Black;
            lbl_sifre.Font = font_sifre;
            lbl_sifre.Text = "Şifre: "+sifre;
            
            flp.Controls.Add(label_isim_soyisim);
            flp.Controls.Add(lbl_tel);
            flp.Controls.Add(lbl_mail);
            flp.Controls.Add(lbl_sehir);
            flp.Controls.Add(lbl_ilce);
            flp.Controls.Add(lbl_sifre);
            flowLayoutPanel_UYELER.Controls.Add(flp);
        }
        //engelli kullanıcılar radiobutonu, engelli kullanıcıları listeler
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel_UYELER.Controls.Clear();
            if (radioButton2.Checked == true)
            {
                Engelli_Uye_Listele();
            }
            else
            {
                flowLayoutPanel_UYELER.Controls.Clear();
            }
        }
        //ENGELLİ UYELERİ LİSTELE
        public void Engelli_Uye_Listele()
        {           
            flowLayoutPanel_UYELER.Controls.Clear();
            try
            {
                var response = service.Engelli_Uye_Listele();
                if (response != null)
                {
                    Response_Uyeler = JsonConvert.DeserializeObject(response);
                    int ek_id;
                    string ek_uye_ad;
                    string ek_uye_soyad;
                    string ek_uye_telefon;
                    string ek_uye_mail;
                    string ek_uye_sifre;
                    string ek_uye_sehir;
                    string ek_uye_ilce;
                    string ek_uye_engel_sebep;
                    string ek_uye_enge_tarih;
                    foreach (var item in Response_Uyeler)
                    {
                        ek_id = item.EK_Id;
                        ek_uye_ad = item.Uye_Ad;
                        ek_uye_soyad = item.Uye_Soyad;
                        ek_uye_telefon = item.Uye_Telefon;
                        ek_uye_mail = item.Uye_Email;
                        ek_uye_sifre = item.Uye_Sifre;
                        ek_uye_sehir = item.Name;
                        ek_uye_ilce = item.isim;
                        ek_uye_engel_sebep = item.EK_Engel_Sebebi;
                        ek_uye_enge_tarih = item.EK_Engel_Tarihi;
                        Engelli_Uye_Listele_FlowPanel(ek_id, ek_uye_ad, ek_uye_soyad, ek_uye_telefon, ek_uye_mail, ek_uye_sifre, ek_uye_sehir, ek_uye_ilce, ek_uye_engel_sebep, ek_uye_enge_tarih);
                    }
                }
                else if (response == null)
                {
                    MessageBox.Show("Hiç bildirim yok");
                }
            }
            catch
            {
                MessageBox.Show("Sunucu yada Servis kaynaklı hata", "HELPAS");
            }            
        }
        //engelli kullanıcıları flowpanele yerleştirme
        public void Engelli_Uye_Listele_FlowPanel(int ek_id, string ek_uye_ad, string ek_uye_soyad, string ek_uye_telefon, string ek_uye_mail, string ek_uye_sifre, string ek_uye_sehir, string ek_uye_ilce, string ek_uye_engel_sebep, string ek_uye_enge_tarih)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 350;
            int y = 310;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.WhiteSmoke;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = ek_id;
            
            //isim soyisim
            Font f_isim_soyisim = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_isim_soyisim = new Label();
            label_isim_soyisim.Size = new System.Drawing.Size(426, 104);
            label_isim_soyisim.AutoSize = true;
            label_isim_soyisim.AutoEllipsis = true;
            label_isim_soyisim.UseCompatibleTextRendering = true;
            label_isim_soyisim.ForeColor = Color.FromArgb(46, 204, 113);
            label_isim_soyisim.AutoSize = true;
            label_isim_soyisim.Font = f_isim_soyisim;
            label_isim_soyisim.Text = "Ad Soyad: " + ek_uye_ad + " " + ek_uye_soyad;
            //telefon
            Font font_tel = new Font("Rajdhani", 14);
            Label lbl_tel = new Label();
            lbl_tel.AutoSize = true;
            lbl_tel.AutoEllipsis = true;
            lbl_tel.UseCompatibleTextRendering = true;
            lbl_tel.ForeColor = Color.Black;
            lbl_tel.Font = font_tel;
            lbl_tel.Text = "Tel: " + ek_uye_telefon;
            //mail
            Font font_mail = new Font("Rajdhani", 14);
            Label lbl_mail = new Label();
            lbl_mail.AutoSize = true;
            lbl_mail.AutoEllipsis = true;
            lbl_mail.UseCompatibleTextRendering = true;
            lbl_mail.ForeColor = Color.DimGray;
            lbl_mail.AutoSize = true;
            lbl_mail.Font = font_mail;
            lbl_mail.Text = "Mail: " + ek_uye_mail;
            //şehir
            Font font_sehir = new Font("Rajdhani", 14);
            Label lbl_sehir = new Label();
            lbl_sehir.AutoSize = true;
            lbl_sehir.AutoEllipsis = true;
            lbl_sehir.UseCompatibleTextRendering = true;
            lbl_sehir.ForeColor = Color.Black;
            lbl_sehir.Font = font_sehir;
            lbl_sehir.Text = "Şehir: " + ek_uye_sehir;
            //ilçe
            Font font_ilce = new Font("Rajdhani", 14);
            Label lbl_ilce = new Label();
            lbl_ilce.AutoSize = true;
            lbl_ilce.AutoEllipsis = true;
            lbl_ilce.UseCompatibleTextRendering = true;
            lbl_ilce.ForeColor = Color.Black;
            lbl_ilce.Font = font_ilce;
            lbl_ilce.Text = "İlçe: " + ek_uye_ilce;
            //şifre
            Font font_sifre = new Font("Rajdhani", 14);
            Label lbl_sifre = new Label();
            lbl_sifre.AutoSize = true;
            lbl_sifre.AutoEllipsis = true;
            lbl_sifre.UseCompatibleTextRendering = true;
            lbl_sifre.ForeColor = Color.Black;
            lbl_sifre.Font = font_sifre;
            lbl_sifre.Text = "Şifre: " + ek_uye_sifre;
            //engel sebebi
            Font font_sebep = new Font("Rajdhani", 14);
            Label lbl_sebep = new Label();
            lbl_sebep.AutoSize = false;
            lbl_sebep.Size = new Size(330, 75);
            lbl_sebep.AutoEllipsis = true;
            lbl_sebep.UseCompatibleTextRendering = true;
            lbl_sebep.ForeColor = Color.Black;
            lbl_sebep.Font = font_sebep;
            lbl_sebep.Text = "Engel Sebebi: " + ek_uye_engel_sebep;
            //engel tarihi
            Font font_tarih = new Font("Rajdhani", 14);
            Label lbl_tarih = new Label();
            lbl_tarih.AutoSize = true;
            lbl_tarih.AutoEllipsis = true;
            lbl_tarih.UseCompatibleTextRendering = true;
            lbl_tarih.ForeColor = Color.Black;
            lbl_tarih.Font = font_tarih;
            lbl_tarih.Text = "Engel Tarihi: " + ek_uye_enge_tarih;
            //engel kaldır butonu
            Button btn_EngelKaldir = new Button();
            Font font_button = new Font("Rajdhani", 16);
            btn_EngelKaldir.Size = new Size(320, 39);
            btn_EngelKaldir.Font = font_button;
            btn_EngelKaldir.ForeColor = Color.DarkKhaki;
            btn_EngelKaldir.FlatStyle = FlatStyle.Flat;
            btn_EngelKaldir.Text = "Engeli Kaldır";
            btn_EngelKaldir.Tag = ek_id;
            btn_EngelKaldir.Click+= new EventHandler(this.Engel_Kaldir_Click);
            flp.Controls.Add(label_isim_soyisim);
            flp.Controls.Add(lbl_tel);
            flp.Controls.Add(lbl_mail);
            flp.Controls.Add(lbl_sehir);
            flp.Controls.Add(lbl_ilce);
            flp.Controls.Add(lbl_sifre);
            flp.Controls.Add(lbl_sebep);
            flp.Controls.Add(lbl_tarih);
            flp.Controls.Add(btn_EngelKaldir);
            flowLayoutPanel_UYELER.Controls.Add(flp);
        }
        //Engelli listesi panelinde Engel kaldır butonu click eventi
        public void Engel_Kaldir_Click(object sender, EventArgs e)
        {
            try
            {
                int engel_id;
                Button Engel_Kaldir = sender as Button;
                string Engel_Id = Engel_Kaldir.Tag.ToString();
                Int32.TryParse(Engel_Id.ToString(), out engel_id);
                DialogResult ds;
                ds = MessageBox.Show("Kullanıcı engelini kaldırmak istiyor musun?", "HELPAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    var response = service.UYE_ENGELI_KALDIR(engel_id);
                    if(response=="ok")
                    {
                        MessageBox.Show("Engel Kalktı", "HELPAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Engelli_Uye_Listele();
                    }
                    else if(response=="error")
                    {
                        MessageBox.Show("Engel kaldirilamadı.");
                    }                   
                }
            }
            catch
            {
                MessageBox.Show("Hata ile karşılaşıldı.");
            }                       
        }
        //DİREKT ENGELLEMEK İÇİN ENGELLE FORMUNA YÖNELTİKECEN İSTEK
        public void Kullanicilar_Direkt_Engel_Click(object sender, EventArgs e)
        {
            DialogResult ds;
            ds = MessageBox.Show("Kullanıcıyı engellemek istiyor musun?", "HELPAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ds==DialogResult.Yes)
            {
                FlowLayoutPanel panel = sender as FlowLayoutPanel;
                Kullanici_Engelle_Form K_E_F = new Kullanici_Engelle_Form(panel.Tag.ToString(), "");
                K_E_F.ShowDialog();
            }          
        }
        #endregion
        #region Istekler
        //Istekleri Listeleme
        public void BekleyenIstekListele_for_Istekler_Function()
        {
            try
            {
                var response = service.Istek_Listele_Bekleyenler();
                if (response != null)
                {
                    Response_BekleyenIstek_Listele = JsonConvert.DeserializeObject(response);
                    int istek_id;
                    string alan_ismi;
                    string dal_ismi;
                    int uye_id;
                    string sehir_ismi;
                    string ilce_ismi;
                    string istek_aciklama;
                    string istek_tarihi;
                    int usta_id;
                    foreach (var item in Response_BekleyenIstek_Listele)
                    {

                        if (item.Id_Dal == "")
                        {
                            dal_ismi = "yok";
                            istek_id = item.Istek_Id;
                            alan_ismi = Alan__Ismi(Convert.ToInt32(item.Id_Alan));
                            uye_id = Convert.ToInt32(item.Id_Uye);
                            sehir_ismi = Sehir_Ismi(Convert.ToInt32(item.Id_Sehir));
                            ilce_ismi = Ilce_Ismi(Convert.ToInt32(item.Id_Ilce));
                            istek_aciklama = item.Istek_Aciklama;
                            istek_tarihi = item.Istek_Tarih;
                            BekleyenIstekListele_IsteklerFlowPanel(istek_id, alan_ismi, dal_ismi, uye_id, sehir_ismi, ilce_ismi, istek_aciklama, istek_tarihi);
                        }
                        else
                        {
                            istek_id = item.Istek_Id;
                            alan_ismi = Alan__Ismi(Convert.ToInt32(item.Id_Alan));
                            dal_ismi = AltAlan__Ismi(Convert.ToInt32(item.Id_Dal));
                            uye_id = Convert.ToInt32(item.Id_Uye);
                            sehir_ismi = Sehir_Ismi(Convert.ToInt32(item.Id_Sehir));
                            ilce_ismi = Ilce_Ismi(Convert.ToInt32(item.Id_Ilce));
                            istek_aciklama = item.Istek_Aciklama;
                            istek_tarihi = item.Istek_Tarih;
                            BekleyenIstekListele_IsteklerFlowPanel(istek_id, alan_ismi, dal_ismi, uye_id, sehir_ismi, ilce_ismi, istek_aciklama, istek_tarihi);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bekleyen istek yok", "HELPAS");
                }
            }
            catch
            {
                MessageBox.Show("Sunucu ya da Servis hatası", "HELPAS");
            }
            
            
        }
        //Istekleri Listeleme
        public async void HizmetSaglanmis_Istekleri_Listele_Function()
        {
            var response = service.Istek_HizmetVerilenler();
            if(response != null)
            {
                dynamic Response_SaglananIstek_Listele = JsonConvert.DeserializeObject(response);
                int istek_id;
                string alan_ismi;
                string dal_ismi;
                int uye_id;
                string sehir_ismi;
                string ilce_ismi;
                string istek_aciklama;
                string istek_tarihi;
                int usta_id;
                foreach (var item in Response_SaglananIstek_Listele)
                {
                    if (item.Id_Dal == "")
                    {
                        dal_ismi = "yok";
                        istek_id = item.Istek_Id;
                        alan_ismi = Alan__Ismi(Convert.ToInt32(item.Id_Alan));
                        uye_id = Convert.ToInt32(item.Id_Uye);
                        sehir_ismi = Sehir_Ismi(Convert.ToInt32(item.Id_Sehir));
                        ilce_ismi = Ilce_Ismi(Convert.ToInt32(item.Id_Ilce));
                        istek_aciklama = item.Istek_Aciklama;
                        istek_tarihi = item.Istek_Tarih;
                        usta_id = Convert.ToInt32(item.Usta);
                        HizmetSaglanmisIstekListele_IsteklerFlowPanel(istek_id, alan_ismi, dal_ismi, uye_id, sehir_ismi, ilce_ismi, istek_aciklama, istek_tarihi, usta_id);
                    }
                    else
                    {
                        istek_id = item.Istek_Id;
                        alan_ismi = Alan__Ismi(Convert.ToInt32(item.Id_Alan));
                        dal_ismi = AltAlan__Ismi(Convert.ToInt32(item.Id_Dal));
                        uye_id = Convert.ToInt32(item.Id_Uye);
                        sehir_ismi = Sehir_Ismi(Convert.ToInt32(item.Id_Sehir));
                        ilce_ismi = Ilce_Ismi(Convert.ToInt32(item.Id_Ilce));
                        istek_aciklama = item.Istek_Aciklama;
                        istek_tarihi = item.Istek_Tarih;
                        usta_id = Convert.ToInt32(item.Usta);
                        HizmetSaglanmisIstekListele_IsteklerFlowPanel(istek_id, alan_ismi, dal_ismi, uye_id, sehir_ismi, ilce_ismi, istek_aciklama, istek_tarihi, usta_id);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hizmet sağlanan bir sonuç bulunamadı", "HELPAS");
            }
            
        }
        //usta atanmayı bekleyen istekler
        public void BekleyenIstekListele_IsteklerFlowPanel(int istek_id,string alan_ismi,string dal_ismi,int uye_id,string sehir_ismi,string ilce_ismi,string istek_aciklama,string istek_tarihi)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 350;
            int y = 310;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.LightGray;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = istek_id;
            //alan ismi
            Font f_alan_ismi = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_alan_ismi = new Label();
            label_alan_ismi.Size = new System.Drawing.Size(426, 104);
            label_alan_ismi.AutoSize = true;
            label_alan_ismi.AutoEllipsis = true;
            label_alan_ismi.UseCompatibleTextRendering = true;
            label_alan_ismi.ForeColor = Color.FromArgb(46, 204, 113);
            label_alan_ismi.AutoSize = true;
            label_alan_ismi.Font = f_alan_ismi;
            label_alan_ismi.Text = "Alan İsmi: " + alan_ismi;
            //branş ismi
            Font f_brans = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_brans = new Label();
            label_brans.Size = new System.Drawing.Size(426, 104);
            label_brans.AutoSize = true;
            label_brans.AutoEllipsis = true;
            label_brans.UseCompatibleTextRendering = true;
            label_brans.ForeColor = Color.FromArgb(46, 204, 113);
            label_brans.AutoSize = true;
            label_brans.Font = f_brans;
            label_brans.Text = "Branş İsmi: " + dal_ismi;
            //üye_id
            Font font_uye_id = new Font("Rajdhani", 14);
            Label lbl_uye_id = new Label();
            lbl_uye_id.AutoSize = true;
            lbl_uye_id.AutoEllipsis = true;
            lbl_uye_id.UseCompatibleTextRendering = true;
            lbl_uye_id.ForeColor = Color.DimGray;
            lbl_uye_id.AutoSize = true;
            lbl_uye_id.Font = font_uye_id;
            lbl_uye_id.Text = "Üye Numarası: " + uye_id;
            //şehir
            Font font_sehir = new Font("Rajdhani", 14);
            Label lbl_sehir = new Label();
            lbl_sehir.AutoSize = true;
            lbl_sehir.AutoEllipsis = true;
            lbl_sehir.UseCompatibleTextRendering = true;
            lbl_sehir.ForeColor = Color.Black;
            lbl_sehir.Font = font_sehir;
            lbl_sehir.Text = "Şehir: " + sehir_ismi;
            //ilçe
            Font font_ilce = new Font("Rajdhani", 14);
            Label lbl_ilce = new Label();
            lbl_ilce.AutoSize = true;
            lbl_ilce.AutoEllipsis = true;
            lbl_ilce.UseCompatibleTextRendering = true;
            lbl_ilce.ForeColor = Color.Black;
            lbl_ilce.Font = font_ilce;
            lbl_ilce.Text = "İlçe: " + ilce_ismi;
            //istek tarihi
            Font font_istek_tarihi = new Font("Rajdhani", 14);
            Label lbl_istek_tarihi = new Label();
            lbl_istek_tarihi.AutoSize = true;
            lbl_istek_tarihi.AutoEllipsis = true;
            lbl_istek_tarihi.UseCompatibleTextRendering = true;
            lbl_istek_tarihi.ForeColor = Color.Black;
            lbl_istek_tarihi.Font = font_istek_tarihi;
            lbl_istek_tarihi.Text = "İstek Tarihi: " + istek_tarihi;
            //istek_aciklaması
            Font font_istek_aciklamasi = new Font("Rajdhani", 14,FontStyle.Bold);
            Label lbl_istek_aciklamasi = new Label();
            lbl_istek_aciklamasi.AutoSize = false;
            lbl_istek_aciklamasi.Size = new Size(330, 75);
            lbl_istek_aciklamasi.AutoEllipsis = true;
            lbl_istek_aciklamasi.UseCompatibleTextRendering = true;
            lbl_istek_aciklamasi.ForeColor = Color.Black;
            lbl_istek_aciklamasi.Font = font_istek_aciklamasi;
            lbl_istek_aciklamasi.Text = "İstek Açıklaması: " + istek_aciklama;
           
            //hizmet sağla buton
            Button btn_HizmetSagla = new Button();
            Font font_button = new Font("Rajdhani", 16);
            btn_HizmetSagla.Size = new Size(320, 39);
            btn_HizmetSagla.Font = font_button;
            btn_HizmetSagla.ForeColor = Color.DarkKhaki;
            btn_HizmetSagla.FlatStyle = FlatStyle.Flat;
            btn_HizmetSagla.Text = "Hizmet Sağla";
            btn_HizmetSagla.Tag = alan_ismi+"+"+dal_ismi+"+"+sehir_ismi+"+"+ilce_ismi;
            btn_HizmetSagla.AccessibleName = istek_id.ToString();
            btn_HizmetSagla.Top = -30;
            //btn_HizmetSagla.Name;
            btn_HizmetSagla.Click += new EventHandler(this.Hizmet_Sagla_Click);
            //dinamik panel
            flp.Controls.Add(label_alan_ismi);
            flp.Controls.Add(label_brans);
            flp.Controls.Add(lbl_uye_id);
            flp.Controls.Add(lbl_sehir);
            flp.Controls.Add(lbl_ilce);
            flp.Controls.Add(lbl_istek_tarihi);
            flp.Controls.Add(lbl_istek_aciklamasi);          
            flp.Controls.Add(btn_HizmetSagla);
            //main panel
            flowLayoutPanel_Istekler.Controls.Add(flp);
        }
        //Hizmet SAĞLANMIŞ İSTEKLER LİSTESİ
        public void HizmetSaglanmisIstekListele_IsteklerFlowPanel(int istek_id, string alan_ismi, string dal_ismi, int uye_id, string sehir_ismi, string ilce_ismi, string istek_aciklama, string istek_tarihi, int usta_id)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 350;
            int y = 310;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.LightGray;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = istek_id;
            //alan ismi
            Font f_alan_ismi = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_alan_ismi = new Label();
            label_alan_ismi.Size = new System.Drawing.Size(426, 104);
            label_alan_ismi.AutoSize = true;
            label_alan_ismi.AutoEllipsis = true;
            label_alan_ismi.UseCompatibleTextRendering = true;
            label_alan_ismi.ForeColor = Color.FromArgb(46, 204, 113);
            label_alan_ismi.AutoSize = true;
            label_alan_ismi.Font = f_alan_ismi;
            label_alan_ismi.Text = "Alan İsmi: " + alan_ismi;
            //branş ismi
            Font f_brans = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_brans = new Label();
            label_brans.Size = new System.Drawing.Size(426, 104);
            label_brans.AutoSize = true;
            label_brans.AutoEllipsis = true;
            label_brans.UseCompatibleTextRendering = true;
            label_brans.ForeColor = Color.FromArgb(46, 204, 113);
            label_brans.AutoSize = true;
            label_brans.Font = f_brans;
            label_brans.Text = "Branş İsmi: " + dal_ismi;
            //üye_id
            Font font_uye_id = new Font("Rajdhani", 14);
            Label lbl_uye_id = new Label();
            lbl_uye_id.AutoSize = true;
            lbl_uye_id.AutoEllipsis = true;
            lbl_uye_id.UseCompatibleTextRendering = true;
            lbl_uye_id.ForeColor = Color.DimGray;
            lbl_uye_id.AutoSize = true;
            lbl_uye_id.Font = font_uye_id;
            lbl_uye_id.Text = "Üye Numarası: " + uye_id;
            //şehir
            Font font_sehir = new Font("Rajdhani", 14);
            Label lbl_sehir = new Label();
            lbl_sehir.AutoSize = true;
            lbl_sehir.AutoEllipsis = true;
            lbl_sehir.UseCompatibleTextRendering = true;
            lbl_sehir.ForeColor = Color.Black;
            lbl_sehir.Font = font_sehir;
            lbl_sehir.Text = "Şehir: " + sehir_ismi;
            //ilçe
            Font font_ilce = new Font("Rajdhani", 14);
            Label lbl_ilce = new Label();
            lbl_ilce.AutoSize = true;
            lbl_ilce.AutoEllipsis = true;
            lbl_ilce.UseCompatibleTextRendering = true;
            lbl_ilce.ForeColor = Color.Black;
            lbl_ilce.Font = font_ilce;
            lbl_ilce.Text = "İlçe: " + ilce_ismi;
            //atanmış usta
            Font font_usta = new Font("Rajdhani", 14);
            Label lbl_usta = new Label();
            lbl_usta.AutoSize = true;
            lbl_usta.AutoEllipsis = true;
            lbl_usta.UseCompatibleTextRendering = true;
            lbl_usta.ForeColor = Color.Black;
            lbl_usta.Font = font_usta;
            lbl_usta.Text = "Usta Id: " + usta_id;
            //istek tarihi
            Font font_istek_tarihi = new Font("Rajdhani", 14,FontStyle.Bold);
            Label lbl_istek_tarihi = new Label();
            lbl_istek_tarihi.AutoSize = true;
            lbl_istek_tarihi.AutoEllipsis = true;
            lbl_istek_tarihi.UseCompatibleTextRendering = true;
            lbl_istek_tarihi.ForeColor = Color.Black;
            lbl_istek_tarihi.Font = font_istek_tarihi;
            lbl_istek_tarihi.Text = "İstek Tarihi: " + istek_tarihi;
            //istek_aciklaması
            Font font_istek_aciklamasi = new Font("Rajdhani", 14, FontStyle.Bold);
            Label lbl_istek_aciklamasi = new Label();
            lbl_istek_aciklamasi.AutoSize = false;
            lbl_istek_aciklamasi.Size = new Size(330, 75);
            lbl_istek_aciklamasi.AutoEllipsis = true;
            lbl_istek_aciklamasi.UseCompatibleTextRendering = true;
            lbl_istek_aciklamasi.ForeColor = Color.Black;
            lbl_istek_aciklamasi.Font = font_istek_aciklamasi;
            lbl_istek_aciklamasi.Text = "İstek Açıklaması: " + istek_aciklama;
            //hizmet bitir buton
            Button btn_HizmetiBitir = new Button();
            Font font_button = new Font("Rajdhani", 16);
            btn_HizmetiBitir.Size = new Size(320, 39);
            btn_HizmetiBitir.Font = font_button;
            btn_HizmetiBitir.ForeColor = Color.DarkKhaki;
            btn_HizmetiBitir.FlatStyle = FlatStyle.Flat;
            btn_HizmetiBitir.Text = "Hizmeti Bitir";
            btn_HizmetiBitir.AccessibleName = istek_id.ToString();
            btn_HizmetiBitir.Tag = usta_id;
            btn_HizmetiBitir.Top = -30;
            btn_HizmetiBitir.Click += new EventHandler(this.Hizmet_Bitir_Click);
            //dinamik panel
            flp.Controls.Add(label_alan_ismi);
            flp.Controls.Add(label_brans);
            flp.Controls.Add(lbl_uye_id);
            flp.Controls.Add(lbl_sehir);
            flp.Controls.Add(lbl_ilce);
            flp.Controls.Add(lbl_usta);
            flp.Controls.Add(lbl_istek_tarihi);
            flp.Controls.Add(lbl_istek_aciklamasi);
            flp.Controls.Add(btn_HizmetiBitir);
            //main panel
            flowLayoutPanel_Istekler.Controls.Add(flp);
        }
        //HİZMETİ KALDIRMA BUTONU
        public void Hizmet_Bitir_Click(object sender, EventArgs e)
        {
            Button hizmet_bitir = sender as Button;
            DialogResult ds;
            ds = MessageBox.Show("Bu işlem şunları içerir;\n- Hizmet sona erer.\n- Usta serbest kalır.\n- İstek, tablodan tamamen kaldırılır.\n\nHizmeti bitirmek istiyorum.", "HELPAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ds==DialogResult.Yes)
            {
                try
                {   
                    var response = service.Hizmet_Sonlandir(Convert.ToInt32(hizmet_bitir.Tag), Convert.ToInt32(hizmet_bitir.AccessibleName));
                    if(response=="ok")
                    {
                        MessageBox.Show("Hizmet sonlandırıldı", "HELPAS");
                        flowLayoutPanel_Istekler.Controls.Clear();
                        HizmetSaglanmis_Istekleri_Listele_Function();
                    }
                }
                catch
                {
                    MessageBox.Show("Sunucu ya da Servis hatası", "HELPAS");
                }
            }
        }
        //HİZMET VERME BUTONU
        public void Hizmet_Sagla_Click(object sender, EventArgs e)
        {
            Button buton = sender as Button;
            HizmetSaglaForm H_S_F = new HizmetSaglaForm(buton.Tag.ToString(), buton.AccessibleName);
            H_S_F.ShowDialog();
        }
        //BEKLEYEN İSTEKLER SEÇENEĞİ RADİOBUTTON
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel_Istekler.Controls.Clear();
            BekleyenIstekListele_for_Istekler_Function();
        }
        //HİZMET SAĞLANAN İSTEKLER SEÇENEĞİ RADİOBUTTON
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel_Istekler.Controls.Clear();
            HizmetSaglanmis_Istekleri_Listele_Function();
        }
        #endregion
        #region Yorumlar
        //yorum yapılan ustaları getirir
        public void TümUstaları_Getir_Function()
        {
            var response = service.Yorum_Yapılan_Ustalar();
            dynamic Response_YorumYapılanUsta_Listele = JsonConvert.DeserializeObject(response);
            int usta_id;
            string usta_ismi;
            string usta_soyismi;
            string usta_mail;
            string usta_telefon;
            
            foreach (var item in Response_YorumYapılanUsta_Listele)
            {
                usta_id = Convert.ToInt32(item.Usta_Id);
                usta_ismi = item.Usta_Isim;
                usta_soyismi = item.Usta_SoyIsim;
                usta_mail = item.Usta_Email;
                usta_telefon = item.Usta_Telefon;
                YorumYapılanUstaListele_for_FlowPanel(usta_id, usta_ismi, usta_soyismi, usta_mail, usta_telefon);
            }
        }
        //yorum yapılan ustaların flowpanele yerleştirilmesi
        public void YorumYapılanUstaListele_for_FlowPanel(int ustaid,string ustaisim,string ustasoyisim,string mail,string telefon)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 327;
            int y = 175;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.LightGray;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = ustaid;
            //usta ismi
            Font f_usta_ismi = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_usta_ismi = new Label();
            label_usta_ismi.Size = new System.Drawing.Size(426, 104);
            label_usta_ismi.AutoSize = true;
            label_usta_ismi.AutoEllipsis = true;
            label_usta_ismi.UseCompatibleTextRendering = true;
            label_usta_ismi.ForeColor = Color.Black;
            label_usta_ismi.AutoSize = true;
            label_usta_ismi.Font = f_usta_ismi;
            label_usta_ismi.Text = "Usta İsmi: " + ustaisim;
            //usta soyismi
            Font f_soyisim = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_soyisim = new Label();
            label_soyisim.Size = new System.Drawing.Size(426, 104);
            label_soyisim.AutoSize = true;
            label_soyisim.AutoEllipsis = true;
            label_soyisim.UseCompatibleTextRendering = true;
            label_soyisim.ForeColor = Color.Black;
            label_soyisim.AutoSize = true;
            label_soyisim.Font = f_soyisim;
            label_soyisim.Text = "Usta Soyİsmi: " + ustasoyisim;
            //usta mail
            Font font_mail = new Font("Rajdhani", 14);
            Label lbl_mail = new Label();
            lbl_mail.AutoSize = true;
            lbl_mail.AutoEllipsis = true;
            lbl_mail.UseCompatibleTextRendering = true;
            lbl_mail.ForeColor = Color.DimGray;
            lbl_mail.AutoSize = true;
            lbl_mail.Font = font_mail;
            lbl_mail.Text = "EMail: " + mail;
            //usta telefon
            Font font_telefon = new Font("Rajdhani", 14);
            Label lbl_telefon = new Label();
            lbl_telefon.AutoSize = true;
            lbl_telefon.AutoEllipsis = true;
            lbl_telefon.UseCompatibleTextRendering = true;
            lbl_telefon.ForeColor = Color.Black;
            lbl_telefon.Font = font_telefon;
            lbl_telefon.Text = "Telefon: " + telefon;
            //usta Yorumları Görüntüle buton
            Button btn_YorumGetir = new Button();
            Font font_button = new Font("Rajdhani", 16);
            btn_YorumGetir.Size = new Size(300, 39);
            btn_YorumGetir.Font = font_button;
            btn_YorumGetir.ForeColor = Color.DarkKhaki;
            btn_YorumGetir.FlatStyle = FlatStyle.Flat;
            btn_YorumGetir.Text = "Yorumlara Gözat";
            btn_YorumGetir.Tag = ustaid+"+"+ustaisim+"+"+ustasoyisim;
            btn_YorumGetir.Top = -30;
            btn_YorumGetir.Click += new EventHandler(this.Yorumlara_Gözat_Click);
            //dinamik panel
            flp.Controls.Add(label_usta_ismi);
            flp.Controls.Add(label_soyisim);
            flp.Controls.Add(lbl_mail);
            flp.Controls.Add(lbl_telefon);
            flp.Controls.Add(btn_YorumGetir);
            //main panel
            flowLayoutPanel_YorumYapılan_Ustalar.Controls.Add(flp);
        }
        //Görsellik olarak her usta seçildiğinde otomatik diğer alanların kapanması
        public void Gorsellik_Usta_Yorumları_Gizle_Goster(bool visible)
        {
            flowLayoutPanel_UstaYorumları.Visible = visible;
            label30.Visible = visible;
            label_Usta_Ismi_Yorumlar.Visible = visible;
        }
        //Görsellik olarak yorum ayrıntı göstermenin gizlenip gösterilmesi
        public void Gorsellik_Usta_Yorumlar_Ayrıntı_Gizle_Goster(bool visible)
        {
            label32.Visible = visible;
            label_uye_ismi.Visible = visible;
            label_tarih.Visible = visible;
            richTextBox1.Visible = visible;
            button_Yorum_Kaldir_Ustalar.Visible = visible;
        }
        //yorum yapılan ustanın yorumlarını görmek için click eventi
        public void Yorumlara_Gözat_Click(object sender, EventArgs e)
        {
            Gorsellik_Usta_Yorumlar_Ayrıntı_Gizle_Goster(false);
            Gorsellik_Usta_Yorumları_Gizle_Goster(true);
            flowLayoutPanel_UstaYorumları.Controls.Clear();
            Button buton = sender as Button;
            string usta_id;
            string usta_ismi;
            string usta_soyismi;
            
            string ParseString_Tag = buton.Tag.ToString();
            char[] ayrac = { '+' };
            string[] parcalar = ParseString_Tag.Split(ayrac);
            usta_id = parcalar[0];
            usta_ismi = parcalar[1];
            usta_soyismi = parcalar[2];
            
            Ustanın_Yorumları(usta_id);
            label_Usta_Ismi_Yorumlar.Text = usta_ismi+" "+usta_soyismi;
        }
        //yorum yapılan ustaya hangi kullanıcı hangi yorumu yapmış
        public void Ustanın_Yorumları(string gelen_usta_id)
        {
            var response = service.Usta_Yorumlari_Mobil(gelen_usta_id);
            dynamic Response_UstaYorumları_Listele = JsonConvert.DeserializeObject(response);
            int yorum_id;
            string uye_ismi;
            string uye_soyismi;
            string yorum_tarihi;
            string yorum_icerik;
            foreach (var item in Response_UstaYorumları_Listele)
            {
                yorum_id = Convert.ToInt32(item.Yorum_Id);
                uye_ismi = item.Uye_Ad;
                uye_soyismi = item.Uye_Soyad;
                yorum_tarihi = item.Yorum_Tarih;
                yorum_icerik = item.Yorum_İcerik;
                Usta_Yorumlar_Listele_for_FlowPanel(yorum_id, uye_ismi, uye_soyismi, yorum_tarihi, yorum_icerik);
            }
        }
        //ustaya yapılan yorumları flowpanele yerleştirme
        public void Usta_Yorumlar_Listele_for_FlowPanel(int yorumid,string uyeismi,string uyesoyismi,string yorumtarihi,string yorumicerik)
        {
            //bildirimler paneli size 350,222 veya 234,253
            int x = 340;
            int y = 260;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.LightGray;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = yorumid;
            //uye ismi
            Font f_uye_ismi = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_uye_ismi = new Label();
            label_uye_ismi.Size = new System.Drawing.Size(426, 104);
            label_uye_ismi.AutoSize = true;
            label_uye_ismi.AutoEllipsis = true;
            label_uye_ismi.UseCompatibleTextRendering = true;
            label_uye_ismi.ForeColor = Color.Black;
            label_uye_ismi.AutoSize = true;
            label_uye_ismi.Font = f_uye_ismi;
            label_uye_ismi.Text = "Uye İsmi: " + uyeismi;
            //uye soyismi
            Font f_soyisim = new Font("Rajdhani", 14, FontStyle.Bold);
            Label label_soyisim = new Label();
            label_soyisim.Size = new System.Drawing.Size(426, 104);
            label_soyisim.AutoSize = true;
            label_soyisim.AutoEllipsis = true;
            label_soyisim.UseCompatibleTextRendering = true;
            label_soyisim.ForeColor = Color.Black;
            label_soyisim.AutoSize = true;
            label_soyisim.Font = f_soyisim;
            label_soyisim.Text = "Üye Soyİsmi: " + uyesoyismi;
            //yorum tarihi
            Font font_tarih = new Font("Rajdhani", 14);
            Label lbl_tarih = new Label();
            lbl_tarih.AutoSize = true;
            lbl_tarih.AutoEllipsis = true;
            lbl_tarih.UseCompatibleTextRendering = true;
            lbl_tarih.ForeColor = Color.DimGray;
            lbl_tarih.AutoSize = true;
            lbl_tarih.Font = font_tarih;
            lbl_tarih.Text = "Yorum Tarihi: " + yorumtarihi;
            //yorum içeriği
            Font font_yorum_icerigi = new Font("Rajdhani", 14,FontStyle.Underline);
            Label lbl_yorum_icerigi = new Label();         
            lbl_yorum_icerigi.AutoSize = false;
            lbl_yorum_icerigi.Size = new Size(330, 120);
            lbl_yorum_icerigi.AutoEllipsis = true;
            lbl_yorum_icerigi.UseCompatibleTextRendering = true;
            lbl_yorum_icerigi.ForeColor = Color.Black;
            lbl_yorum_icerigi.Font = font_yorum_icerigi;
            lbl_yorum_icerigi.Text = "Yorumu: \n" + yorumicerik;
            //usta Yorumları Görüntüle buton
            Button btn_Yorumu_Aktar = new Button();
            Font font_button = new Font("Rajdhani", 16);
            btn_Yorumu_Aktar.Size = new Size(300, 39);
            btn_Yorumu_Aktar.Font = font_button;
            btn_Yorumu_Aktar.ForeColor = Color.DarkKhaki;
            btn_Yorumu_Aktar.FlatStyle = FlatStyle.Flat;
            btn_Yorumu_Aktar.Text = "Yorumu Gör";
            btn_Yorumu_Aktar.AccessibleName = yorumid+"+"+uyeismi + "+" + uyesoyismi + "+" + yorumtarihi + "+" + yorumicerik;
            btn_Yorumu_Aktar.Top = -30;
            btn_Yorumu_Aktar.Click += new EventHandler(this.Yorumu_Goster_Click);
            //dinamik panel
            flp.Controls.Add(label_uye_ismi);
            flp.Controls.Add(label_soyisim);
            flp.Controls.Add(lbl_tarih);
            flp.Controls.Add(lbl_yorum_icerigi);
            flp.Controls.Add(btn_Yorumu_Aktar);
            //main panel
            flowLayoutPanel_UstaYorumları.Controls.Add(flp);
        }
        //yapılan yorumu text ve label ile görme
        public void Yorumu_Goster_Click(object sender, EventArgs e)
        {
            Gorsellik_Usta_Yorumlar_Ayrıntı_Gizle_Goster(true);
            string yorum_id;
            string uye_ismi;
            string uye_soyismi;
            string yorum_tarihi;
            string yorum_icerik;
            Button buton = sender as Button;
            string ParseString_Tag = buton.AccessibleName;
            char[] ayrac = { '+' };
            string[] parcalar = ParseString_Tag.Split(ayrac);
            yorum_id = parcalar[0];
            uye_ismi = parcalar[1];
            uye_soyismi = parcalar[2];
            yorum_tarihi = parcalar[3];
            yorum_icerik = parcalar[4];
            label_uye_ismi.Text = uye_ismi+" "+uye_soyismi;
            label_tarih.Text = yorum_tarihi;
            richTextBox1.Text = yorum_icerik;
            button_Yorum_Kaldir_Ustalar.Tag = yorum_id;
        }
        //gösterilen yorumu yorum id'si ile siler
        private void button_Yorum_Kaldir_Ustalar_Click(object sender, EventArgs e)
        {
            DialogResult ds;
            ds = MessageBox.Show("Ustanın yorumunu kaldırmak istiyor musun?","HELPAS",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(ds==DialogResult.Yes)
            {
                MessageBox.Show(button_Yorum_Kaldir_Ustalar.Tag.ToString());
            }
        }
        #endregion
        private void button_UstaKaydet_Click(object sender, EventArgs e)
        {
        }
    }
}
