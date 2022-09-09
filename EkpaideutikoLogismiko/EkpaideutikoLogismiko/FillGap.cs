using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideutikoLogismiko
{
    class FillGap
    {
        public int id;
        public string question;
        public string answer;
        public int gaps;

        //----Constructors----
        public FillGap(int id, string question, string answer, int gaps)
        {
            this.id = id;
            this.question = question;
            this.answer = answer;
            this.gaps = gaps;
        }
    }
}
