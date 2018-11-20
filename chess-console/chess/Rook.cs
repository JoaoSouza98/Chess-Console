using board;

namespace chess {
    class Rook : Piece{

        public Rook(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "R";
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
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row -= 1;
            }

            //south
            pos.defineValues(position.row + 1, position.column);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row += 1;
            }

            //east
            pos.defineValues(position.row, position.column + 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column += 1;
            }

            //west
            pos.defineValues(position.row, position.column - 1);
            while (board.validPosition(pos) && validMove(pos)) {
                array[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column -= 1;
            }

            return array;
        }
    }
}
