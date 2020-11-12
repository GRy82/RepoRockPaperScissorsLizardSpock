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
                int optionSelected = MenuServer(gameModeOptions, false); //Choose single or multiplayer
                int rounds = DetermineRounds();
                bool multiPlayer = false;
                if (optionSelected == 2)
                {
                    multiPlayer = true;
                }
                Battle battle = LoadObjects(multiPlayer, rounds);
                battle.Run();
                
            }
        }

        public static int MenuServer(List<string> options, bool exit)
        {
            ConsoleOptionsInterface optionsMenu = new ConsoleOptionsInterface(options, exit);
            int optionSelected = optionsMenu.Launch();
            return optionSelected;
        }

        public static int DetermineRounds()
        {
            string rounds;
            do
            {
                Console.Write("Enter the number of rounds you wish to play(must be odd number): ");
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
            if (Convert.ToInt32(rounds) % 2 == 0)
            {
                return false;
            }
            return true;
        }

        public static Battle LoadObjects(bool multiPlayer, int rounds)
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
            //Instantiate each gesture
            Gestures rock = new Rock();
            Gestures paper = new Paper();
            Gestures scissors = new Scissors();
            Gestures lizard = new Lizard();
            Gestures spock = new Spock();
            //store it into a list.
            List<Gestures> gestures = new List<Gestures> { rock, paper, scissors, lizard, spock };

            Battle battle = new Battle(players, gestures, rounds);
            return battle;
        }

    }
}


