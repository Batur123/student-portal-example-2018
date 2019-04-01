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
    public partial class Admin_SistemeKayitEkle : Form
    {
        public Admin_SistemeKayitEkle()
        {
            InitializeComponent();
        }

        private void Admin_SistemeKayitEkle_Load(object sender, EventArgs e)
        {
            if (memurcheck.Checked)
            {

            }
            else if (hocacheck.Checked)
            {

            }

        }

        private void memurcheck_CheckedChanged(object sender, EventArgs e)
        {
            hocacheck.Checked = false;
          
        }

        private void hocacheck_CheckedChanged(object sender, EventArgs e)
        {
            memurcheck.Checked = false;
  
        }

        private void GirisButon_Click(object sender, EventArgs e)
        {
           
            if (hocacheck.Checked)
            {
                if (KAdiBox.Text != string.Empty && KSifreBox.Text != string.Empty && isimbox.Text != string.Empty && soyisimbox.Text != string.Empty && unvanbox.Text != string.Empty) //Eğer boş değilse kayıt tamamlanır.
                {
                    try
                    {

                        VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                        VeritabaniOlusturma.Akademisyen hoca = new VeritabaniOlusturma.Akademisyen //Bu yapıyı yeni keşfettim. Tek tek hoca.AAD = isimbox.Text yazmaya gerek yokmuş.
                        {
                            AAd = isimbox.Text,
                            ASoyad = soyisimbox.Text,
                            AKullaniciAd = KAdiBox.Text,
                            ASifre = KSifreBox.Text,
                            AUnvan = unvanbox.Text
                        };

                        ct.AkademisyenTablo.Add(hoca);
                        ct.SaveChanges();

                        MessageBox.Show("Kayıt işlemi başarıyla tamamlandı.");
                    }
                    catch (Exception ex) //Exception yakalama...
                    {
                        MessageBox.Show("Bir hata oluştu. \n\n" + ex);
                    }
                  /*  finally
                    {
                            Şimdilik bu kısım iptal edildi.
                    } */
                   
                }
                else
                {

                    MessageBox.Show("Lütfen Kullanıcı adı,Şifre,İsim,Soyisim veya Ünvan isimli kutucuklardan birini boş bırakmayınız. Aksi takdirde kayıt işlemi gerçekleştirilmeyecektir.");

                }
                
            }
            else if (memurcheck.Checked)
            {
                if (KAdiBox.Text != string.Empty && KSifreBox.Text != string.Empty && isimbox.Text != string.Empty && soyisimbox.Text != string.Empty)
                {
                    try
                    {

                        VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                        VeritabaniOlusturma.OgrenciIsleriGorevlisi memur = new VeritabaniOlusturma.OgrenciIsleriGorevlisi //Bu yapıyı yeni keşfettim. Tek tek hoca.AAD = isimbox.Text yazmaya gerek yokmuş.
                        {
                            GAd = isimbox.Text,
                            GSoyad = soyisimbox.Text,
                            GKullaniciAd = KAdiBox.Text,
                            GSifre = KSifreBox.Text,
                        };

                        ct.GorevliMemur.Add(memur);
                        ct.SaveChanges();

                        MessageBox.Show("Kayıt işlemi başarıyla tamamlandı.");
                    }
                    catch (Exception ex) //Exception yakalama...
                    {
                        MessageBox.Show("Bir hata oluştu. \n\n" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı adı,Şifre,İsim,Soyisim isimli kutucaklardan birini boş bırakmayınız. Aksi takdirde kayıt işlemi gerçekleştirilmeyecektir.");
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen Akademisyen veya Memur seçim kısmını boş bırakmayınız.");
            }
        }
    }
}
