using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class NameHumans
    {
        public List<string> EnterNames(int numberOfPlayers)
        {
            //collect names of players, according  to number of human players participating.
            List<string> names = new List<string> { };
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                string proposedName = null;
                bool validName = false;
                while (!validName)
                {
                    Console.Write("\nPlayer" + i + ", please enter your name: ");
                    proposedName = Console.ReadLine();
                    validName = ValidateName(proposedName);
                }
                names.Add(proposedName);
            }

            return names;
        }

        public bool ValidateName(string proposedName)
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
                    Console.WriteLine("\nOnly letter characters accepted.");
                    return false;
                }
            }
            return true;
        }
    }
}
