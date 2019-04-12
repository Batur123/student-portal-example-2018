using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Ek Not: Burası o kadar karışık ki NASA da çalışan adam gelse anlayamaz. Gerisini sizdüşünün. 

namespace GB_Student_Portal
{
    public class AClass_NotGirme 
    {
        

        public static int DersNOO, BolumNOO;
        public static string BolumAD, DersAD;
        public Class_Not NotGiris(int Vize,int Final,bool ButeGirdi,string OgrenciNo,string BolumAdi,string DersAdi)
        {
            Class_Not notgir = new Class_Not();
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();

            //Değerleri Belirleme
            int SVize, SFinal,SButunleme;
            string SOgrenciNo, SBolumAdi, SDersAdi;
            double SOrtalama,SButOrt;
            bool ButKontrol;

            //Değerleri Aktarma
            SVize = Vize;
            SFinal = Final;
            SOgrenciNo = OgrenciNo;
            SBolumAdi = BolumAdi;
            SDersAdi = DersAdi;
            ButKontrol = ButeGirdi;
            SOrtalama = SVize * 0.4 + SFinal * 0.6;
            
            
               
            try
            {
                if (ButeGirdi == true)
                {

                }
                else
                {
                    if (db.BolumTablo.Any(u => u.BolumAd == SBolumAdi) && db.DersTablo.Any(u => u.DersAd == SDersAdi)) //ComboBoxta seçilen bölüm ve ders adı sistemde var mı diye kontrol eder.
                    {
                        if (db.OgrenciNotTablo.Any(u => u.ONumara == SOgrenciNo && u.DersID == DersNOO && u.BolumID == BolumNOO)) //Öğrenciye girilen not ve dersi daha önce girilmişmi diye kontrol eder. Eğer girilmişse Güncellenir, girilmemişse ilk defa insert edilir.
                        {
                            if (DersNOO == 0 || BolumNOO == 0)
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
                                    MessageBox.Show("Öğrencinin notları başarıyla güncellendi.");
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

                            MessageBox.Show("Not kaydı yapıldı.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Böyle bir bölüm bulunmamaktadır. Lütfen tekrar deneyiniz");
                    }
                }
            }
            catch (Exception ex) //Exception yakalama...
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + ex);
            }

            return notgir;
        }


        public Class_Ders DersAl(string DersAdi)
        {
            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
            Class_Ders a = new Class_Ders();

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

            return a;
        }

        public Class_Bolum BolumAl(string BolumAdi)
        {

            VeritabaniOlusturma.ProjeVeritabani db = new VeritabaniOlusturma.ProjeVeritabani();
            Class_Bolum a = new Class_Bolum();

            a.BolumIsmi = BolumAdi;
            BolumAD = BolumAdi;

            var BolumIDOgren = from p in db.BolumTablo
                               where p.BolumAd == BolumAdi
                               select new
                               {
                                   BolumID1 = p.BolumID,
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
