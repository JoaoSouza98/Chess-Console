using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {

            Board b = new Board(8, 8);

            b.putPiece(new Rook(b, Color.Black), new Position(0, 0));
            b.putPiece(new Rook(b, Color.Black), new Position(1, 3));
            b.putPiece(new King(b, Color.Black), new Position(2, 4));

            Screen.showBoard(b);

            Console.ReadLine();

        }
    }
}