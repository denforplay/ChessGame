using ChessLib.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents king figure
    /// </summary>
    public sealed class King : ChessBase
    {
        /// <summary>
        /// Copy constructor to create king from other king
        /// </summary>
        /// <param name="otherChess">King from which copy info</param>
        public King(King otherChess) : base(otherChess)
        {
        }

        /// <summary>
        /// King constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public King(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            for (int i = 0; i < _moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);

                if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + _moveDirections[i].X - 1, nextPosition.Vertical + _moveDirections[i].Y - 1))
                    continue;

                nextPosition.Horizontal += _moveDirections[i].X;
                nextPosition.Vertical += _moveDirections[i].Y;

                var chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

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

            return nextSteps;
        }

        protected override void InitializeMoveDirections()
        {
            _moveDirections = new Vector2<int>[]
           {
                 new Vector2<int>(0, 1),
                 new Vector2<int>(1, 1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(1, -1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(-1, -1),
                 new Vector2<int>(-1, 0),
                 new Vector2<int>(-1, 1)
           };
        }
    }
}
