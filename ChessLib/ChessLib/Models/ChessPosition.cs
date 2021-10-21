using System;

namespace ChessLib.Models
{
    /// <summary>
    /// Class represents chess position
    /// </summary>
    public sealed class ChessPosition
    {
        private int _horizontal;
        private int _vertical;

        /// <summary>
        /// Chess position constructor
        /// </summary>
        /// <param name="horizontalPosition">Horizontal position</param>
        /// <param name="verticalPosition">Vertical position</param>
        public ChessPosition(int horizontalPosition, int verticalPosition)
        {
            Vertical = verticalPosition;
            Horizontal = horizontalPosition;
        }

        public ChessPosition(char horizontalPosition, int verticalPosition)
        {
            Vertical = verticalPosition;
            Horizontal = Math.Abs('a' - Char.ToLower(horizontalPosition)) + 1;
        }

        /// <summary>
        /// Represents horizontal position coordinate
        /// </summary>
        public int Horizontal
        {
            get => _horizontal;
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Chess figure can't be out of the board");
                }

                _horizontal = value;
            }
        }

        /// <summary>
        /// Represents vetrical position coordinate
        /// </summary>
        public int Vertical
        {
            get => _vertical;
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Chess figure can't be out of the board");
                }

                _vertical = value;
            }
        }

        /// <summary>
        /// Compares two positions
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if objects is equals</returns>
        public override bool Equals(object obj)
        {
            ChessPosition otherChessCoordinate = obj as ChessPosition;
            if (otherChessCoordinate is not null)
            {
                return otherChessCoordinate.Horizontal == this.Horizontal &&
                    otherChessCoordinate.Vertical == this.Vertical;
            }

            return false;
        }

        /// <summary>
        /// Hash code algorithm for chess position
        /// </summary>
        /// <returns>Hash code of chess position</returns>
        public override int GetHashCode()
        {
            int hash = 18;
            hash = hash * 29 + Horizontal.GetHashCode();
            hash = hash * 29 + Vertical.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Returns a string that represents chess position.
        /// </summary>
        /// <returns>A string that represents chess position</returns>
        public override string ToString()
        {
            return $"X: {Horizontal}, Y: {Vertical}";
        }
    }
}
