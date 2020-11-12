using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Paper : Gestures
    {
        public Paper()
        {
            this.weaknesses.Add("Lizard");
            this.weaknesses.Add("Scissors");
            this.strengths.Add("Spock");
            this.strengths.Add("Rock");
        }
    }
}
