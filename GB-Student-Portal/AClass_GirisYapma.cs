using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB_Student_Portal
{


    public class AClass_GirisYapma
    { 

        VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani(); //Database Erişimi - Erişim Yeri-> Veritabanı Oluşturma Formu
        public Class_Admin AdminGiris(string KullaniciAdi,string Sifre) //Admin Girişi 
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
        
        public Class_Akademisyen AkademiGiris(string KullaniciAdi, string Sifre) //Akademisyen Girişi
        {
            Class_Akademisyen kisi = null;
            try
            {
                var giriskontrol = db.AkademisyenTablo.Where(kisi22 => kisi22.AKullaniciAd == KullaniciAdi && kisi22.ASifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.
                
                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
                {
                    var Secim222 = from p in db.AkademisyenTablo
                                   where p.AKullaniciAd == KullaniciAdi
                                   select new
                                   {
                                       KAD = p.AKullaniciAd,
                                       KSIFRE = p.ASifre,
                                   };

                    foreach (var text in Secim222.ToList())
                    {
                        kisi = new Class_Akademisyen();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Akademisyen a = new AnaMenu_Akademisyen();
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

        public Class_Ogrenci OgrenciGiris(string OgrenciNO, string Sifre) //Öğrenci Gİrişi
        {
            Class_Ogrenci kisi = null;
            try
            {
                var giriskontrol = db.OgrenciTablo.Where(kisi22 => kisi22.ONumara == OgrenciNO && kisi22.OSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.

                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
                {
                    var Secim222 = from p in db.OgrenciTablo
                                   where p.ONumara == OgrenciNO
                                   select new
                                   {
                                       KAD = p.ONumara,
                                       KSIFRE = p.OSifre,
                                   };

                    foreach (var text in Secim222.ToList())
                    {
                        kisi = new Class_Ogrenci();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Ogrenci a = new AnaMenu_Ogrenci();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Öğrenci numaranızı veya şifrenizi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

            return kisi;
        }

        public Class_Memur MemurGiris(string KullaniciAdi, string Sifre) //Memur Girişi
        {
            Class_Memur kisi = null;
            try
            {
                var giriskontrol = db.GorevliMemur.Where(kisi22 => kisi22.GKullaniciAd == KullaniciAdi && kisi22.GSifre == Sifre).FirstOrDefault(); //Girişi kontrol eder.

                if (giriskontrol != null) //Giriş doğru ise bu kısım çalışır.
                {
                    var Secim222 = from p in db.GorevliMemur
                                   where p.GKullaniciAd == KullaniciAdi
                                   select new
                                   {
                                       KAD = p.GKullaniciAd,
                                       KSIFRE = p.GSifre,
                                   };

                    foreach (var text in Secim222.ToList())
                    {
                        kisi = new Class_Memur();
                        kisi.KullaniciAdi = text.KAD;
                        kisi.KullaniciSifre = text.KSIFRE; //Class'a bilgileri kaydeder.
                    }

                    MessageBox.Show("Başarıyla giriş yaptınız! Yönetici paneline yönlendiriliyorsunuz...");
                    AnaMenu_Memur a = new AnaMenu_Memur();
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
