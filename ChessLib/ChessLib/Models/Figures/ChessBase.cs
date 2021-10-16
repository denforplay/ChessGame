using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents chess base
    /// </summary>
    public abstract class ChessBase
    {
        private ChessColor _chessColor;
        private ChessPosition _currentChessPosition;

        public ChessColor ChessColor => _chessColor;

        public ChessPosition CurrentPosition
        {
            get
            {
                return _currentChessPosition;
            }
            set
            {
                if (value != null)
                {
                    _currentChessPosition = value;
                }
            }
        }

        /// <summary>
        /// Base chess constructor
        /// </summary>
        /// <param name="color">Chess color</param>
        public ChessBase(ChessPosition startPosition, ChessColor color)
        {
            _currentChessPosition = startPosition;
            _chessColor = color;
        }

        /// <summary>
        /// Chess move method
        /// </summary>
        /// <param name="chessPosition">Where move chess position</param>
        public abstract void Move(ChessPosition nextPosition, GameBoard gameBoard);

        /// <summary>
        /// Method to get all possible steps for chess
        /// </summary>
        /// <returns>List of all possible steps that figure can make</returns>
        public abstract List<ChessPosition> GetPossibleSteps(GameBoard gameBoard);
    }
}
