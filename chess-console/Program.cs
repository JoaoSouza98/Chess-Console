using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {

            try {
                Match match = new Match();

                while(!match.matchOver) {
                    Console.Clear();
                    Screen.showBoard(match.b);
                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] validMoves = match.b.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.showBoard(match.b, validMoves);

                    Console.WriteLine();

                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.makeMove(origin, destiny);
                }

                Screen.showBoard(match.b);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}