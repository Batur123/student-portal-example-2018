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
    public partial class Admin_DersEkle : Form
    {
        public Admin_DersEkle()
        {
            InitializeComponent();
        }

        public static int BolumNumarasi, SSOgretimNumarasi;

        private void derskaydetbuton_Click(object sender, EventArgs e)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
           

            var HocaKontrol = db.AkademisyenTablo.Where(hoca => hoca.AKullaniciAd == dersiverentext.Text).FirstOrDefault(); //Girişi kontrol eder.

            if(dersiverentext.Text != string.Empty && dersadtext.Text != string.Empty && derskreditext.Text != string.Empty && bolumcombo.Text !=null)
            {
                if (HocaKontrol != null) //Böyle bir akademisyen varsa çalışsın
                {
                    //===========================================================
                    //Bolum ismini ComboBoxtan alıp BolumID öğrenme
                    var BolumeAta = from p in db.BolumTablo
                                    where p.BolumAd == bolumcombo.Text
                                    select new
                                    {
                                        BolumID1 = p.BolumID,
                                    };

                    foreach (var text in BolumeAta.ToList())
                    {
                        BolumNumarasi = text.BolumID1;
                    }

                    if(BolumNumarasi == 0) //BolumeAta kontrol kısmında ComboBox'ta seçilen kısım değiştirilirse veya işlem tamamlanmazsa, bölümü bulamamış olur. Eğer bölümü bulamazsa SQL bu veriyi 0 olarak atar. Eğer 0 ise program hata verecektir.
                    {
                        MessageBox.Show("Bölümü doğru seçtiğinize emin olun. Ders Ekleme işlemi tamamlanmadı.");
                    }
                    else
                    {
                        //Bolum ismini ComboBoxtan alıp BolumID öğrenme
                        //===========================================================
                        //Akademisyen Kullanıcı Adını alıp ID'yi öğrenme
                        var HocaID = from p in db.AkademisyenTablo
                                     where p.AKullaniciAd == dersiverentext.Text
                                     select new
                                     {
                                         HocaID1 = p.OgretimID,
                                     };

                        foreach (var text in HocaID.ToList())
                        {
                            SSOgretimNumarasi = text.HocaID1;
                        }
                        //Akademisyen Kullanıcı Adını alıp ID'yi öğrenme
                        //===========================================================
                        VeritabaniOlusturma.Ders ders = new VeritabaniOlusturma.Ders
                        {
                            DersAd = dersadtext.Text,
                            BolumID = BolumNumarasi,
                            OgretimID = SSOgretimNumarasi,
                            DersKredisi = Convert.ToInt32(derskreditext.Text)

                        };

                        db.DersTablo.Add(ders);
                        db.SaveChanges();

                        MessageBox.Show("Ders başarıyla eklendi. \n Ders Adı:" + dersadtext.Text + "\nDers Kredisi:" + derskreditext.Text);
                    }                  

                }
                else
                {
                    MessageBox.Show("Dersi veren kişinin kullanıcı adı bulunamadı veya yanlış girdiniz. Lütfen Akademisyen kullanıcı adını tekrar giriniz.");
                }

            }
            else
            {
                MessageBox.Show("Lütfen boş kutucuk bırakmayınız.");
            }
           
            
        }

        private void derskreditext_KeyPress(object sender, KeyPressEventArgs e) //Ders Kredisi kısmına sadece sayı girişi yapılmasına izin verir.
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bolumcombo_KeyPress(object sender, KeyPressEventArgs e) //ComboBox'un editlenmesini yasaklar.
        {
            e.Handled = true;
        }

        private void Admin_DersEkle_Load(object sender, EventArgs e)
        {

            try
            {
                VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
                var BolumleriGetir = from c in db.BolumTablo
                                     select new
                                     {
                                         Bolum = c.BolumAd
                                     };

                bolumcombo.DataSource = BolumleriGetir.ToList();
                bolumcombo.DisplayMember = "Bolum";
                bolumcombo.ValueMember = "Bolum";
                bolumcombo.Text = ""; 
            }
            catch (Exception msg)
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + msg);
            }
        }
    }
}
