using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {

            try {
                Board b = new Board(8, 8);

                b.putPiece(new Rook(b, Color.Black), new Position(0, 0));
                b.putPiece(new Rook(b, Color.Black), new Position(1, 3));
                b.putPiece(new King(b, Color.Black), new Position(0, 2));

                b.putPiece(new Rook(b, Color.White), new Position(3, 5));

                Screen.showBoard(b);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}