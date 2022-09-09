using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideutikoLogismiko
{
    class TrueFalse
    {
        public int id;
        public string question;
        public bool answer;

        //----Constructors----
        public TrueFalse(int id, string question, bool answer)
        {
            this.id = id;
            this.question = question;
            this.answer = answer;
        }
    }
}
