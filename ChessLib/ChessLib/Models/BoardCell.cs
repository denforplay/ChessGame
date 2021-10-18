using ChessLib.Models.Figures;
using System;

namespace ChessLib.Models
{
    /// <summary>
    /// Represents board cell
    /// </summary>
    public struct BoardCell
    {
        private ChessPosition _chessPosition;
        private ChessBase _chess;

        /// <summary>
        /// Chess position on board
        /// </summary>
        public ChessPosition ChessPosition => _chessPosition;

        /// <summary>
        /// Represents chess
        /// </summary>
        public ChessBase Chess => _chess;


        /// <summary>
        /// Board cell constructor
        /// </summary>
        /// <param name="chessPosition">Chess position</param>
        /// <param name="chess">Chess</param>
        public BoardCell(ChessPosition chessPosition, ChessBase chess)
        {
            _chessPosition = chessPosition;
            _chess = chess;
        }

        /// <summary>
        /// Set other chess in board cell
        /// </summary>
        /// <param name="otherChess">Other chess to set in cell</param>
        public void SetChess(ChessBase otherChess)
        {
            _chess = otherChess;
        }

        /// <summary>
        /// Check if this cell equals to other object
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if cells are equals, other return false</returns>
        public override bool Equals(object obj)
        {
            if (obj is BoardCell)
            {
                BoardCell otherCell = (BoardCell)obj;
                return ChessPosition == otherCell.ChessPosition;
            }

            return false;
        }

        /// <summary>
        /// Generate hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            int hash = 1332;
            hash = hash * 7 + _chess.GetHashCode();
            hash = hash * 7 + _chessPosition.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Returns a string that represents board cell.
        /// </summary>
        /// <returns>A string that represents board cell</returns>
        public override string ToString()
        {
            return $"{_chessPosition} {_chess}";
        }
    }
}
