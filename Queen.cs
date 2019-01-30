using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Queen : Piece {

        public Queen(Board board, int color) : base(board, color) {

            base.type = "queen";

            if (color == 0) {
                base.icon = '\u2655';
            } else {
                base.icon = '\u265b';
            }

        }

        public override void SetDestinations(int posX, int posY) {
           

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //metody skopiowane z wiezy gora dol prawo lewo

            //gora
            tmpX = posX;
            tmpY = posY + 1;

            while (tmpY < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY++;

            }
            
            if (tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //dol
            tmpX = posX;
            tmpY = posY - 1;

            while (tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY--;

            }
            
            if (tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //prawo
            tmpX = posX + 1;
            tmpY = posY;

            while (tmpX < Board.GameSize
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;

            }
            
            if (tmpX < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //lewo
            tmpX = posX - 1;
            tmpY = posY;

            while (tmpX >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;

            }
            
            if (tmpX >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //skopiowane z laufra

            //w gore prawo po przekatnej
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
           
            if (tmpX < Board.GameSize
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //gora lewo po przekatnej
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
           
            if (tmpX >= 0
                && tmpY < Board.GameSize
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //dol prawo po przekatnej
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

            //dol lewo po przekatnej
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
