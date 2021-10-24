using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System;
using System.Collections.Generic;

namespace ChessLib.Models
{
    /// <summary>
    /// Represents game board
    /// </summary>
    public sealed class GameBoard
    {
        public readonly int BOARD_SIZE = 8;

        public event Action<ChessBase> OnChessRemoved;

        private BoardCell[,] _boardCells;

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
        }

        public bool IsPositionOnBoard(int horizontal, int vertical)
        {
            return horizontal >= 0 && horizontal < BOARD_SIZE && vertical >= 0 && vertical < BOARD_SIZE;
        }

        /// <summary>
        /// Method to remove chess from board
        /// </summary>
        /// <param name="onBoardCell">Board cell from what remove chess</param>
        public void RemoveChess(BoardCell onBoardCell)
        {
            OnChessRemoved?.Invoke(onBoardCell.Chess);
            onBoardCell.SetChess(new EmptyChess(onBoardCell.ChessPosition, ChessColor.None));
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
                    BoardCell boardCell = new BoardCell(chessPosition, new EmptyChess(chessPosition, ChessColor.None));
                    _boardCells[row, col] = boardCell;
                }
            }
        }
    }
}
