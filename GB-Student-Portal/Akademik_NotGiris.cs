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

        public static int BolumNumarasi;
        public static int SSDersID;

        private void notverbuton_Click(object sender, EventArgs e)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();

            int Vize, Final,Butunleme;
            double Ortalama;
            Vize = Convert.ToInt32(vizeBox.Text); //TextBox'a gelen verileri değişkenlere atayıp ortalama hesaplar.
            Final = Convert.ToInt32(finalBox.Text);
            Ortalama = Vize * 0.4 + Final * 0.6; //Ortalama Vize %40 , Final %60'ı alınır.
            ortBox.Text = Ortalama.ToString();

            try
            {
                if (db.BolumTablo.Any(u => u.BolumAd == BolumCombo.Text)) //ComboBoxta seçilen bölüm sistemde var mı diye kontrol eder.
                {
                    if (db.OgrenciNotTablo.Any(u => u.ONumara == ognoTextBox.Text)) //Öğrenciye girilen not ve dersi daha önce girilmişmi diye kontrol eder. Eğer girilmişse Güncellenir, girilmemişse ilk defa insert edilir.
                    {
                      
                        var BolumKontrol2 = db.BolumTablo.Where(bolum1 => bolum1.BolumAd == BolumCombo.Text).FirstOrDefault(); //Girişi kontrol eder.

                        if (BolumKontrol2 != null) //Böyle bir bölüm varsa çalışsın
                        {
                            var BolumIDOgren = from p in db.BolumTablo
                                            where p.BolumAd == BolumCombo.Text
                                            select new
                                            {
                                                BolumID1 = p.BolumID,
                                            };

                            foreach (var text in BolumIDOgren.ToList())
                            {
                                BolumNumarasi = text.BolumID1;
                            }

                            var DersNoOgren = from p in db.DersTablo
                                              where p.DersAd == DersCombo.Text
                                              select new
                                              {
                                                  DersID1 = p.DersID,
                                              };

                            foreach (var text in DersNoOgren.ToList())
                            {
                                SSDersID = text.DersID1;
                            }

                            if(BolumNumarasi == 0 || SSDersID == 0)
                            {
                                MessageBox.Show("Bölüm ismi veya Ders ismi yanlış seçilmiş olabilir. Lütfen tekrar deneyiniz. Ders kaydı tamamlanmadı.");
                            }
                            else
                            {
                                var notguncelle =
                                                        from not in db.OgrenciNotTablo
                                                        where not.ONumara == ognoTextBox.Text /*&& ord.DersID == Convert.ToInt32(DersCombo.Text)*/
                                                        select not;

                                foreach (var not in notguncelle)
                                {
                                    not.Vize = Convert.ToInt32(vizeBox.Text);
                                    not.Final = Convert.ToInt32(finalBox.Text);
                                    not.BolumID = BolumNumarasi;
                                    not.DersID = SSDersID;
                                    not.Ortalama = Convert.ToDouble(ortBox.Text);

                                }
                                try
                                {
                                    db.SaveChanges();
                                    MessageBox.Show("Öğrencinin ders notları zaten önceden verilmiş olduğu için tekrar yeni değerler ile güncellendi.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bir hata oluştuç \n\n " + ex);
                                }
                            }                         
                        }
                        else
                        {
                            MessageBox.Show("Bölüm yok?");
                        }
                    }
                    else //İlk defa not verilcekse burası çalışır?
                    {
                        VeritabaniOlusturma.OgrenciNot ogr = new VeritabaniOlusturma.OgrenciNot
                        {
                            ONumara = ognoTextBox.Text, //Öğrenci Numarası
                            Vize = Convert.ToInt32(vizeBox.Text),
                            Final = Convert.ToInt32(finalBox.Text),
                            Ortalama = Convert.ToInt32(ortBox.Text),
                            DersID = SSDersID,
                            BolumID = BolumNumarasi,
                        };

                        db.OgrenciNotTablo.Add(ogr);
                        db.SaveChanges();

                        MessageBox.Show("Not kaydı yapıldı.");
                    }            
                }
                else
                {
                    MessageBox.Show("Böyle bir bölüm bulunmamaktadır. Lütfen tekrar deneyiniz");
                }                        
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
