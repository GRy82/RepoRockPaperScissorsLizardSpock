using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Battle
    {
        List<Player> players;
        List<Gestures> gestures;
        int rounds;
        int winningNumber;
        int currentRound;
        string currentTurn;
        bool multi;
        string otherTurn;
        ConsoleOptionsInterface gestureChoice;
        List<string> gestureNames = new List<string> { };

        public Battle(List<Player> players, List<Gestures> gestures, int rounds, bool multi)
        {
            this.gestures = gestures;
            this.players = players;
            this.rounds = rounds;
            this.winningNumber = Convert.ToInt32(rounds / 2) + 1;
            this.multi = multi;
            this.currentRound = 1;
            this.currentTurn = "Player1";
            if (multi) {
                this.otherTurn = "Player2";
            }
            else {
                this.otherTurn = "Computer";
            }
            foreach (Gestures gesture in gestures)
            {
                gestureNames.Add(gesture.name);
            }
            gestureChoice = new ConsoleOptionsInterface(gestureNames, false);
        }

        public void Run()
        {
            int humanCount = 0;
            for(int i = 0; i <= 1; i++)
            {
                if (players[i].type == "Human") {
                    humanCount++;
                }
            }
            if (humanCount == 2) {
                RunSinglePlayer();
            }
            else {
                RunMultiPlayer();
            }
        }

        public void RunSinglePlayer()
        {
            do
            {
                UserPrompt();
            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);

        }

        public void RunMultiPlayer()
        {
            do
            {

            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);
        }

        public void UserPrompt()
        {
            Console.WriteLine("This is round " + currentRound + ". Select your gesture choice " + currentTurn);
            int choice = gestureChoice.Launch();
            if (multi) {
                string temp = currentTurn;
                currentTurn = otherTurn;
                otherTurn = temp;
            }
           
        }
        

        public void RoundWinnerDisplay()
        {

        }
        public void DetermineWinner()
        {
 
        }
    }
}
