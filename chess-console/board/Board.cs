namespace board {
    class Board {

        public int rowsAmount { get; set; }
        public int columnsAmount { get; set; }
        private Piece[,] pieces;

        public Board(int rowsAmount, int columnsAmount) {
            this.rowsAmount = rowsAmount;
            this.columnsAmount = columnsAmount;
            pieces = new Piece[rowsAmount, columnsAmount];
        }

        public Piece piece(int row, int column) {
            return pieces[row, column];
        }

        //override improvment for piece positioning
        public Piece piece(Position pos) {
            return pieces[pos.row, pos.column];
        }

        public bool IsTherePiece(Position pos) {
            validatePosition(pos);

            return piece(pos) != null; //<-- boolean expression
        }

        public void putPiece(Piece p, Position pos) {
            if (IsTherePiece(pos)) {
                throw new BoardException("There's already a piece at this position!");
            }
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos) {
            if (piece(pos) == null) {
                return null;
            }

            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.column] = null;
            return aux;
        }

        //catch invalid position according to the board size
        public bool validPosition(Position pos) {
            if (pos.row < 0 || pos.row >= rowsAmount || pos.column < 0 || pos.column >= columnsAmount) {
                return false;
            }
            return true;
        }

        //case validPosition == false, throw an customized Exception
        public void validatePosition(Position pos) {
            if(!validPosition(pos)) {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
