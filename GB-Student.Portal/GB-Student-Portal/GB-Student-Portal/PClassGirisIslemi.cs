using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB_Student_Portal
{
    public class PClassGirisIslemi
    {
        VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
        public Class_Admin GirisKontrol(string KullaniciAdi,string Sifre)
        {
           

            var AdminGiris = db.AdminTablo.FirstOrDefault(a => a.AdminKullaniciAdi == KullaniciAdi); // çalışmıyor
            Class_Admin kisi = null;
            if (AdminGiris != null)
            {
                if (AdminGiris.AdminSifre.Equals(kisi.AdminSifre))
                {
                    var Secim222 = from p in db.AdminTablo
                                   where p.AdminKullaniciAdi == KullaniciAdi
                                   select new
                                   {

                                       KAD = p.AdminKullaniciAdi,
                                       KSIFRE = p.AdminSifre,
                                       
                                      

                                   };

                    foreach (var text in Secim222.ToList())
                    {
                        kisi = new Class_Admin();
                        kisi.AdminKAD = text.KAD;
                        kisi.AdminSifre = text.KSIFRE;
                        

                        
                    }
                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Admin a = new AnaMenu_Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz."); //Şifren yanlışsa bu yazı çıkar.
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz."); //Tabloda kayıtlı kullanıcı yoksa bu yazı çıkar.
            }

            return kisi;
        }
        


    }
}
