using ChessLib.Models.Enums;
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
        /// Chess copy constructor
        /// </summary>
        /// <param name="otherChess">Chess from where copy information</param>
        public ChessBase(ChessBase otherChess)
        {
            CurrentPosition = otherChess.CurrentPosition;
            _chessColor = otherChess.ChessColor;
        }

        /// <summary>
        /// Chess move method
        /// </summary>
        /// <param name="chessPosition">Where move chess position</param>
        public virtual void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {

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

        /// <summary>
        /// Method to get all possible steps for chess
        /// </summary>
        /// <returns>List of all possible steps that figure can make</returns>
        public virtual List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            for (int i = 0; i < _moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);
                while (nextPosition.Vertical <= 8 && nextPosition.Vertical >= 1
&& nextPosition.Horizontal >= 1 && nextPosition.Horizontal <= 8)
                {
                    if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + _moveDirections[i].X - 1, nextPosition.Vertical + _moveDirections[i].Y - 1))
                        break;
                    nextPosition.Horizontal += _moveDirections[i].X;
                    nextPosition.Vertical += _moveDirections[i].Y;

                    ChessBase chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                    if (chess is EmptyChess)
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    else if (chess.ChessColor != this.ChessColor)
                    {
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                        break;
                    }
                    else
                        break;
                }
            }

            return nextSteps;
        }

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
