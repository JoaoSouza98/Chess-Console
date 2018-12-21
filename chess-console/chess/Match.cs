using System.Collections.Generic;
using board;

namespace chess {
    class Match {

        public Board b { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool matchOver { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }

        public Match() {
            b = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            matchOver = false;
            check = false;
            vulnerableEnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            showPieces();
        }

        public Piece movePiece (Position origin, Position destiny) {
            Piece p = b.removePiece(origin);
            p.incrementMovmentAmnt();
            Piece capturedPiece = b.removePiece(destiny);
            b.putPiece(p, destiny);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }

            // # Special Move - Castling - King side (roque pequeno) # //
            if (p is King && destiny.column == origin.column + 2) {
                Position originR = new Position(origin.row, origin.column + 3);
                Position destinyR = new Position(origin.row, origin.column + 1);
                Piece R = b.removePiece(originR);
                R.incrementMovmentAmnt();
                b.putPiece(R, destinyR);
            }

            // # Special Move - Castling - Queen side (roque grande) # //
            if (p is King && destiny.column == origin.column - 2) {
                Position originR = new Position(origin.row, origin.column - 4);
                Position destinyR = new Position(origin.row, origin.column - 1);
                Piece R = b.removePiece(originR);
                R.incrementMovmentAmnt();
                b.putPiece(R, destinyR);
            }

            // # Special Move - En Passant # //
            if (p is Pawn) {
                if (origin.column != destiny.column && capturedPiece == null) {
                    Position posP;
                    if (p.color == Color.White) {
                        posP = new Position(destiny.row + 1, destiny.column);
                    }
                    else {
                        posP = new Position(destiny.row - 1, destiny.column);
                    }
                    capturedPiece = b.removePiece(posP);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece) {
            Piece p = b.removePiece(destiny);
            p.decrementMovmentAmnt();
            if (capturedPiece != null) {
                b.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            b.putPiece(p, origin);

            // # Special Move - Castling - King side (roque pequeno) # //
            if (p is King && destiny.column == origin.column + 2) {
                Position originR = new Position(origin.row, origin.column + 3);
                Position destinyR = new Position(origin.row, origin.column + 1);
                Piece R = b.removePiece(destinyR);
                R.decrementMovmentAmnt();
                b.putPiece(R, originR);
            }
            
            // # Special Move - Castling - Queen side (roque grande) # //
            if (p is King && destiny.column == origin.column - 2) {
                Position originR = new Position(origin.row, origin.column - 4);
                Position destinyR = new Position(origin.row, origin.column - 1);
                Piece R = b.removePiece(destinyR);
                R.decrementMovmentAmnt();
                b.putPiece(R,originR);
            }

            // # Special Move - En Passant # //
            if (p is Pawn) {
                if (origin.column != destiny.column && capturedPiece == vulnerableEnPassant) {
                    Piece pawn = b.removePiece(destiny);
                    Position posP;
                    if (p.color == Color.White) {
                        posP = new Position(3, destiny.column);
                    }
                    else {
                        posP = new Position(4, destiny.column);
                    }
                    b.putPiece(pawn, posP);
                }
            }

        }

        public void makeAMove(Position origin, Position destiny) {
            Piece capturedPiece = movePiece(origin, destiny);

            if (isInCheck(currentPlayer)) {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardException("You cannot put yourself in CHECK!");
            }

            Piece p = b.piece(destiny);

            // # Special Move - Promotion # //
            if (p is Pawn) {
                if ((p.color == Color.White && destiny.row == 0) || p.color == Color.Black && destiny.row == 7) {
                    p = b.removePiece(destiny);
                    pieces.Remove(p);
                    Piece queen = new Queen(b, p.color);
                    b.putPiece(queen, destiny);
                    pieces.Add(queen);
                }
            }

            if (isInCheck(opponent(currentPlayer))) {
                check = true;
            } else {
                check = false;
            }

            if (testCheckmate(opponent(currentPlayer))) {
                matchOver = true;
            }
            else {
                turn++;
                changePlayer();
            }
            

            // # Special Move - En Passant # //
            if (p is Pawn && (destiny.row == origin.row - 2 || destiny.row == origin.row + 2)) {
                vulnerableEnPassant = p;
            } else {
                vulnerableEnPassant = null;
            }
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


        private Color opponent(Color color) {
            if (color == Color.White) {
                return Color.Black;
            } else {
                return Color.White;
            }
        }


        private Piece king(Color color) {
            foreach (Piece x in inGamePieces(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null; //caso não tem rei (o que não deve acontecer numa partida de xadrez) retorna nulo
        }

        public bool isInCheck(Color color) {
            Piece k = king(color);
            if (k == null) { //<--should never happen, only implemented for keep the good practices
                throw new BoardException("There is no " + color + " king");
            }

            foreach (Piece x in inGamePieces(opponent(color))) {
                bool[,] array = x.possibleMoves();
                if (array[k.position.row, k.position.column]) { // == true omitido
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color) {
            if(!isInCheck(color)) {
                return false;
            }

            foreach (Piece x in inGamePieces(color)) {
                bool[,] array = x.possibleMoves();
                for (int i = 0; i<b.rowsAmount; i++) {
                    for (int j = 0; j<b.columnsAmount; j++) {
                        if(array[i, j]) {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = movePiece(origin, destiny);
                            bool testCheck = isInCheck(color);
                            undoMove(origin, destiny, capturedPiece);

                            if (!testCheck) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void placeNewPiece(char column, int row, Piece piece) {
            b.putPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void showPieces() {
            placeNewPiece('a', 1, new Rook(b, Color.White));
            placeNewPiece('b', 1, new Knight(b, Color.White));
            placeNewPiece('c', 1, new Bishop(b, Color.White));
            placeNewPiece('d', 1, new Queen(b, Color.White));
            placeNewPiece('e', 1, new King(b, Color.White, this));
            placeNewPiece('f', 1, new Bishop(b, Color.White));
            placeNewPiece('g', 1, new Knight(b, Color.White));
            placeNewPiece('h', 1, new Rook(b, Color.White));
            placeNewPiece('a', 2, new Pawn(b, Color.White, this));
            placeNewPiece('b', 2, new Pawn(b, Color.White, this));
            placeNewPiece('c', 2, new Pawn(b, Color.White, this));
            placeNewPiece('d', 2, new Pawn(b, Color.White, this));
            placeNewPiece('e', 2, new Pawn(b, Color.White, this));
            placeNewPiece('f', 2, new Pawn(b, Color.White, this));
            placeNewPiece('g', 2, new Pawn(b, Color.White, this));
            placeNewPiece('h', 2, new Pawn(b, Color.White, this));

            placeNewPiece('a', 8, new Rook(b, Color.Black));
            placeNewPiece('b', 8, new Knight(b, Color.Black));
            placeNewPiece('c', 8, new Bishop(b, Color.Black));
            placeNewPiece('d', 8, new Queen(b, Color.Black));
            placeNewPiece('e', 8, new King(b, Color.Black, this));
            placeNewPiece('f', 8, new Bishop(b, Color.Black));
            placeNewPiece('g', 8, new Knight(b, Color.Black));
            placeNewPiece('h', 8, new Rook(b, Color.Black));
            placeNewPiece('a', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('b', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('c', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('d', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('e', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('f', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('g', 7, new Pawn(b, Color.Black, this));
            placeNewPiece('h', 7, new Pawn(b, Color.Black, this));
        }
    }
}
