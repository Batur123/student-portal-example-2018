using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Admin
    {
        private string kullaniciadi;
        private string sifre;

        public string AdminKAD
        {
            get { return kullaniciadi; }
            set { kullaniciadi = value; }
        }

        public string AdminSifre
        {
            get { return sifre; }
            set { sifre = value; }
        }

    }
}
