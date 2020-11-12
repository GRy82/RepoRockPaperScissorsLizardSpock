using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Rock : Gestures
    {
        public Rock()
        {
            weaknesses.Add("Spock");
            weaknesses.Add("Paper");
            strengths.Add("Scissors");
            strengths.Add("Lizard");
        }
    }
}
