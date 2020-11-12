using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Lizard : Gestures
    {
        public Lizard()
        {
            this.weaknesses = new List<string> { };
            this.strengths = new List<string> { };
            this.weaknesses.Add("Rock");
            this.weaknesses.Add("Scissors");
            this.strengths.Add("Paper");
            this.strengths.Add("Spock");
            this.name = "Lizard";
        }
    }
}
