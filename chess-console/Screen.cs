using System;
using board;
using chess;

namespace chess_console {
    class Screen {

        public static void showBoard(Board board) {
            for(int i = 0; i < board.rowsAmount; i ++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columnsAmount; j++) {
                    showPiece(board.piece(i, j));
                    
                }
                //After filling a row it breaks the line
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void showBoard(Board board, bool[,] validMoves) {
            ConsoleColor originalBackgroung = Console.BackgroundColor;
            ConsoleColor alternateColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rowsAmount; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columnsAmount; j++) {
                    if (validMoves[i, j] == true) {
                        Console.BackgroundColor = alternateColor;
                    } else {
                        Console.BackgroundColor = originalBackgroung;
                    }
                    showPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackgroung;
                }
                //After filling a row it breaks the line
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackgroung;
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }


        public static void showPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            } else {
                
                if (piece.color == Color.White) {
                Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
