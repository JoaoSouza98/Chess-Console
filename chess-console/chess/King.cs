using board;

namespace chess {
    class King : Piece {

        private Match match;

        public King(Board board, Color color, Match match) : base(board, color) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }

        private bool validMove(Position pos) {
            Piece p = board.piece(pos);

            return p == null || p.color != this.color;
        }

        private bool testRookForCastling(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.movmentsAmount == 0;
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

            // # Special Move - Castling # //
            if (movmentsAmount == 0 && !match.check) {
                // Castling - King side (roque pequeno)
                Position posR1 = new Position(position.row, position.column + 3);
                if (testRookForCastling(posR1)) {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if(board.piece(p1) == null && board.piece(p2) == null) {
                        array[position.row, position.column + 2] = true;
                    }
                }

                // Castling - Queen side (roque grande)
                Position posR2 = new Position(position.row, position.column - 4);
                if (testRookForCastling(posR2)) {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null) {
                        array[position.row, position.column - 2] = true;
                    }
                }
            }

            return array;
        }
    }
}
