using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PansiyonUygulaması
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True");
        private void btn_Hesapla_Click(object sender, EventArgs e)
        {
            if (txt_PersonelSayısı.Text.Length > 0)
            {
                int asgaari = 5000;

                int maas = Convert.ToInt32(txt_PersonelSayısı.Text) * asgaari;
                lbl_PersonelMaas.Text = Convert.ToString(maas);

            }

            int KasadakiToplamTutar = Convert.ToInt32(lbl_KasadakiToplamTutar.Text);
            int personelMaas = Convert.ToInt32(lbl_PersonelMaas.Text);
            int AlınanÜrüler = Convert.ToInt32(lbl_Gıda.Text) + Convert.ToInt32(lbl_Icecek.Text) + Convert.ToInt32(lbl_Gıda.Text);
            int Faturalar = Convert.ToInt32(lbl_Elektirik.Text) + Convert.ToInt32(lbl_Su.Text) + Convert.ToInt32(lbl_Internet.Text);
            int sonuc = KasadakiToplamTutar - personelMaas - AlınanÜrüler - Faturalar;
            lbl_Sonuç.Text=Convert.ToString(sonuc);
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select sum(Ucret) as toplam from MüsteriEkle", baglantı);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lbl_KasadakiToplamTutar.Text = oku["toplam"].ToString();


            }
            
            


            baglantı.Close();

            AlınanÜrünleriGetir();
            faturalariGetir();


        }
        public void AlınanÜrünleriGetir()
        {
            baglantı.Open();
            SqlCommand komu1 = new SqlCommand("select sum(Gıda) as Toplam from Stoklar ", baglantı);
            SqlDataReader oku1 = komu1.ExecuteReader();
            while (oku1.Read())
            {

              lbl_Gıda.Text = oku1["Toplam"].ToString();

            }
            baglantı.Close();

            baglantı.Open();
            SqlCommand komu2 = new SqlCommand("select sum(Icecek) as Toplam2 from Stoklar ", baglantı);
            SqlDataReader oku2 = komu2.ExecuteReader();
            while (oku2.Read())
            {

                lbl_Icecek.Text = oku2["Toplam2"].ToString();

            }
            baglantı.Close();

            baglantı.Open();
            SqlCommand komu3 = new SqlCommand("select sum(Cerezler) as Toplam3 from Stoklar ", baglantı);
            SqlDataReader oku3 = komu3.ExecuteReader();
            while (oku3.Read())
            {

               lbl_cerez.Text = oku3["Toplam3"].ToString();

            }
            baglantı.Close();
        }

        public void faturalariGetir()
        {
            baglantı.Open();
            string sql = ("select sum(Elektirik) as Toplam from Faturalar ");
            SqlCommand komut = new SqlCommand(sql, baglantı);
            SqlDataReader oku = komut.ExecuteReader();  
            while (oku.Read())
            {
                lbl_Elektirik.Text = oku["Toplam"].ToString();
            }
            baglantı.Close();

            baglantı.Open();
            SqlCommand komu2 = new SqlCommand("select sum(Su) as Toplam2 from Faturalar ", baglantı);
            SqlDataReader oku2 = komu2.ExecuteReader();
            while (oku2.Read())
            {

                lbl_Su.Text = oku2["Toplam2"].ToString();

            }
            baglantı.Close();

            baglantı.Open();
            SqlCommand komu3 = new SqlCommand("select sum(Internet) as Toplam3 from Faturalar ", baglantı);
            SqlDataReader oku3 = komu3.ExecuteReader();
            while (oku3.Read())
            {

                lbl_Internet.Text = oku3["Toplam3"].ToString();

            }
            baglantı.Close();
        }
         
    }
}
