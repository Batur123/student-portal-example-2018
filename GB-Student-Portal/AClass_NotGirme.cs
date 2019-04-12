using System;
using System.Collections.Generic; 
using System.Linq; //LINQ to SQL araçlarına erişim.
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //MessageBox ları göstermek için bunu kullanmak zorunda kaldık. Yoksa kabul etmiyor. Form Kütüphanesi 

// Ek Not: Burası o kadar karışık ki NASA da çalışan adam gelse anlayamaz. Gerisini sizdüşünün. 

namespace GB_Student_Portal
{
    public class AClass_NotGirme 
    {
        
        public static int DersNOO, BolumNOO;
        public static string BolumAD, DersAD; //Bunlar işte garip değerler. Görmezden geliniz. En aşağıdaki fonksiyonları çalıştırıyor.

        public Class_Not NotGiris(int Vize,int Final,int Butunleme,bool ButeGirdi,string OgrenciNo,string BolumAdi,string DersAdi) //vize,final,but,butkontrol,ogno,bolumad,dersad
        {
            Class_Not notgir = new Class_Not(); //class i çağır ve nesnesini oluştur
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani(); //veritabanı ana dizin erişim kodu

            //Değerleri Belirleme
            int SVize, SFinal,SButunleme;
            string SOgrenciNo, SBolumAdi, SDersAdi;
            double SOrtalama;
            bool ButKontrol;

            //Değerleri Aktarma
            SVize = Vize;
            SFinal = Final;
            SOgrenciNo = OgrenciNo;
            SBolumAdi = BolumAdi;
            SDersAdi = DersAdi;
            ButKontrol = ButeGirdi;
            SButunleme = Butunleme;

            //Ek Not: Kodları daha performanslı bir şekilde nasıl çalıştıracağımı çözemediğim için aynı kodları 2 kere kopyalamadım. Bu yüzden ButeGirdi Boolean değişkeni True veya False gelirse 
            // yine bi ton işlem yapmak zorunda kalıyor.

            

            try
            {
                if (ButeGirdi == true) //Eğer öğrenci bütünlemeye girdiyse çalıştırılır.
                {
                    SOrtalama = SVize * 0.4 + SButunleme * 0.6; //Vize ve Bütünlemenin Ortalaması Alınır.

                    if (db.BolumTablo.Any(u => u.BolumAd == SBolumAdi) || db.DersTablo.Any(u => u.DersAd == SDersAdi)) //ComboBoxta seçilen bölüm ve ders adı sistemde var mı diye kontrol eder.
                    {
                        if (db.OgrenciNotTablo.Any(u => u.ONumara == SOgrenciNo && u.DersID == DersNOO && u.BolumID == BolumNOO)) //Öğrenciye girilen not ve dersi daha önce girilmişmi diye kontrol eder. Eğer girilmişse Güncellenir, girilmemişse ilk defa insert edilir.
                        {
                            if (DersNOO == 0 || BolumNOO == 0) //Normalde seçtiğiniz bölüm veya ders sistemde yoksa döndürülen değer 0 olur. O yüzden 0 olursa yanlış seçmiş anlamına gelir.
                            {
                                MessageBox.Show("Bölüm ismi veya Ders ismi yanlış seçilmiş olabilir. Lütfen tekrar deneyiniz. Ders kaydı tamamlanmadı."); //msj
                            }
                            else
                            {
                                try //muhtar
                                {
                                    var notss = db.OgrenciNotTablo.First(u => u.ONumara == SOgrenciNo && u.DersID == DersNOO && u.BolumID == BolumNOO); //Güncelleme işlemini Öğrenci No,Ders ID ve Bölüm ID'ye göre yapıyor.

                                    //Değerleri Aktarma
                                    notss.Vize = SVize;
                                    notss.Butunleme = SButunleme;
                                    notss.Ortalama = SOrtalama;
                                    notss.BolumID = BolumNOO;
                                    notss.DersID = DersNOO;

                                    //Değişiklikleri DB isimli veritabanı erişimine kaydetme.
                                    db.SaveChanges();
                                    MessageBox.Show("Öğrencinin vize ve bütünleme notları başarıyla güncellendi");
                                }
                                catch (Exception msj) //hata msj
                                {
                                    MessageBox.Show("Bir hata oluştu. \n\n " + msj); //hata msj
                                }
                            }
                        }
                        else //İlk defa not verilcekse burası çalışır?
                        {
                            VeritabaniOlusturma.OgrenciNot ogr = new VeritabaniOlusturma.OgrenciNot //veritabanı öğrenci not tablosu erişim kodu
                            { 
                                //Değerleri Aktarma
                                ONumara = OgrenciNo, 
                                Vize = SVize,
                                Final = SFinal,
                                Ortalama = SOrtalama,
                                DersID = DersNOO,
                                BolumID = BolumNOO,
                            };

                             
                            db.OgrenciNotTablo.Add(ogr); //Değerleri Ogrenci Not Tablosuna ekleme
                            db.SaveChanges(); //Değişiklikleri kaydetme

                            MessageBox.Show("Bu öğrencinin bölümüne ve dersine ilk defa not girişi yapıldığı tespit edildi. Öğrencinin vize ve bütünleme notları başarıyla verildi.");
                        }
                    }
                    else //Eğer öğrenci bütünlemeye girmediyse çalıştırılır.
                    {
                        SOrtalama = SVize * 0.4 + SFinal * 0.6; //Vize ve Final'in Ortalaması Alınır.

                        if (db.BolumTablo.Any(u => u.BolumAd == SBolumAdi) || db.DersTablo.Any(u => u.DersAd == SDersAdi)) //ComboBoxta seçilen bölüm ve ders adı sistemde var mı diye kontrol eder.
                        {
                            if (db.OgrenciNotTablo.Any(u => u.ONumara == SOgrenciNo && u.DersID == DersNOO && u.BolumID == BolumNOO)) //Öğrenciye girilen not ve dersi daha önce girilmişmi diye kontrol eder. Eğer girilmişse Güncellenir, girilmemişse ilk defa insert edilir.
                            {
                                if (DersNOO == 0 || BolumNOO == 0) //açıklaması üstte yazıyor
                                {
                                    MessageBox.Show("Bölüm ismi veya Ders ismi yanlış seçilmiş olabilir. Lütfen tekrar deneyiniz. Ders kaydı tamamlanmadı.");
                                }
                                else
                                {
                                    try
                                    {
                                        var notss = db.OgrenciNotTablo.First(u => u.ONumara == SOgrenciNo && u.DersID == DersNOO && u.BolumID == BolumNOO);

                                        notss.Vize = SVize;
                                        notss.Final = SFinal;
                                        notss.Ortalama = SOrtalama;
                                        notss.BolumID = BolumNOO;
                                        notss.DersID = DersNOO;
                                        db.SaveChanges();
                                        MessageBox.Show("Öğrencinin vize ve final notları başarıyla güncellendi.");
                                    }
                                    catch (Exception msj)
                                    {
                                        MessageBox.Show("Bir hata oluştu. \n\n " + msj);
                                    }
                                }
                            }
                            else //İlk defa not verilcekse burası çalışır?
                            {
                                VeritabaniOlusturma.OgrenciNot ogr = new VeritabaniOlusturma.OgrenciNot
                                {
                                    ONumara = OgrenciNo, //Öğrenci Numarası
                                    Vize = SVize,
                                    Final = SFinal,
                                    Ortalama = SOrtalama,
                                    DersID = DersNOO,
                                    BolumID = BolumNOO,
                                };

                                db.OgrenciNotTablo.Add(ogr);
                                db.SaveChanges();

                                MessageBox.Show("Bu öğrencinin bölüme ve dersine ilk defa not girişi yapıldığı tespit edildi. Öğrencinin vize ve final notları başarıyla verildi.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle bir bölüm veya ders sistemde bulunmamaktadır. Lütfen tekrar deneyiniz");
                        }
                    }
                }
            }
            catch (Exception ex) //Exception yakalama...
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + ex);
            }

            return notgir; //Null döndürürse hata verir. Program çöker?
        }


        public Class_Ders DersAl(string DersAdi)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani(); //db erişim
            Class_Ders a = new Class_Ders(); //ders a nesnesi olustur

            a.DersAdii = DersAdi;
            DersAD = DersAdi;

            var DersNoOgren = from p in db.DersTablo //Ders Adını alıp ID'sini öğrenme
                              where p.DersAd == DersAdi
                              select new
                              {
                                  DersID1 = p.DersID, 
                              };

            foreach (var text in DersNoOgren.ToList()) //Öğrenilen ID'yi aktarma ? Ama nereye aktarıyo
            {
                a.DersNumarasi = text.DersID1;
                DersNOO = text.DersID1;
            }

            return a; //döndür
        }

        public Class_Bolum BolumAl(string BolumAdi)
        {

            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
            Class_Bolum a = new Class_Bolum();

            a.BolumIsmi = BolumAdi;
            BolumAD = BolumAdi;

            var BolumIDOgren = from p in db.BolumTablo //Bölüm Adını alıp ID'sini öğrenme
                               where p.BolumAd == BolumAdi
                               select new
                               {
                                   BolumID1 = p.BolumID, //Öğrenilen ID'yi aktarma. Bir yere aktarıyor işte
                               };

            foreach (var text in BolumIDOgren.ToList())
            {
                a.BolumNumara = text.BolumID1;
                BolumNOO = text.BolumID1;
                
               
            }

            return a;
        }
    }
}
