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

        public AClass_NotGirme notislem;

        public Class_Not notclass;
        public Class_Bolum bolumclass;
        public Class_Ders dersclass;

        //public static int BolumNumarasi;
        //public static int SSDersID;

        
        private void notverbuton_Click(object sender, EventArgs e)
        {
            string sifirmesaj = "12";

            try
            {                
                if (ButGirdiCheckBox.Checked)
                {
                    if (vizeBox.Text == "" || butBox.Text == "" || ognoTextBox.Text == "" || BolumCombo.Text == "" || DersCombo.Text == "")
                    {
                        MessageBox.Show("Lütfen Vize,Bütünleme,Öğrenci Numarası,Bölüm veya Ders isimli kutucuklardan birisini bile boş bırakmayınız.");
                    }
                    else
                    {
                        vizeBox.Text = sifirmesaj;
                        NotGirisYap();
                    }
                }
                else
                {
                    if(vizeBox.Text == "" || finalBox.Text == "" || ognoTextBox.Text == "" || BolumCombo.Text == "" || DersCombo.Text == "")
                    {
                        MessageBox.Show("Lütfen Vize,Final,Öğrenci Numarası,Bölüm veya Ders isimli kutucuklardan birisini bile boş bırakmayınız.");
                    }
                    else
                    {
                        butBox.Text = sifirmesaj;
                        NotGirisYap();
                    }
                }                                       
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n");
                MessageBox.Show(hata.Message);
            }          
        } 

        public void NotGirisYap()
        {
            notislem = new AClass_NotGirme(); ;

            try
            {

               
                dersclass = notislem.DersAl(DersCombo.Text);
                bolumclass = notislem.BolumAl(BolumCombo.Text);
                notclass = notislem.NotGiris(Convert.ToInt32(vizeBox.Text), Convert.ToInt32(finalBox.Text), Convert.ToInt32(butBox.Text), ButGirdiCheckBox.Checked, ognoTextBox.Text, BolumCombo.Text, DersCombo.Text);

                if (notclass != null && bolumclass != null && dersclass != null)
                {
                   //Zaten MessageBox'lar Class'ın içinde bulunduğu için buraya herhangi bir mesaj yazmaya gerek yok.
                }
                else
                {
                    MessageBox.Show("Çalıştırılan NotGirişYap() isimli fonksiyonda bir hata oluştu. Değerleri düzgün girdiğinize emin misiniz?");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n" + hata);
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
