using board;

namespace chess {
    class Pawn : Piece {

        private Match match;

        public Pawn(Board board, Color color, Match match) : base(board, color) {
            this.match = match;
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

                // # Special Move - En Passant (White move)# //
                if (position.row == 3) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && isThereEnemy(left) && board.piece(left) == match.vulnerableEnPassant) {
                        array[left.row - 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && isThereEnemy(right) && board.piece(right) == match.vulnerableEnPassant) {
                        array[right.row - 1, right.column] = true;
                    }
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

                // # Special Move - En Passant (Black move)# //
                if (position.row == 4) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && isThereEnemy(left) && board.piece(left) == match.vulnerableEnPassant) {
                        array[left.row + 1, left.column] = true;
                    }

                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && isThereEnemy(right) && board.piece(right) == match.vulnerableEnPassant) {
                        array[right.row + 1, right.column] = true;
                    }
                }

            }
            return array;
        }
    }
}
