using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Student_Portal
{
    public class Class_Akademisyen : Class_Kullanici
    {
        private int BOLUMID;

        public int BolumID
        {
            get { return BOLUMID; }
            set { BOLUMID = value; }
        }



    }
}
