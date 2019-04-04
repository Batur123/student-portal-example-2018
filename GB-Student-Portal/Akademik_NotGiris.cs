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
    public partial class Akademik_NotGiris : Form
    {
        public Akademik_NotGiris()
        {
            InitializeComponent();
        }

        private void notverbuton_Click(object sender, EventArgs e)
        {
            try
            {

             /*   VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                VeritabaniOlusturma.Ogrenci ogr = new VeritabaniOlusturma.Ogrenci
                {
                    ONumara = KAdiBox.Text, //Öğrenci Numarası
                    OSifre = soyisimbox.Text, //Şifre
                    OAd = KAdiBox.Text, //Adı
                    OSoyad = KSifreBox.Text, //Soyadı
                    SistemeKayit = 1, //Sisteme Kayıt Edildi.
                    DersKaydi = 0, // 0: Ders Kaydı Yapılmamış.
                    IkinciOgretim = 0 //0: Birinci Öğretim 1: İkinci Öğretim

                };

                ct.OgrenciTablo.Add(ogr);
                ct.SaveChanges(); */

                MessageBox.Show("Öğrenci kayıt işleminiz başarıyla tamamlandı.");
            }
            catch (Exception ex) //Exception yakalama...
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaMenu_Akademisyen a = new AnaMenu_Akademisyen();
            a.Show();
            this.Hide();
        }

        private void Akademik_NotGiris_Load(object sender, EventArgs e)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();

            var BolumleriGetir = from c in db.BolumTablo
            select new
            {
                Name = c.BolumAd
            };

            Dim q = From a In db.tblCompanies _
                    Where a.intUserID = _intUserID
                    Select a

            Me.cboCompany.DataSource = q.ToList()
            Me.cboCompany.DisplayMember = "vchCompanyName"
            Me.cboCompany.ValueMember = "intCompanyID"
        }
    }
}
