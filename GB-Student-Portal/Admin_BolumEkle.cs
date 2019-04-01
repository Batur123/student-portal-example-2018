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
    public partial class Admin_BolumEkle : Form
    {
        public Admin_BolumEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                VeritabaniOlusturma.ProjeVeritabani ct = new VeritabaniOlusturma.ProjeVeritabani();
                VeritabaniOlusturma.Bolum bolum = new VeritabaniOlusturma.Bolum //Bu yapıyı yeni keşfettim. Tek tek hoca.AAD = isimbox.Text yazmaya gerek yokmuş.
                {
                    BolumAd = bolumBOx.Text,                  
                };

                ct.BolumTablo.Add(bolum);
                ct.SaveChanges();

                MessageBox.Show("Bölüm ekleme işlemi başarıyla tamamlandı. \n Bölüm Adı:"+bolumBOx.Text);
            }
            catch (Exception ex) //Exception yakalama...
            {
                MessageBox.Show("Bir hata oluştu. \n\n" + ex);
            }
        }
    }
}
