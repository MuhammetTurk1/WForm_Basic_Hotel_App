using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonUygulaması
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void btn_admingiris_Click(object sender, EventArgs e)
        {
           FrmAdminGiris a = new FrmAdminGiris();
            a.ShowDialog();
        }

        private void btn_YeniMüsteri_Click(object sender, EventArgs e)
        {
            FrmYeniMüsteri A = new FrmYeniMüsteri();
            A.ShowDialog();
        }

        private void btn_Odalar_Click(object sender, EventArgs e)
        {
            FrmOdalar a = new FrmOdalar();
            a.ShowDialog();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            lbl_Tarih1.Text=DateTime.Now.ToLongDateString();
            lbl_tarih2.Text=DateTime.Now.ToLongTimeString();
        }

        private void btn_GelirGider_Click(object sender, EventArgs e)
        {
            FrmGelirGider k = new FrmGelirGider();
            k.ShowDialog();
        }

        private void btn_Stoklar_Click(object sender, EventArgs e)
        {
            new FrmStoklar().ShowDialog();
        }

        private void btn_Cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

         
    }
}
