using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Ders
    {
        private string DersAdi;
        private int DersNo;

        public int DersNumarasi
        {
            get { return DersNo; }
            set { DersNo = value; }
        }

        public string DersAdii
        {
            get { return DersAdi; }
            set { DersAdi = value; }
        }



    }
}
