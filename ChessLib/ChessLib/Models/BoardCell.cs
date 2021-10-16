using ChessLib.Models.Figures;
using System;

namespace ChessLib.Models
{
    public struct BoardCell
    {
        private ChessPosition _chessPosition;
        private ChessBase _chess;

        public ChessPosition ChessPosition => _chessPosition;

        public BoardCell(ChessPosition chessPosition, ChessBase chess)
        {
            _chessPosition = chessPosition;
            _chess = chess;
        }

        public void SetChess(ChessBase otherChess)
        {
            _chess = otherChess;
        }

        public override bool Equals(object obj)
        {
            if (obj is BoardCell)
            {
                BoardCell otherCell = (BoardCell)obj;
                return ChessPosition == otherCell.ChessPosition;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1332;
            hash = hash * 7 + _chess.GetHashCode();
            hash = hash * 7 + _chessPosition.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{_chessPosition}\n{_chess}";
        }
    }
}
