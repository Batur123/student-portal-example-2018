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
    public partial class Memur_OgrenciKayit : Form
    {
        public Memur_OgrenciKayit()
        {
            InitializeComponent();
        }

        private void GirisButon_Click(object sender, EventArgs e)
        {

            if (birinciogretim.Checked)
            {

                if (KAdiBox.Text != string.Empty && KSifreBox.Text != string.Empty && isimbox.Text != string.Empty && soyisimbox.Text != string.Empty) //Eğer boş değilse kayıt tamamlanır.
                {

                    try
                    {

                        VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                        VeritabaniOlusturma.Ogrenci ogr = new VeritabaniOlusturma.Ogrenci
                        {
                            ONumara = KAdiBox.Text, //Öğrenci Numarası
                            OSifre = soyisimbox.Text, //Şifre
                            OAd = KAdiBox.Text, //Adı
                            OSoyad = KSifreBox.Text, //Soyadı
                            SistemeKayit = 1, //Sisteme Kayıt Edildi.
                            DersKaydi = 0, // 0: Ders Kaydı Yapılmamış.
                            IkinciOgretim = 0, //0: Birinci Öğretim 1: İkinci Öğretim
                            

                        };

                        ct.OgrenciTablo.Add(ogr);
                        ct.SaveChanges();

                        MessageBox.Show("Öğrenci kayıt işleminiz başarıyla tamamlandı.");
                    }
                    catch (Exception ex) //Exception yakalama...
                    {
                        MessageBox.Show("Bir hata oluştu. \n\n" + ex);
                    }

                }
                else
                {

                    MessageBox.Show("Lütfen Kullanıcı adı,Şifre,İsim,Soyisim veya Ünvan isimli kutucuklardan birini boş bırakmayınız. Aksi takdirde kayıt işlemi gerçekleştirilmeyecektir.");

                }
            }
            else if (kinciogretim.Checked)
            {
                if (KAdiBox.Text != string.Empty && KSifreBox.Text != string.Empty && isimbox.Text != string.Empty && soyisimbox.Text != string.Empty) //Eğer boş değilse kayıt tamamlanır.
                {

                    try
                    {

                        VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                        VeritabaniOlusturma.Ogrenci ogr = new VeritabaniOlusturma.Ogrenci
                        {
                            ONumara = KAdiBox.Text, //Öğrenci Numarası
                            OSifre = soyisimbox.Text, //Şifre
                            OAd = KAdiBox.Text, //Adı
                            OSoyad = KSifreBox.Text, //Soyadı
                            SistemeKayit = 1,
                            DersKaydi = 0,
                            IkinciOgretim = 1
                        };

                        ct.OgrenciTablo.Add(ogr);
                        ct.SaveChanges();

                        MessageBox.Show("Öğrenci kayıt işleminiz başarıyla tamamlandı.");
                    }
                    catch (Exception ex) //Exception yakalama...
                    {
                        MessageBox.Show("Bir hata oluştu. \n\n" + ex);
                    }

                }
                else
                {

                    MessageBox.Show("Lütfen Kullanıcı adı,Şifre,İsim,Soyisim veya Ünvan isimli kutucuklardan birini boş bırakmayınız. Aksi takdirde kayıt işlemi gerçekleştirilmeyecektir.");

                }
            }
            else
            {
                MessageBox.Show("Birinci veya ikinci öğretim türünden birini seçmek zorundasınız. Lütfen seçtikten sonra kayıt işlemi için tekrar deneyiniz.");
            }


        }

        private void birinciogretim_CheckedChanged(object sender, EventArgs e)
        {
            kinciogretim.Checked = false;
            birinciogretim.Checked = true;

        }

        private void kinciogretim_CheckedChanged(object sender, EventArgs e)
        {
            birinciogretim.Checked = false;
            kinciogretim.Checked = true;

        }

        private void Memur_OgrenciKayit_Load(object sender, EventArgs e)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani(); //Database erişimi.
                                                                                                //================================================================================================
                                                                                                //Bölüm isimlerini Combobox'a Getirme
            var BolumleriGetir = from c in db.BolumTablo
                                 select new
                                 {
                                     Bolum = c.BolumAd
                                 };

            bolumcombobox.DataSource = BolumleriGetir.ToList(); //BolumleriGetir isimli var query değişkenimizi liste olarak ComboBox'un veri kaynağına aktarılıyor.
            bolumcombobox.DisplayMember = "Bolum"; //Bolum isimli kısım LINQ Query'sinde c.BolumAd olarak belirlenmiştir.
            bolumcombobox.ValueMember = "Bolum";
            bolumcombobox.Text = ""; //Açılışta rastgele bir bölüm seçilmesin diye ComboBox sorgu işleminden sonra temizlenir. Bunun sebebi boş gözükmesi içindir.
                                  //Bölüm isimlerini Combobox'a Getirme
        }
    }
}


