using System;
using board;
using chess;

namespace chess_console {
    class Program {
        static void Main(string[] args) {

            ChessPosition pos = new ChessPosition('c', 7);

            Console.WriteLine(pos.toPosition());

            Console.ReadLine();

        }
    }
}