using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Battle
    {
        List<Player> players;
        List<Gestures> gestures;

        public Battle(List<Player> players, List<Gestures> gestures)
        {
            this.gestures = gestures;
            this.players = players;
        }

        public void Run(int rounds)
        {
            int humanCount = 0;
            for(int i = 0; i <= 1; i++)
            {
                if (players[i].type == "Human") {
                    humanCount++;
                }
            }
            if (humanCount == 2) {
                RunSinglePlayer(rounds);
            }
            else {
                RunMultiPlayer(rounds);
            }
        }

        public void RunSinglePlayer(int rounds)
        {

        }

        public void RunMultiPlayer(int rounds)
        {

        }
    }
}
