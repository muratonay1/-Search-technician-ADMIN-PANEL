using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpAsCompanyApp
{
    public partial class HizmetSaglaForm : Form
    {
        SonService.WebService1SoapClient service = new SonService.WebService1SoapClient();
        public string ParseString_Tag;
        public string Alan_Ismi;
        public string Brans_Ismi;
        public string Sehir_Ismi;
        public string Ilce_Ismi;
        public int Istek_Id;
        public int usta_kontrol;
        public int usta_musait;
        public string OUT_usta_id;
        //FORM INITIALIZE
        public HizmetSaglaForm(string Gelen_Tag, string Gelen_AccessName)
        {
            //Bize gelen buton tagında;
            // alanismi + dalismi + sehirismi + ilceismi bulunmaktadır. Bunları ayırmak zorundayız ki hizmeti verebilecek usta ararken bu değişkenleri kullanabilelim
            //Bize gelen buton accessname'inde;
            //istek id bulunmaktadır. istek id 'yi hizmeti atamak için kullanacağız.
            ParseString_Tag = Gelen_Tag;
            char[] ayrac = { '+' };
            string[] parcalar = ParseString_Tag.Split(ayrac);
            Alan_Ismi = parcalar[0];
            Brans_Ismi = parcalar[1];
            Sehir_Ismi = parcalar[2];
            Ilce_Ismi = parcalar[3];
            Istek_Id = Convert.ToInt32(Gelen_AccessName);
            if(Brans_Ismi=="yok")
            {
                Brans_Ismi = "0";
            }
            InitializeComponent();
        }

        //hizmeti sağla butonu
        private void button_HizmetVer_Click(object sender, EventArgs e)
        {
            DialogResult ds;
            ds = MessageBox.Show("Hizmet verilsin mi?", "HELPAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ds==DialogResult.Yes)
            {
                OUT_usta_id = listBox_Musait_Ustalar.SelectedItem.ToString().Split('-').First();
                Int32.TryParse(OUT_usta_id.ToString(), out usta_musait);
                Usta_Musaitmi(usta_musait);
                if (usta_kontrol == 1)
                {
                    //usta yı kullanıcıya atıyoruz.(ISTEKLER TABLOSUNA USTA ID YI ATIYORUZ) şimdi ustalar tablosunda usta musaitliğe 0 vermeliyiz.
                    var response = service.Usta_Ata(Istek_Id,usta_musait);
                    if (response == "ok")
                    {
                        //ustalar tablosundan ustanın musaitlik değerini 0 yapıyoruz yani ustayı meşgül duruma getiriyoruz ki başka bir kullanıcıya atanamasın
                        var response1 = service.Usta_Musaitlik_Degistir(usta_musait,0);
                        if(response1=="ok")
                        {
                            MessageBox.Show("Usta kullanıcıya yönlendirildi.", "HELPAS");
                            this.Close();
                        }                        
                    }
                    else if(response == "error")
                    {
                        MessageBox.Show("Usta ataması yapılmadı. Teknik bir hata mevcut", "HELPAS");
                    }
                }
                else if (usta_kontrol == 0)
                {
                    MessageBox.Show("Usta başka bir kullanıcıya atanmış", "HELPAS");
                }
            }         
        }

        /*
         * ŞİRKET ÇALIŞANI PENCEREYİ AÇIK BIRAKIP BAŞKA BİR İŞLE MEŞGUL OLABİLİR VE BİR SÜRE SONRA BAŞKA BİR PERSONEL SEÇİLEN USTAYI
         * BAŞKA BİR KULLANICIYA ATAYABİLİR. BU SEBEPLE HİZMETİ VER BUTONUNA BASMADAN HEMEN ÖNCE TEKRARDAN USTA MÜSAİTLİK DURUMUNU KONTROL ETMEMİZ GEREKİYOR.
         */ 
         public void Usta_Musaitmi(int usta_id)
         {
            try
            {
                var response = service.Usta_Musaitmi(usta_id);
                if(response != "")
                {
                    dynamic Response_Musait_Ustalar = JsonConvert.DeserializeObject(response);
                    int _usta_musait;
                    foreach (var item in Response_Musait_Ustalar)
                    {
                        _usta_musait = item.Usta_Musaitlik;
                        if (_usta_musait == 0)
                        {
                            usta_kontrol = 0;
                        }
                        else if (_usta_musait == 1)
                        {
                            usta_kontrol = 1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("USTA BULUANAMADI", "HELPAS");
                }               
            }
            catch
            {
                MessageBox.Show("Sunucu ya da Servis hatası", "HELPAS");
            }
         }

        //başlangıç istek bilgileri
        public void UyeBilgileriDoldur()
        {
            label_Bilgiler.Text =
                            "Alan Ismi: " + Alan_Ismi +
                            "\nBranş İsmi: " + Brans_Ismi +
                            "\nSehir İsmi: " + Sehir_Ismi +
                            "\nE-Ilce İsmi: " + Ilce_Ismi +
                            "\nIstek Id: " + Istek_Id;
        }
        //isteklere uygun usta listele servis
        public void UygunUstaListesi(string alan, string dal, string sehir, string ilce)
        {
            var response = service.Uygun_Ustalar(alan, dal, sehir, ilce);           
            if (response != null)
            {
                dynamic Response_Musait_Ustalar = JsonConvert.DeserializeObject(response);
                int _usta_id;
                string _usta_ismi;
                string _usta_soyisim;
                foreach (var item in Response_Musait_Ustalar)
                {
                    _usta_id = item.Usta_Id;
                    _usta_ismi = item.Usta_Isim;
                    _usta_soyisim = item.Usta_SoyIsim;
                    //ustalar listboxa uygun ustaları atama
                    listBox_Musait_Ustalar.Items.Add(_usta_id + "-" + _usta_ismi + " " + _usta_soyisim);
                }
            }
            else
            {
                listBox_Musait_Ustalar.Items.Add("USTA BULUNAMADI");
            }
        }
        //form load 
        private void HizmetSaglaForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Brans_Ismi);
            UyeBilgileriDoldur();
            UygunUstaListesi(Alan_Ismi, Brans_Ismi, Sehir_Ismi, Ilce_Ismi);
        }

        //cikis yap butonu
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //listboxtan usta seçme ve labele usta ismi yazdırma
        private void listBox_Musait_Ustalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_Usta_Ismi.Text = listBox_Musait_Ustalar.SelectedItem.ToString();           
        }
    }
}
