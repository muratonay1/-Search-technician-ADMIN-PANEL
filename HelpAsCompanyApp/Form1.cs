using System;
using System.Collections.Generic;
using System;
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
using System.Net;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace HelpAsCompanyApp
{
    public partial class Form1 : Form
    {
        private int tick1;
        private int tick2;
        private int tick3;
        private int tick4;
        private Form1 frm1;
        string Refresing_Request;
        public bool Connection_Status;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
       
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);           
        }

        public Form1()
        {
            InitializeComponent();
        }
        public bool Internet_Connection_Check()//Internet Connection Test
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if(connection==true)
            {
                Connection_Status = true;
            }
            if(connection==false)
            {
                Connection_Status = false;
            }
            return Connection_Status;
        }
        public string Service_Connection_Check()//Web Service Connection Test
        {
            REQUEST_URL request = new REQUEST_URL();
            var url = request.URL;
            string sonuc = "";
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)myRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {               
                    return "ok";                 
                }
                else
                {
                    return "err";
                }
            }
            catch (Exception ex)
            {
                return "err";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            label1.Text = "İnternet bağlantısı kontrol ediliyor...";
            label1.ForeColor = Color.WhiteSmoke;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick1++;
            if(tick1%20==0)
            {
                timer1.Enabled = false;
                timer1.Stop();
                if(IsConnectedToInternet()== true)
                {
                    label1.Text = "İnternet bağlantısı başarılı.";
                    label1.ForeColor = Color.FromArgb(37, 211, 102);//YEŞİL
                    timer2.Enabled = true;
                    timer2.Start();

                }
                if(IsConnectedToInternet() == false)
                {
                    label1.Text = "İnternet bağlantısı başarısız.";
                    label1.ForeColor = Color.FromArgb(205, 32, 31);//KIRMIZI
                    button1.Visible = true;
                    button2.Visible = true;
                    Refresing_Request = "internet";
                }               
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tick2++;
            if(tick2%20==0)
            {
                label1.Text = "Servise Bağlanılıyor...";
                label1.ForeColor = Color.WhiteSmoke;
                timer2.Enabled = false;
                timer2.Stop();
                timer3.Enabled = true;
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tick3++;
            if (tick3 % 20 == 0)
            {
                if(Service_Connection_Check()=="ok")
                {
                    timer3.Enabled = false;
                    timer3.Stop();
                    label1.Text = "Servise Bağlandın.";
                    label1.ForeColor = Color.FromArgb(37, 211, 102);
                    timer4.Enabled = true;
                    timer4.Start();

                }
                if(Service_Connection_Check()=="err")
                {
                    timer3.Enabled = false;
                    timer3.Stop();
                    label1.Text = "Servise Bağlanırken Hata";
                    label1.ForeColor = Color.FromArgb(205, 32, 31);
                    button1.Visible = true;
                    button2.Visible = true;
                    Refresing_Request = "service";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Refresing_Request=="internet")
            {
                button1.Visible = false;
                button2.Visible = false;
                label1.ForeColor = Color.WhiteSmoke;
                label1.Text = "İnternet bağlantısı kontrol ediliyor...";
                timer1.Enabled = true;
                timer1.Start();
            }
            if(Refresing_Request=="service")
            {
                button1.Visible = false;
                button2.Visible = false;
                this.Refresh();
                label1.Text = "Servise Bağlanılıyor...";
                label1.ForeColor = Color.WhiteSmoke;
                timer3.Enabled = true;
                timer3.Start();
            }           
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            tick4++;
            if(tick4%20==0)
            {
                timer4.Enabled = false;
                timer4.Stop();
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();               
            }
        }
    }
}
