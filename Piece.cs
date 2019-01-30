using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

     abstract class Piece {

      
        private Board board;

        protected Board Board {
            get { return board; }
        }

      
        protected string type;
        
       
        public string Type {
            get { return type; }
        }

       
        protected char icon;

        
        public char Icon {
            get { return icon;  }
        }

        /// <summary>
        /// status figur.
        /// true - na planszy
        /// false - poza
        /// </summary>
        private bool alive;

        
        public bool Alive {
            get { return alive; }
            set { alive = value;  }
        }


        private int color;

        
        public int Color {
            get { return color; }
        }

       
        private bool played;

       
        public bool Played {
            get { return this.played; }
        }

        /// <summary>
        /// Constructor figur.
        /// </summary>
        /// <param name="board"> plansza na ktorej figury sie znajduja. </param>
        /// <param name="color"> kolor figur 0 - białe </param>
        public Piece(Board board, int color ) {

            this.board = board;
            this.color = color;
            this.alive = true; 
            this.played = false; 

        }

       
        public void PlayedOnce() {
            this.played = true;
        }

        /// <summary>
        /// Modyfikacje na planszy 
        /// zalezne od argumentu.
        /// </summary>
        /// <param name="posX"> pozycja x.</param>
        /// <param name="posY"> pozcyja y.</param>
        public abstract void SetDestinations(int posX, int posY);

     }

}
