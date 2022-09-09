using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideutikoLogismiko
{
    class Sequence
    {
        public int id;
        public string question;
        public string first;
        public string second;
        public string third;
        public string fourth;
        public string fifth;
        public string sixth;
        public string answer;

        //----Constructors----
        public Sequence(int id, string question, string first, string second, string third, string fourth, string fifth, string sixth, string answer)
        {
            this.id = id;
            this.question = question;
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
            this.fifth = fifth;
            this.sixth = sixth;
            this.answer = answer;
        }
    }
}
