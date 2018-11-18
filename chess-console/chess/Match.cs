using System;
using board;

namespace chess {
    class Match {

        public Board b { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool matchOver { get; set; }

        public Match() {
            b = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            matchOver = false;
            showPieces();
        }

        public void makeMove(Position origin, Position destiny) {
            Piece p = b.removePiece(origin);
            p.incrementMovmentAmnt();
            Piece capturedPiece = b.removePiece(destiny);
            b.putPiece(p, destiny);
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
