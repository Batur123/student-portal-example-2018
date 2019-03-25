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
        public Class_Admin AdminGiris(string KullaniciAdi,string Sifre)
        {
            Class_Admin kisi = null;
            try
            {
                var giriskontrol = db.AdminTablo.Where(kisi22 => kisi22.AdminKullaniciAdi == KullaniciAdi && kisi22.AdminSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.

                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
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
                        kisi.AdminSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Admin a = new AnaMenu_Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            return kisi;
        }
        
        public Class_Akademisyen AkademiGiris(string KullaniciAdi, string Sifre)
        {
            Class_Akademisyen kisi = null;
            try
            {
                var giriskontrol = db.AdminTablo.Where(kisi22 => kisi22.AdminKullaniciAdi == KullaniciAdi && kisi22.AdminSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.
                
                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
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
                        kisi = new Class_Akademisyen();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Admin a = new AnaMenu_Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            return kisi;
        }

        public Class_Ogrenci OgrenciGiris(string KullaniciAdi, string Sifre)
        {
            Class_Ogrenci kisi = null;
            try
            {
                var giriskontrol = db.AdminTablo.Where(kisi22 => kisi22.AdminKullaniciAdi == KullaniciAdi && kisi22.AdminSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.

                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
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
                        kisi = new Class_Ogrenci();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Admin a = new AnaMenu_Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            return kisi;
        }

        public Class_Memur MemurGiris(string KullaniciAdi, string Sifre)
        {
            Class_Memur kisi = null;
            try
            {
                var giriskontrol = db.AdminTablo.Where(kisi22 => kisi22.AdminKullaniciAdi == KullaniciAdi && kisi22.AdminSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.

                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
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
                        kisi = new Class_Memur();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Admin a = new AnaMenu_Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            return kisi;
        }



    }
}
