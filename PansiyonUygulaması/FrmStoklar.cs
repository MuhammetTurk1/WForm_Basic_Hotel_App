using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonUygulaması
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True");

        
        public void kayıtlarıGetir()
        {
            baglantı.Open();
            string getir = "Select * from Stoklar ";
            SqlCommand komut = new SqlCommand(getir, baglantı);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
             

        }

        public void kayıtalarıGetir2()
        {
            //baglantı.Open();
            string sql = ("select * from Faturalar");
            SqlCommand komut = new SqlCommand(sql, baglantı);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable da = new DataTable();

            ad.Fill(da);
            dataGridView_fatura.DataSource= da;
            baglantı.Close();
        }





        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            string kayıt = "INSERT INTO Stoklar (Gıda,Icecek,Cerezler ) VALUES (@Gıda2,@Icecek2,@Cerezler2)";
            SqlCommand komut = new SqlCommand(kayıt, baglantı);

            komut.Parameters.Add("Gıda2", txt_GıdaTutari.Text);
            komut.Parameters.Add("Icecek2", txt_İçeçekTurari.Text);
            komut.Parameters.Add("Cerezler2", txt_Atıştırmalıklar.Text);

            komut.ExecuteNonQuery();
            baglantı.Close();
            kayıtlarıGetir();
            MessageBox.Show("kaydınız başarı ile oluşturulmuştur");

        }

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            kayıtlarıGetir();
            kayıtalarıGetir2();
        }

        private void txt_FaturaKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            string sql = ("INSERT INTO Faturalar (Elektirik,Su,Internet) VALUES (@ELEK,@SU,@INT)");
            SqlCommand komut = new SqlCommand(sql, baglantı);

            komut.Parameters.Add("ELEK", txt_Elektirik.Text);
            komut.Parameters.Add("SU", txt_Su.Text);
            komut.Parameters.Add("INT", txt_Internet.Text);

            komut.ExecuteNonQuery();
            kayıtalarıGetir2();
            baglantı.Close();

        }
    }
}
