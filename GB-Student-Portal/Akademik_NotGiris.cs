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

             /* VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
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

            try
            {
                VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani(); //Database erişimi.
                //================================================================================================
                //Bölüm isimlerini Combobox'a Getirme
                var BolumleriGetir = from c in db.BolumTablo
                                     select new
                                     {
                                         Bolum = c.BolumAd
                                     };

                BolumCombo.DataSource = BolumleriGetir.ToList(); //BolumleriGetir isimli var query değişkenimizi liste olarak ComboBox'un veri kaynağına aktarılıyor.
                BolumCombo.DisplayMember = "Bolum"; //Bolum isimli kısım LINQ Query'sinde c.BolumAd olarak belirlenmiştir.
                BolumCombo.ValueMember = "Bolum";
                BolumCombo.Text = ""; //Açılışta rastgele bir bölüm seçilmesin diye ComboBox sorgu işleminden sonra temizlenir. Bunun sebebi boş gözükmesi içindir.
               //Bölüm isimlerini Combobox'a Getirme
               //================================================================================================
               //Ders isimlerini Combobox'a Getirme
                var DersleriGetir = from c in db.DersTablo
                                    select new
                                    {
                                        Ders = c.DersAd
                                    };

                DersCombo.DataSource = DersleriGetir.ToList();
                DersCombo.DisplayMember = "Ders";
                DersCombo.ValueMember = "Ders";
                DersCombo.Text = "";
                //Ders isimlerini Combobox'a Getirme
                //================================================================================================
            }
            catch (Exception msg)
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + msg);
            }
            
        }

        private void ButGirdiCheckBox_Click(object sender, EventArgs e)
        {
            if(butBox.ReadOnly == true)
            {
                butBox.ReadOnly = false;
                butBox.Clear();
            }
            else if(butBox.ReadOnly == false)
            {
                butBox.ReadOnly = true;
                butBox.Clear();
            }
            else
            {
                MessageBox.Show("Hata");
            }
            
        }
    }
}
