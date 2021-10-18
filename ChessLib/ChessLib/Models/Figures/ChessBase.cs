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

        /// <summary>
        /// Represents current chess color.
        /// </summary>
        public ChessColor ChessColor => _chessColor;

        /// <summary>
        /// Represents current chess position.
        /// </summary>
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
        public virtual void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {
                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(null);
                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
        }

        /// <summary>
        /// Method to get all possible steps for chess
        /// </summary>
        /// <returns>List of all possible steps that figure can make</returns>
        public abstract List<ChessPosition> GetPossibleSteps(GameBoard gameBoard);
    }
}
