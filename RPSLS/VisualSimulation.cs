using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class VisualSimulation
    {
        public void AsciiDepiction(Gestures leftGesture, Gestures rightGesture)
        {
            List<string> displayLines = new List<string> { };
            if (leftGesture.name != "Spock" && rightGesture.name != "Spock")
            {
                displayLines.Add("    " + leftGesture.symbolLeft + "   vs.  " + rightGesture.symbolRight);
            }
            else
            { 
                if (leftGesture.name == "Spock" && rightGesture.name == "Spock")
                {
                    displayLines = TwoSpock(leftGesture.symbolLeft, rightGesture.symbolRight);
                }
                else if (leftGesture.name != "Spock" && rightGesture.name == "Spock")
                {
                    displayLines = RightSpock(leftGesture.symbolLeft, rightGesture.symbolRight);
                }
                else
                {
                    
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < displayLines.Count; i++) { 
               Console.WriteLine(displayLines[i]);
            }
            Console.WriteLine("");

        }
        
        public List<string> RightSpock(leftGestureSymbol, rightGestureSymbol)
        {

        }

        public List<string> TwoSpock(string leftGestureSymbol, string rightGestureSymbol)
        {
            List<string> displayLines = new List<string> { };
            string tempString = null;
            int counterLeft = 0;
            int counterRight = 0;
            int leftLineLength = 0;
            int maxLength = 27;
            int vsSpace = 7; //The amount of space that a "  vs.  " takes up between two spocks.
            int spacesNeeded = 0;

            for (int i = 0; i < 5; i++) {
                displayLines.Add("");
                while (counterLeft < leftGestureSymbol.Length && leftGestureSymbol[counterLeft] != '\n')
                {
                    tempString += (leftGestureSymbol[counterLeft]);
                    counterLeft++;
                    leftLineLength++;
                }
                counterLeft++;
                displayLines[i] += tempString;
                tempString = null;

                while (counterRight < rightGestureSymbol.Length && rightGestureSymbol[counterRight] != '\n')
                {
                    tempString += (rightGestureSymbol[counterRight]);
                    counterRight++;
                }
                counterRight++;
                if (i != 2) {
                    spacesNeeded = maxLength - leftLineLength - vsSpace;
                    for (int j = 0; j < spacesNeeded; j++)
                    {
                        displayLines[i] += " ";
                    }
                }
                else {                   
                    displayLines[i] += "  vs.  ";      
                }
                leftLineLength = 0;
                displayLines[i] += tempString;
                tempString = null;
            }

            return displayLines;
        }


    }
}
