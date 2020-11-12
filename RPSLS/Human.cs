using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace RPSLS
{

    public class Human : Player
    {
        ConsoleOptionsInterface gestureChoices;
        List<Gestures> gestures;
        List<string> gestureNames = new List<string> { };
        public Human(List<Gestures> gestures)
        {
            this.wins = 0;
            this.type = "Human";
            this.gestures = gestures;
            foreach (Gestures gesture in gestures)
            {
                this.gestureNames.Add(gesture.name);
            }

            this.gestureChoices = new ConsoleOptionsInterface(gestureNames, false);
        }
    }
}
