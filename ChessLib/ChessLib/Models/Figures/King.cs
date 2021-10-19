using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class King : ChessBase
    {
        public King(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            Vector2[] directions = new Vector2[]
            {
                 new Vector2(0, 1),
                 new Vector2(1, 1),
                 new Vector2(1, 0),
                 new Vector2(1, -1),
                 new Vector2(0, -1),
                 new Vector2(-1, -1),
                 new Vector2(-1, 0),
                 new Vector2(-1, 1)
            };

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

            for (int i = 0; i < directions.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);

                if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + (int)directions[i].X - 1, nextPosition.Vertical + (int)directions[i].Y - 1))
                    continue;

                nextPosition.Horizontal += (int)directions[i].X;
                nextPosition.Vertical += (int)directions[i].Y;

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
