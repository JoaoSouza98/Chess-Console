using board;

namespace chess {
    class King : Piece {

        public King(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "K";
        }

        private bool validMove(Position pos) {
            Piece p = board.piece(pos);

            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMoves() {
            bool[,] array = new bool[board.rowsAmount, board.columnsAmount];

            Position pos = new Position(0, 0);

            //north
            pos.defineValues(position.row - 1, position.column);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //northeast
            pos.defineValues(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //east
            pos.defineValues(position.row, position.column + 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //southeast
            pos.defineValues(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //south
            pos.defineValues(position.row + 1, position.column);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //southwest
            pos.defineValues(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //west
            pos.defineValues(position.row, position.column - 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            //northwest
            pos.defineValues(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            return array;
        }
    }
}
