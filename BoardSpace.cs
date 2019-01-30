using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class BoardSpace {

       
        private bool occupied;

        
        public bool Occupied {
            get { return occupied; }
            set { occupied = value; }
        }

        
        private Piece piece;

      
        public Piece Piece {
            get { return piece;  }
            set {
                piece = value;

                if (value == null) {
                    this.occupied = false;
                } else {
                    this.occupied = true;
                }
            }
        }

        
        private bool isPossibleDestination;

        
        public bool IsPossibleDestination {
            get { return isPossibleDestination; }
            set { isPossibleDestination = value; }
        }

        public BoardSpace() {

            this.occupied = false; 
            this.isPossibleDestination = false; 

        }

        /// <summary>
        /// miejsce - x
        /// else - spacja
        /// </summary>
        /// <returns> odpowiedni znak na BoardSpace.</returns>
        public char GetBoardSpaceChar() {

            char output = '-';

            if (this.occupied) {
                output = this.piece.Icon;
            }

            return output;
        }

        public string ToString() {
            string output = ("Occupied : " + this.occupied
                + ", isPossibleDestination : " + this.isPossibleDestination);

            if (this.occupied) {
                output = output + (", Piece : " + this.piece.Type + this.piece.Color);
            }

            return output;
                
        }
        
    }

}
