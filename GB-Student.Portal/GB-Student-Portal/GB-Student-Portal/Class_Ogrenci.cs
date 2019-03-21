using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Ogrenci : Class_Kullanici
    {
        private string OgrenciNumarasi;
        private string OgrenciTC;

        public string OgrenciNO
        {
            get { return OgrenciNumarasi; }
            set { OgrenciNumarasi = value; }
        }
        public string OgrenciTCKimlik
        {
            get { return OgrenciTC; }
            set { OgrenciTC = value; }
        }

    }
}
