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
    public partial class Genel_GirisYapEkrani : Form
    {
        public Genel_GirisYapEkrani()
        {
            InitializeComponent();
        }

        public Class_Admin adminuser;
        public Class_Akademisyen akademiuser;
        public Class_Ogrenci ogrenciuser;
        public Class_Memur memuruser;

        public AClass_GirisYapma islem;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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

                    try
                    {
                        islem = new AClass_GirisYapma();
                        ogrenciuser = islem.OgrenciGiris(KAdiBox.Text, KSifreBox.Text);
                        //this.Hide();
                        if (ogrenciuser != null)
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
                else if (comboBox1.SelectedItem.ToString() == "Akademisyen")
                {

                    try
                    {
                        islem = new AClass_GirisYapma();
                        akademiuser = islem.AkademiGiris(KAdiBox.Text, KSifreBox.Text);
                        //this.Hide();
                        if (akademiuser != null)
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
                else if (comboBox1.SelectedItem.ToString() == "Memur")
                {

                    try
                    {
                        islem = new AClass_GirisYapma();
                        memuruser = islem.MemurGiris(KAdiBox.Text, KSifreBox.Text);
                        //this.Hide();
                        if (memuruser != null)
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
                else if (comboBox1.SelectedItem.ToString() == "Admin")
                {
                    
                    try
                    {
                        islem = new AClass_GirisYapma();
                        adminuser = islem.AdminGiris(KAdiBox.Text, KSifreBox.Text);
                        //this.Hide();
                        if (adminuser != null)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program C# ile Batuhan Özkoç ve Yunus Emre Ayar tarafından yapılmıştır. EntityFramework paketi desteği ile çalışmaktadır. CodeFirst Development ile yapılmıştır. Veritabanı için ayrı bir işlem yapmanıza gerek yoktur. Bazı kısımları halen yapım aşamasındadır. Proje, ödev olarak Yazılım Mühendisliği dersinde Araştırma Görevlisi Hasan Ulutaş tarafından verilmiştir. Tamamiyle eğitim amaçlı olan proje Öğrenci Bilgi Sistemidir. ");
        }
    }
}