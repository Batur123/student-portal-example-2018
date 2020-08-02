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
    public partial class AnaMenu_Memur : Form
    {
        public AnaMenu_Memur()
        {
            InitializeComponent();
        }

        private void AnaMenu_Memur_Load(object sender, EventArgs e)
        {

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
            Memur_OgrenciTranskript a = new Memur_OgrenciTranskript();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Memur_OgrenciKayit a = new Memur_OgrenciKayit();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersKaydi_Memur a = new DersKaydi_Memur();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Memur_OgrenciBelgesi a = new Memur_OgrenciBelgesi();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Memur_OgrenciHarc a = new Memur_OgrenciHarc();
            a.Show();
            this.Hide();
        }
    }
}
