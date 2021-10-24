using ChessLib.Models.Enums;
using ChessLib.Models.Figures.FigureMovements;
using System;
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
        protected Vector2<int>[] _moveDirections;
        protected IMovement _movement;

        /// <summary>
        /// Represents current chess color.
        /// </summary>
        public ChessColor ChessColor => _chessColor;

        /// <summary>
        /// Represents current chess position.
        /// </summary>
        public ChessPosition CurrentPosition
        {
            get => _currentChessPosition;
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
            InitializeMoveDirections();
        }

        /// <summary>
        /// Chess copy constructor
        /// </summary>
        /// <param name="otherChess">Chess from where copy information</param>
        public ChessBase(ChessBase otherChess)
        {
            CurrentPosition = otherChess.CurrentPosition;
            _chessColor = otherChess.ChessColor;
            InitializeMoveDirections();
        }

        public List<ChessPosition> GetPossibleSteps(GameBoard gameBoard) => _movement.GetPossibleSteps(this, _moveDirections, gameBoard);

        /// <summary>
        /// Chess move method
        /// </summary>
        /// <param name="chessPosition">Where move chess position</param>
        public virtual void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {
                if (_movement is PawnMovement)
                    (_movement as PawnMovement).IsFirstStep = false;

                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(new EmptyChess(CurrentPosition, ChessColor.None));

                if (gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess is not EmptyChess)
                {
                    gameBoard.RemoveChess(gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1]);
                }

                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        protected abstract void InitializeMoveDirections();

        /// <summary>
        /// Check if this chess equals to other object
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if chesses are equals, other return false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ChessBase otherChess)
            {
                return _chessColor == otherChess.ChessColor
                    && CurrentPosition == otherChess.CurrentPosition;
            }

            return false;
        }

        /// <summary>
        /// Generate hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            int hash = 2441;
            hash += hash * 12 + _chessColor.GetHashCode();
            hash += hash * 12 + _currentChessPosition.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Returns a string that represents chess figure.
        /// </summary>
        /// <returns>A string that represents chess figure</returns>
        public override string ToString()
        {
            return $"{ChessColor} {GetType().Name} {CurrentPosition}";
        }
    }
}
