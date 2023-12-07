
/*
  Author: Mckenzie Regalado
  Date created: 12/7/2023
*/

namespace C_;
class Program
{
    static readonly char[ , ] Board = new char[3, 3];  // We represent the board as a 3x3 2-dimesional array.

    static readonly bool[] is_occupied = new bool[9];

    static void InitBoard()                           // Initialize the board.
    {
        // 3x3 board
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Board[i, j] = ' ';   
            }
        }
    }

    static void DisplayBoard()                       // Display the board
    {
        Console.WriteLine("");
        Console.Write($" {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} ");
        Console.Write($"\n---|---|---\n");
        Console.Write($" {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} ");
        Console.Write($"\n---|---|---\n");
        Console.Write($" {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} ");
        Console.WriteLine("\n");
    }

    static int RemainingMove()                       // Check how many moves are available.
    {
        int move = 9;
        for (int i = 0; i < is_occupied.Length; i++)
        {
            if (is_occupied[i])
            {
                move--;
            }
        }
        return move;
    }

    static bool IsValidMove(int position)          // Check if the position that the player entered is in the range (1-9).
    {
        return position >= 1 && position <= 9;
    }

    static bool IsOccupied(int position)           // Check if the position already occupied.
    {
        return is_occupied[position-1];
    }

    static void Move(int player_id, int position)
    {
        char move = (player_id == 1) ? 'X' : 'O';

        if (!IsValidMove(position))
        {
            Console.WriteLine("Invalid move! Please try again.");
            return;
        }

        if (IsOccupied(position))
        {
            Console.WriteLine("Position already occupied! Please try again.");
            return;
        }

        switch (position)
        {
            case 1:
                /* code */
                Board[0, 0] = move;
                is_occupied[0] = true;
                break;
            case 2:
                /* code */
                Board[0, 1] = move;
                is_occupied[1] = true;
                break;
            case 3:
                /* code */
                Board[0, 2] = move;
                is_occupied[2] = true;
                break;
            case 4:
                /* code */
                Board[1, 0] = move;
                is_occupied[3] = true;
                break;
            case 5:
                /* code */
                Board[1, 1] = move;
                is_occupied[4] = true;
                break;
            case 6:
                /* code */
                Board[1, 2] = move;
                is_occupied[5] = true;
                break;
            case 7:
                /* code */
                Board[2, 0] = move;
                is_occupied[6] = true;
                break;
            case 8:
                /* code */
                Board[2, 1] = move;
                is_occupied[7] = true;
                break;
            case 9:
                /* code */
                Board[2, 2] = move;
                is_occupied[8] = true;
                break;
            default:
                break;
        }
    }

static char CheckWinner() 
{ 

    /*
     * Return the first player that gets 3 marks in a row (horizontally, vertically, or diagonally). Otherwise, return none.
    */

    // Check horizontally
    for (int i = 0; i < 3; i++)
    {
        /* code */
        if (Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2])
        {
            return Board[i, 0];
        }
    }

    // Check vertically
    for (int i = 0; i < 3; i++)
    {
        /* code */
        if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
        {
            return Board[0, i];
        }
    }

    // Check diagonally
    if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
    {
        return Board[0, 0];
    }

    if (Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0])
    {
        return Board[0, 2];
    }

    return ' ';
}

    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine(" _____ _      _____          _____");
        Console.WriteLine("|_   _(_)__  |_   _|_ _ __  |_   _|__  ___");
        Console.WriteLine("  | | | / _|   | |/ _` / _|   | |/ _ \\/ -_)");
        Console.WriteLine("  |_| |_\\__|   |_|\\__,_\\__|   |_|\\___/\\___|");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("\n1). Player 1 is X and Player 2 is O.          ");
        Console.WriteLine("2). To place your move in the board just enter a number between [1-9].");
        Console.Write($" 1 | 2 | 3 ");
        Console.Write($"\n---|---|---\n");
        Console.Write($" 4 | 5 | 6 ");
        Console.Write($"\n---|---|---\n");
        Console.Write($" 7 | 8 | 9 ");
        Console.WriteLine("\n3). The player to get three marks in a row (horizontally, vertically, or diagonally) first wins.");
        Console.Write($" X |   |   ");
        Console.Write($"\n---|---|---\n");
        Console.Write($"   | X |   ");
        Console.Write($"\n---|---|---\n");
        Console.Write($"   |   | X ");
        Console.WriteLine("\n");

        InitBoard();
        DisplayBoard();

        while (RemainingMove() != 0)                                         // loop until we run out of moves.
        {
            /*
             * Since we are accepting an integer type in the user input,
             * it's better to use try-catch block to handle the exception properly or to prevent the program from crashing.
            */
            try
            {
                int player_id = (RemainingMove() % 2 != 0) ? 1 : 2;

                Console.Write($"Player {player_id}: ");

                int position = Convert.ToInt16(Console.ReadLine());           // Player's location in the board.

                Move(player_id, position);

                DisplayBoard();

                if (CheckWinner() != ' ')                                     // If the player gets 3 in a row, display a greeting message.
                {
                    Console.WriteLine($"Congratulations to PLAYER {player_id}! Well done!");
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Please, Number Only!");
            }
        }

        // Draw
        if (CheckWinner() == ' ' && RemainingMove() == 0)                   // If none of the players gets 3 marks in a row and all the location in the boards are filled,
        {
            Console.WriteLine("Draw!");                                     // that means we have a DRAW or TIE.
        }
    }
}