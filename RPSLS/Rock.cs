using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Rock : Gestures
    {
        public Rock()
        {
            this.weaknesses.Add("Spock");
            this.weaknesses.Add("Paper");
            this.strengths.Add("Scissors");
            this.strengths.Add("Lizard");
        }
    }
}
