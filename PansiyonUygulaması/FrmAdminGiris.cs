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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void btn_giriş_Click(object sender, EventArgs e)
        {
            //if (txt_KullanıcıAdı.Text == "admin" && txt_Sifre.Text == "12345")
            //{
            //    FrmAnaForm a = new FrmAnaForm();
            //    a.ShowDialog();
            //    MessageBox.Show("tebrkler başarılı giriş yaptınız");

            //}
            //else
            //{
            //    MessageBox.Show("kullanıcı veya şifreniz hatalıdır");
            //}


            SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True");
            try
            {
               
                baglantı.Open();
                string Sql = "select * from AdminGiris where Kullanıcı=@geçiçiKullanıcı and Sifre=@geciciSifre ";
                SqlCommand komut = new SqlCommand(Sql, baglantı);
                SqlParameter prm1 = new SqlParameter("geçiçiKullanıcı", txt_KullanıcıAdı.Text.Trim());
                SqlParameter prm2 = new SqlParameter("geciciSifre", txt_Sifre.Text.Trim());

                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();                 //sanal bir tablo yaptık
                SqlDataAdapter da = new SqlDataAdapter(komut);  //bu sanal tabloyu sqldataadopyer ile doldrucaz
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    FrmAnaForm fr = new FrmAnaForm();
                    fr.ShowDialog();
                } 
            }
            catch (Exception)
            {

                MessageBox.Show("hatalı giriş");
            }


        }
    }
}
