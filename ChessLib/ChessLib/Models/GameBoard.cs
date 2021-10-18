using System;

namespace ChessLib.Models
{
    /// <summary>
    /// Represents game board
    /// </summary>
    public class GameBoard
    {
        public readonly int BOARD_SIZE = 8;

        private BoardCell[,] _boardCells;
        private ChessPlayer _whitePlayer;
        private ChessPlayer _blackPlayer;
        private ChessPlayer _currentTurnPlayer;

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
            _currentTurnPlayer.TakeChessFigure(fromPositionChess);
            _currentTurnPlayer.MoveChess(toPosition, this);
            _currentTurnPlayer = _currentTurnPlayer == _whitePlayer ? _blackPlayer : _whitePlayer;
        }

        public bool IsPositionInBoard(int horizontal, int verical)
        {
            return horizontal >= 0 && horizontal < BOARD_SIZE && verical >= 0 && verical < BOARD_SIZE;
        }

        public void RemoveChess(BoardCell onBoardCell)
        {
            if (onBoardCell.Chess.ChessColor == ChessColor.White)
                _whitePlayer.RemoveChess(onBoardCell.Chess);
            else
                _blackPlayer.RemoveChess(onBoardCell.Chess);
            onBoardCell.SetChess(null);
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
            _whitePlayer = new ChessPlayer(ChessColor.White);
            _blackPlayer = new ChessPlayer(ChessColor.Black);
            _whitePlayer.Initialize(this);
            _blackPlayer.Initialize(this);
            _currentTurnPlayer = _whitePlayer;
        }
    }
}
