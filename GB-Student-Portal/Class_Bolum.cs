using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Bolum //miras yok
    {
        private string BolumAdi;
        private int BolumNo;


        public string BolumIsmi
        {
            get { return BolumAdi; }
            set { BolumAdi = value; }
        }

        public int BolumNumara
        {
            get { return BolumNo; }
            set { BolumNo = value; }
        }


    }
}
