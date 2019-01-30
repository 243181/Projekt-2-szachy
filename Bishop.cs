using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Bishop : Piece {

        public Bishop(Board board, int color) : base(board, color) {

            base.type = "bishop";

            if (color == 0) {
                base.icon = '\u2657';
            } else {
                base.icon = '\u265d'; //might be u265D
            }

        }

        public override void SetDestinations(int posX, int posY) {
        

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //w gore po prawej przekątnej
            tmpX = posX + 1;
            tmpY = posY + 1;

            while (tmpX < Board.GameSize 
                && tmpY < Board.GameSize 
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY++;

            }
            //sprawdzenie czy znalezlismy miejsce
            if (tmpX < Board.GameSize
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //gore lewa przekatna
            tmpX = posX - 1;
            tmpY = posY + 1;

            while (tmpX >= 0
                && tmpY < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY++;

            }
            //sprawdzenie czy znalizlismy miejsce
            if (tmpX >= 0
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //dol prawa przekatna
            tmpX = posX + 1;
            tmpY = posY - 1;

            while (tmpX < Board.GameSize
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY--;

            }
      
            if (tmpX < Board.GameSize
                && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //dol lewa przekatna
            tmpX = posX - 1;
            tmpY = posY - 1;

            while (tmpX >= 0
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY--;

            }
 
            if (tmpX >= 0
                && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

        }
    }

}
