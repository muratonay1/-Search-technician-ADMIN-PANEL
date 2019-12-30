using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpAsCompanyApp
{
    public partial class Kullanici_Engelle_Form : Form
    {
        SonService.WebService1SoapClient service = new SonService.WebService1SoapClient();
        //bildirim id ve user id + sembolü ile birlikte geliyor.
        public string bildirimid_userid;
        public string bildirim;
        public int USER_ID;
        public int BILDIRIM_ID;
        public dynamic Response_Uye_Sorgula;
        //MAIN FORMDAN GELEN KULLANICI BILGILERI
        public Kullanici_Engelle_Form(string BILDIRIMID_USERID, string BILDIRIM)
        {
            bildirimid_userid =BILDIRIMID_USERID;
            bildirim = BILDIRIM;
            //bildirim id yi ilk parçadan alıyoruz.
            string B_I = BILDIRIMID_USERID.Split('+').First();
            Int32.TryParse(B_I.ToString(), out BILDIRIM_ID);
            //user id yi ikinci parçadan alıyoruz
            string U_I = BILDIRIMID_USERID.Split('+').Last();
            Int32.TryParse(U_I.ToString(), out USER_ID);
            InitializeComponent();
        }
        //ENGELLE BUTONU
        private void Btn_Engelle_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "")
                {
                    string Bugun_Ismi_TR = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)DateTime.Now.DayOfWeek];//türkçe gün ismi          
                    string Bugun_Sayi = DateTime.Now.Day.ToString();
                    string Bugun_Yil = DateTime.Now.Year.ToString();
                    string Bugun_Ay = DateTime.Now.Month.ToString();
                    string TARIH = Bugun_Sayi + "-" + Bugun_Ay + "-" + Bugun_Yil + "-" + Bugun_Ismi_TR;
                    var response = service.UYE_ENGELLE(USER_ID, textBox1.Text, TARIH);
                    if(response=="ok")
                    {
                        MessageBox.Show("Kullanıcıyı Engelledin", "HELPAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(response=="error")
                    {
                        MessageBox.Show("Engelleme sırasında hata oluştu","HELPAS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Engel sebebi belirtilmelidir.", "HELPAS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }               
            }
            catch
            {
                MessageBox.Show("Teknik hata meydana geldi", "HELPAS");
            }           
        }
        //form load
        private void Kullanici_Engelle_Form_Load(object sender, EventArgs e)
        {
            Uye_Sorgula();
        }
        //GELEN KULLANICI ID YE GORE KULLANICI BILGILERININ SERVISTEN ALINMASI
        public void Uye_Sorgula()
        {
            try
            {
                var response = service.Uye_Sorgula_forEngelle(USER_ID);
                if (response != null)
                {
                    Response_Uye_Sorgula = JsonConvert.DeserializeObject(response);
                    string USR_AD;
                    string USR_SOYAD;
                    string USR_TEL;
                    string USR_MAIL;
                    foreach (var item in Response_Uye_Sorgula)
                    {
                        //Direkt Kullanıcı engellenirken yorum kullanılmaması için
                        if (bildirim == "")
                        {
                            USR_AD = item.Uye_Ad;
                            USR_SOYAD = item.Uye_Soyad;
                            USR_TEL = item.Uye_Telefon;
                            USR_MAIL = item.Uye_Email;
                            label_Bilgiler.Text =
                            "Kullanıcı Adı: " + USR_AD +
                            "\nSoyadı: " + USR_SOYAD +
                            "\nTelefon: " + USR_TEL +
                            "\nE-Mail: " + USR_MAIL;
                        }
                        else if (bildirim != "")
                        {
                            USR_AD = item.Uye_Ad;
                            USR_SOYAD = item.Uye_Soyad;
                            USR_TEL = item.Uye_Telefon;
                            USR_MAIL = item.Uye_Email;
                            label_Bilgiler.Text =
                            "Kullanıcı Adı: " + USR_AD +
                            "\nSoyadı: " + USR_SOYAD +
                            "\nTelefon: " + USR_TEL +
                            "\nE-Mail: " + USR_MAIL +
                            "\nYorumu: " + bildirim;
                        }
                    }
                }

                else if (response == null)
                {
                    MessageBox.Show("KULLANICI BULUNAMADI");
                }
            }
            catch
            {
                MessageBox.Show("Teknik bir hata meydana geldi", "HELPAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //ÇIKIŞ BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
