using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Scissors : Gestures
    {
        public Scissors()
        {
            this.weaknesses = new List<string> { };
            this.strengths = new List<string> { };
            this.weaknesses.Add("Spock");
            this.weaknesses.Add("Rock");
            this.strengths.Add("Paper");
            this.strengths.Add("Lizard");
            this.name = "Scissors";
            this.symbolLeft = "8<";
            this.symbolRight = ">8";
        }
    }
}
