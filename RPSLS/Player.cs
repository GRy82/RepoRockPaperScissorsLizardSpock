using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    abstract public class Player
    {
        public int wins;
        public string type;
        public Gestures currentGesture;
    }
}
