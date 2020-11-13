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
        bool multi;
        VisualSimulation visSim;

        List<string> gestureNames = new List<string> { };

        public Battle(List<Player> players, List<Gestures> gestures, int rounds, bool multi)
        {
            this.gestures = gestures;
            this.players = players;
            this.rounds = rounds;
            this.winningNumber = Convert.ToInt32(rounds / 2) + 1;
            this.multi = multi;
            this.currentRound = 1;
            this.visSim = new VisualSimulation();
            foreach (Gestures gesture in gestures)
            {
                gestureNames.Add(gesture.name);
            }
        }

        public void Run()
        {
            do
            {
                DisplayScore();
                Gestures gesture1 = players[0].GetGesture();
                Gestures gesture2 = players[1].GetGesture();
                
                if (gesture1 == gesture2) {
                    Tie();
                }
                else {
                    Player roundWinningPlayer = CompareGestures(gesture1, gesture2);
                    RoundWinner(roundWinningPlayer);
                }
            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);
            AnnounceWinner();
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

        public void AnnounceWinner()
        {
            string winner = players[1].name;
            if (players[0].wins >= winningNumber)
            {
                winner = players[0].name;
            }
            Console.WriteLine("\n\nThe winner of Rock-Paper-Scissors-Lizard-Spock is...\n\n      ..." + winner + "!");
            Continue("\nPress 'enter' to continue...", true);
        }
      
        public void Continue(string prompt, bool clear)
        {
            Console.WriteLine(prompt);
            Console.ReadLine();
            if (clear == true) {
                Console.Clear();
            }
        }
        public void DisplayScore()
        {
            Console.WriteLine("\nRound:" + currentRound + "/" + rounds + "\n");
            Console.WriteLine(players[0].name + ": " + players[0].wins + " points.  " + players[1].name + ": " + players[1].wins + " points.");
        }

        public void Tie()   
        {
            Console.WriteLine("\n" + players[0].name + " chose " + players[0].currentGesture.name + " and " + players[1].name + " chose " + players[1].currentGesture.name + ".");
            visSim.AsciiDepiction(players[0].currentGesture, players[1].currentGesture);
            Console.WriteLine("The result of this round is a tie, and will be repeated");
            Continue("\nPress enter to continue to next round", true);
        }

        public void RoundWinner(Player roundWinningPlayer)
        {
            Console.WriteLine("\n" + players[0].name + " chose " + players[0].currentGesture.name + " and " + players[1].name + " chose " + players[1].currentGesture.name + ".");
            visSim.AsciiDepiction(players[0].currentGesture, players[1].currentGesture);
            Console.WriteLine(roundWinningPlayer.name + " wins round " + currentRound);
            roundWinningPlayer.wins++;
            currentRound++;
            Continue("\nPress enter to continue to next round", true);
        }
    }   
}
