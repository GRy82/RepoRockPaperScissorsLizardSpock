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
        }

        public void Run()
        {
            int humanCount = 0;
            for (int i = 0; i <= 1; i++)
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
                var human = (Human)players[0];
                var comp = (Computer)players[1];
                Gestures playerGesture = human.ChooseGesture();
                Gestures computerGesture = comp.RandomizeGesture();
                Player roundWinningPlayer = CompareGestures(playerGesture, computerGesture);
                RoundWinner(roundWinningPlayer);
            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);

        }

        public void RunMultiPlayer()
        {
            do
            {
                var human = (Human)players[0];
                Gestures playerGesture = human.ChooseGesture();
                var human2 = (Human)players[0];
                Gestures player2Gesture = human2.ChooseGesture();
                Player roundWinningPlayer = CompareGestures(playerGesture, player2Gesture);
                RoundWinner(roundWinningPlayer);
            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);
        }

        public Player CompareGestures(Gestures gesture1, Gestures gesture2)
        {
            string gesture2Name = gesture2.name;
            for (int i = 0; i < 2; i++)
            {
                if (gesture2.name == gesture1.weaknesses[i])
                {
                    return players[1];
                }
            }
            return players[0];
        }

        public void DisplayScore()
        {
            Console.WriteLine("It is round " + currentRound + " of " + rounds + " rounds." );
            Console.WriteLine(players[0].name + " has " + players[0].wins + "points.  " + players[1].name + " has " + players[1].wins + "points.");
        }

        public void RoundWinner(Player roundWinningPlayer)
        {

            Console.WriteLine(roundWinningPlayer.name + " wins round " + currentRound);
            roundWinningPlayer.wins++;
        }
    }   
}
