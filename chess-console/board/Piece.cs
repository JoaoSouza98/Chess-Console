namespace board {
    abstract class Piece {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movmentsAmount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color) {
            this.position = null;
            this.board = board;
            this.color = color;
            movmentsAmount = 0;
        }

        public void incrementMovmentAmnt() {
            movmentsAmount++;
        }

        public void decrementMovmentAmnt() {
            movmentsAmount--;
        }

        public bool avaliableMoves() {
            bool[,] array = possibleMoves();
            for (int i=0; i<board.rowsAmount; i++) {
                for (int j=0; j < board.columnsAmount; j++) {
                    if(array[i,j]) {
                        return true; // return instruction breaks the method
                    }
                }
            }
            return false;


        }

        public bool canMoveTo(Position pos) {
            return possibleMoves()[pos.row, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
