using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB_Student_Portal
{
    public partial class AnaMenu_Akademisyen : Form
    {
        public AnaMenu_Akademisyen()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Genel_GirisYapEkrani a = new Genel_GirisYapEkrani();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Akademik_NotGiris a = new Akademik_NotGiris();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Akademik_VerilenDersler a = new Akademik_VerilenDersler();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports ile Personel Kartı gösterme ekranı... Yapım Aşamasında");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Akademik_SifreDegis a = new Akademik_SifreDegis();
            a.Show();
            this.Hide();
        }
    }
}
