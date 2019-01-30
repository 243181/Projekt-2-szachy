using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Board {

  
        public const int GameSize = 8;

        /// <summary>
        /// [0][0] - a1
        /// [0][7] - a8
        /// [7][0] - h1
        /// [7][7] - h8
        /// </summary>
        private BoardSpace[][] board;

       
        private LinkedList<Piece> deadBlacks;
        private LinkedList<Piece> deadWhites;

        public LinkedList<Piece> DeadBlacks {
            get { return this.deadBlacks; }
        }
        public LinkedList<Piece> DeadWhites {
            get { return this.deadWhites; }
        }


        public Board() {

            this.Reset();

        }

      
        public void Reset() {
            //inicjalizowanie slownika
            this.deadBlacks = new LinkedList<Piece>();
            this.deadWhites = new LinkedList<Piece>();

            //inicjowanie tablicy
            this.board = new BoardSpace[Board.GameSize][];
            for (int i = 0; i < this.board.Length; i++) {
                this.board[i] = new BoardSpace[Board.GameSize];
            }

            //tworzenie miejsca
            for (int i = 0; i < this.board.Length; i++) {
                for (int j = 0; j < this.board.Length; j++) {

                    this.board[i][j] = new BoardSpace();

                }
            }

            //wieze
            this.board[0][0].Piece = new Rook(this, 0);
            this.board[7][0].Piece = new Rook(this, 0);
            this.board[0][7].Piece = new Rook(this, 1);
            this.board[7][7].Piece = new Rook(this, 1);

            //konie
            this.board[1][0].Piece = new Knight(this, 0);
            this.board[6][0].Piece = new Knight(this, 0);
            this.board[1][7].Piece = new Knight(this, 1);
            this.board[6][7].Piece = new Knight(this, 1);

            //laufry
            this.board[2][0].Piece = new Bishop(this, 0);
            this.board[5][0].Piece = new Bishop(this, 0);
            this.board[2][7].Piece = new Bishop(this, 1);
            this.board[5][7].Piece = new Bishop(this, 1);

            //krolowe
            this.board[3][0].Piece = new Queen(this, 0);
            this.board[3][7].Piece = new Queen(this, 1);

            //krolowie
            this.board[4][0].Piece = new King(this, 0);
            this.board[4][7].Piece = new King(this, 1);

            //piony
            for (int i = 0; i < Board.GameSize; i++) {
                this.board[i][1].Piece = new Pawn(this, 0);
            }

            for (int i = 0; i < Board.GameSize; i++) {
                this.board[i][6].Piece = new Pawn(this, 1);
            }
        }

        public BoardSpace GetBoardSpace(int posX, int posY) {
            return this.board[posX][posY];
        }

        public void KillPiece(BoardSpace space) { 

            Piece tmp = space.Piece;
            int color = tmp.Color;
            tmp.Alive = false;


            if ( tmp.Type.Equals("king") ) {

                if (color == 0) {
                    this.deadWhites.AddFirst(tmp);
                } else {
                    this.deadBlacks.AddFirst(tmp);
                }
            } else {
                if (color == 0) {
                    this.deadWhites.AddLast(tmp);
                } else {
                    this.deadBlacks.AddLast(tmp);
                }
            }
            
            space.Piece = null; 
            space.Occupied = false; 
            space.IsPossibleDestination = false; 

        }

        
        public string ToString() {

            StringBuilder output = new StringBuilder();

            output.Append(this.DeadPiecesToString(this.deadBlacks) + "\n");

            output.Append("    A    B    C    D    E    F    G   H" + "\n");

            output.Append("  ┌────┬────┬────┬────┬────┬────┬────┬────┐" + "\n");

            for (int i = (Board.GameSize * 2) - 1; i > 0; i--) {

                if (i % 2 != 0) {

                    output.Append((i / 2) + 1 + " ");

                    for (int j = 0; j < Board.GameSize; j++) {

                        if (this.board[j][(i / 2)].Occupied && this.board[j][(i / 2)].IsPossibleDestination) {
                            output.Append("│ X  ");
                        } else if (this.board[j][(i / 2)].IsPossibleDestination) {
                            output.Append("│ x  ");
                        } else if (this.board[j][(i / 2)].Occupied) {
                            output.Append("│ " + this.board[j][(i / 2)].Piece.Icon + " ");
                        } else {
                            output.Append("│    ");
                        }

                    }

                    output.Append("│\n");

                } else {
                    output.Append("  ├────┼────┼────┼────┼────┼────┼────┼────┤" + "\n");
                }

            }

            output.Append("  └────┴────┴────┴────┴────┴────┴────┴────┘" + "\n");

            output.Append(this.DeadPiecesToString(this.deadWhites) + "\n");

            return output.ToString();
        }

      
        private string DeadPiecesToString(LinkedList<Piece> deadPieces) {

            StringBuilder output = new StringBuilder();

            foreach (Piece piece in deadPieces) {

                output.Append(" " + piece.Icon + " ");

            }

            return output.ToString();

        }

    }

}
