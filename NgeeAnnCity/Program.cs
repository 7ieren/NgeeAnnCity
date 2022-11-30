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
                    Game currentGame = InitNewGame();
                    PlayGame(currentGame);
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
            Console.WriteLine("| 1.    Start New Game        |\n| 2.    Load Saved Game       |\n| 3.    Display High Scores   |\n| 4.    Exit Game             |");
            Console.WriteLine("|_____________________________|");
            Console.Write("\n Enter your choice: ");

        }

        static void DisplayBoard(char[,] board)
        {
            int NUM_ROWS = 20;
            int NUM_COLUMNS = 20;
            Console.WriteLine("     A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R   S   T");
            Console.WriteLine("   +---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+");
            for (int row = 0; row < NUM_ROWS; row++)
            {
                if (row < 9)
                {
                    Console.Write("  {0}", Convert.ToString(row + 1));
                }
                else
                {
                    Console.Write(" {0}", Convert.ToString(row + 1));
                }

                for (int col = 0; col < NUM_COLUMNS; col++)
                {
                    Console.Write("| {0} ", board[row,col]);
                }
                Console.WriteLine("|");
                Console.Write("   ");
                for (int col = 0; col < NUM_COLUMNS; col++)
                {
                    Console.Write("+---");
                } 
                Console.WriteLine("+");
            }

        }
  
        static Game InitNewGame()
        {
            char[,] Board = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };
            Console.Write(" Welcome to Ngee Ann City!\n Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Game newGame = new Game() { PlayerName = name, PlayerScore = 0, PlayerBoard = Board, Coins = 16 };
            return newGame;
        }

        static void PlayGame(Game game)
        {
            int choice = -1;
            List<string> buildingList = new List<string>();
            buildingList.Add("R");
            buildingList.Add("I");
            buildingList.Add("C");
            buildingList.Add("P");
            buildingList.Add("*");

            while (choice != 5)
            {
                DisplayBoard(game.PlayerBoard);

                DisplayBuildings();
                Random rnd = new Random();
                string building1 = buildingList[rnd.Next(0, 4)];
                string building2 = buildingList[rnd.Next(0, 4)];

                Console.WriteLine(" 1. Build a {0}\n 2. Build a {1}", building1, building2);
                Console.Write(" 3. See Current Score\n 4. Save Game\n 5. Exit to Main Menu\n Enter your choice: ");

                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine(" Only integers from 1 - 5 are allowed. Try Again.\n"); choice = -1; }

                if (choice == 1)
                {

                }

                if (choice == 2)
                {

                }

                if (choice == 3)
                {

                }

                if (choice == 4)
                {

                }

                else if (choice > 5)
                {
                    Console.WriteLine(" Only integers from 1 - 5 are allowed. Try Again.\n"); choice = -1;
                }


            }
        }

        static void DisplayBuildings()
        { 
            Console.WriteLine(" (R) Residential \n (I) Industry\n (C) Commercial \n (P) Park \n (*) Road");
        }

        static void LoadSavedGame()
        {

        }

        static void DisplayHighScores()
        {

        }

    }
}
