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
                if (leftGesture.name == "Spock" && rightGesture.name == "Spock") {
                    displayLines = TwoSpock(leftGesture.symbolLeft, rightGesture.symbolRight);
                }
                else if (leftGesture.name != "Spock" && rightGesture.name == "Spock") {
                    displayLines = RightSpock(leftGesture.symbolLeft, rightGesture.symbolRight);
                }
                else {
                    displayLines = LeftSpock(leftGesture.symbolLeft, rightGesture.symbolRight);
                }
            }
            Console.WriteLine("");
            for (int i = 0; i < displayLines.Count; i++) { 
               Console.WriteLine(displayLines[i]);
            }
            Console.WriteLine("");
        }

        public List<string> LeftSpock(string leftGestureSymbol, string rightGestureSymbol)
        {
            List<string> displayLines = new List<string> { };
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                displayLines.Add("");
                while (counter < leftGestureSymbol.Length && leftGestureSymbol[counter] != '\n')
                {
                    displayLines[i] += leftGestureSymbol[counter];
                    counter++;
                }
                counter++;
            }
            displayLines[2] += "  vs.  " + rightGestureSymbol;

            return displayLines;
        }
        
        public List<string> RightSpock(string leftGestureSymbol, string rightGestureSymbol)
        {
            List<string> displayLines = new List<string> { };
            int leftSymbolLeftSpaces = 4;
            int vsLength = 7;
            int symbolLength = leftGestureSymbol.Length;
            int totalSpace = symbolLength + vsLength + leftSymbolLeftSpaces;
            //COnstruct left part of string and necessary spacing
            for (int i = 0; i < 5; i++){
                displayLines.Add("");
                if (i != 2) {
                    for (int j = 0; j < totalSpace; j++) {
                        displayLines[i] += " ";
                    }
                }
                else {
                    displayLines[i] += "    " + leftGestureSymbol + "  vs.  ";
                }
            }
            //Construct right side of strings, containing spock.
            int counter = 0;
            for (int i = 0; i < displayLines.Count; i++)
            {
                while(counter < rightGestureSymbol.Length && rightGestureSymbol[counter] != '\n')
                {
                    displayLines[i] += rightGestureSymbol[counter];
                    counter++;
                }
                counter++;
            }

            return displayLines;          
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
            //For each line of the spocks printed, contruct a string to be part of a returned List<string>
            for (int i = 0; i < 5; i++) {
                displayLines.Add("");
                //Construct left side of spock at line 'i'
                while (counterLeft < leftGestureSymbol.Length && leftGestureSymbol[counterLeft] != '\n')
                {
                    tempString += (leftGestureSymbol[counterLeft]);
                    counterLeft++;
                    leftLineLength++;
                }
                counterLeft++;
                displayLines[i] += tempString;
                tempString = null;
                //construct right side of spock at line 'i'
                while (counterRight < rightGestureSymbol.Length && rightGestureSymbol[counterRight] != '\n')
                {
                    tempString += (rightGestureSymbol[counterRight]);
                    counterRight++;
                }
                counterRight++;
                //IN the 3rd line, "  vs.  " is printed in between the lines of spock. otherwise add the calculated number of spaces.
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
                displayLines[i] += tempString; // add right side spock string to total string in list.
                //reset values.
                leftLineLength = 0;
                tempString = null;
            }

            return displayLines;
        }


    }
}
