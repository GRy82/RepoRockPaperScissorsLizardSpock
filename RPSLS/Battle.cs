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

        public Battle(List<Player> players, List<Gestures> gestures, int rounds)
        {
            this.gestures = gestures;
            this.players = players;
            this.rounds = rounds;
            this.winningNumber = Convert.ToInt32(rounds / 2) + 1;
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
                
            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);

        }

        public void RunMultiPlayer()
        {
            int winningNumber = Convert.ToInt32(rounds / 2) + 1;
            do
            {

            } while (players[0].wins < winningNumber && players[1].wins < winningNumber);
        }

        public void Display()
        {
            Console.WriteLine(this is);
            Console.WriteLine("Press 'enter');
        }
    }
}
