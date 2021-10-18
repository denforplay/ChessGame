namespace ChessLib.Models
{
    /// <summary>
    /// Represents game board
    /// </summary>
    public class GameBoard
    {
        public readonly int BOARD_SIZE = 8;

        private BoardCell[,] _boardCells;
        private ChessPlayer FirstPlayer;
        private ChessPlayer SecondPlayer;
        private ChessPlayer CurrentTurnPlayer;

        /// <summary>
        /// All board cells
        /// </summary>
        public BoardCell[,] BoardCells => _boardCells;

        /// <summary>
        /// Gameboard constructor
        /// </summary>
        public GameBoard()
        {
            InitializeBoardCells();
            InitializePlayers();
        }

        public void MoveChess(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            CurrentTurnPlayer.TakeChessFigure(fromPositionChess);
            CurrentTurnPlayer.MoveChess(toPosition, this);
            CurrentTurnPlayer = CurrentTurnPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;
        }

        /// <summary>
        /// Intialize board cells
        /// </summary>
        private void InitializeBoardCells()
        {
            _boardCells = new BoardCell[BOARD_SIZE, BOARD_SIZE];
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    ChessPosition chessPosition = new ChessPosition(row + 1, col + 1);
                    BoardCell boardCell = new BoardCell(chessPosition, null);
                    _boardCells[row, col] = boardCell;
                }
            }
        }
        
        /// <summary>
        /// Initialize players by chess figures depends on figures colors
        /// </summary>
        private void InitializePlayers()
        {
            FirstPlayer = new ChessPlayer(ChessColor.White);
            SecondPlayer = new ChessPlayer(ChessColor.Black);
            FirstPlayer.Initialize(this);
            SecondPlayer.Initialize(this);
            CurrentTurnPlayer = FirstPlayer;
        }
    }
}
