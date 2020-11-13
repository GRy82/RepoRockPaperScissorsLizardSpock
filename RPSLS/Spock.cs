using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Spock : Gestures
    {
        public Spock()
        {
            this.weaknesses = new List<string> { };
            this.strengths = new List<string> { };
            this.weaknesses.Add("Paper");
            this.weaknesses.Add("Lizard");
            this.strengths.Add("Scissors");
            this.strengths.Add("Rock");
            this.name = "Spock";
            this.symbolLeft = "   ___\n  (>.<)  \\\\//\n   | |  \\(__)\n /|   |\\  /\n/ |   | \\/";
            this.symbolRight = "       ___\n\\\\//  (>.<)\n(__)/  | |\n  \\  /|   |\\\n   \\/ |   | \\";
        }
    }
}
