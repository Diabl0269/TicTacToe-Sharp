using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string row0 = "   1 2 3 ";
            string row1 = " 1 - - - ";
            string row2 = " 2 - - - ";
            string row3 = " 3 - - - ";

            Console.WriteLine("Welcome to the TicTacToe game");
            Console.WriteLine();
            Console.WriteLine(row0);
            Console.WriteLine(row1);
            Console.WriteLine(row2);
            Console.WriteLine(row3);

            string row;
            int column;
            bool GameWon = false;
            bool CurrentPlayer = true;

            for (int i = 0, x = 1; i < x && !(GameWon); i++, x++)
            {
                row = rowCheck();
                column = columnCheck();         
                if (row == line1())
                {
                    if ((column == 3) || (column == 5) || (column == 7))
                    {
                        if (openSlot(row1, column))
                        {
                            row1 = changeRow(row1, column, CurrentPlayer);
                            CurrentPlayer = switchturns(CurrentPlayer);
                        }
                    }                    
                }
                if (row == line2())
                {
                    if ((column == 3) || (column == 5) || (column == 7))
                    {
                        if (openSlot(row2, column))
                        {
                            row2 = changeRow(row2, column, CurrentPlayer);
                            CurrentPlayer = switchturns(CurrentPlayer);
                        }
                    }
                }
                if (row == line3())
                {
                    if ((column == 3) || (column == 5) || (column == 7))
                    {
                        if (openSlot(row3, column))
                        {
                            row3 = changeRow(row3, column, CurrentPlayer);
                            CurrentPlayer = switchturns(CurrentPlayer);
                        }
                    }                   
                }
                drewBoard(row0, row1, row2, row3);
                GameWon = foundWinner(row1, row2, row3);
            }
            string PlayerThatWon;
            if (GameWon)
            {
                if (CurrentPlayer)
                    PlayerThatWon = "player 2";
                else
                    PlayerThatWon = "player 1";

                Console.WriteLine("Bravo " + PlayerThatWon  + " won");
            }
        }       
        static string line1() // The first line
        {
            string row1 = " 1 1 2 3 ";
            return row1;
        }
        static string line2() // The second line
        {
            string row2 = " 2 1 2 3 ";
            return row2;
        }
        static string line3() // The third line
        {
            string row3 = " 3 1 2 3 ";
            return row3;
        }
        static string rowCheck() // in to string
        {
            string row = "";
            while (row == "")
            {
                row += rowInput();
                switch (row)
                {
                    case "1":
                        row = line1();
                        break;
                    case "2":
                        row = line2();
                        break;
                    case "3":
                        row = line3();
                        break;

                    default:
                        rowInput();
                        break;
                }
            }
            return row;
        }
        static int columnCheck() // in to integer
        {
            int result = 0;
            while (result < 3)
            {
                result = columnInput();               
                switch (result)
                {
                    case 1:
                        result = 3;
                        break;
                    case 2:
                        result = 5;
                        break;
                    case 3:
                        result = 7;
                        break;

                    default:
                        columnInput();
                        break;
                }
            }
            return result;
        }
        static bool switchturns(bool CurrentPlayer) // Play with another player
        {
            return CurrentPlayer == true ? false : true;
        }
        static int rowInput() // row input
        {
            string input;
            Console.WriteLine("Enter which row you want and press ENTER");
            input = Console.ReadLine();
            while (!isValidInput(input))
            {
                Console.WriteLine("Invalid input, try again");
                input = Console.ReadLine();
            }
            int row = int.Parse(input);
            return row;
        }
        static int columnInput() // colum  input
        {
            string input;
            Console.WriteLine("Now enter which colum you want and press ENTER");
            input = Console.ReadLine();
            while (!isValidInput(input))
            {
                Console.WriteLine("Invalid input, try again");
                input = Console.ReadLine();
            }
            int colum = int.Parse(input);
            return colum;
        }
        static void drewBoard(string line0, string line1, string line2, string line3) // board drew
        {
            Console.WriteLine(line0);
            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
        }
        static bool foundWinner(string row1 , string row2, string row3) // the winner of the game
        {
            bool diagonal = false, row = false, column = false;
            if ((row2[3] != '-') && (row1[5] != '-') && (row3[7] != '-'))
            {
                diagonal = row2[5] == row1[3] && row2[5] == row3[7] ||
                                row2[5] == row1[7] && row2[5] == row3[3];            
                       
                row = row1[3] == row1[5] && row1[3] == row1[7] ||
                           row2[3] == row2[5] && row2[3] == row2[7] ||
                           row3[3] == row3[5] && row3[3] == row3[7];
                                    
                column = row1[3] == row2[3] && row1[3] == row3[3] ||
                              row1[5] == row2[5] && row1[5] == row3[5] ||
                              row1[7] == row2[7] && row1[7] == row3[7];
            }
            return diagonal || row || column;
        }
        static bool openSlot(string row, int column) // checks if slot open
        {
            return row[column] == '-';
        } 
        static string changeRow(string row, int col, bool playerturn) // player turn
        {
            string result = "";
            string playerSymbol = playerturn == true ? "X" : "O";
            for (int i = 0; i < row.Length; i++)
            {
                result += i == col ? playerSymbol : row[i].ToString();
            }
            return result;
        }
        static bool isValidInput(string input) // ENTER or SPACE typed
        {
            string trimmedInput = input.Trim();
            return input == "1" || input == "2" || input == "3";
        }
    }
}
