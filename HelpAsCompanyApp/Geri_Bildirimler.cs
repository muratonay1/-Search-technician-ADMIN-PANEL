using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace HelpAsCompanyApp
{
    public class Geri_Bildirimler:Form2
    {
        SonService.WebService1SoapClient service = new SonService.WebService1SoapClient();
        Form2 frm2 = new Form2();
        public int OUT_Bildirim_Id;
        public dynamic Response_Bildirim_Sil;
        public int bildirim_id;
        public int user_id;
        string user_isim;
        string user_bilidirim;
        public dynamic Geri_Bildirim_FlowLayoutDesign(int User_Bildirim_Id ,int User_Id , string User_Isim,string User_Soyad, string Bildirim_Tarihi  , string User_Bildirim )
        {
            //bildirimler paneli size
            int x = 1030;
            int y = 100;
            
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.WhiteSmoke;
            flp.Size = new System.Drawing.Size(x, y);
            flp.Padding = new Padding(10);
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Tag = User_Bildirim_Id + "+" + User_Id;
            flp.Name = User_Bildirim;
            flp.DoubleClick += new EventHandler(this.Engelle_click);
            
            //kullanıcı adı ve soyadı
            Font f_isim = new Font("Rajdhani", 18, FontStyle.Bold);
            Label label_isim = new Label();
            label_isim.Size = new System.Drawing.Size(426, 104);
            label_isim.AutoSize = true;
            label_isim.AutoEllipsis = true;
            label_isim.UseCompatibleTextRendering = true;
            label_isim.ForeColor = Color.FromArgb(46, 204, 113);
            label_isim.AutoSize = true;
            label_isim.Font = f_isim;
            label_isim.Text = User_Isim+" "+User_Soyad;
            
            //bildirim tarihi
            Font font_tarih = new Font("Rajdhani", 14);
            Label lbl_tarih = new Label();
            lbl_tarih.AutoSize = true;
            lbl_tarih.AutoEllipsis = true;
            lbl_tarih.UseCompatibleTextRendering = true;
            lbl_tarih.ForeColor = Color.Black;
            lbl_tarih.Font = font_tarih;
            lbl_tarih.Text = Bildirim_Tarihi;
         
            //bildirim metni
            Font f_bildirim = new Font("Rajdhani", 14);
            Label label_bildirim = new Label();
            label_bildirim.Size = new System.Drawing.Size(426, 104);
            label_bildirim.AutoSize = true;
            label_bildirim.AutoEllipsis = true;
            label_bildirim.UseCompatibleTextRendering = true;
            label_bildirim.ForeColor = Color.DimGray;
            label_bildirim.AutoSize = true;
            label_bildirim.Font = f_bildirim;
            label_bildirim.Text = User_Bildirim;

            //bildirim kaldır butonu
            Button btn_kaldir = new Button();
            btn_kaldir.Text = "YORUMU KALDIR";
            btn_kaldir.Size = new Size(77, 80);
            btn_kaldir.Tag = User_Bildirim_Id;
            btn_kaldir.Name = User_Isim;
            btn_kaldir.Click += new EventHandler(this.Kaldir_click);
            //Tek haber için panele yığma
            flp.Controls.Add(label_isim);
            flp.Controls.Add(lbl_tarih);
            flp.Controls.Add(btn_kaldir);
            flp.Controls.Add(label_bildirim);
            
            return flp;          
        }
        public void Kaldir_click(object sender, EventArgs e)
        {
            Button bildirim_kaldir = sender as Button;
            string bildirim_id = bildirim_kaldir.Tag.ToString();
            Int32.TryParse(bildirim_id.ToString(), out OUT_Bildirim_Id);
            DialogResult ds;
            ds = MessageBox.Show(bildirim_kaldir.Name+"'in bildirimini kaldırıyorsun", "Bilgilendirme",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(ds==DialogResult.Yes)
            {
                Bildirim_Sil(OUT_Bildirim_Id);
            }           
        }
        public void Engelle_click(object sender, EventArgs e)
        {
            FlowLayoutPanel kullanıcı_engelle = sender as FlowLayoutPanel;
           // MessageBox.Show(kullanıcı_engelle.Tag.ToString()+"/"+kullanıcı_engelle.Name);
            string bildirim_id = kullanıcı_engelle.Tag.ToString();
            
            DialogResult ds;
            ds = MessageBox.Show(kullanıcı_engelle.Name + " \n(YORUM SAHİBİNİ ENGELLEMEK İSTİYOR MUSUN?)", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                
                Kullanici_Engelle_Form K_E_F = new Kullanici_Engelle_Form(kullanıcı_engelle.Tag.ToString(),kullanıcı_engelle.Name);
                K_E_F.ShowDialog();

            }
        }
        public async void Bildirim_Sil(int Bildirim_id)
        {
            var response = service.Geri_Bildirim_Sil(Bildirim_id);
            MessageBox.Show(response);
            listele();
            
        }

    }
}
