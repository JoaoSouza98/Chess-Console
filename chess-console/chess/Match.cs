using System.Collections.Generic;
using board;

namespace chess {
    class Match {

        public Board b { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool matchOver { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;


        public Match() {
            b = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            matchOver = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            showPieces();
        }

        public void movePiece (Position origin, Position destiny) {
            Piece p = b.removePiece(origin);
            p.incrementMovmentAmnt();
            Piece capturedPiece = b.removePiece(destiny);
            b.putPiece(p, destiny);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if(x.color == color) {
                    aux.Add(x);     
                }
            }
            return aux;
        }

        public HashSet<Piece> inGamePieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }


        public void placeNewPiece(char column, int row, Piece piece) {
            b.putPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void showPieces() {
            placeNewPiece('c', 1, new Rook(b, Color.White));
            placeNewPiece('c', 2, new Rook(b, Color.White));
            placeNewPiece('d', 2, new Rook(b, Color.White));
            placeNewPiece('e', 2, new Rook(b, Color.White));
            placeNewPiece('e', 1, new Rook(b, Color.White));
            placeNewPiece('d', 1, new King(b, Color.White));

            placeNewPiece('c', 7, new Rook(b, Color.Black));
            placeNewPiece('c', 8, new Rook(b, Color.Black));
            placeNewPiece('d', 7, new Rook(b, Color.Black));
            placeNewPiece('e', 7, new Rook(b, Color.Black));
            placeNewPiece('e', 8, new Rook(b, Color.Black));
            placeNewPiece('d', 8, new King(b, Color.Black));

        }
    }
}
