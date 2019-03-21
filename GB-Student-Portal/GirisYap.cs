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
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }

        public Class_Admin user2;
        public PClassGirisIslemi islem2;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            /* VeritabaniOlusturma.ProjeVeritabani secim = new VeritabaniOlusturma.ProjeVeritabani();
             var urunler = from p in secim.YetkiSeviyesi
                           select new
                           {
                               Ürün_Numarası = p.ID,
                               Ürün_Adı = p.Adi,
                               Ürün_Miktarı = p.Miktar,
                               Kilogram_Fiyatı = p.KilogramFiyati

                           }; */
        }

        private void AdminButon_Click(object sender, EventArgs e)
        {



        }

        private void GirisButon_Click(object sender, EventArgs e)
        {

        }

        private void GirisButon_Click_1(object sender, EventArgs e)
        {
            VeritabaniOlusturma.ProjeVeritabani dc = new VeritabaniOlusturma.ProjeVeritabani();
           
            
           



            if (KAdiBox.Text != string.Empty && KSifreBox.Text != string.Empty && comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Öğrenci")
                {
                    var OgrenciGiris = dc.OgrenciTablo.FirstOrDefault(a => a.ONumara.Equals(KAdiBox.Text));

                    if (OgrenciGiris != null)
                    {
                        if (OgrenciGiris.ONumara.Equals(KSifreBox.Text))
                        {
                            MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                            AnaMenu_Ogrenci ac = new AnaMenu_Ogrenci();
                            ac.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Akademisyen")
                {
                    var AkademisyenGiris = dc.AkademisyenTablo.FirstOrDefault(a => a.AKullaniciAd.Equals(KAdiBox.Text));

                    if (AkademisyenGiris != null)
                    {
                        if (AkademisyenGiris.ASifre.Equals(KSifreBox.Text))
                        {
                            MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                            AnaMenu_Akademisyen ac = new AnaMenu_Akademisyen();
                            ac.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Memur")
                {

                    var MemurGiris = dc.GorevliMemur.FirstOrDefault(a => a.GKullaniciAd.Equals(KAdiBox.Text));
                    if (MemurGiris != null)
                    {
                        if (MemurGiris.GSifre.Equals(KSifreBox.Text))
                        {
                            MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                            AnaMenu_Memur ac = new AnaMenu_Memur();
                            ac.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                    }
                }

                else if (comboBox1.SelectedItem.ToString() == "Admin")
                {
                    

                    try
                    {
                        islem2 = new PClassGirisIslemi();
                        user2 = islem2.GirisKontrol(KAdiBox.Text, KSifreBox.Text);
                        //this.Hide();
                        if (user2 != null)
                        {
                            this.Hide();
                        }
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Bir hata oluştu. \n");
                        MessageBox.Show(hata.Message);
                    }

                 
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre kısmını boş bırakmayınız. Giriş türünüde seçmeyi unutmayınız.");
            }
        }
    }
}