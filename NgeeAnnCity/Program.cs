using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Security;

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

        static void DisplayBoard(char[,] board, Game g)
        {
            int NUM_ROWS = g.MaxRow;
            int NUM_COLUMNS = g.MaxRow;
            
            if (NUM_ROWS == 10)
            {
                Console.WriteLine("     A   B   C   D   E   F   G   H   I   J  ");
                Console.WriteLine("   +---+---+---+---+---+---+---+---+---+---+");
            }
            
            if (NUM_ROWS == 20)
            {
                Console.WriteLine("     A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R   S   T");
                Console.WriteLine("   +---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+");
            }

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
            
            Console.Write(" Welcome to Ngee Ann City!\n Enter your name: ");

            string name = Console.ReadLine();

            Console.Write(" Choose your grid size: \n 1. 10x10 \n 2. 20x20 \n 0. Exit \n Your Choice: ");
            int max_row = 0;
            int choice = -1;

            while (choice != 0)
            {
                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.Write(" Only integers from 1 - 2 are allowed. Try Again.\n Your Choice: "); choice = -1; }

                if (choice == 1)
                {
                    max_row = 10;
                    char[,] Board = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
                    };

                    Console.WriteLine("\n Have fun in Ngee Ann City, " + name + "!\n");
                    Game newGame = new Game() { MaxRow = max_row, PlayerName = name, PlayerScore = 0, PlayerBoard = Board, Coins = 8, Turn = 0 };
                    return newGame;

                }

                if (choice == 2)
                {
                    max_row = 20;
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
                    Console.WriteLine("\n Have fun in Ngee Ann City, " + name + "!\n");
                    Game newGame = new Game() { MaxRow = max_row, PlayerName = name, PlayerScore = 0, PlayerBoard = Board, Coins = 16, Turn = 0 };
                    return newGame;
                }


                else if (choice > 2)
                {
                    Console.Write(" Only integers from 1 - 2 are allowed. Try Again.\n Your Choice: ");
                }
            }

            Game Game = new Game();
            return Game;
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

                if (game.Coins == 0)
                {
                    EndGame(game);
                    break;
                }

                DisplayBoard(game.PlayerBoard, game);

                Random rnd = new Random();
                char building1 = buildingList[rnd.Next(0, 5)];
                char building2 = buildingList[rnd.Next(0, 5)];
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

                Console.Write(" 3. See Current Score\n 4. Save Game\n 5. Exit to Main Menu\n 0. Need Help? \n\n Enter your choice: ");

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

                if (choice == 0)
                {
                    HelpInfo();
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

                        if (row + 1 == game.MaxRow)
                        {
                            checkDown = false;
                        }

                        if (row + 1 == 1)
                        {
                            checkUp = false;
                        }
                        if (col + 1 == game.MaxRow)
                        {
                            checkRight = false;
                        }
                        if (col + 1 == 1)
                        {
                            checkLeft = false;
                        }

                        if (row + 1 == game.MaxRow && col == 0)
                        {
                            checkDown = false;
                            checkLeft = false;
                        }

                        if (row == 0 && col + 1 == game.MaxRow)
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

        static int seeCurrentScore(Game game)
        {
            char[,] board = game.PlayerBoard;        
            int pts = 0;
            int total = 0;

            int RCount = 0;
            int ICount = 0;
            int CCount = 0;
            int PCount = 0;
            int HWYCount = 0;

            int RPts = 0;
            int IPts = 0;
            int CPts = 0;
            int PPts = 0;
            int HWYPts = 0;

            List<int> R = new List<int>();
            List<int> I = new List<int>();
            List<int> C = new List<int>();
            List<int> P = new List<int>();
            List<int> HWY = new List<int>();

            foreach (int row in Enumerable.Range(0, board.GetLength(0)))
            {                 
                foreach (int col in Enumerable.Range(0, board.GetLength(1)))
                {
                    char c = board[row, col];
                    List<char> adjacent = new List<char>();

                    // if current building is *
                    int count = 0;
                    if (c == '*')
                    {
                        count += 1;
                        HWYCount += 1;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                HWY.Add(count);
                            }
                            count = 0;
                        }
                    }
                    if (count != 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            HWY.Add(count);
                        }
                        count = 0;
                    }
                                                     
                    if (col + 1 != game.MaxRow)
                    {
                        adjacent.Add(board[row, col + 1]);
                    }
                    if (col != 0)
                    {
                        adjacent.Add(board[row, col - 1]);
                    }
                    if (row + 1 != game.MaxRow)
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

                    // if current building is R
                    else if (c == 'R')
                    {                     
                        if (adjacent.Contains('I')){
                            R.Add(1);
                            RCount += 1;
                        }
                        else
                        {
                            pts = 0;
                            RCount = 0;

                            for (int i = 0; i < adjacent.Count; i++)
                            {
                                if (adjacent[i] == 'R' || adjacent[i] == 'C')
                                {                                  
                                    pts += 1;
                                    RCount += 1;
                                }
                                else if (adjacent[i] == 'P')
                                {                              
                                    pts += 2;
                                    RCount += 1;
                                }
                            }                        
                            R.Add(pts);
                        }
                    }

                    // if current buidling is I
                    else if (c == 'I')
                    {
                        ICount += 1;
                        I.Add(1);
                    }

                    // if current building is C
                    else if (c == 'C')
                    {
                        List<char> CAdjacent = new List<char>();
                        for (int i = 0; i < adjacent.Count; i++)
                        {
                            if (adjacent[i] == 'C')
                            {
                                CAdjacent.Add('C');
                                CCount += 1;
                            }
                        }
                        C.Add(CAdjacent.Count);                
                    } 
                    
                    // if current building is P
                    else if (c == 'P')
                    {
                        List<char> PAdjacent = new List<char>();
                        for (int i = 0; i < adjacent.Count; i++)
                        {
                            if (adjacent[i] == 'P')
                            {
                                PAdjacent.Add('P');
                                PCount += 1;
                            }
                        }
                        P.Add(PAdjacent.Count);
                    }                  
                }
            }
        
            // R Points calculation
            if (RCount == 0)
            {
                Console.WriteLine('0');
            }
            else if (RCount != 0)
            {
                for (int i = 0; i < R.Count; i++)
                {               
                    RPts += R[i];
                    total += RPts;
                }
            }

            // I Points calculation
            if (ICount == 0)
            {
                Console.WriteLine('0');
            }
            else if (ICount != 0)
            {
                for (int i = 0; i < I.Count; i++)
                {                 
                    IPts += I[i];
                    total += IPts;

                }
            }

            // C Points calculation
            if (CCount == 0)
            {
                Console.WriteLine('0');
            }
            else if (CCount != 0)
            {
                for (int i = 0; i < C.Count; i++)
                {                  
                    CPts += C[i];
                    total += CPts;
                }
            }

            // P Points calculation
            if (PCount == 0)
            {
                Console.WriteLine("0");
            }
            else if (PCount != 0)
            {
                for (int i = 0; i < P.Count; i++)
                {                 
                    PPts += P[i];
                    total += PPts;
                }
            }

            // * Points Calculation
            if (HWYCount == 0)
            {
                Console.WriteLine('0');
            }
            else if (HWYCount != 0)
            {
                for (int i = 0; i < HWY.Count; i++)
                {                  
                    HWYPts += HWY[i];
                    total += HWYPts;
                }
            }

            // Display score for each building
            Console.WriteLine("\nYour current points: " + "Residential (R) - " + RPts + " | " + "Industry (I) - " +
                IPts + " | " + "Commercial (C) - " + CPts + " | " + "Park (P) - " + PPts + " | " + "Road (*) - " + HWYPts);
            Console.WriteLine(" ");

            // Update overall Player Score
            game.PlayerScore = total;

            Console.WriteLine(" Total Points: " + total);
            return total;             
        }

        static void LoadSavedGame()
        {

        }

        static void DisplayHighScores()
        {
   
        }

        static void HelpInfo()
        {
            
            Console.WriteLine(" Building Scores: \n Industry (I) - Scores 1 point per industry in the city. Each industry generates 1 coin per residential building adjacent to it.");
            Console.WriteLine(" Commercial (C): Scores 1 point per commercial adjacent to it. Each commercial generates 1 coin \n Residential (R): If it is next to an industry (I), then it scores 1 point only. Otherwise, it scores 1 point for each adjacent residential (R) or commercial (C), and 2 points for each adjacent park (O).\n Park (O): Scores 1 point per park adjacent to it. \n Road (*): Scores 1 point per connected road (*) in the same row.\n ");
        }

        static void SaveGame(Game game)
        {
            char[,] board = game.PlayerBoard;
            char s = ' ';

            string turn = $"Turn - {game.Turn}\n";
            File.WriteAllText("D:\\VS2022 Stash\\NgeeAnnCity\\NgeeAnnCity\\testing.txt", turn);

            Console.WriteLine("Game saved!\n");
        }

        static void EndGame(Game game)
        {
            Console.WriteLine(" You have finished your coins! \n This is your final board: \n Your final score: " + seeCurrentScore(game));
            DisplayBoard(game.PlayerBoard, game);
        }

    }
}
