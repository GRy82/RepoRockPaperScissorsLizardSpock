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

                List<string> names = EnterNames(optionSelected);

                Battle battle = LoadObjects(multiPlayer, rounds, names);
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
                Console.Write("\nEnter the number of rounds you wish to play(must be odd number): ");
                rounds = Console.ReadLine();
            } while (ValidateRounds(rounds) == false);

            return Convert.ToInt32(rounds);
        }

        public static List<string> EnterNames(int numberOfPlayers)
        {
            //collect names of players, according  to number of human players participating.
            List<string> names = new List<string> { };
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                string proposedName = null;
                bool validName = false;
                while (!validName)
                {
                    Console.WriteLine("Player" + i + ", please enter your name.");
                    proposedName = Console.ReadLine();
                    validName = ValidateName(proposedName);
                }
                names.Add(proposedName);
            }

            return names;
        }

        public static bool ValidateName(string proposedName)
        {
            if (proposedName.Length > 20)
            { //Check length
                Console.WriteLine("Your name must be 20 characters or less");
                return false;
            }
            //check for unaccepted characters.
            for (int i = 0; i < proposedName.Length; i++)
            {
                if (!(proposedName[i] >= 97 && proposedName[i] <= 122) && !(proposedName[i] >= 65 && proposedName[i] <= 90))
                {
                    Console.WriteLine("Only letter characters accepted.");
                    return false;
                }
            }
            return true;
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
