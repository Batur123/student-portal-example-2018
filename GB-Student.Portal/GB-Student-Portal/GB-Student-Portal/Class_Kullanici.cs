using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Kullanici
    {
        private string KAd;
        private string KSoyad;
        private string KSifre;

        public string KullaniciAdi
        {
            get { return KAd; }
            set { KAd = value; }
        }
        public string KullaniciSoyadi
        {
            get { return KSoyad; }
            set { KSoyad = value; }
        }
        public string KullaniciSifre
        {
            get { return KSifre; }
            set { KSifre = value; }
        }


    }
}
