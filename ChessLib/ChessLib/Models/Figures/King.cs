using ChessLib.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class King : ChessBase
    {
        public King(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
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

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessBase> enemyChesses = gameBoard.GetAllOponentChesses(ChessColor == ChessColor.White ? ChessColor.Black : ChessColor.White);
            IEnumerable<ChessPosition> enemyChessesPossibleSteps = new List<ChessPosition>();
            foreach (var chess in enemyChesses)
            {
                if (chess is not King)
                {
                    enemyChessesPossibleSteps = enemyChessesPossibleSteps.Concat(chess.GetPossibleSteps(gameBoard));
                }
            }
            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < _moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);

                if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + _moveDirections[i].X - 1, nextPosition.Vertical + _moveDirections[i].Y - 1))
                    continue;

                nextPosition.Horizontal += _moveDirections[i].X;
                nextPosition.Vertical += _moveDirections[i].Y;

                if (enemyChessesPossibleSteps.Contains(nextPosition))
                    continue;

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
    }
}
