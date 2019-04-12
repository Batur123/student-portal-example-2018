using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Not
    {
        private int VizeNot;
        private int FinalNot;
        //private int ButunlemeNot;
        private double OrtalamaNot;
        private bool ButDurum;

        public int CVize
        {
            get { return VizeNot; }
            set { VizeNot = value; }
        }

        public int CFinal
        {
            get { return FinalNot; }
            set { FinalNot = value; }
        }

       /* public int CButunleme
        {
            get { return ButunlemeNot; }
            set { ButunlemeNot = value; }
        } */

        public double COrt
        {
            get { return OrtalamaNot; }
            set { OrtalamaNot = value; }
        }

        public bool ButeGirdi
        {
            get { return ButDurum; }
            set { ButDurum = value; }
        }






    }
}
