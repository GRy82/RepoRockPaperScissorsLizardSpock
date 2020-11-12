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
    }
}
