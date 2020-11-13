using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace RPSLS
{
    class Setup
    {

        public void Launch()
        {
            bool runProgram = true;
            while (runProgram == true)
            {
                List<string> gameModeOptions = new List<string> { "Single Player", "Multi Player" };
                //Select single player, multiplater, or exit program.
                int optionSelected = MenuServer(gameModeOptions, true); //Choose single or multiplayer
                if (optionSelected == 3)
                {
                    Environment.Exit(-1);
                }
                int rounds = DetermineRounds();
                bool multiPlayer = false;
                if (optionSelected == 2)
                {
                    multiPlayer = true;
                }

                NameHumans namingFunctions = new NameHumans();
                List<string> names = namingFunctions.EnterNames(optionSelected);

                Battle battle = LoadObjects(multiPlayer, rounds, names);
                Console.Clear();
                battle.Run();
            }
        }

        public static int MenuServer(List<string> options, bool exit)
        {
            ConsoleOptionsInterface optionsMenu = new ConsoleOptionsInterface(options, exit, false);
            int optionSelected = optionsMenu.Launch();
            return optionSelected;
        }

        public static int DetermineRounds()
        {
            string rounds;
            do
            {
                Console.Write("\nEnter the number of rounds you wish to play(must be odd number): ");
                rounds = Console.ReadLine();
            } while (ValidateRounds(rounds) == false);

            return Convert.ToInt32(rounds);
        }

        public static bool ValidateRounds(string rounds)
        {
            foreach (char character in rounds)
            {
                int asciiChar = Convert.ToInt32(character);
                if (asciiChar < 48 || asciiChar > 57)
                {
                    return false;
                }
            }
            int intRounds = Convert.ToInt32(rounds);
            if (intRounds % 2 == 0 || intRounds < 3)
            {
                return false;
            }
            return true;
        }

        public static Battle LoadObjects(bool multiPlayer, int rounds, List<string> names)
        {
            //Instantiate each gesture
            Gestures rock = new Rock();
            Gestures paper = new Paper();
            Gestures scissors = new Scissors();
            Gestures lizard = new Lizard();
            Gestures spock = new Spock();
            //store it into a list.
            List<Gestures> gestures = new List<Gestures> { rock, paper, scissors, lizard, spock };

            //Instantiate players
            Player player1 = new Human(gestures, names[0]);
            Player player2;
            if (multiPlayer == true)
            {
                player2 = new Human(gestures, names[1]);
            }
            else
            {
                player2 = new Computer(gestures);
            }
            List<Player> players = new List<Player> { player1, player2 };

            Battle battle = new Battle(players, gestures, rounds, multiPlayer);
            return battle;
        }
    }
}
