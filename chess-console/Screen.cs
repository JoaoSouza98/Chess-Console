using System;
using board;
using chess;

namespace chess_console {
    class Screen {

        public static void showBoard(Board board) {
            for(int i = 0; i < board.rowsAmount; i ++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columnsAmount; j++) {
                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        showPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                }
                //After filling a row it breaks the line
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }


        public static void showPiece(Piece piece) {
            if(piece.color == Color.White) {
                Console.Write(piece);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

    }
}
