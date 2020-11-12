using ProblemSolving1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            while (runProgram == true) {
                List<string> gameModeOptions = new List<string> { "Single Player", "Multi Player" };
                int optionSelected = MenuServer(gameModeOptions, false);
                bool multiPlayer = false;
                if (optionSelected == 2)
                {
                    multiPlayer = true;
                }
                LoadObjects(multiPlayer);

                
            }
        }


        public static int MenuServer(List<string> options, bool exit)
        {
            ConsoleOptionsInterface optionsMenu = new ConsoleOptionsInterface(options, exit);
            int optionSelected = optionsMenu.Launch();
            return optionSelected;
        }

        public static void LoadObjects(bool multiPlayer)
        {
            Player player1 = new Human();
            Player player2;
            if (multiPlayer == true) {
                player2 = new Human();
            }
            else {
                player2 = new Computer();
            }
            List<Player> players = new List<Player> { player1, player2 };


        }

    }
}


