using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NgeeAnnCity
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            Console.WriteLine(" {0,21}", "Ngee Ann City");

            while (choice != 0)
            {
                DisplayMenu();
                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine(" Only integers from 1 - 4 are allowed. Try Again.\n"); choice = -1; }

                if (choice == 1)
                {
                    InitNewGame();
                }

                if (choice == 2)
                {
                    LoadSavedGame();
                }

                if (choice == 3)
                {
                    DisplayHighScores();
                }

                else if (choice == 4)
                {
                    Console.WriteLine(" Goodbye! Thank you for playing!");
                    choice = 0;
                }

                else if (choice > 4)
                {
                    Console.WriteLine(" Only integers from 1 - 4 are allowed. Try Again.\n"); choice = -1;
                }
            }

            Console.ReadLine();

        }

        static void DisplayMenu()
        {
            Console.WriteLine(" _____________________________\n|                             |");
            Console.WriteLine("| {0} {1, 8} {2, 16}", "No.", "Option", "|");
            Console.WriteLine("| 1.    Start New Game        |\n| 2.    Load Saved Game       |\n| 3.    Display High Scores   |\n| 4.    Exit Game             |");
            Console.WriteLine("|_____________________________|");
            Console.Write("\n Enter your choice: ");

        }

        static void PlayGame()
        {

        }

        static void InitNewGame()
        {

        }

        static void LoadSavedGame()
        {

        }

        static void DisplayHighScores()
        {

        }

    }
}
