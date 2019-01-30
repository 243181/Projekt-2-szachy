using ChessGame.Source;
using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessGame {
    
    public partial class MainWindow : Window {

        /// <summary>
        /// klasa boardModel
        /// </summary>
        private Board boardModel;

        /// <summary>
        /// 0 - białe
        /// 1 - czarne
        /// </summary>
        private int turn;

        /// <summary>
        /// Tablica dla przycisków na planszy.
        /// </summary>
        private BoardButton[][] buttonArray;

        
        private int mode;

        /// <summary>
        /// Ostatni naciśnięty przycisk
        /// </summary>
        private BoardButton lastPressed;

        public MainWindow() {

            InitializeComponent();

            this.boardModel = new Board();
            Debug.WriteLine(this.boardModel.ToString()); //usuń kiedy sie wykona

            this.mode = 0;

            this.turn = 0; //białe zaczynają 0
            this.ShowTurn();

            this.UpdateDeadPiecesViews();

            //initializing the buttonArray
            this.buttonArray = new BoardButton[Board.GameSize][]; //Change Game size
            for (int i = 0; i < this.buttonArray.Length; i++) {
                this.buttonArray[i] = new BoardButton[Board.GameSize];
            }

            //inicjowanie przycisku na planszy.
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    string name = "space" + i + j;

                    BoardSpace correspondingSpace = this.boardModel.GetBoardSpace(i, j);

                    BoardButton presentButton = new BoardButton(i, j, name, correspondingSpace);
                    this.buttonArray[i][j] = presentButton;
                    
                    if (!correspondingSpace.Occupied
                        || correspondingSpace.Piece.Color != this.turn) {

                        presentButton.IsEnabled = false;

                    }

                    int realJ = (j - this.buttonArray.Length + 1) * -1;

                    Grid.SetColumn(presentButton, i);
                    Grid.SetRow(presentButton, realJ);
                    this.boardGrid.Children.Add(presentButton);

                    presentButton.AddHandler(BoardButton.ClickEvent, new RoutedEventHandler(boardButton_Click)); 

                }

            }

        }

        /// <summary>
        /// Pokazywanie kogo kolej.
        /// </summary>
        private void ShowTurn() {

            if (this.turn == 0) {
                this.turnDisplay.Text = "Ruch Białych";
            } else {
                this.turnDisplay.Text = "Ruch Czarnych";
            }

        }

        private void boardButton_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();            

            BoardButton clickedButton = sender as BoardButton;
            Debug.WriteLine(clickedButton.Name);//REMOVE

            int x = clickedButton.PosX;
            int y = clickedButton.PosY;

            BoardSpace clickedSpace = this.boardModel.GetBoardSpace(x, y);

            if (this.mode == 0) { 

                clickedSpace.Piece.SetDestinations(x, y);
                this.mode = (this.mode + 1) % 2;
                this.lastPressed = clickedButton;

            } else {

                if (!clickedButton.Equals(this.lastPressed)) {

                    this.MovePiece(clickedSpace);
                    this.lastPressed = null;

                    //zmiana piona po dojsciu do konca planszy
                    if ( (y == 0 || y == 7 ) 
                        && clickedSpace.Piece.Type == "pawn") {

                        this.Promote(clickedSpace);

                    }

                    clickedSpace.Piece.PlayedOnce(); 

                    this.turn = (this.turn + 1) % 2;//zmiana ruchu po wybraniu miejsca

                }

                this.mode = (this.mode + 1) % 2; 

            }

            this.UpdateView();
            Debug.WriteLine(this.boardModel.ToString());

            int winner = this.GameWon();

            this.AskForNewGame(winner);

        }

        private void MovePiece(BoardSpace destination) {

            if (destination.Occupied) {
                this.boardModel.KillPiece(destination);
            }

            int sourceX = this.lastPressed.PosX;
            int sourceY = this.lastPressed.PosY;
            BoardSpace sourceSpace = this.boardModel.GetBoardSpace(sourceX, sourceY);

            destination.Piece = sourceSpace.Piece; 

            sourceSpace.Piece = null;

        }

        private void Promote(BoardSpace space) {

            string choice;

            PromotionDialogue dialogue = new PromotionDialogue();
            dialogue.ShowDialog();
            choice = dialogue.Choice;

            int presentColor = space.Piece.Color;

            switch (choice) {
                case "queen":
                    space.Piece = new Queen(this.boardModel, presentColor);
                    break;
                case "knight":
                    space.Piece = new Knight(this.boardModel, presentColor);
                    break;
                case "rook":
                    space.Piece = new Rook(this.boardModel, presentColor);
                    break;
                case "bishop":
                    space.Piece = new Bishop(this.boardModel, presentColor);
                    break;
                case "pawn":
                    space.Piece = new Pawn(this.boardModel, presentColor);
                    break;
            }

        }

        /// <summary>
        /// Sprawdza kto wygrał gre
        /// -1 - nikt
        ///  0 - białe
        ///  1 - czarne
        /// </summary>
        private int GameWon() {

            foreach (Piece piece in this.boardModel.DeadWhites) {
                if (piece.Type == "king") {
                    return 1; //czarne
                }
            }

            foreach (Piece piece in this.boardModel.DeadBlacks) {
                if (piece.Type == "king") { 
                    return 0; //białe
                }
            }

            return -1;

        }

        private void AskForNewGame(int winner) {

            string message;

            if ( winner == 0) {
                message = "Białe wygrały, nowa gra?";
            } else if (winner == 1) {
                message = "Czarne wygrały, nowa gra?";
            } else {
                return; 
            }

            string title = "Wygrałeś, nowa gra?";
            MessageBoxResult choice = MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (choice == MessageBoxResult.Yes) {
                this.boardModel.Reset();
                this.turn = 0;
                this.UpdateView();
                Debug.WriteLine(this.boardModel.ToString());
            } else {
                Application.Current.Shutdown();
            }
        }

        private void UpdateView() {

            this.ShowTurn();

            this.UpdateDeadPiecesViews();

            //aktualizowanie planszy
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    BoardButton presentButton = this.buttonArray[i][j];
                    BoardSpace presentSpace = this.boardModel.GetBoardSpace(i, j);

                    if (mode == 0) { //pokazuje mozliwe miejsca docelowe figury.
                        presentButton.ClearValue(BoardButton.BackgroundProperty); 
                        presentSpace.IsPossibleDestination = false;
                    }

                    if (presentSpace.IsPossibleDestination) {
                        presentButton.Background = Brushes.Green;
                    }

                    if (!presentSpace.IsPossibleDestination 
                        && ( !presentSpace.Occupied 
                             || presentSpace.Piece.Color != this.turn) ) {

                        presentButton.IsEnabled = false;

                    } else {
                        presentButton.IsEnabled = true;
                    }

                    //w chwili wybrania figury
                    //tylko przycisk i miejsca docelowe sa pokazane
                    if(this.mode == 1 
                        && !presentSpace.IsPossibleDestination 
                        && !presentButton.Equals(this.lastPressed)) {
                        presentButton.IsEnabled = false;
                    }

                    presentButton.Content = presentSpace.GetBoardSpaceChar();

                    Debug.WriteLine(presentSpace.ToString());
                    
                }

            }

        }
        
        /// <summary>
        /// aktualizowanie zebranych figur.
        /// </summary>
        private void UpdateDeadPiecesViews() {


            StringBuilder deadWhitesString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadWhites) {
                deadWhitesString.Append(" " + piece.Icon + " ");
            }

            this.deadWhitesView.Text = deadWhitesString.ToString();

            StringBuilder deadBlacksString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadBlacks) {
                deadBlacksString.Append(" " + piece.Icon + " ");
            }

            this.deadBlacksView.Text = deadBlacksString.ToString();
        }

    }

}
