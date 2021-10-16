namespace ChessLib.Models
{
    public class GameBoard
    {
        public readonly int BOARD_SIZE = 8;

        private BoardCell[,] _boardCells;
        private Player FirstPlayer;
        private Player SecondPlayer;
        private Player CurrentTurnPlayer;
        public BoardCell[,] BoardCells => _boardCells;

        public GameBoard()
        {
            InitializeBoardCells();
            InitializePlayers();
        }

        public void MoveChess(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            CurrentTurnPlayer.TakeChessFigure(fromPositionChess).Move(toPosition, this);
        }

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
        
        private void InitializePlayers()
        {
            FirstPlayer = new Player(ChessColor.White);
            SecondPlayer = new Player(ChessColor.Black);
            FirstPlayer.Initialize(this);
            SecondPlayer.Initialize(this);
            CurrentTurnPlayer = FirstPlayer;
        }
    }
}
