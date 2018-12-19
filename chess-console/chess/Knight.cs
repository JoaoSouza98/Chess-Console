using board;

namespace chess {
    class Knight : Piece{

        public Knight(Board board, Color color) : base(board, color) { 
        }

        public override string ToString() {
            return "N";
        }

        private bool validMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMoves() {
            bool[,] array = new bool[board.rowsAmount, board.columnsAmount];

            Position pos = new Position(0,0);

            pos.defineValues(position.row - 1, position.column - 2);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column - 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column + 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 1, position.column + 2);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, position.column + 2);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column + 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column - 1);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, position.column - 2);
            if (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
            }

            return array;

        }
    }
}
