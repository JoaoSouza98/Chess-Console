using board;

namespace chess {
    class Queen : Piece {

        public Queen(Board board, Color color) : base(board, color) { 
        }

        public override string ToString() {
            return "Q";
        }

        private bool validMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] array = new bool[board.rowsAmount, board.columnsAmount];

            Position pos = new Position(0, 0);

            //west
            pos.defineValues(pos.row, pos.column - 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row, pos.column - 1);
            }

            //east
            pos.defineValues(position.row, position.column + 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row, pos.column + 1);
            }

            //north
            pos.defineValues(position.row - 1, position.column);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column);
            }

            //south
            pos.defineValues(position.row + 1, position.column);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column);
            }

            //northwest
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column - 1);
            }

            //northeast
            pos.defineValues(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column + 1);
            }

            //southeast
            pos.defineValues(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column + 1);
            }

            //southwest
            pos.defineValues(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column - 1);
            }

            return array;
        }
    }
}