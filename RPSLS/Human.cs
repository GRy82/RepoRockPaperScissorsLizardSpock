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
        List<string> gestureNames = new List<string> { };
        public Human(List<Gestures> gestures, string name)
        {
            this.wins = 0;
            this.type = "Human";
            this.name = name;
            this.gestures = gestures;
            foreach (Gestures gesture in gestures)
            {
                this.gestureNames.Add(gesture.name);
            }

            this.gestureChoices = new ConsoleOptionsInterface(gestureNames, false);
        }

        public override Gestures GetGesture()
        {
            Console.WriteLine("\nIt is " + name + "'s turn to pick a gesture.");
            int option = gestureChoices.Launch();
            option -= 1;
            foreach(Gestures gesture in gestures)
            {
                if (option == gestures.IndexOf(gesture))
                {
                    currentGesture = gesture;
                }
            }
            return currentGesture;
        }
    }
}
