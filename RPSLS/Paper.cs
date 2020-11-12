using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Paper : Gestures
    {
        public Paper()
        {
            weaknesses.Add("Lizard");
            weaknesses.Add("Scissors");
            strengths.Add("Spock");
            strengths.Add("Rock");
        }
    }
}
