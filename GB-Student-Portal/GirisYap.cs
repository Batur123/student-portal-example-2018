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

        public Class_Admin adminuser;
        public Class_Akademisyen akademiuser;
        public Class_Ogrenci ogrenciuser;
        public Class_Memur memuruser;

        public PClassGirisIslemi islem;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {

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

                    try
                    {
                        islem = new PClassGirisIslemi();
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
                        islem = new PClassGirisIslemi();
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
                        islem = new PClassGirisIslemi();
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
                        islem = new PClassGirisIslemi();
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
    }
}