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
    public partial class DersKaydi_Akademisyen : Form
    {
        public DersKaydi_Akademisyen()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AnaMenu_Akademisyen a = new AnaMenu_Akademisyen();
            a.Show();
            this.Hide();
        }
    }
}
