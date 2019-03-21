using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity; //Entityframework Kütüphanesi
using System.ComponentModel.DataAnnotations; //Primary Key belirlemek için gerekli olan kütüphane

namespace GB_Student_Portal
{
    public partial class VeritabaniOlusturma : Form
    {
        public VeritabaniOlusturma()
        {
            InitializeComponent();
        }

        private void DatabaseCreateForm_Load(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 10;
            timer1.Interval = 5000;
            timer1.Start();
        }

        public class Ogrenci
        {
            [Key]
            public int OgrenciID { get; set; }
            public string ONumara { get; set; }
            public string OSifre { get; set; }
            public string OAd { get; set; }
            public string OSoyad { get; set; }
            public string OTCKimlik { get; set; }
            public int YetkiNumarasi { get; set; }
            public int DersKaydi { get; set; } // 1= onaylanmamis , 2=taslaga gonderilmis , 3=akademisyen onaylamis , 4=memur onaylamis ve Ders Kaydi onaylanmis
            public int SistemeKayit { get; set; } //1=onaylanmamis , 2=onaylanmis

        }
        public class OgrenciNot
        {
            [Key]
            public int ID { get; set; }
            public string ONumara { get; set; }
            public int DersID { get; set; }
            public int Vize { get; set; }
            public int Final { get; set; }
            public int Butunleme { get; set; }
            public double Ortalama { get; set; }
        }

        public class Akademisyen
        {
            [Key]
            public int OgretimID { get; set; }
            public string AKullaniciAd { get; set; }
            public string ASifre { get; set; }
            public string AAd { get; set; }
            public string ASoyad { get; set; }
            public string AUnvan { get; set; }
            public string ABolumID { get; set; }
            public int YetkiNumarasi { get; set; }
          //  public int SistemeKayit { get; set; } //1=onaylanmamis , 2=onaylanmis
        }

        public class OgrenciIsleriGorevlisi
        {
            [Key]
            public int GorevliID { get; set; }
            public string GKullaniciAd { get; set; }
            public string GSifre { get; set; }
            public string GAd { get; set; }
            public string GSoyad { get; set; }
            public int YetkiNumarasi { get; set; }
           // public int SistemeKayit { get; set; } //1=onaylanmamis , 2=onaylanmis
        }

        public class Ders
        {
            [Key]
            public int DersID { get; set; }
            public string DersAd { get; set; }
            public string OgretimID { get; set; }
            public string BolumID { get; set; }
        }

        public class Bolum
        {
            [Key]
            public int BolumID { get; set; }
            public string BolumAd { get; set; }
        }

        public class Devamsizlik
        {
            [Key]
            public int DevamsizlikID { get; set; }
            public string ONumara { get; set; }
            public int DersID { get; set; }
            public int DevamsizlikSayisi { get; set; }
        }

        public class Admin
        {
            [Key]
            public int AdminID { get; set; }
            public string AdminKullaniciAdi { get; set; }
            public string AdminSifre { get; set; }
            public int YetkiNumarasi { get; set; }
        }

        public class YetkiNumaralari
        {
            [Key]
            public int YetkiID { get; set; }
            public int YetkiNumarasi { get; set; }
            public string YetkiAdi { get; set; }
        }


        public class ProjeVeritabani : DbContext
        {
            public DbSet<Ogrenci> OgrenciTablo { get; set; }
            public DbSet<OgrenciNot> OgrenciNotTablo { get; set; }
            public DbSet<Akademisyen> AkademisyenTablo { get; set; }
            public DbSet<OgrenciIsleriGorevlisi> GorevliMemur { get; set; }
            public DbSet<Ders> DersTablo { get; set; }
            public DbSet<Bolum> BolumTablo { get; set; }
            public DbSet<Devamsizlik> DevamsizlikTablo { get; set; }
            public DbSet<Admin> AdminTablo { get; set; }
            public DbSet<YetkiNumaralari> YetkiSeviyesi { get; set; }
        }


        private void createdatabase()
        {
            GirisYap ac = new GirisYap();
            
            using (var dbContext = new ProjeVeritabani())
            {
                if (!dbContext.Database.Exists())
                {
                    try
                    {
                       

                        ProjeVeritabani Veri = new ProjeVeritabani();
                        Veri.Database.Create();

                        int[] YetkiNumaralari = new int[] { 0,1, 2, 3, 4 };
                        string[] YetkiAdlari = new string[] { "NULL","Akademisyen", "Memur", "Ogrenci","Admin" };

                        string AdminKullanici = "Admin";
                        string AdminSifre = "Sifre123";
                        int YetkiNo = 4;

                        ProjeVeritabani ct = new ProjeVeritabani(); 
                        Admin admin = new Admin();
                        YetkiNumaralari yetki = new YetkiNumaralari();

                        for(int i = 1; i <= 4; i++)
                        {
                            yetki.YetkiNumarasi = YetkiNumaralari[i];
                            yetki.YetkiAdi = YetkiAdlari[i];
                            ct.YetkiSeviyesi.Add(yetki);
                            ct.SaveChanges();
                        }
                        admin.AdminKullaniciAdi = AdminKullanici;
                        admin.AdminSifre = AdminSifre;
                        admin.YetkiNumarasi = YetkiNo;

                        ct.AdminTablo.Add(admin);
                        ct.SaveChanges();

                        MessageBox.Show("Veritabanımız başarıyla oluşturuldu.");
                        
                        ac.Show();
                        this.Hide();
                    }
                    catch (Exception mesaj)
                    {
                        MessageBox.Show("Bir hata oluştu" + mesaj);
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanı zaten daha önceden oluşturulmuş. Giriş ekranına yönlendiriliyorsunuz.");

                    ac.Show();
                    this.Hide();
                }

            }

        }

        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 1)
            {
                createdatabase();

                timer1.Stop();

            }
        }
    }
}
