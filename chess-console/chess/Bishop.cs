using board;

namespace chess {
    class Bishop : Piece{

        public Bishop(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "B";
        }

        private bool validMove(Position pos) {
            Piece p = board.piece(pos);

            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMoves() {
            bool[,] array = new bool[board.rowsAmount, board.columnsAmount];


            Position pos = new Position(0, 0);

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
