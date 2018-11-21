using System;
using board;

namespace chess {
    class Match {

        public Board b { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool matchOver { get; set; }

        public Match() {
            b = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            matchOver = false;
            showPieces();
        }

        public void movePiece (Position origin, Position destiny) {
            Piece p = b.removePiece(origin);
            p.incrementMovmentAmnt();
            Piece capturedPiece = b.removePiece(destiny);
            b.putPiece(p, destiny);
        }

        public void makeAMove(Position origin, Position destiny) {
            movePiece(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (b.piece(pos) == null) {
                throw new BoardException("There isn't a piece at this position!");
            }
            if (currentPlayer != b.piece(pos).color) {
                throw new BoardException("This isn't one of your pieces!");
            }
            if (!b.piece(pos).avaliableMoves()) {
                throw new BoardException("There isn't avaliable moves for this piece!");
            }
        }
        
        public void validateDestinyPosition(Position origin, Position destiny) {
            if (!b.piece(origin).canMoveTo(destiny)) {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        private void showPieces() {

            b.putPiece(new Rook(b, Color.White), new ChessPosition('c', 1).toPosition());
            b.putPiece(new Rook(b, Color.White), new ChessPosition('c', 2).toPosition());
            b.putPiece(new Rook(b, Color.White), new ChessPosition('d', 2).toPosition());
            b.putPiece(new Rook(b, Color.White), new ChessPosition('e', 1).toPosition());
            b.putPiece(new Rook(b, Color.White), new ChessPosition('e', 2).toPosition());
            b.putPiece(new King(b, Color.White), new ChessPosition('d', 1).toPosition());



            b.putPiece(new Rook(b, Color.Black), new ChessPosition('c', 7).toPosition());
            b.putPiece(new Rook(b, Color.Black), new ChessPosition('c', 8).toPosition());
            b.putPiece(new Rook(b, Color.Black), new ChessPosition('d', 7).toPosition());
            b.putPiece(new Rook(b, Color.Black), new ChessPosition('e', 7).toPosition());
            b.putPiece(new Rook(b, Color.Black), new ChessPosition('e', 8).toPosition());
            b.putPiece(new King(b, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
