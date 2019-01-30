using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessGame.Source {

    class BoardButton : Button {

        /// <summary>
        /// pozycja x y na planszy.
        /// </summary>
        private int posX;
        private int posY;

       
        public int PosX {
            get { return this.posX; }
        }

        public int PosY {
            get { return this.posY; }
        }


        private BoardSpace boardSpace;


        public BoardButton(int posX, int posY, string name, BoardSpace boardSpace) {

            this.posX = posX;
            this.posY = posY;

            this.Name = name;
            this.boardSpace = boardSpace;

            this.Content = this.boardSpace.GetBoardSpaceChar();

            this.FontSize = 25;

        }

        /// <summary>
        /// sprawdzenie czy przyciski znajda sie na tym samym x i y.
        /// </summary>
        /// <param name="other">przyciski zostana porownane.</param>
        /// <returns></returns>
        public bool Equals(BoardButton other) {

            return (this.posX == other.PosX && this.posY == other.posY);

        }

    }

}
