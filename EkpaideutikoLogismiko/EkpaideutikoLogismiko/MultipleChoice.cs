using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideutikoLogismiko
{
    class MultipleChoice
    {
        public int id;
        public string question;
        public string first;
        public string second;
        public string third;
        public string fourth;
        public int answer;

        //----Constructors----
        public MultipleChoice(int id, string question, string first, string second, string third, string fourth, int answer)
        {
            this.id = id;
            this.question = question;
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
            this.answer = answer;
        }
    }
}
