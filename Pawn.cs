using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Pawn : Piece {

        public Pawn(Board board, int color) : base(board, color) {

            base.type = "pawn";

            if (color == 0) {
                base.icon = '\u2659';
            } else {
                base.icon = '\u265f'; 
            }

        }

        public override void SetDestinations(int posX, int posY) {
            

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //ruch o dwa pola
            tmpX = posX;
            int otherY;
            if (this.Color == 0) { 
                tmpY = posY + 2;
                otherY = posY + 1;
            } else {
                tmpY = posY - 2;
                otherY = posY - 1;
            }

            if (!this.Played 
                && tmpY < Board.GameSize 
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && !this.Board.GetBoardSpace(tmpX, otherY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //ruch o jedno pole
            tmpX = posX;
            if (this.Color == 0) { 
                tmpY = posY + 1;
            } else {
                tmpY = posY - 1;
            }

            if (tmpY < Board.GameSize
                && tmpY >= 0
                && !this.Board.GetBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //przekatna w prawo
            if (this.Color == 0) { 
                tmpX = posX + 1;
                tmpY = posY + 1;
            } else {
                tmpX = posX + 1;
                tmpY = posY - 1;
            }

            if (tmpX < Board.GameSize && tmpX >= 0
                && tmpY < Board.GameSize && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //przekatna lewo
            if (this.Color == 0) { 
                tmpX = posX - 1;
                tmpY = posY + 1;
            } else {
                tmpX = posX - 1;
                tmpY = posY - 1;
            }

            if (tmpX < Board.GameSize && tmpX >= 0
                && tmpY < Board.GameSize && tmpY >= 0
                && this.Board.GetBoardSpace(tmpX, tmpY).Occupied
                && this.Board.GetBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.GetBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

        }
    }

}
