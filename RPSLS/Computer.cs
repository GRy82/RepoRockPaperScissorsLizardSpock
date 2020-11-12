using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Computer : Player
    {
        public Computer(List<Gestures> gestures)
        {
            this.wins = 0;
            this.type = "Computer";
            this.gestures = gestures;
        }
    }
}
