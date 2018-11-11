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
    }
}
