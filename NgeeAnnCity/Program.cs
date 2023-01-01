using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections.Specialized;

namespace NgeeAnnCity
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> columnDict = InitColDict();
           

            int choice = -1;
            Console.WriteLine(" {0,21}", "Ngee Ann City");


            while (choice != 0)
            {
                DisplayMenu();
                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine(" Only integers from 1 - 4 are allowed. Try Again.\n"); choice = -1; }

                if (choice == 1)
                {
                    Console.WriteLine();
                    Game currentGame = InitNewGame();
                    PlayGame(currentGame, columnDict);
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

        static Dictionary<char, int> InitColDict()
        {
            Dictionary<char, int> columnDict = new Dictionary<char, int>();
            columnDict.Add('A', 0);
            columnDict.Add('B', 1);
            columnDict.Add('C', 2);
            columnDict.Add('D', 3);
            columnDict.Add('E', 4);
            columnDict.Add('F', 5);
            columnDict.Add('G', 6);
            columnDict.Add('H', 7);
            columnDict.Add('I', 8);
            columnDict.Add('J', 9);
            columnDict.Add('K', 10);
            columnDict.Add('L', 11);
            columnDict.Add('M', 12);
            columnDict.Add('N', 13);
            columnDict.Add('O', 14);
            columnDict.Add('P', 15);
            columnDict.Add('Q', 16);
            columnDict.Add('R', 17);
            columnDict.Add('S', 18);
            columnDict.Add('T', 19);
            return columnDict;
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
            Console.WriteLine("\n Have fun in Ngee Ann City, " + name + "!\n");
            Game newGame = new Game() { PlayerName = name, PlayerScore = 0, PlayerBoard = Board, Coins = 16, Turn = 0 };
            return newGame;
        }

        static void PlayGame(Game game, Dictionary<char, int> columnDict)
        {
            int choice = -1;
            List<char> buildingList = new List<char>();
            buildingList.Add('R');
            buildingList.Add('I');
            buildingList.Add('C');
            buildingList.Add('P');
            buildingList.Add('*');

            while (choice != 5)
            {
                DisplayBoard(game.PlayerBoard);

                Random rnd = new Random();
                char building1 = buildingList[rnd.Next(0, 4)];
                char building2 = buildingList[rnd.Next(0, 4)];
                bool sameBldng = false;

                if (building1 == building2)
                {
                    sameBldng = true;

                    while (sameBldng == true)
                    {
                        building2 = buildingList[rnd.Next(0, 4)];

                        if (building2 != building1)
                        {
                            sameBldng = false;
                        }

                    }
                }

                Dictionary<char, string> buildingDict = new Dictionary<char, string>();
                buildingDict.Add('R', "Residential");
                buildingDict.Add('I', "Industry");
                buildingDict.Add('C', "Commercial");
                buildingDict.Add('P', "Park"); 
                buildingDict.Add('*', "Road"); 

                try
                {
                    if (game.Turn == 0) {
                        Console.WriteLine("\n You have " + Convert.ToString(game.Coins) + " Coins! \n 1. Build a {0}\n 2. Build a {1}", buildingDict[building1] + " (" + building1 + ")", buildingDict[building2] + " (" + building2 + ")");
                    }

                    else
                    {
                        Console.WriteLine("\n You have " + Convert.ToString(game.Coins) + " Coins remaining! \n 1. Build a {0}\n 2. Build a {1}", buildingDict[building1] + " (" + building1 + ")", buildingDict[building2] + " (" + building2 + ")");
                    }
                }

                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not found!");
                }

                Console.Write(" 3. See Current Score\n 4. Save Game\n 5. Exit to Main Menu\n\n Enter your choice: ");

                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine(" Only integers from 1 - 5 are allowed. Try Again.\n"); choice = -1; }
                Console.WriteLine(); 

                if (choice == 1) 
                {
                    buildBuilding(building1, game, columnDict);
                    Console.WriteLine();

                }

                if (choice == 2)
                {
                    buildBuilding(building2, game, columnDict);
                    Console.WriteLine();

                }

                if (choice == 3)
                {
                    seeCurrentScore(game);
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
        static Game buildBuilding(char bldng, Game game, Dictionary<char, int> columnDict)
        {
            int row;
            int col;
            char[,] board = game.PlayerBoard;

            bool success = false;

            Console.Write(" Build a (" + bldng + ") where? ");

            while (!success)
            {
                string position = Console.ReadLine();
                string upperPosition = position[0].ToString().ToUpper();
                try 
                {
                    col = columnDict[Convert.ToChar(upperPosition[0])];
                    row = Convert.ToInt32(position.Remove(0, 1)) - 1;
                    if (game.Turn == 0)
                    {
                        board[row, col] = bldng;
                        game.Turn++;
                        game.Coins--;
                        return game;
                    }

                    else
                    {
                        bool passCheck = false;
                        bool checkLeft = true;
                        bool checkRight = true;
                        bool checkDown = true;
                        bool checkUp = true;
                        bool occupied = false;

                        if (row + 1 == 20)
                        {
                            checkDown = false;
                        }

                        if (row + 1 == 1)
                        {
                            checkUp = false;
                        }
                        if (col + 1 == 20)
                        {
                            checkRight = false;
                        }
                        if (col + 1 == 1)
                        {
                            checkLeft = false;
                        }

                        if (row == 19 && col == 0)
                        {
                            checkDown = false;
                            checkLeft = false;
                        }

                        if (row == 0 && col == 19)
                        {
                            checkUp = false;
                            checkRight = false;
                        }
                        if (row == 0 && col == 0)
                        {
                            checkUp = false;
                            checkLeft = false;
                        }

                        if (checkLeft)
                        {
                            if (board[row, col - 1] != ' ')
                            {
                                passCheck = true;

                                if (passCheck == true)
                                {
                                    if (board[row, col] == ' ')
                                    {
                                        board[row, col] = bldng;
                                        success = true;
                                    }
                                    else
                                    {
                                        occupied = true;
                                    }
                                }

                                else
                                {
                                    Console.WriteLine(" You must build next to an existing building.");
                                }
                            }
                        }

                        if (checkRight)
                        {
                            if (board[row, col + 1] != ' ')
                            {
                                passCheck = true;
                                if (passCheck == true)
                                {
                                    if (board[row, col] == ' ')
                                    {
                                        board[row, col] = bldng;
                                        success = true;
                                    }
                                    else
                                    {
                                        occupied = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" You must build next to an existing building.");
                                }
                            }
                        }

                        if (checkUp)
                        {
                            if (board[row - 1, col] != ' ')
                            {
                                passCheck = true;

                                if (passCheck == true)
                                {
                                    if (board[row, col] == ' ')
                                    {
                                        board[row, col] = bldng;
                                        success = true;
                                    }

                                    else
                                    {
                                        occupied = true;
                                    }
                                }

                                else
                                {
                                    Console.WriteLine(" You must build next to an existing building.");
                                }
                            }
                        }

                        if (checkDown)
                        {
                            if (board[row + 1, col] != ' ')
                            {
                                passCheck = true;
                                if (passCheck == true)
                                {
                                    if (board[row, col] == ' ')
                                    {
                                        board[row, col] = bldng;
                                        success = true;
                                    }
                                    else
                                    {
                                        occupied = true;
                                    }
                                }

                                else
                                {
                                    Console.WriteLine(" You must build next to an existing building.");
                                }
                            }
                        }

                        if (occupied)
                        {
                            Console.Write(" This plot is already occupied. Try again: ");

                        }

                        if (!passCheck)
                        {
                            Console.Write(" You must build next to an existing building. Try again: ");

                        }

                        if (success)
                        {
                            game.Turn++;
                            game.Coins--;
                        }

                    }
                }

                catch
                {
                    Console.Write(" Location does not exist! An example is 'A1'. Try again: ");
                }
                
                
            }

            return game;
            
        }

        static void seeCurrentScore(Game game)
        {
            char[,] board = game.PlayerBoard;
            int ICount = 0;
            int pts = 0;
            int HSEC = 0;
            List<int> HSE = new List<int>();

            foreach (int row in Enumerable.Range(0, board.GetLength(0)))
            {
                foreach (int col in Enumerable.Range(0, board.GetLength(1)))
                {
                    char c = board[row, col];
                    List<char> adjacent = new List<char>();
                    
                    if (col != 19)
                    {
                        adjacent.Add(board[row, col + 1]);
                    }
                    if (col != 0)
                    {
                        adjacent.Add(board[row, col - 1]);
                    }
                    if (row != 19)
                    {
                        adjacent.Add(board[row + 1, col]);
                    }
                    if (row != 0)
                    {
                        adjacent.Add(board[row - 1, col]);
                    }                

                    if (c == ' ')
                    {
                        continue;
                    }
                    else if (c == 'R')
                    {
                        if (adjacent.Contains('I')){
                            HSE.Add(1);
                            HSEC += 1;
                        }
                        else
                        {
                            pts = 0;
                            HSEC = 0;

                            for (int i = 0; i < adjacent.Count; i++)
                            {
                                if (adjacent[i] == 'R' || adjacent[i] == 'C')
                                {
                                    pts += 1;
                                    HSEC += 1;
                                }
                                else if (adjacent[i] == 'P')
                                {
                                    pts += 2;
                                    HSEC += 1;
                                }
                            }
                            HSE.Add(pts);
                        }
                    }
                   
                }
            }
            for (int i = 0; i < HSE.Count; i++)
            {            
                game.PlayerScore += HSE[i];
                Console.Write(HSE[i] + " ");
            }
            Console.WriteLine("Your current score: " + game.PlayerScore);
        }

        static void LoadSavedGame()
        {

        }

        static void DisplayHighScores()
        {

        }


    }
}
