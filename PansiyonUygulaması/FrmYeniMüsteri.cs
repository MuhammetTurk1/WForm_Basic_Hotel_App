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
    public partial class FrmYeniMüsteri : Form
    {
        public FrmYeniMüsteri()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True");

        //Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True


        private void dtp_ÇıkışTarihi_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime küçükTarih = Convert.ToDateTime(dtp_GirişTarihi.Text);
            DateTime büyükTarih = Convert.ToDateTime(dtp_ÇıkışTarihi.Text);

            TimeSpan sonuc = büyükTarih - küçükTarih;
            label11.Text = sonuc.TotalDays.ToString(); //GÜN SAYISI ;

            int ücret = Convert.ToInt32(label11.Text)* 50; //ÜCRETİ
            txt_Ücret.Text = ücret.ToString();
        }

        private void btnKAydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            // SqlCommand komut = new SqlCommand("INSERT INTO MüsteriEkle (Adi,SoyAdi,Cinsiyet,Telefon,Mail,Tc,OdaNo,Ucret,GirisTarihi,CikişTarihi) VALUES ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "','" + cmb_Cinsiyet.Text + "','" + maskedtxt_Telefon.Text + "','" + txtMail.Text + "','" + txtTCKimlikNo.Text + "','" + txtOdaNumarasi.Text + "','" + txt_Ücret.Text + "','" + dtp_GirişTarihi.Value.ToString("yyyy-MM-dd") + "','" + dtp_ÇıkışTarihi.Value.ToString("yyyy-MM-dd") + "')" , baglantı);
            string kayıt = "INSERT INTO MüsteriEkle (Adi,SoyAdi,Cinsiyet,Telefon,Mail,Tc,OdaNo,Ucret,GirisTarihi,CikişTarihi) VALUES (@Adi,@SoyAdi,@Cinsiyet,@Telefon,@Mail,@Tc,@OdaNo,@Ucret,@GirisTarihi,@CikişTarihi)";

            SqlCommand komut = new SqlCommand(kayıt, baglantı);

            komut.Parameters.AddWithValue("@Adi", txtAdi.Text);
            komut.Parameters.AddWithValue("@SoyAdi", txtSoyAdi.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", cmb_Cinsiyet.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedtxt_Telefon.Text);
            komut.Parameters.AddWithValue("@Mail", txtMail.Text);
            komut.Parameters.AddWithValue("@Tc", txtTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@OdaNo", txtOdaNumarasi.Text);
            komut.Parameters.AddWithValue("@Ucret", txt_Ücret.Text);
            komut.Parameters.AddWithValue("@GirisTarihi", dtp_GirişTarihi.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@CikişTarihi", dtp_ÇıkışTarihi.Value.ToString("yyyy-MM-dd"));


            komut.ExecuteNonQuery();   
            baglantı.Close();
            kayıtları_getir();
            MessageBox.Show("kaydınız başarı ile oluşturulmuştur");
        }

        public void kayıtları_getir()
        {
            baglantı.Open();
            string getir = "Select * from MüsteriEkle ";
            SqlCommand komut = new SqlCommand(getir,baglantı);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource=dt;
            baglantı.Close();

        }
        public void verileriSİL(int id)
        {
            baglantı.Open();
            string sil = "Delete from MüsteriEkle where MusteriId=@MusteriId";
            SqlCommand komut = new SqlCommand(sil, baglantı);
            komut.Parameters.AddWithValue("@MusteriId", id);
            komut.ExecuteNonQuery();
            baglantı.Close() ;

        }




        private void btnListele_Click(object sender, EventArgs e)
        {
            kayıtları_getir();
        }


        private void btn_AramaYap_Click(object sender, EventArgs e)
        {
            string kayit = "select * from MüsteriEkle where Adi=@Adi ";
            SqlCommand komut = new SqlCommand(kayit, baglantı);

            komut.Parameters.AddWithValue("@Adi", txt_KullanıcıAra.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            baglantı.Close();

               
         }
        int i = 0;
        private void btn_Güncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open() ;
            string kayıtguncelle = ("update MüsteriEkle set  Adi =@Adi ,SoyAdi=@SoyAdi,Cinsiyet=@Cinsiyet,Telefon=@Telefon," +
                "Mail=@Mail,Tc=@Tc,OdaNo=@OdaNo,Ucret=@Ucret,GirisTarihi=@GirisTarihi,CikişTarihi=@CikişTarihi  where MusteriId=@MusteriId" );

            SqlCommand komut = new SqlCommand(kayıtguncelle,baglantı);



            komut.Parameters.AddWithValue("@Adi", txtAdi.Text);
            komut.Parameters.AddWithValue("@SoyAdi", txtSoyAdi.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", cmb_Cinsiyet.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedtxt_Telefon.Text);
            komut.Parameters.AddWithValue("@Mail", txtMail.Text);
            komut.Parameters.AddWithValue("@Tc", txtTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@OdaNo", txtOdaNumarasi.Text);
            komut.Parameters.AddWithValue("@Ucret", txt_Ücret.Text);
            komut.Parameters.AddWithValue("@GirisTarihi", dtp_GirişTarihi.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@CikişTarihi", dtp_ÇıkışTarihi.Value.ToString("yyyy-MM-dd"));

            komut.Parameters.AddWithValue("@MusteriId", dataGridView1.Rows[i].Cells[0].Value);

            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("güncelleme işleminiz başarıyla tamamlanmıştır");

            kayıtları_getir();

        }

        private void btn_SiL_Click(object sender, EventArgs e)
        {
            //verileriSİL(int id)
            foreach (DataGridViewRow secilen in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(secilen.Cells[0].Value);
                verileriSİL(id);
                kayıtları_getir();
            }
        }

        private void btn_Yenile_Click(object sender, EventArgs e)
        {

        }


        private void btn_Oda101_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "101";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda101 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_Oda102_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "102";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda102 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btnOda103_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "103";


            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda103 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_Oda104_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "104";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda104 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_oda105_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "105";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda105 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_oda106_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "106";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda106 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_oda107_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "107";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda107 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();

        }

        private void btn_oda108_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "108";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda108 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();

        }

        private void btn_oda109_Click(object sender, EventArgs e)
        {
            txtOdaNumarasi.Text = "109";

            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Oda109 (Adi,SoyAdi) values ('" + txtAdi.Text + "','" + txtSoyAdi.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        private void btn_BoşOdalar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("BU ALAN BOŞ ODALARI İFADE EDER");
        }

        private void btn_DoluOdalar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("BU ALAN DOLU ODALARI İFADE EDER");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex; //rowindex komutu (seçtiğimiz hücrenin satır numarasını verir

            txtAdi.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoyAdi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmb_Cinsiyet.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            maskedtxt_Telefon.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtTCKimlikNo.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtOdaNumarasi.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txt_Ücret.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            dtp_GirişTarihi.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            dtp_ÇıkışTarihi.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();

        }

        private void FrmYeniMüsteri_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglantı);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                btn_Oda101.Text = oku1["Adi"].ToString() + " " + oku1["SoyAdi"].ToString();
            }
            if (btn_Oda101.Text != "101")
            {
                btn_Oda101.BackColor = Color.Red;
                btn_Oda101.Enabled = false;

            }

            baglantı.Close();

            //oda102

            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("select * from Oda102", baglantı);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                btn_Oda102.Text = oku2["Adi"].ToString() + " " + oku2["SoyAdi"].ToString();
            }
            if (btn_Oda102.Text != "102")
            {
                btn_Oda102.BackColor = Color.Red;
                btn_Oda102.Enabled = false;

            }

            baglantı.Close();

            //oda103

            baglantı.Open();
            SqlCommand komut3 = new SqlCommand("select * from Oda103", baglantı);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                btnOda103.Text = oku3["Adi"].ToString() + " " + oku3["SoyAdi"].ToString();
            }
            if (btnOda103.Text != "103")
            {
                btnOda103.BackColor = Color.Red;
                btnOda103.Enabled = false;

            }

            baglantı.Close();

            //oda104

            baglantı.Open();
            SqlCommand komut4 = new SqlCommand("select * from Oda104", baglantı);
            SqlDataReader oku4 = komut4.ExecuteReader();

            while (oku4.Read())
            {
                btn_Oda104.Text = oku4["Adi"].ToString() + " " + oku4["SoyAdi"].ToString();
            }
            if (btn_Oda104.Text != "104")
            {
                btn_Oda104.BackColor = Color.Red;
                btn_Oda104.Enabled = false;

            }

            baglantı.Close();

            //oda105

            baglantı.Open();
            SqlCommand komut5 = new SqlCommand("select * from Oda105", baglantı);
            SqlDataReader oku5 = komut5.ExecuteReader();

            while (oku5.Read())
            {
                btn_oda105.Text = oku5["Adi"].ToString() + " " + oku5["SoyAdi"].ToString();
            }
            if (btn_oda105.Text != "105")
            {
                btn_oda105.BackColor = Color.Red;
                btn_oda105.Enabled = false;

            }

            baglantı.Close();

            //oda16

            baglantı.Open();
            SqlCommand komut6 = new SqlCommand("select * from Oda106", baglantı);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku6.Read())
            {
                btn_oda106.Text = oku6["Adi"].ToString() + " " + oku6["SoyAdi"].ToString();
            }
            if (btn_oda106.Text != "106")
            {
                btn_oda106.BackColor = Color.Red;
                btn_oda106.Enabled = false;

            }

            baglantı.Close();

            //oda17

            baglantı.Open();
            SqlCommand komut7 = new SqlCommand("select * from Oda107", baglantı);
            SqlDataReader oku7 = komut7.ExecuteReader();

            while (oku7.Read())
            {
                btn_oda107.Text = oku7["Adi"].ToString() + " " + oku7["SoyAdi"].ToString();
            }
            if (btn_oda107.Text != "107")
            {
                btn_oda107.BackColor = Color.Red;
                btn_oda107.Enabled = false;

            }

            baglantı.Close();

            //oda18

            baglantı.Open();
            SqlCommand komut8 = new SqlCommand("select * from Oda108", baglantı);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku8.Read())
            {
                btn_oda108.Text = oku8["Adi"].ToString() + " " + oku8["SoyAdi"].ToString();
            }
            if (btn_oda108.Text != "108")
            {
                btn_oda108.BackColor = Color.Red;
                btn_oda108.Enabled = false;

            }

            baglantı.Close();

            //oda19

            baglantı.Open();
            SqlCommand komut9 = new SqlCommand("select * from Oda109", baglantı);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku9.Read())
            {
                btn_oda109.Text = oku9["Adi"].ToString() + " " + oku9["SoyAdi"].ToString();
            }
            if (btn_oda109.Text != "109")
            {
                btn_oda109.BackColor = Color.Red;
                btn_oda109.Enabled = false;

            }

            baglantı.Close();
        }
    }
}
