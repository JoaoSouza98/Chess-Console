using board;

namespace chess {
    class Pawn : Piece {

        public Pawn(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "P";
        }

        public bool isThereEnemy(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != this.color;
        }

        private bool free(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves() {
            bool[,] array = new bool[board.rowsAmount, board.columnsAmount];

            Position pos = new Position(0, 0);

            if (color == Color.White) {
                pos.defineValues(position.row - 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 2, position.column);
                if (board.validPosition(pos) && free(pos) && movmentsAmount == 0) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && isThereEnemy(pos)) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && isThereEnemy(pos)) {
                    array[pos.row, pos.column] = true;
                }
            }
            else {
                pos.defineValues(position.row + 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 2, position.column);
                if (board.validPosition(pos) && free(pos) && movmentsAmount == 0) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && isThereEnemy(pos)) {
                    array[pos.row, pos.column] = true;
                }

                pos.defineValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && isThereEnemy(pos)) {
                    array[pos.row, pos.column] = true;
                }

            }
            return array;
        }
    }
}
