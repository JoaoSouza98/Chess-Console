using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {

            try {
                Match match = new Match();

                while(!match.matchOver) {
                    try {
                        Screen.showMatch(match);


                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] validMoves = match.b.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.showBoard(match.b, validMoves);

                        Console.WriteLine();

                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.makeAMove(origin, destiny);
                    } catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.showMatch(match);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}