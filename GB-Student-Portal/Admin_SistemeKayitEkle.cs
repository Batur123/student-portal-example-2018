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
    public partial class Admin_SistemeKayitEkle : Form
    {
        public Admin_SistemeKayitEkle()
        {
            InitializeComponent();
        }

        private void Admin_SistemeKayitEkle_Load(object sender, EventArgs e)
        {
            if (memurcheck.Checked)
            {
                try
                {

                    VeritabaniOlusturma.ProjeVeritabani Veri = new VeritabaniOlusturma.ProjeVeritabani();
                    Veri.Database.Create();

                    int[] YetkiNumaralari = new int[] { 0, 1, 2, 3, 4 };
                    string[] YetkiAdlari = new string[] { "NULL", "Akademisyen", "Memur", "Ogrenci", "Admin" };

                    string AdminKullanici = "Admin";
                    string AdminSifre = "Sifre123";
                    int YetkiNo = 4;

                    VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                    VeritabaniOlusturma.Admin admin = new VeritabaniOlusturma.Admin();

                    admin.AdminKullaniciAdi = AdminKullanici;
                    admin.AdminSifre = AdminSifre;
                    admin.YetkiNumarasi = YetkiNo;

                    ct.AdminTablo.Add(admin);
                    ct.SaveChanges();

                }
                catch (Exception mesaj)
                {
                    MessageBox.Show("Bir hata oluştu" + mesaj);
                }
            }
            else if (hocacheck.Checked)
            {

            }

        }

        private void memurcheck_CheckedChanged(object sender, EventArgs e)
        {
            hocacheck.Checked = false;
          
        }

        private void hocacheck_CheckedChanged(object sender, EventArgs e)
        {
            memurcheck.Checked = false;
  
        }
    }
}
