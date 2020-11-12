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
            this.name = "Computer";
        }

        public Gestures RandomizeGesture()
        {
            Random rand = new Random();
            int randomInteger = rand.Next(5);
            foreach(Gestures gesture in gestures)
            {
                if (randomInteger == gestures.IndexOf(gesture))
                {
                    currentGesture = gesture;
                }
            }
            return currentGesture;
        }
    }
}
