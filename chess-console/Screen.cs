using System;
using board;

namespace chess_console {
    class Screen {

        public static void showBoard(Board board) {
            for(int i = 0; i < board.rowsAmount; i ++) {
                for(int j = 0; j < board.columnsAmount; j++) {
                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(board.piece(i, j) + " ");
                    }
                }
                //After filling a row it breaks the line
                Console.WriteLine();
            }
        }
    }
}
