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
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-3DI31D0;Initial Catalog=Ayçiçeği;Integrated Security=True");
       
        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglantı);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while(oku1.Read())
            {
                 btn_Oda101.Text = oku1["Adi"].ToString()+" "+oku1["SoyAdi"].ToString();   
            }
            if (btn_Oda101.Text != "101")
            {
                btn_Oda101.BackColor = Color.Red;

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
            if (btnOda103.Text!= "103")
            {
                btnOda103.BackColor = Color.Red;

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

            }

            baglantı.Close();

            //oda18

            baglantı.Open();
            SqlCommand komut8 = new SqlCommand("select * from Oda108", baglantı);
            SqlDataReader oku8= komut8.ExecuteReader();

            while (oku8.Read())
            {
                btn_oda108.Text = oku8["Adi"].ToString() + " " + oku8["SoyAdi"].ToString();
            }
            if (btn_oda108.Text != "108")
            {
                btn_oda108.BackColor = Color.Red;

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

            }

            baglantı.Close();
        }

        private void btn_Oda101_Click(object sender, EventArgs e)
        {

        }
    }
}
